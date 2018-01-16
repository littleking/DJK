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
    public partial class FrmTest : DevExpress.XtraEditors.XtraForm
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        #region Property
        private static FrmTest mInstance = null;
        /// <summary>
        /// FrmMain的唯一实例体
        /// </summary>
        public static FrmTest Instance
        {
            get
            {
                return mInstance;
            }
            set
            {
                mInstance = value;
            }
        }
        #endregion

        private void testBtn_Click(object sender, EventArgs e)
        {
            FrmMain.Instance.XtraTabOpen("FrmProgress", "信息");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmMain.Instance.XtraTabOpen("FrmStart", "信息");
        }
    }
}
