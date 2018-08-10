using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System.Threading;

namespace JKJC
{
    public partial class FrmLogin : XtraForm
    {

        private DataSet _dataHistoryUser = new DataSet("Login");
        private KGMWebService.GmWebServletClient webService;
        private Thread thRun;
        private bool myClose;
        public FrmLogin()
        {
            InitializeComponent();
            thRun = new Thread(new ThreadStart(Run));
            thRun.Start();
            myClose = false;
            string ws = ConfigurationManager.AppSettings["WSAddress"].ToString();
            webService = new KGMWebService.GmWebServletClient("GmWebServletImplPort", ws);
            LoadLogin();
        }

        private void Run()
        {
            while (true)
            {
                killP();
                Thread.Sleep(1 * 10 * 1000);//10秒
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            killP();
            Environment.Exit(0);
            this.Close();
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

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return;
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            UserLogin();
        }

        private void enableButtons()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    BtnOK.Show();
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    btnLogin.Hide();
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    txtUser.Enabled = true;
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    txtPassword.Enabled = true;
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    Refresh();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void disableButtons()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    BtnOK.Hide();
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    btnLogin.Show();
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    txtUser.Enabled = false;
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    txtPassword.Enabled = false;
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    Refresh();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UserLogin()
        {


            try
            {
                disableButtons();

            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
            try
            {
                splashScreenManager1.ShowWaitForm();
                #region 验证登陆信息
                //获取页面信息
                string strLoginName = txtUser.Text.Trim();
                string strLoginPwd = txtPassword.Text.Trim();

                string strMsg = string.Empty;
                string storeData = webService.login(strLoginName,strLoginPwd);
                if (storeData == "0")
                {
                    strMsg = "密码错误，请重试！";
                }
                else if (storeData == "-1")
                {
                    strMsg = "用户名不存在，请重试！";
                }
                else
                {
                    LoginData ld = getLogin(storeData);
                    CurrentUser.storeName = ld.storeName;
                    CurrentUser.UserName = strLoginName;
                    CurrentUser.CardMima = ld.dianpu_shitika_miyue;
                }

                #endregion


               

                #region 登陆后的操作
                if (string.IsNullOrEmpty(strMsg))
                {
                    WriteLogin();
                    splashScreenManager1.CloseWaitForm();
                    thRun.Abort();
                    myClose = true;
                    //启动主窗体
                    this.DialogResult = DialogResult.OK;
                    
                }
                else
                {
                        //还原按钮状态
                    enableButtons();
                    splashScreenManager1.CloseWaitForm();
                    MessageBox.Show(strMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion


            }
            catch (Exception ex)
            {
                splashScreenManager1.CloseWaitForm();
                LogHelper.WriteLog(ex.Message.ToString());
                MessageBox.Show("登陆失败,请重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void LoadLogin()
        {
            _dataHistoryUser = LoginHelper.LoadXml();
            if (_dataHistoryUser.Tables.Count > 0 && _dataHistoryUser.Tables[0].Rows.Count > 0)
            {
                txtUser.Text = _dataHistoryUser.Tables[0].Rows[0]["Account"].ToString();
            }
        }

        /// <summary>
        /// 修改历史登陆用
        /// </summary>
        public void WriteLogin()
        {
            //string strKeepPwd = checkKeepPwd.Checked ? "1" : "0";
            //string strAutoLogin = checkAutoLogin.Checked ? "1" : "0";
            LoginHelper.WriteByAccount(txtUser.Text.Trim(), null, null, null, null, null, null);
            
        }

        /// <summary>
        /// 按键
        /// </summary>
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnOK_Click(null, null);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private LoginData getLogin(string strJson)
        {
            LoginData vj = new LoginData();
            try
            {
                vj = JsonConvert.DeserializeObject<LoginData>(strJson);
            }
            catch (Exception ex)
            {
                string ss = ex.ToString();
            }
            return vj;
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!myClose)
            {
                killP();
                Environment.Exit(0);
            }
        }
    }
}
