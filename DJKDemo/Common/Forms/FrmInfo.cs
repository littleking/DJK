using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DJKUI
{
    public partial class FrmInfo : Form
    {
        public FrmInfo()
        {
            InitializeComponent();
            textBox1.Text = "";
            dateEdit1.Text = "";
            textBox3.Text = "";
            this.comboBoxEdit1.SelectedIndex = -1;
            comboBoxEdit1.Properties.Items.Add("男");
            comboBoxEdit1.Properties.Items.Add("女");
        }

        private bool ValidateInfo()
        {
            bool rtn = true;
            if (this.textBox1.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            else if (this.dateEdit1.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入生日", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            else if (this.textBox3.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入出生地", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            else if(this.comboBoxEdit1.SelectedIndex<0)
            {
                XtraMessageBox.Show("请选择性别", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            return rtn;
        }

        private bool CheckNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return false;
            }
            Regex regex = new Regex(@"^(-)?\d+(\.\d+)?$");
            if (regex.IsMatch(number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void picStart_Click(object sender, EventArgs e)
        {
            try
            {
                //string w_name = "tester";
                //string w_birth_day = "1984-09-10";
                //string w_location = "wuhan";
                //string w_sex = "Female";
                //string sql = string.Format("INSERT INTO patient VALUES (NULL, '{0}', '{1}', '{2}', '中国', NULL, NULL, NULL, NULL, NULL, 0, 0, 0, '{3}', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 0, 0, 0, 0, 10, 0, 0, 76, 88, 85, 91, 98, 64, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 1, 1, 1, 1, 1, 2, NULL, NULL, NULL);", w_name, w_birth_day, w_location, w_sex);
                //byte[] sqlBytes = System.Text.Encoding.Unicode.GetBytes(sql);
                //string dbname = "C:\\Clasp32\\DATA\\data.db3";
                // AgentDll.exec_sql(dbname,sql);
                if (ValidateInfo()){
                    textBox1.Text = "";
                    dateEdit1.Text = "";
                    textBox3.Text = "";
                    this.comboBoxEdit1.SelectedIndex = -1;
                    FrmMain.Instance.XtraTabOpen("FrmSelect", "信息");
                }
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            dateEdit1.Text = "";
            textBox3.Text = "";
            this.comboBoxEdit1.SelectedIndex = -1;
            FrmMain.Instance.XtraTabOpen("FrmStart", "信息");
        }
    }
}
