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
    public partial class FrmSelect : DevExpress.XtraEditors.XtraForm
    {
        public FrmSelect()
        {
            InitializeComponent();
            
        }

        private void testBtn_Click_1(object sender, EventArgs e)
        {
            FrmMain.Instance.XtraTabOpen("FrmCheck", "信息");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmMain.Instance.XtraTabOpen("FrmStart", "信息");
        }
    }
}
