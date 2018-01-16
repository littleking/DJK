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
    public partial class FrmTest : FrmBase
    {

        public FrmTest()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmMain.Instance.XtraTabOpen("FrmTestDetail", "信息");
        }


    }
}
