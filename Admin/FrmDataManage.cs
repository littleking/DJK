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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.IO;

namespace Admin
{
    public partial class FrmDataManage : XtraForm
    {
        DJK.DAL.admin_MedicalData dalMedical = new DJK.DAL.admin_MedicalData();
        DJK.DAL.admin_MedicalSource dalSource = new DJK.DAL.admin_MedicalSource();
        private int medicalID;
        SqlConnection conn;
        SqlConnection connGrid;
        DataTable dtTree;
        DataSet dsTree;
        DataTable dtGrid;
        DataSet dsGrid;
        SqlDataAdapter sda;
        SqlDataAdapter sdaGrid;
        private int infoTotal = 0;
        private int matrixTotal = 0;
        public FrmDataManage()
        {
            InitializeComponent();
            //ShowButtonRight(new string[] { "Save", "Exit" });
            string info = ConfigurationManager.AppSettings["info"].ToString();
            string matrix = ConfigurationManager.AppSettings["matrix"].ToString();
            infoTotal = int.Parse(info);
            matrixTotal = int.Parse(matrix);
            conn = null;
            sda = null;
            connGrid = null;
            sdaGrid = null;
            dtTree = null;
            dsTree = new DataSet();
            dtGrid = null;
            dsGrid = new DataSet();
            medicalID = 0;
            TreeInit();
            initClarity();
            this.searchControlClarity.Client = this.listBoxClarity;
            initFormula();
        }

        private void TreeInit()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connectionstring"];
                conn = new SqlConnection(connectionString);
                sda = new SqlDataAdapter();
                dsTree = new DataSet();
                sda.SelectCommand = new SqlCommand("select ID,Item,Description,ParentID,Code,Sort,IsRoot,DataFormula,DataMin,DataMax from admin_medicalData", conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(sda);//自动生成相应的命令，这句很重要

                conn.Open();

                sda.Fill(dsTree);
                dtTree = dsTree.Tables[0];

                this.treeList1.ClearNodes();
                this.treeList1.DataSource = null;
                this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
                this.treeList1.DataSource = dtTree;
                this.treeList1.KeyFieldName = "ID";
                this.treeList1.ParentFieldName = "ParentID";
                //this.treeList1.Nodes[0].Expanded = true;
                this.treeList1.RootValue = 0;
                this.treeListCode.FieldName = "Code";
                this.treeListItem.FieldName = "Item";
                this.treeList1.ExpandAll();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void GridReload(int mid)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connectionstring"];
                connGrid = new SqlConnection(connectionString);
                sdaGrid = new SqlDataAdapter();
                dsGrid = new DataSet();
                sdaGrid.SelectCommand = new SqlCommand("select ID,MedicalID,Source,SourceTable,SourceNum,SourceID from admin_medicalSource where medicalID=" + mid + " order by SourceTable,SourceNum", connGrid);
                SqlCommandBuilder cb = new SqlCommandBuilder(sdaGrid);//自动生成相应的命令，这句很重要

                connGrid.Open();

                sdaGrid.Fill(dsGrid);
                dtGrid = dsGrid.Tables[0];
                gridSource.DataSource = dtGrid;
                gridSourceView.RefreshData();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (connGrid != null)
                {
                    connGrid.Close();
                }
            }
        }

        private void TreeReload()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connectionstring"];
                conn = new SqlConnection(connectionString);
                sda = new SqlDataAdapter();
                dsTree = new DataSet();
                sda.SelectCommand = new SqlCommand("select ID,Item,Description,ParentID,Code,Sort,IsRoot,DataMin,DataMax,DataFormula from admin_medicalData", conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(sda);//自动生成相应的命令，这句很重要

                conn.Open();

                sda.Fill(dsTree);
                dtTree = dsTree.Tables[0];
                treeList1.DataSource = dtTree;
                treeList1.ExpandAll();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void saveTree()
        {
            treeList1.PostEditor();
            treeList1.EndCurrentEdit();
            treeList1.BeginUpdate();
            int rows = sda.Update(dsTree.Tables[0]);
            dtTree.AcceptChanges();
            treeList1.EndUpdate();
        }

        private void saveGrid()
        {
            gridSourceView.PostEditor();
            gridSourceView.UpdateCurrentRow();
            int rows = sdaGrid.Update(dsGrid.Tables[0]);
            dtGrid.AcceptChanges();
        }


        //protected override void Save()
        //{
        //    treeList1.PostEditor();
        //    treeList1.EndCurrentEdit();
        //    int rows = sda.Update(dsTree.Tables[0]);
        //    dtTree.AcceptChanges();
        //    if (rows > 0)
        //    {
        //        XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        XtraMessageBox.Show("保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //protected override void Exit()
        //{
        //    if (conn != null)
        //    {
        //        conn.Close();
        //    }
        //    this.Close();
        //}


        private void treeList1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            if (e.Button == MouseButtons.Right
                    && ModifierKeys == Keys.None
                    && treeList1.State == TreeListState.Regular)
            {
                Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
                TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
                if (hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    tree.SetFocusedNode(hitInfo.Node);
                }

                if (tree.FocusedNode != null)
                {
                    popupMenu1.ShowPopup(p);
                }
            }
        }

