using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Paricom
{
    public partial class FrmCheck : FrmBase
    {

        private TestHelper th;
        private bool isCheck;
        public FrmCheck()
        {
            InitializeComponent();
            th = new TestHelper();
            isCheck = false;
        }


        private void picHead_Click(object sender, EventArgs e)
        {
            try
            {
                string msg;
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("正在测试绑带");
                splashScreenManager1.SetWaitFormDescription(" 请等待。。。");
                if (th.TestHead())
                {
                    msg = "连接成功";
                }
                else
                {
                    msg = "头部绑带未连接";
                }
                splashScreenManager1.CloseWaitForm();
                XtraMessageBox.Show(msg, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }

        private void picLHand_Click(object sender, EventArgs e)
        {
            try
            {
                string msg;
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("正在测试绑带");
                splashScreenManager1.SetWaitFormDescription(" 请等待。。。");
                if (th.TestLH())
                {
                    msg = "连接成功";
                }
                else
                {
                    msg = "左手绑带未连接";
                }
                splashScreenManager1.CloseWaitForm();
                XtraMessageBox.Show(msg, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }

        private void picRHand_Click(object sender, EventArgs e)
        {
            try
            {
                string msg;
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("正在测试绑带");
                splashScreenManager1.SetWaitFormDescription(" 请等待。。。");
                if (th.TestRH())
                {
                    msg = "连接成功";
                }
                else
                {
                    msg = "右手绑带未连接";
                }
                splashScreenManager1.CloseWaitForm();
                XtraMessageBox.Show(msg, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }

        private void picLFoot_Click(object sender, EventArgs e)
        {
            try
            {

                string msg;
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("正在测试绑带");
                splashScreenManager1.SetWaitFormDescription(" 请等待。。。");
                if (th.TestLF())
                {
                    msg = "连接成功";
                }
                else
                {
                    msg = "左脚绑带未连接";
                }
                splashScreenManager1.CloseWaitForm();
                XtraMessageBox.Show(msg, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }

        private void picRightF_Click(object sender, EventArgs e)
        {
            try
            {
                string msg;
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption("正在测试绑带");
                splashScreenManager1.SetWaitFormDescription(" 请等待。。。");
                if (th.TestRF())
                {
                    msg = "连接成功";
                }
                else
                {
                    msg = "右脚绑带未连接";
                }
                splashScreenManager1.CloseWaitForm();
                XtraMessageBox.Show(msg, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }

        private void EnterPass()
        {
            th.CloseBandTest();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string str;
            if(isCheck){
                EnterPass();
                FrmMain.Instance.XtraTabOpen("FrmSelect", "信息");
            }
            else
            {

                DialogResult dr = XtraMessageBox.Show("绑带连接未检测，或检测未通过，" + "确定要继续吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(dr == DialogResult.OK){
                    EnterPass();
                    FrmMain.Instance.XtraTabOpen("FrmSelect", "信息");
                }

            }
        }

        private void picCheck_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("正在测试绑带");
            splashScreenManager1.SetWaitFormDescription(" 请等待。。。");
            
            string str = "";
            try
            {
                isCheck = th.TestBand(out str);
            }catch(Exception ex)
            {
                isCheck = false;
                XtraMessageBox.Show("程序出现错误，请重试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            splashScreenManager1.CloseWaitForm();
            string msg = "";
            if (isCheck)
            {
                msg = "连接成功";
                
            }
            else
            {
                msg += str+"的绑带未连接";
            }
            XtraMessageBox.Show(msg, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
