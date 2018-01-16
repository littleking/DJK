using DataLibrary;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
                catch(Exception ex)
                {
                    XtraMessageBox.Show("数据保存失败，请联系管理员!"+ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.txtSex.SelectedIndex = -1;
                    this.txtName.Text = "";
                    this.txtBirthDay.Text = "";
                    this.txtBirthPlace.Text = "";
                    this.pictureBox1.Enabled = true;
                    this.Invoke((MethodInvoker)(() => {
                        FrmMain.Instance.XtraTabOpen("FrmCheck", "信息");
                    }));
                });

            }
        }

        private void StartTool()
        {
            try
            {
                th.TestLaunch(this.checkEdit1.Checked);
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
            
            return rtn;
        }

    }
}