        private void barSubDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.popupMenu1.HidePopup();
            TreeListNode clickedNode = this.treeList1.FocusedNode;
            string name = clickedNode.GetDisplayText("Code");
            string formname = clickedNode.GetDisplayText("Item");
            int pid = (int)clickedNode[treeList1.ParentFieldName];
            int id = (int)clickedNode[treeList1.KeyFieldName];
            if (XtraMessageBox.Show("您确定要删除" + name + " " + formname + "吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clickedNode.ParentNode != null)
                    clickedNode.ParentNode.Nodes.Remove(clickedNode);
                else
                {
                    treeList1.Nodes.Remove(clickedNode);
                }
                saveTree();
                TreeReload();
                treeList1.LayoutChanged();
            }
        }

        private void barSubChild_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.popupMenu1.HidePopup();
            TreeListNode clickedNode = this.treeList1.FocusedNode;
            string code = clickedNode.GetDisplayText("Code");
            string item = clickedNode.GetDisplayText("Item");
            int pid = (int)clickedNode[treeList1.ParentFieldName];
            int id = (int)clickedNode[treeList1.KeyFieldName];
            FrmAdd frmAdd = new FrmAdd(code, pid, id, true);
            frmAdd.ShowDialog();
            DJK.Model.admin_MedicalData _model = frmAdd._model;
            if (_model != null)
            {
                CreateNodes(this.treeList1, clickedNode, _model);
            }
        }

        private void barSubCurrent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.popupMenu1.HidePopup();
            TreeListNode clickedNode = this.treeList1.FocusedNode;
            string code = clickedNode.GetDisplayText("Code");
            string item = clickedNode.GetDisplayText("Item");
            int pid = (int)clickedNode[treeList1.ParentFieldName];
            int id = (int)clickedNode[treeList1.KeyFieldName];
            FrmAdd frmAdd = new FrmAdd(code, pid, id, false);
            frmAdd.ShowDialog();
            DJK.Model.admin_MedicalData _model = frmAdd._model;
            if (_model != null)
            {
                if (pid == 0)
                {
                    CreateNodes(this.treeList1, null, _model);
                }
                else
                {
                    CreateNodes(this.treeList1, clickedNode.ParentNode, _model);
                }
            }
        }

        private void CreateNodes(TreeList tl, TreeListNode parentNode, DJK.Model.admin_MedicalData model)
        {
            DataRow dr = dtTree.NewRow();
            dr["code"] = model.Code;
            dr["item"] = model.Item;
            if (model.DataMin != null)
            {
                dr["datamin"] = model.DataMin;
            }
            if (model.DataMax != null)
            {
                dr["datamax"] = model.DataMax;
            }
            if (model.DataFormula != null)
            {
                dr["dataformula"] = model.DataFormula;
            }
            tl.BeginUnboundLoad();
            tl.AppendNode(dr, parentNode);
            tl.EndUnboundLoad();
            saveTree();
            TreeReload();
            tl.LayoutChanged();
        }

        private void treeList1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name.Equals("treeListMin"))
            {
                if (e.Value.ToString().Length == 0)
                {
                    e.Value = DBNull.Value;
                }
            }
            treeList1.PostEditor();
            treeList1.EndCurrentEdit();
            int rows = sda.Update(dsTree.Tables[0]);
            dtTree.AcceptChanges();
        }

        private void initClarity()
        {
            DataTable left = CreateTable();
            //int i = 1;
            //for (i = 1; i <= infoTotal; i++)
            //{
            //    left.Rows.Add(new object[] { i, i, "i" + i.ToString(), "info", i });
            //}
            //for (int j = 1; j <= matrixTotal; j++)
            //{
            //    left.Rows.Add(new object[] { i, i, "m" + j.ToString(), "matrix", j });
            //    i++;
            //}
            listBoxClarity.DataSource = left;
            listBoxClarity.ValueMember = "ID";
            listBoxClarity.DisplayMember = "Source";
        }

        private DataTable CreateTable()
        {
            DJK.DAL.admin_Clarity dalClarity = new DJK.DAL.admin_Clarity();
            DataSet ds = dalClarity.GetAlltList();

            DataTable t = ds.Tables[0];
            //t.Columns.Add("ID", typeof(int));
            //t.Columns.Add("MedicalID", typeof(int));
            //t.Columns.Add("Source", typeof(string));
            //t.Columns.Add("SourceTable", typeof(string));
            //t.Columns.Add("SourceNum", typeof(int));
            return t;
        }

        private void initFormula()
        {
            DataTable t = new DataTable();
            t.Columns.Add("ID", typeof(int));
            t.Columns.Add("FormulaDescription", typeof(string));
            t.Rows.Add(new object[] { 1, "最大值" });
            t.Rows.Add(new object[] { 2, "平均值" });
            repositoryItemLookUpEdit1.DataSource = t;
            repositoryItemLookUpEdit1.ValueMember = "ID";
            repositoryItemLookUpEdit1.DisplayMember = "FormulaDescription";
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            TreeListNode clickedNode = this.treeList1.FocusedNode;
            string code = clickedNode.GetDisplayText("Code");
            string item = clickedNode.GetDisplayText("Item");
            int pid = (int)clickedNode[treeList1.ParentFieldName];
            int id = (int)clickedNode[treeList1.KeyFieldName];
            medicalID = id;
            GridReload(medicalID);
        }

        private void FrmDataManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null)
            {
                conn.Close();
            }
            if (connGrid != null)
            {
                connGrid.Close();
            }
        }


        Point p = Point.Empty;

        private void listBoxClarity_MouseDown(object sender, MouseEventArgs e)
        {
            ListBoxControl c = sender as ListBoxControl;
            p = new Point(e.X, e.Y);
            int selectedIndex = c.IndexFromPoint(p);
            if (selectedIndex == -1)
                p = Point.Empty;
        }

        private void listBoxClarity_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if ((p != Point.Empty) && ((Math.Abs(e.X - p.X) > 5) || (Math.Abs(e.Y - p.Y) > 5)))
                    listBoxClarity.DoDragDrop(sender, DragDropEffects.Move);
        }

        private void gridSource_DragOver(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            Point pt = grid.PointToClient(new Point(e.X, e.Y));
            GridView view = grid.GetViewAt(pt) as GridView;
            if (view == null)
                return;
            GridHitInfo hitInfo = gridSourceView.CalcHitInfo(pt);
            e.Effect = DragDropEffects.Move;
        }

        private void gridSource_DragDrop(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            Point pt = grid.PointToClient(new Point(e.X, e.Y));
            GridView view = grid.GetViewAt(pt) as GridView;
            if (view == null)
                return;
            DataRowView row = listBoxClarity.SelectedItem as DataRowView;
            DataTable dt = (DataTable)gridSource.DataSource;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[2].ToString() == row[2].ToString())
                {
                    return;
                }
            }
            (gridSource.DataSource as DataTable).Rows.Add(new object[] { null, medicalID, row[2], row[3], row[4], row[0] });
            saveGrid();
            GridReload(medicalID);
        }

        private void barSubItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRowView dr = (DataRowView)gridSourceView.GetRow(gridSourceView.FocusedRowHandle);
            this.popupMenu2.HidePopup();
            if (XtraMessageBox.Show("您确定要删除" + dr["Source"] + "吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                gridSourceView.GetRow(gridSourceView.FocusedRowHandle);
                gridSourceView.DeleteRow(gridSourceView.FocusedRowHandle);
                saveGrid();
                GridReload(medicalID);
            }
        }

        private void gridSourceView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                System.Drawing.Point p2 = Control.MousePosition;
                this.popupMenu2.ShowPopup(p2);
            }
        }


        private void treeList1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if(e.Value == null)
            {
                e.Value = DBNull.Value;
            }
            else if (e.Value.ToString().Length == 0)
            {
                e.Value = DBNull.Value;

            }
        }
    }

}
