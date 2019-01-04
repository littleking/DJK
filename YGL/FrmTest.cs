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

namespace YGL
{
    public partial class FrmTest : XtraForm
    {
        private TestHelper th;
        private Thread pro;
        private bool suspend;
        public FrmTest()
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
                    killP();
                    FrmInfo.Instance.Show();
                    this.Close();
                }
                else
                {
                    
                    // splashScreenManager1.CloseWaitForm();
                    this.Invoke((MethodInvoker)(() =>
                    {
                        //splashScreenManager1.SendCommand(WaitForm1.WaitFormCommand.SetProgress, 100);
                        this.pictureBox1.Enabled = true;
                        //splashScreenManager1.CloseWaitForm();
                        //FrmMain.Instance.XtraTabOpen("FrmFinish", "信息");
                        //FrmFinish frmFinish = new FrmFinish();
                        FrmFinish frmFinish = new FrmFinish();
                        frmFinish.Show();
                        pro.Abort();
                        splashScreenManager1.CloseWaitForm();
                        this.Close();
                    }));
                }
            });
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
            //string reportFile = System.Windows.Forms.Application.StartupPath + "/report.xlsm";
            //string sourceFile = System.Windows.Forms.Application.StartupPath + "/clarity.xls";
            string reportFile = "c:/clasp32/data" + "/test.xlsm";
            string sourceFile = "c:/clasp32/data" + "/clarity.xls";
            string dataFile = System.Windows.Forms.Application.StartupPath + "/data.xml";
            string testFile = ConfigurationManager.AppSettings["sourceAddress"];
            FileInfo fileInfo = new FileInfo(testFile);
            SysVar.dtNow = DateTime.Parse(fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
            //有最新文件，开始上传数据
            if (DateTime.Compare(SysVar.dtNow, SysVar.dtOld) > 0)
            {
                SysVar.dtOld = SysVar.dtNow;
                DataProcess dp = new DataProcess(reportFile, sourceFile, testFile, dataFile);
                rtn = dp.uploadInfo();
            }
            else
            {
                rtn = false;
                // XtraMessageBox.Show("测试数据没有生成，请重新测试，如果还是不成功请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogHelper.WriteLog("测试数据没有生成，请重新测试，如果还是不成功请联系管理员！");
            }
            return rtn;
        }


        //private bool GetReport()
        //{
        //    bool rtn = false;
        //    string reportFile = System.Windows.Forms.Application.StartupPath + "/report.xlsm";
        //    string sourceFile = System.Windows.Forms.Application.StartupPath + "/clarity.xls";
        //    string tempFolder = System.Windows.Forms.Application.StartupPath + "/temp/";
        //    string testFile = ConfigurationManager.AppSettings["sourceAddress"];
        //    string destFolder = ConfigurationManager.AppSettings["FileFolder"];
        //    if (!Directory.Exists(tempFolder))
        //    {
        //        Directory.CreateDirectory(tempFolder);
        //    }
        //    if (File.Exists(testFile))
        //    {
        //        if (File.Exists(sourceFile))
        //        {
        //            File.Delete(sourceFile);
        //        }
        //        File.Copy(testFile, sourceFile,true);
        //        //LogHelper.WriteLog("开始生成报告!");
        //        //XtraMessageBox.Show("开始生成报告", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        rtn = ThreadFun(reportFile, sourceFile);

        //        CopyDirectory(tempFolder, destFolder);
        //        //Thread.Sleep(60000);
        //        //LogHelper.WriteLog("报告生成结束!");
        //        //XtraMessageBox.Show("报告生成结束", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        rtn = false;
        //    }
        //    return rtn;
        //}

        //private bool ThreadFun(string reportFile, string sourceFile)
        //{
        //    bool rtn = true;
        //    try
        //    {
        //        Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
        //        excel.Visible = false;
        //        excel.Workbooks.Open(reportFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        //        IntPtr t = new IntPtr(excel.Hwnd);
        //        int k = 0;
        //        GetWindowThreadProcessId(t, out k);
        //        System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
        //        p.Kill();
        //    }
        //    catch (Exception ex)
        //    {
        //        File.Delete(sourceFile);
        //        LogHelper.WriteLog("Excel权限问题或没有安装，处理数据失败!");
        //        XtraMessageBox.Show("Excel问题导致云端处理数据失败,请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return false;
        //    }

        //    File.Delete(sourceFile);
        //    return true;
        //}

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
                splashScreenManager1.SetWaitFormCaption("数据处理中");
                ExportXml();
                rtn = GetReport();
                if (!rtn)
                {
                    splashScreenManager1.CloseWaitForm();
                    XtraMessageBox.Show("报告数据处理失败，请重新尝试一次", "错误");
                }
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

    }
}
