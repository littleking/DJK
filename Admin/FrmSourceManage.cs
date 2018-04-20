using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DJK.Model;
using System.Configuration;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using DJK.DAL;
using System.Data.SqlClient;

namespace Admin
{
    public partial class FrmSourceManage : XtraForm
    {
        DJK.DAL.admin_Clarity dalClarity = new DJK.DAL.admin_Clarity();
        DJK.Model.admin_Clarity modelClarity = new DJK.Model.admin_Clarity();
        SqlConnection connGrid;
        SqlDataAdapter sdaGrid;
        DataSet dsGrid;
        DataTable dtGrid;
        public FrmSourceManage()
        {
            InitializeComponent();
            connGrid = null;
            sdaGrid = null;
            dtGrid = null;
            dsGrid = new DataSet();
            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connectionstring"];
                connGrid = new SqlConnection(connectionString);
                sdaGrid = new SqlDataAdapter();
                dsGrid = new DataSet();
                sdaGrid.SelectCommand = new SqlCommand("select ID,SourceTable,SourceNum,SourceMin,SourceMax from admin_Clarity order by SourceTable,SourceNum", connGrid);
                SqlCommandBuilder cb = new SqlCommandBuilder(sdaGrid);//自动生成相应的命令，这句很重要

                connGrid.Open();

                sdaGrid.Fill(dsGrid);
                dtGrid = dsGrid.Tables[0];
                gridSource.DataSource = dtGrid;
                gridSourceView.RefreshData();

            }
            catch (Exception ex)
            {
                string er = ex.ToString();
            }
            finally
            {
                if (connGrid != null)
                {
                    connGrid.Close();
                }
            }
        }

        private void saveGrid()
        {
            gridSourceView.PostEditor();
            gridSourceView.UpdateCurrentRow();
            int rows = sdaGrid.Update(dsGrid.Tables[0]);
            dtGrid.AcceptChanges();
        }

        private void gridSourceView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            saveGrid();
            //LoadGrid();
        }

        private void barSubItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.popupMenu1.HidePopup();
            FrmAddSource frmAdd = new FrmAddSource();
            frmAdd.ShowDialog();
            DJK.Model.admin_Clarity _model = frmAdd._model;
            if (_model != null)
            {
                DataRow dr = dtGrid.NewRow();
                dr["SourceTable"] = _model.SourceTable;
                dr["SourceNum"] = _model.SourceNum;
                dr["SourceMin"] = _model.SourceMin;
                dr["SourceMax"] = _model.SourceMax;
                dtGrid.Rows.Add(dr);
                saveGrid();
                LoadGrid();
            }
        }

        private void barSubItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.popupMenu1.HidePopup();
            if (XtraMessageBox.Show("您确定要删除这行数据吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                gridSourceView.DeleteRow(gridSourceView.FocusedRowHandle);
                saveGrid();
                LoadGrid();
            }
        }

        private void gridSourceView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                System.Drawing.Point p2 = Control.MousePosition;
                this.popupMenu1.ShowPopup(p2);
            }
        }
    }
}
