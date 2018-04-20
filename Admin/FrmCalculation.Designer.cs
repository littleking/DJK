namespace Admin
{
    partial class FrmCalculation
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListItem = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.treeList1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(577, 334);
            this.panelControl1.TabIndex = 0;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListCode,
            this.treeListItem,
            this.treeListValue});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(2, 2);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(573, 330);
            this.treeList1.TabIndex = 0;
            // 
            // treeListCode
            // 
            this.treeListCode.Caption = "编码";
            this.treeListCode.FieldName = "Code";
            this.treeListCode.Name = "treeListCode";
            this.treeListCode.OptionsColumn.AllowEdit = false;
            this.treeListCode.OptionsColumn.AllowMove = false;
            this.treeListCode.OptionsColumn.AllowSort = false;
            this.treeListCode.OptionsColumn.ReadOnly = true;
            this.treeListCode.Visible = true;
            this.treeListCode.VisibleIndex = 0;
            this.treeListCode.Width = 207;
            // 
            // treeListItem
            // 
            this.treeListItem.Caption = "描述";
            this.treeListItem.FieldName = "Item";
            this.treeListItem.Name = "treeListItem";
            this.treeListItem.OptionsColumn.AllowEdit = false;
            this.treeListItem.OptionsColumn.AllowSort = false;
            this.treeListItem.OptionsColumn.ReadOnly = true;
            this.treeListItem.Visible = true;
            this.treeListItem.VisibleIndex = 1;
            this.treeListItem.Width = 221;
            // 
            // treeListValue
            // 
            this.treeListValue.Caption = "结果";
            this.treeListValue.FieldName = "DataValue";
            this.treeListValue.Format.FormatString = "f2";
            this.treeListValue.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListValue.Name = "treeListValue";
            this.treeListValue.OptionsColumn.AllowEdit = false;
            this.treeListValue.OptionsColumn.AllowSort = false;
            this.treeListValue.OptionsColumn.ReadOnly = true;
            this.treeListValue.Visible = true;
            this.treeListValue.VisibleIndex = 2;
            this.treeListValue.Width = 127;
            // 
            // FrmCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 334);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmCalculation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCalculation";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListItem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListValue;
    }
}