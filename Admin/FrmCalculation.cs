using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DJK.DAL;
using System.Data.SqlClient;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using DJK.Model;
using System.Configuration;
using Formula;

namespace Admin
{
    public partial class FrmCalculation : XtraForm
    {
        List<MatrixParser> mpList;
        List<InfoParser> ipList;
        public FrmCalculation(List<MatrixParser> mList, List<InfoParser> iList)
        {
            InitializeComponent();
            mpList = mList;
            ipList = iList;
            initTree();
        }

        private void initTree()
        {
            FormulaCalculation fc = new FormulaCalculation(mpList, ipList);
            DateTime t1 = DateTime.Now;
            List<DJK.Model.admin_MedicalData> list = fc.getResult();
            DateTime t2 = DateTime.Now;
            TimeSpan ts1 = new TimeSpan(t1.Ticks);
            TimeSpan ts2 = new TimeSpan(t2.Ticks);
            TimeSpan ts = ts2.Subtract(ts1).Duration();
            double time = ts.TotalSeconds;
            MessageBox.Show("计算耗时" + time + "秒");
            this.treeList1.ClearNodes();
            this.treeList1.DataSource = null;
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.DataSource = list;
            this.treeList1.KeyFieldName = "ID";
            this.treeList1.ParentFieldName = "ParentID";
            //this.treeList1.Nodes[0].Expanded = true;
            this.treeList1.RootValue = 0;
            this.treeListCode.FieldName = "Code";
            this.treeListItem.FieldName = "Item";
            this.treeListValue.FieldName = "DataValue";
            this.treeList1.ExpandAll();
        }
    }
}
