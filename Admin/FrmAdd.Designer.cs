namespace Admin
{
    partial class FrmAdd
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtItem = new DevExpress.XtraEditors.TextEdit();
            this.txtMin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMax = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpFormula = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlLock)).BeginInit();
            this.groupControlLock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpFormula.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlLock
            // 
            this.groupControlLock.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControlLock.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.groupControlLock.Appearance.Options.UseBackColor = true;
            this.groupControlLock.Appearance.Options.UseForeColor = true;
            this.groupControlLock.Controls.Add(this.lookUpFormula);
            this.groupControlLock.Controls.Add(this.labelControl5);
            this.groupControlLock.Controls.Add(this.txtMax);
            this.groupControlLock.Controls.Add(this.labelControl4);
            this.groupControlLock.Controls.Add(this.txtMin);
            this.groupControlLock.Controls.Add(this.labelControl3);
            this.groupControlLock.Controls.Add(this.txtItem);
            this.groupControlLock.Controls.Add(this.txtCode);
            this.groupControlLock.Controls.Add(this.labelControl2);
            this.groupControlLock.Controls.Add(this.labelControl1);
            this.groupControlLock.Location = new System.Drawing.Point(0, 39);
            this.groupControlLock.Size = new System.Drawing.Size(379, 299);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(46, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "编码：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(46, 108);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "项目：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(119, 55);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Size = new System.Drawing.Size(208, 22);
            this.txtCode.TabIndex = 2;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(119, 103);
            this.txtItem.Name = "txtItem";
            this.txtItem.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.txtItem.Properties.Appearance.Options.UseFont = true;
            this.txtItem.Size = new System.Drawing.Size(208, 22);
            this.txtItem.TabIndex = 3;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(119, 150);
            this.txtMin.Name = "txtMin";
            this.txtMin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtMin.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.txtMin.Properties.Appearance.Options.UseFont = true;
            this.txtMin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMin.Properties.Mask.EditMask = "d";
            this.txtMin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMin.Size = new System.Drawing.Size(208, 22);
            this.txtMin.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(46, 155);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "最小值：";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(119, 199);
            this.txtMax.Name = "txtMax";
            this.txtMax.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtMax.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.txtMax.Properties.Appearance.Options.UseFont = true;
            this.txtMax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMax.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMax.Properties.Mask.EditMask = "d";
            this.txtMax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMax.Size = new System.Drawing.Size(208, 22);
            this.txtMax.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(46, 204);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 16);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "最大值：";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 12F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(46, 249);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(80, 16);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "计算方式：";
            // 
            // lookUpFormula
            // 
            this.lookUpFormula.Location = new System.Drawing.Point(119, 249);
            this.lookUpFormula.Name = "lookUpFormula";
            this.lookUpFormula.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpFormula.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpFormula.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormulaDescription", "计算方式")});
            this.lookUpFormula.Properties.NullText = "";
            this.lookUpFormula.Properties.PopupFormMinSize = new System.Drawing.Size(30, 0);
            this.lookUpFormula.Size = new System.Drawing.Size(208, 20);
            this.lookUpFormula.TabIndex = 9;
            // 
            // FrmAdd
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 338);
            this.Name = "FrmAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAdd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAdd_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlLock)).EndInit();
            this.groupControlLock.ResumeLayout(false);
            this.groupControlLock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpFormula.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtItem;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpFormula;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtMax;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtMin;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}