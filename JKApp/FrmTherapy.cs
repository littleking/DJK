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

namespace JKApp
{
    public partial class FrmTherapy : XtraForm
    {

        private TestHelper th;
        public FrmTherapy()
        {
            InitializeComponent();
            th = new TestHelper();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DataProcess dp = new DataProcess();
            int rtn = dp.setUsed(Patient.w_code);
            LogHelper.WriteLog(CurrentUser.UserName + "-" + Patient.w_code + "执行结果为" + rtn);
            DoTherapy();
        }

        private void DoTherapy()
        {
            try
            {
                Thread.Sleep(500);
                th.TestLaunch(true);
                Thread.Sleep(15000);
                th.CloseBandTest();
                Thread.Sleep(3000);
                th.TestToStart();
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                LogHelper.WriteLog(haha);
                XtraMessageBox.Show(ex.ToString(), "错误");

            }
        }

        private void GoBack()
        {
            killP();
            this.Close();
            //FrmInfo.Instance.checkWaitedSource();
            FrmInfo.Instance.Show();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            killP();
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
