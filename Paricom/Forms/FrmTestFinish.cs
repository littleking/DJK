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
    public partial class FrmTestFinish : FrmBase
    {

        public FrmTestFinish()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //Application.Exit();
            killP();
            FrmMain.Instance.XtraTabOpen("FrmInfo", "信息");
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
    }
}
