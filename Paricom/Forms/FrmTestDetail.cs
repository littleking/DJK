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

namespace Paricom
{
    public partial class FrmTestDetail : FrmBase
    {
        private TestHelper th;
        public FrmTestDetail()
        {
            InitializeComponent();
            th = new TestHelper();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("正在校准测试仪，准备开始测试");
            splashScreenManager1.SetWaitFormDescription(" 请等待。。。");
            Task.Factory.StartNew(() =>
            {

                StartTool();

            }).ContinueWith(x =>
            {
                //splashScreenManager1.CloseWaitForm();
                this.pictureBox1.Enabled = true;
                this.Invoke((MethodInvoker)(() => {
                    splashScreenManager1.CloseWaitForm();
                    FrmMain.Instance.XtraTabOpen("FrmDoTest", "信息");
                }));
            });
        }


        private void StartTool()
        {
            try
            {
                th.TestToStart();
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }


    }
}
