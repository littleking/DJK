using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace QiYuan
{
    public partial class FrmInfo : XtraForm
    {
        private TestHelper th;

        public FrmInfo()
        {
            InitializeComponent();
            runBat();
            th = new TestHelper();
            this.txtSex.SelectedIndex = -1;
            txtSex.Properties.Items.Add("男");
            txtSex.Properties.Items.Add("女");
            this.txtName.Text = "";
            this.txtBirthDay.Text = "";
            this.txtBirthPlace.Text = "";
            string tempFolder = System.Windows.Forms.Application.StartupPath + "/temp/";
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ValidateInfo())
            {
                Patient.w_name = txtName.Text.Trim();
                Patient.w_birth_day = txtBirthDay.Text;
                Patient.w_location = txtBirthPlace.Text.Trim();
                Patient.w_sex = txtSex.Text;
                string sql = string.Format("INSERT INTO patient VALUES (NULL, '{0}', '{1}', '{2}', '中国', NULL, NULL, NULL, NULL, NULL, 0, 0, 0, '{3}', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 0, 0, 0, 0, 10, 0, 0, 76, 88, 85, 91, 98, 64, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 1, 1, 1, 1, 1, 2, NULL, NULL, NULL);", Patient.w_name, Patient.w_birth_day, Patient.w_location, Patient.w_sex);
                string clearSql = "Delete from patient";
                string dbpath = "C:\\Clasp32\\DATA\\data.db3";
                bool findScio = false;
                try
                {
                    th.ExecSql(dbpath, clearSql);
                    Thread.Sleep(100);
                    th.ExecSql(dbpath, sql);
                }
                catch (Exception ex)
                {
                    //XtraMessageBox.Show("数据保存失败，请联系管理员!" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    XtraMessageBox.Show("检测程序启动失败，请联系管理员!" , "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pictureBox1.Enabled = false;
                splashScreenManager2.ShowWaitForm();
                //splashScreenManager2.SetWaitFormCaption("正在查找设备");
                //splashScreenManager2.SetWaitFormDescription(" 请等待。。。");
                Task.Factory.StartNew(() =>
                {
                    int count = 0;
                    while(!findScio){
                        try
                        {
                            th.TestLaunch(this.checkEdit1.Checked);
                            Thread.Sleep(4000);
                            if (th.TestHead())
                            {
                                th.CloseBandTest();
                                Thread.Sleep(8000);
                                findScio = true;
                            }
                            else
                            {
                                
                                splashScreenManager2.SetWaitFormCaption("设备和人体通讯异常，第"+(count+1)+"次重试中");
                                count++;
                                killP();
                                Thread.Sleep(5000);
                                
                            }
                            if (count == 3)
                            {
                                splashScreenManager2.CloseWaitForm();
                                this.pictureBox1.Enabled = true;
                                XtraMessageBox.Show("绑带检测未通过，请检查绑带后重新开始！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            //th.TestLaunch(false);
                            //th.CloseBandTest();
                            //Thread.Sleep(6000);
                        }
                        catch (Exception ex)
                        {
                            string haha = ex.ToString();
                            XtraMessageBox.Show("检测程序无法启动，请联系管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    //StartTool();

                }).ContinueWith(x =>
                {
                    splashScreenManager2.CloseWaitForm();
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.txtSex.SelectedIndex = -1;
                        this.txtName.Text = "";
                        this.txtBirthDay.Text = "";
                        this.txtBirthPlace.Text = "";
                        this.pictureBox1.Enabled = true;
                        //FrmMain.Instance.XtraTabOpen("FrmTest", "信息");
                        FrmTest frmTest = new FrmTest();
                        frmTest.Show();
                        FrmInfo.Instance.Hide();
                    }));
                });

            }
        }

        private void StartTool()
        {
            try
            {
                th.TestLaunch(this.checkEdit1.Checked);
                Thread.Sleep(2000);
                //th.TestLaunch(false);
                //th.CloseBandTest();
                //Thread.Sleep(6000);
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show("检测程序无法启动，请联系管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void runBat()
        {
            Process proc = null;
            try
            {
                string targetDir = Application.StartupPath;
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = "run.bat";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        private bool ValidateInfo()
        {
            bool rtn = true;
            if (this.txtName.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            else if (this.txtSex.SelectedIndex < 0)
            {
                XtraMessageBox.Show("请选择性别", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            else if (this.txtBirthDay.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入出生日期", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            else if (this.txtBirthPlace.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入出生地", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            return rtn;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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




        private void FrmInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }

        #region Property
        private static FrmInfo mInstance = null;
        /// <summary>
        /// FrmMain的唯一实例体
        /// </summary>
        public static FrmInfo Instance
        {
            get
            {
                return mInstance;
            }
            set
            {
                mInstance = value;
            }
        }
        #endregion

        private void FrmInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            killP();
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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmTest test = new FrmTest();
            test.Show();
        }
    }
}
