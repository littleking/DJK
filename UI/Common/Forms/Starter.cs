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

namespace UI
{
    public partial class Starter : Form
    {
        public Starter()
        {
            InitializeComponent();
        }

        private void Starter_Shown(object sender, EventArgs e)
        {
            try
            {
                //killP();
                AgentDll.launchEx(true);
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
            Thread.Sleep(10000);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
