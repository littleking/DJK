using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Paricom
{
    public partial class FrmLogin : Form
    {

        private DataSet _dataHistoryUser = new DataSet("Login");
        private KGMWebService.GmWebServletClient webService;
        public FrmLogin()
        {
            InitializeComponent();
            string ws = ConfigurationManager.AppSettings["WSAddress"].ToString();
            webService = new KGMWebService.GmWebServletClient("GmWebServletImplPort", ws);
            LoadLogin();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    //启动主窗体
                    this.DialogResult = DialogResult.OK;
                    
                }
                else
                {
                        //还原按钮状态
                    enableButtons();

                    MessageBox.Show(strMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion


            }
            catch (SystemException ex)
            {
                MessageBox.Show("登陆服务异常，请稍后重试，如果仍有问题请与系统管理员联系处理故障。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHelper.WriteLog(ex.Message.ToString());
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
    }
}
