using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JHHY
{
    public partial class OrderSelect : XtraForm
    {
        private List<OrderData> ol;
        public string verifyCode;
        public OrderSelect(List<OrderData> olist)
        {
            InitializeComponent();
            ol = olist;
            bindData();
            verifyCode = "";
        }

        private void bindData()
        {

            this.listView1.BeginUpdate(); 
            this.listView1.Columns.Add("", 0);
            this.listView1.Columns.Add("联系人", 100);
            this.listView1.Columns.Add("预约日期", 198);
            this.listView1.Columns.Add("校验码", 128);
            this.listView1.Columns.Add("服务项目", 220);
            ListViewItem[] p = new ListViewItem[ol.Count];
            for (int i = 0; i < ol.Count; i++)
            {
                p[i] = new ListViewItem(new string[] { "", ol[i].name, ol[i].orderDate, ol[i].verifyCode, ol[i].serviceName });
            }
            this.listView1.Items.AddRange(p);
            this.listView1.EndUpdate();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.listView1.SelectedItems.Count==0){
                    MessageBox.Show("请选择要使用的校验码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                verifyCode = this.listView1.SelectedItems[0].SubItems[3].Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
