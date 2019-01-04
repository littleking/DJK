namespace JKApp
{
    partial class FrmEmotionSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmotionSheet));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridSheet = new DevExpress.XtraGrid.GridControl();
            this.gridViewSheet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridColumnNo,
            this.gridColumnName,
            this.gridColumn1});
            this.gridViewSheet.GridControl = this.gridSheet;
            this.gridViewSheet.Name = "gridViewSheet";
            this.gridViewSheet.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnNo
            // 
            this.gridColumnNo.Caption = "No";
            this.gridColumnNo.FieldName = "no";
            this.gridColumnNo.Name = "gridColumnNo";
            this.gridColumnNo.OptionsColumn.AllowEdit = false;
            this.gridColumnNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnNo.OptionsColumn.AllowMove = false;
            this.gridColumnNo.OptionsColumn.AllowShowHide = false;
            this.gridColumnNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnNo.Visible = true;
            this.gridColumnNo.VisibleIndex = 0;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Name";
            this.gridColumnName.FieldName = "name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsColumn.AllowEdit = false;
            this.gridColumnName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnName.OptionsColumn.AllowMove = false;
            this.gridColumnName.OptionsColumn.AllowShowHide = false;
            this.gridColumnName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 1;
            this.gridColumnName.Width = 300;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Value";
            this.gridColumn1.FieldName = "value";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.AllowShowHide = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // FrmEmotionSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmEmotionSheet";
            this.Text = "情绪数据";
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}