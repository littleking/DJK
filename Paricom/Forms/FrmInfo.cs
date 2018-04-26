using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paricom
{
    public partial class FrmInfo : FrmBase
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
                try
                {
                    th.ExecSql(dbpath, clearSql);
                    Thread.Sleep(100);
                    th.ExecSql(dbpath, sql);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("数据保存失败，请联系管理员!" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pictureBox1.Enabled = false;
                splashScreenManager2.ShowWaitForm();
                splashScreenManager2.SetWaitFormCaption("正在保存信息和准备测试仪");
                splashScreenManager2.SetWaitFormDescription(" 请等待。。。");
                Task.Factory.StartNew(() =>
                {
                    StartTool();

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
                        //FrmMain.Instance.XtraTabOpen("FrmCheck", "信息");
                        FrmMain.Instance.XtraTabOpen("FrmSelect", "信息");
                    }));
                });

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

        private void StartTool()
        {
            try
            {
                th.TestLaunch(this.checkEdit1.Checked);
                th.CloseBandTest();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
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

            DataProcess dp = new DataProcess();
            string msg = dp.validOrder(this.txtName.Text.Trim());
            if (msg.Length > 0)
            {
                XtraMessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            return rtn;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

    }
}
