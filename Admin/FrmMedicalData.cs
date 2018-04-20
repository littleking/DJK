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
using DJK.Model;
using DJK.DAL;
using System.Configuration;

namespace Admin
{
    public partial class FrmMedicalData : FrmTemplate
    {

        FormModelType _ModelType;
        DJK.Model.admin_MedicalData modelData = new DJK.Model.admin_MedicalData();
        DJK.DAL.admin_MedicalData dalData = new DJK.DAL.admin_MedicalData();
        private int infoTotal=0;
        private int matrixTotal=0;

        public FrmMedicalData(FormModelType formModeType)
        {
            InitializeComponent();
            //ShowButton(new string[] { "Add","Delete","Save" });
            string info = ConfigurationManager.AppSettings["info"].ToString();
            string matrix = ConfigurationManager.AppSettings["matrix"].ToString();
            infoTotal = int.Parse(info);
            matrixTotal = int.Parse(matrix);
            if (formModeType == null)
            {
                _ModelType = FormModelType.FormModelAdd;
            }
            else
            {
                _ModelType = formModeType;
            }
            initLeft();
            initRight();
            this.searchControlLeft.Client = this.listBoxControlLeft;
        }

        private DataTable CreateTable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("ID", typeof(int));
            t.Columns.Add("MedicalID", typeof(int));
            t.Columns.Add("Source", typeof(string));
            return t;
        }

        private void initLeft()
        {
            DataTable left = CreateTable();
            int i = 1;
            for(i=1; i <= infoTotal; i++)
            {
                left.Rows.Add(new object[] { i, i, "i " + i.ToString() });
            }
            for(int j=1;j<=matrixTotal;j++)
            {
                left.Rows.Add(new object[] { i,i, "m " + j.ToString() });
                i++;
            }
            listBoxControlLeft.DataSource = left;
            listBoxControlLeft.ValueMember = "ID";
            listBoxControlLeft.DisplayMember = "Source";
            
        }

        private void initRight()
        {
            DataTable right = CreateTable();
            if (modelData.SourceList != null)
            {
                foreach(DJK.Model.admin_MedicalSource sourceModel in modelData.SourceList)
                {
                    right.Rows.Add(new object[] { sourceModel.ID, sourceModel.MedicalID, sourceModel.Source });
                }
            }
            listBoxControlRight.DataSource = right;
            listBoxControlRight.ValueMember = "ID";
            listBoxControlRight.DisplayMember = "Source";
        }

        //protected override void Save()
        //{
        //    if (_ModelType == FormModelType.FormModelAdd)
        //    {
        //        addData();
        //    }
        //    else
        //    {
        //        updateData();
        //    }
        //}

        //protected override void Add()
        //{
        //    _ModelType = FormModelType.FormModelAdd;
        //    modelData = new DJK.Model.admin_MedicalData();
        //    txtCode.Text = "";
        //    txtItem.Text = "";
        //}


        //protected override void Delete()
        //{
        //    if(_ModelType == FormModelType.FormModelEdit)
        //    {
        //        DialogResult dResult = MessageBox.Show("确定要删除此条记录吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //        if (dResult == System.Windows.Forms.DialogResult.OK)
        //        {
        //            dalData.Delete(modelData.ID);
        //            XtraMessageBox.Show("删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            this.Close();
        //        }
        //    }
        //}

        private void updateData()
        {
            if (saveCheck())
            {
                modelData.Code = txtCode.Text.Trim().ToString();
                modelData.Item = txtItem.Text.Trim().ToString();
                bool changed = dalData.Update(modelData);
                if (changed)
                {
                    XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void addData()
        {
            if (saveCheck())
            {
                modelData.Code = txtCode.Text.Trim().ToString();
                modelData.Item = txtItem.Text.Trim().ToString();
                int i = dalData.Add(modelData);
                if (i > 0)
                {
                    _ModelType = FormModelType.FormModelEdit;
                    modelData.ID = i;
                    XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool saveCheck()
        {
            if (txtCode.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入编号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtItem.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入描述！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point p = Point.Empty;

        private void listBoxControlLeft_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ListBoxControl c = sender as ListBoxControl;
            p = new Point(e.X, e.Y);
            int selectedIndex = c.IndexFromPoint(p);
            if (selectedIndex == -1)
                p = Point.Empty;
        }

        private void listBoxControlLeft_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if ((p != Point.Empty) && ((Math.Abs(e.X - p.X) > 5) || (Math.Abs(e.Y - p.Y) > 5)))
                    listBoxControlLeft.DoDragDrop(sender, DragDropEffects.Move);
        }

        private void listBoxControlRight_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listBoxControlRight_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            ListBoxControl listBox = sender as ListBoxControl;
            Point newPoint = new Point(e.X, e.Y);
            newPoint = listBox.PointToClient(newPoint);
            int selectedIndex = listBox.IndexFromPoint(newPoint);
            DataRowView row = listBoxControlLeft.SelectedItem as DataRowView;
            DataTable dt = (DataTable)listBoxControlRight.DataSource;
            foreach(DataRow dr in dt.Rows)
            {
                if (dr[2] == row[2])
                {
                    return;
                }
            }
            (listBox.DataSource as DataTable).Rows.Add(new object[] { row[0], row[1],row[2] });
        }
    }
}
