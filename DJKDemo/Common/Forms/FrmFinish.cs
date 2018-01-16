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

namespace DJKUI
{
    public partial class FrmFinish : DevExpress.XtraEditors.XtraForm
    {
        public FrmFinish()
        {
            InitializeComponent();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmMain.Instance.XtraTabOpen("FrmStart", "信息");
        }
    }
}
