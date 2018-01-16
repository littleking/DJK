using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DJKUI
{
    public partial class FrmStart : Form
    {
        public FrmStart()
        {
            InitializeComponent();
        }


        private void testBtn2_Click(object sender, EventArgs e)
        {
            FrmMain.Instance.XtraTabOpen("FrmInfo", "信息");
        }
    }
}
