using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QiYuan
{
    public partial class FrmTest : Form
    {
        private TestHelper th;
        public FrmTest()
        {
            InitializeComponent();
            th = new TestHelper();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DeleteSource();
            pictureBox1.Enabled = false;
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("校检测试仪并开始测试");
            splashScreenManager1.SetWaitFormDescription(" 请等待。。。");
            Task.Factory.StartNew(() =>
            {

                StartTool();

            }).ContinueWith(x =>
            {
                splashScreenManager1.CloseWaitForm();
                this.pictureBox1.Enabled = true;
                this.Invoke((MethodInvoker)(() => {
                    //splashScreenManager1.CloseWaitForm();
                    //FrmMain.Instance.XtraTabOpen("FrmFinish", "信息");
                    FrmFinish frmFinish = new FrmFinish();
                    frmFinish.Show();
                    this.Close();
                }));
            });
        }

        private void DeleteSource()
        {
            string testFile = "c:/Clasp32/clarity.xls";
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }

        private void StartTool()
        {
            try
            {
                th.OneClickTest();
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
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
    }
}
