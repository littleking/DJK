using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;
using DevExpress.XtraSplashScreen;

namespace JKApp
{
    public partial class FrmTestLocal : XtraForm
    {
        private TestHelper th;
        private Thread pro;
        private bool suspend;
        public FrmTestLocal()
        {
            InitializeComponent();
            th = new TestHelper();
        }

        private void DoProgress()
        {
            this.Invoke((MethodInvoker)(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (suspend)
                    {
                        i = 100;
                    }
                    splashScreenManager1.SendCommand(WaitForm1.WaitFormCommand.SetProgress, i);
                    Thread.Sleep(60 * 10 * 12);
                    
                }
            }));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                DoTest();
            }catch(Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
            
        }

        private void DoTest()
        {
            try
            {
                DeleteSource();
                pictureBox1.Enabled = false;
                splashScreenManager1.ShowWaitForm();
                //splashScreenManager1.SetWaitFormCaption("校检测试仪并开始测试");
                //splashScreenManager1.SetWaitFormDescription(" 请等待。。。");
                bool start = false;
                suspend = false;
                pro = new Thread(DoProgress);
                pro.Start();
                Task.Factory.StartNew(() =>
                {
                start = StartTool();
                suspend = true;

                }).ContinueWith(x =>
                {
                    if (!start)
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            killP();
                            pro.Abort();
                            FrmInfoLocal.Instance.Show();
                            splashScreenManager1.CloseWaitForm();
                            this.Close();
                        }));
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)(() =>
                        { 
                            //this.pictureBox1.Enabled = true;
                            pro.Abort();
                            splashScreenManager1.CloseWaitForm();
                            if (XtraMessageBox.Show("检测已经结束，是否要进行调理？选Yes后请点击调理按钮开始调理，选No将结束检测", "检测结束", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                
                            }
                            else
                            {
                                FrmFinishLocal frmFinish = new FrmFinishLocal();
                                frmFinish.Show();
                                this.Close();
                            }
                        }));
                    }
                });
            }catch(Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }

        private void ExportXml()
        {
            killP();
            Thread.Sleep(2000);
            th.ExportXML();
        }


        private bool GetReport()
        {
            bool rtn = false;
            string reportFile = "c:/clasp32/data" + "/report.xlsm";
            string sourceFile = "c:/clasp32/data" + "/clarity.xls";
            string tempFolder = "c:/clasp32/data/temp/";
            string testFile = ConfigurationManager.AppSettings["sourceAddress"];
            string destFolder = ConfigurationManager.AppSettings["FileFolder"];
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }
            if (File.Exists(testFile))
            {
                if (File.Exists(sourceFile))
                {
                    File.Delete(sourceFile);
                }
                File.Copy(testFile, sourceFile, true);
                string temp = System.Windows.Forms.Application.StartupPath + "/DevExpress.Nap.v16.2.dll";
                copyStream(reportFile, temp);
                //LogHelper.WriteLog("开始生成报告!");
                //XtraMessageBox.Show("开始生成报告", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = ThreadFun(reportFile, sourceFile);

                CopyDirectory(tempFolder, destFolder);
                //Thread.Sleep(60000);
                //LogHelper.WriteLog("报告生成结束!");
                //XtraMessageBox.Show("报告生成结束", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                rtn = false;
            }
            return rtn;
        }

        private void copyStream(string resultFile, string temp)
        {
            if (File.Exists(resultFile))
            {
                File.Delete(resultFile);
            }
            FileStream filestream = new FileStream(temp, FileMode.Open);
            byte[] bt = new byte[filestream.Length];
            filestream.Read(bt, 0, bt.Length);
            string base64Str = System.Text.Encoding.Default.GetString(bt);
            var contents = Convert.FromBase64String(base64Str);
            using (var fss = new FileStream(resultFile, FileMode.Create, FileAccess.Write))
            {
                fss.Write(contents, 0, contents.Length);
                fss.Flush();
            }
        }

        private bool ThreadFun(string reportFile, string sourceFile)
        {
            bool rtn = true;
            try
            {
                Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                excel.Visible = false;
                excel.Workbooks.Open(reportFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                IntPtr t = new IntPtr(excel.Hwnd);
                int k = 0;
                GetWindowThreadProcessId(t, out k);
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                p.Kill();
            }
            catch (Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                File.Delete(sourceFile);
                LogHelper.WriteLog("Excel权限问题或没有安装，处理数据失败!");
                XtraMessageBox.Show("Excel问题导致处理数据失败,请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            File.Delete(sourceFile);
            return true;
        }


        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        private void DeleteSource()
        {
            string testFile = "c:/Clasp32/clarity.xls";
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }

        private bool StartTool()
        {
            bool rtn = false;
            try
            {
                //th.OneClickTest();
                th.TestToStart();
                splashScreenManager1.SetWaitFormCaption("检测中");
                th.TestStart();
                Thread.Sleep(5000);
                splashScreenManager1.SetWaitFormCaption("报告生成中");
                GetReport();
                return true;
            }
            catch (Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                string haha = ex.ToString();
                LogHelper.WriteLog(haha);
                XtraMessageBox.Show(ex.ToString(), "错误");
                return false;
            }
        }

        private bool saveSource()
        {
            string sourceFile = "c:/clasp32/clarity.xls";
            if(!File.Exists(sourceFile)){
                return false;
            }
            string bakPath = System.Windows.Forms.Application.StartupPath + "/WaitedSource/";
            if (!Directory.Exists(bakPath))
                Directory.CreateDirectory(bakPath);
            string filename = Patient.w_code + ".bak";
            string savePath = bakPath + filename;
            string sourcePath = bakPath + "clarity.xls";
            if (File.Exists(sourcePath))
            {
                File.Delete(sourcePath);
            }
            FileInfo file = new FileInfo(sourceFile);
            file.CopyTo(sourcePath, true);
            bool saved = ReadXlsToBase64(savePath, sourcePath);
            return saved;
        }

        private bool ReadXlsToBase64(string savePath,string sourcePath)
        {
            bool rtn = true;
            try
            {
                FileStream filestream = new FileStream(sourcePath, FileMode.Open);
                byte[] bt = new byte[filestream.Length];

                //调用read读取方法  
                filestream.Read(bt, 0, bt.Length);
                string base64Str = Convert.ToBase64String(bt);
                filestream.Close();

                //将Base64串写入临时文本文件  
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }
                FileStream fs = new FileStream(savePath, FileMode.Create);
                byte[] data = System.Text.Encoding.Default.GetBytes(base64Str);
                //开始写入  
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流  
                fs.Flush();
                fs.Close();

            }
            catch (Exception ex)
            {
                return false;
            }

            File.Delete(sourcePath);


            return rtn;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            killP();
            Application.Exit();
        }

        private void killP()
        {
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processList)
            {
                if (process.ProcessName.ToUpper() == "CONMAIN")
                {
                    process.Kill(); //结束进程
                }
            }
        }

        /**
        * 窗体移动API
        */
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0xB;

        private void FrmTest_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }

        private void FrmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            killP();
            //Application.Exit();
        }

        private void CopyDirectory(string srcPath, string destPath)
        {
            try
            {
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)     //判断是否文件夹
                    {
                        if (!Directory.Exists(destPath + "\\" + i.Name))
                        {
                            Directory.CreateDirectory(destPath + "\\" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                        }
                        CopyDirectory(i.FullName, destPath + "\\" + i.Name);    //递归调用复制子文件夹
                    }
                    else
                    {
                        File.Copy(i.FullName, destPath + "\\" + i.Name, true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                        File.Delete(i.FullName);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void DoTherapy()
        {
            try
            {
                killP();
                Thread.Sleep(500);
                th.TestLaunch(true);
                Thread.Sleep(15000);
                th.CloseBandTest();
                Thread.Sleep(3000);
                th.TestToStart();
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                LogHelper.WriteLog(haha);
                XtraMessageBox.Show(ex.ToString(), "错误");

            }
        }

        private void GoBack()
        {
            killP();
            this.Close();
            //FrmInfo.Instance.checkWaitedSource();
            FrmInfoLocal.Instance.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DoTherapy();
        }

        private void FrmTestLocal_Load(object sender, EventArgs e)
        {

        }
    }
}
