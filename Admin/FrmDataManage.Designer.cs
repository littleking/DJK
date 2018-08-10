namespace Admin
{
    partial class FrmDataManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListItem = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListMin = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListMax = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListFormula = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barSubCurrent = new DevExpress.XtraBars.BarSubItem();
            this.barSubChild = new DevExpress.XtraBars.BarSubItem();
            this.barSubDelete = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.listBoxClarity = new DevExpress.XtraEditors.ListBoxControl();
            this.searchControlClarity = new DevExpress.XtraEditors.SearchControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridSource = new DevExpress.XtraGrid.GridControl();
            this.gridSourceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMedicalID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxClarity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControlClarity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSourceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListCode,
            this.treeListItem,
            this.treeListMin,
            this.treeListMax,
            this.treeListFormula});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(2, 2);
            this.treeList1.Name = "treeList1";
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.treeList1.Size = new System.Drawing.Size(692, 445);
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.treeList1_ValidatingEditor);
            this.treeList1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeList1_CellValueChanged);
            this.treeList1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseUp);
            // 
            // treeListCode
            // 
            this.treeListCode.Caption = "编码";
            this.treeListCode.FieldName = "Code";
            this.treeListCode.Name = "treeListCode";
            this.treeListCode.OptionsColumn.AllowSort = false;
            this.treeListCode.Visible = true;
            this.treeListCode.VisibleIndex = 0;
            this.treeListCode.Width = 193;
            // 
            // treeListItem
            // 
            this.treeListItem.Caption = "项目";
            this.treeListItem.FieldName = "Item";
            this.treeListItem.Name = "treeListItem";
            this.treeListItem.OptionsColumn.AllowSort = false;
            this.treeListItem.Visible = true;
            this.treeListItem.VisibleIndex = 1;
            this.treeListItem.Width = 215;
            // 
            // treeListMin
            // 
            this.treeListMin.Caption = "最小值";
            this.treeListMin.FieldName = "DataMin";
            this.treeListMin.Name = "treeListMin";
            this.treeListMin.OptionsColumn.AllowSort = false;
            this.treeListMin.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Object;
            this.treeListMin.Width = 66;
            // 
            // treeListMax
            // 
            this.treeListMax.Caption = "最大值";
            this.treeListMax.FieldName = "DataMax";
            this.treeListMax.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListMax.Name = "treeListMax";
            this.treeListMax.OptionsColumn.AllowSort = false;
            this.treeListMax.Width = 66;
            // 
            // treeListFormula
            // 
            this.treeListFormula.Caption = "计算方式";
            this.treeListFormula.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.treeListFormula.FieldName = "DataFormula";
            this.treeListFormula.Name = "treeListFormula";
            this.treeListFormula.OptionsColumn.AllowSort = false;
            this.treeListFormula.Visible = true;
            this.treeListFormula.VisibleIndex = 2;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormulaDescription", 10, "计算方式")});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.PopupFormMinSize = new System.Drawing.Size(30, 0);
            this.repositoryItemLookUpEdit1.PopupSizeable = false;
            this.repositoryItemLookUpEdit1.PopupWidth = 10;
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            // 
            // barManager2
            // 
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubCurrent,
            this.barSubChild,
            this.barSubDelete,
            this.barSubItem1});
            this.barManager2.MaxItemId = 4;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager2;
            this.barDockControl1.Size = new System.Drawing.Size(952, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 449);
            this.barDockControl2.Manager = this.barManager2;
            this.barDockControl2.Size = new System.Drawing.Size(952, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Size = new System.Drawing.Size(0, 449);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(952, 0);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Size = new System.Drawing.Size(0, 449);
            // 
            // barSubCurrent
            // 
            this.barSubCurrent.Caption = "新增同级节点";
            this.barSubCurrent.Id = 0;
            this.barSubCurrent.Name = "barSubCurrent";
            this.barSubCurrent.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubCurrent_ItemClick);
            // 
            // barSubChild
            // 
            this.barSubChild.Caption = "新增下级节点";
            this.barSubChild.Id = 1;
            this.barSubChild.Name = "barSubChild";
            this.barSubChild.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubChild_ItemClick);
            // 
            // barSubDelete
            // 
            this.barSubDelete.Caption = "删除节点";
            this.barSubDelete.Id = 2;
            this.barSubDelete.Name = "barSubDelete";
            this.barSubDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubDelete_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "删除";
            this.barSubItem1.Id = 3;
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubItem1_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubCurrent),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubChild),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubDelete)});
            this.popupMenu1.Manager = this.barManager2;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl1.Controls.Add(this.treeList1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(696, 449);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(696, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(256, 449);
            this.panelControl2.TabIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.panelControl3);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(147, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(107, 445);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "基础数据";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.listBoxClarity);
            this.panelControl3.Controls.Add(this.searchControlClarity);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 21);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(103, 422);
            this.panelControl3.TabIndex = 2;
            // 
            // listBoxClarity
            // 
            this.listBoxClarity.Cursor = System.Windows.Forms.Cursors.Default;
            this.listBoxClarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxClarity.Location = new System.Drawing.Point(2, 22);
            this.listBoxClarity.Name = "listBoxClarity";
            this.listBoxClarity.Size = new System.Drawing.Size(99, 398);
            this.listBoxClarity.TabIndex = 0;
            this.listBoxClarity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxClarity_MouseDown);
            this.listBoxClarity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxClarity_MouseMove);
            // 
            // searchControlClarity
            // 
            this.searchControlClarity.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControlClarity.Location = new System.Drawing.Point(2, 2);
            this.searchControlClarity.MenuManager = this.barManager2;
            this.searchControlClarity.Name = "searchControlClarity";
            this.searchControlClarity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControlClarity.Size = new System.Drawing.Size(99, 20);
            this.searchControlClarity.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridSource);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(145, 445);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "数据来源";
            // 
            // gridSource
            // 
            this.gridSource.AllowDrop = true;
            this.gridSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSource.Location = new System.Drawing.Point(2, 21);
            this.gridSource.MainView = this.gridSourceView;
            this.gridSource.MenuManager = this.barManager2;
            this.gridSource.Name = "gridSource";
            this.gridSource.Size = new System.Drawing.Size(141, 422);
            this.gridSource.TabIndex = 0;
            this.gridSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSourceView});
            this.gridSource.DragDrop += new System.Windows.Forms.DragEventHandler(this.gridSource_DragDrop);
            this.gridSource.DragOver += new System.Windows.Forms.DragEventHandler(this.gridSource_DragOver);
            // 
            // gridSourceView
            // 
            this.gridSourceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnSource,
            this.gridColumnMedicalID,
            this.gridColumnTable,
            this.gridColumnNum});
            this.gridSourceView.GridControl = this.gridSource;
            this.gridSourceView.Name = "gridSourceView";
            this.gridSourceView.OptionsCustomization.AllowColumnMoving = false;
            this.gridSourceView.OptionsCustomization.AllowFilter = false;
            this.gridSourceView.OptionsCustomization.AllowGroup = false;
            this.gridSourceView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridSourceView.OptionsNavigation.UseTabKey = false;
            this.gridSourceView.OptionsView.ShowDetailButtons = false;
            this.gridSourceView.OptionsView.ShowGroupPanel = false;
            this.gridSourceView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridSourceView_PopupMenuShowing);
            // 
            // gridColumnSource
            // 
            this.gridColumnSource.Caption = "数据源";
            this.gridColumnSource.FieldName = "Source";
            this.gridColumnSource.Name = "gridColumnSource";
            this.gridColumnSource.OptionsColumn.AllowEdit = false;
            this.gridColumnSource.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSource.Visible = true;
            this.gridColumnSource.VisibleIndex = 0;
            this.gridColumnSource.Width = 148;
            // 
            // gridColumnMedicalID
            // 
            this.gridColumnMedicalID.Caption = "节点";
            this.gridColumnMedicalID.FieldName = "MedicalID";
            this.gridColumnMedicalID.Name = "gridColumnMedicalID";
            this.gridColumnMedicalID.Width = 96;
            // 
            // gridColumnTable
            // 
            this.gridColumnTable.Caption = "gridColumn1";
            this.gridColumnTable.FieldName = "SourceTable";
            this.gridColumnTable.Name = "gridColumnTable";
            // 
            // gridColumnNum
            // 
            this.gridColumnNum.Caption = "gridColumn1";
            this.gridColumnNum.FieldName = "SourceNum";
            this.gridColumnNum.Name = "gridColumnNum";
            this.gridColumnNum.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            // 
            // popupMenu2
            // 
            this.popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
            this.popupMenu2.Manager = this.barManager2;
            this.popupMenu2.Name = "popupMenu2";
            // 
            // FrmDataManage
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(952, 449);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "FrmDataManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDataManage_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxClarity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControlClarity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSourceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListItem;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarSubItem barSubCurrent;
        private DevExpress.XtraBars.BarSubItem barSubChild;
        private DevExpress.XtraBars.BarSubItem barSubDelete;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ListBoxControl listBoxClarity;
        private DevExpress.XtraEditors.SearchControl searchControlClarity;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSourceView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMedicalID;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNum;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListMin;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListMax;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListFormula;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    }
}