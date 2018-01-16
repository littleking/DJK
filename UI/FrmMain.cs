using DevExpress.XtraEditors;
using DevExpress.XtraTab;
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
    public partial class FrmMain : Form
    {

        public string key = string.Empty;
        /// <summary>
        /// 是否打开窗体
        /// </summary>
        public bool IsOpenFrm = true;
        public FrmMain()
        {
            InitializeComponent();
            XtraTabOpen("FrmInfo","信息");
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
        /// <summary>
        /// 打开tab页
        /// </summary>
        /// <param name="FrmName"></param>
        /// <param name="Caption"></param>
        /// <param name="frm"></param>
        public void XtraTabOpen(string strFrmName, string Caption)
        {
            string FrmName = strFrmName;
            //验证窗体是否已经打开
            if (!IsFormOpen(FrmName))
            {
                return;
            }
            //通过反射找到对应的窗体（必须加命名空间）
            strFrmName = "UI." + strFrmName;
            Type tForm = Type.GetType(strFrmName);
            if (tForm == null)
            {
                XtraMessageBox.Show("该功能正在开发中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // navBarLeftMenu.Visible = false;
                // tab_con.Visible = false;
                //OpenHome();
                return;
            }
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(tForm);
                //if (strFrmName == "Vstar.BCS.UI.YCK_ORDER"&& !string.IsNullOrEmpty(key))
                object[] args = { key };
                System.Windows.Forms.Form frm;
                key = string.Empty;
                //frm = assembly.CreateInstance(strFrmName, false, System.Reflection.BindingFlags.Default, null, args, null, null) as System.Windows.Forms.Form;
                frm = assembly.CreateInstance(strFrmName) as System.Windows.Forms.Form;
                if (!IsOpenFrm)
                {
                    return;
                }

                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Name = FrmName;
                tabPage.Text = Caption;
                tabPage.AutoScroll = true;
                tabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;

                tabPage.Controls.Add(frm);
                tab_con.TabPages.Add(tabPage);
                tab_con.SelectedTabPage = tabPage;


                frm.Text = Caption;
                frm.Show();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("打开页面失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 

        #region 判断Tab窗口是否允许打开
        /// <summary>
        /// 判断MDI窗口是否允许打开
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        private bool IsFormOpen(string FormName)
        {
            foreach (XtraTabPage tabpage in tab_con.TabPages)
            {
                if (tabpage.Name == FormName)
                {
                    tab_con.SelectedTabPage = tabpage;
                    return false;
                }
            }
            return true;
        }
        #endregion


        #region Property
        private static FrmMain mInstance = null;
        /// <summary>
        /// FrmMain的唯一实例体
        /// </summary>
        public static FrmMain Instance
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

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            killP();
        }
    }

}
