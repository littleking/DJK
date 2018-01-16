using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmTest : DevExpress.XtraEditors.XtraForm
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        #region Property
        private static FrmTest mInstance = null;
        /// <summary>
        /// FrmMain的唯一实例体
        /// </summary>
        public static FrmTest Instance
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

        private void testBtn_Click(object sender, EventArgs e)
        {
            try
            {
                AgentDll.exit_target();
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
            //try
            //{
            //    AgentDll.launchEx(true);
            //}
            //catch(Exception ex)
            //{
            //    string haha = ex.ToString();
            //    XtraMessageBox.Show(ex.ToString(), "错误");
            //}
        }

        private void testBtn2_Click(object sender, EventArgs e)
        {
            try
            {
                AgentDll.exit_target();
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }

        private void testBtn3_Click(object sender, EventArgs e)
        {
            try
            {

                string w_name = "tester";
                string w_birth_day = "1984-09-10";
                string w_location = "wuhan";
                string w_sex = "Female";
                string sql = string.Format("INSERT INTO patient VALUES (NULL, '{0}', '{1}', '{2}', '中国', NULL, NULL, NULL, NULL, NULL, 0, 0, 0, '{3}', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 0, 0, 0, 0, 10, 0, 0, 76, 88, 85, 91, 98, 64, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 1, 1, 1, 1, 1, 2, NULL, NULL, NULL);", w_name, w_birth_day, w_location, w_sex);
                string dbname = "C:\\Clasp32\\DATA\\data.db3";
                StringBuilder sb = new StringBuilder();
                sb.Append(sql);
                AgentDll.exec_sql(sb);
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AgentDll.showForm();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder buf = new StringBuilder(1024);
                AgentDll.btn_check_head_band(buf);
                XtraMessageBox.Show(buf.ToString()+ "hahahaha");
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }
    }
}
