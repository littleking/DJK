namespace QiYuan
{
    partial class FrmCheckSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckSheet));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridSheet = new DevExpress.XtraGrid.GridControl();
            this.gridViewSheet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnData = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSheet)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridSheet);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 514);
            this.panelControl1.TabIndex = 0;
            // 
            // gridSheet
            // 
            this.gridSheet.Location = new System.Drawing.Point(22, 26);
            this.gridSheet.MainView = this.gridViewSheet;
            this.gridSheet.Name = "gridSheet";
            this.gridSheet.Size = new System.Drawing.Size(754, 459);
            this.gridSheet.TabIndex = 0;
            this.gridSheet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSheet});
            // 
            // gridViewSheet
            // 
            this.gridViewSheet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnTitle,
            this.gridColumnData});
            this.gridViewSheet.GridControl = this.gridSheet;
            this.gridViewSheet.Name = "gridViewSheet";
            this.gridViewSheet.OptionsView.ShowColumnHeaders = false;
            this.gridViewSheet.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnTitle
            // 
            this.gridColumnTitle.Caption = "gridColumn1";
            this.gridColumnTitle.FieldName = "title";
            this.gridColumnTitle.Name = "gridColumnTitle";
            this.gridColumnTitle.OptionsColumn.AllowEdit = false;
            this.gridColumnTitle.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnTitle.OptionsColumn.AllowMove = false;
            this.gridColumnTitle.OptionsColumn.AllowShowHide = false;
            this.gridColumnTitle.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnTitle.OptionsColumn.ShowCaption = false;
            this.gridColumnTitle.Visible = true;
            this.gridColumnTitle.VisibleIndex = 0;
            this.gridColumnTitle.Width = 206;
            // 
            // gridColumnData
            // 
            this.gridColumnData.Caption = "gridColumn1";
            this.gridColumnData.FieldName = "result";
            this.gridColumnData.Name = "gridColumnData";
            this.gridColumnData.OptionsColumn.AllowEdit = false;
            this.gridColumnData.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnData.OptionsColumn.AllowMove = false;
            this.gridColumnData.OptionsColumn.AllowShowHide = false;
            this.gridColumnData.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnData.OptionsColumn.ShowCaption = false;
            this.gridColumnData.Visible = true;
            this.gridColumnData.VisibleIndex = 1;
            this.gridColumnData.Width = 475;
            // 
            // FrmCheckSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCheckSheet";
            this.Text = "检测初诊表";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridSheet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSheet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTitle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnData;
    }
}