using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JKJC
{
    public partial class frmValidate : XtraForm
    {
        public frmValidate(string status, string contact, string time)
        {
            InitializeComponent();
            this.lblContact.Text = contact;
            this.lblStatus.Text = status;
            this.lblTime.Text = time;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Dispose();
            this.Close();
        }
    }



}
