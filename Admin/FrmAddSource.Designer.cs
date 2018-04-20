namespace Admin
{
    partial class FrmAddSource
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.comboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtNum = new DevExpress.XtraEditors.TextEdit();
            this.txtMin = new DevExpress.XtraEditors.TextEdit();
            this.txtMax = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlLock)).BeginInit();
            this.groupControlLock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMax.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlLock
            // 
            this.groupControlLock.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControlLock.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.groupControlLock.Appearance.Options.UseBackColor = true;
            this.groupControlLock.Appearance.Options.UseForeColor = true;
            this.groupControlLock.Controls.Add(this.txtMax);
            this.groupControlLock.Controls.Add(this.txtMin);
            this.groupControlLock.Controls.Add(this.txtNum);
            this.groupControlLock.Controls.Add(this.comboType);
            this.groupControlLock.Controls.Add(this.labelControl4);
            this.groupControlLock.Controls.Add(this.labelControl3);
            this.groupControlLock.Controls.Add(this.labelControl2);
            this.groupControlLock.Controls.Add(this.labelControl1);
            this.groupControlLock.Location = new System.Drawing.Point(0, 39);
            this.groupControlLock.Size = new System.Drawing.Size(287, 252);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(32, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "数据类型：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(32, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "数据编号：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(32, 125);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "最小值：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(32, 169);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(56, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "最大值：";
            // 
            // comboType
            // 
            this.comboType.Location = new System.Drawing.Point(120, 46);
            this.comboType.Name = "comboType";
            this.comboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboType.Properties.DropDownRows = 2;
            this.comboType.Properties.Items.AddRange(new object[] {
            "info",
            "matrix"});
            this.comboType.Size = new System.Drawing.Size(100, 20);
            this.comboType.TabIndex = 4;
            this.comboType.SelectedValueChanged += new System.EventHandler(this.comboType_SelectedValueChanged);
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(120, 88);
            this.txtNum.Name = "txtNum";
            this.txtNum.Properties.Mask.EditMask = "d";
            this.txtNum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNum.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtNum.Size = new System.Drawing.Size(100, 20);
            this.txtNum.TabIndex = 5;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(120, 125);
            this.txtMin.Name = "txtMin";
            this.txtMin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMin.Properties.Mask.EditMask = "d";
            this.txtMin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMin.Size = new System.Drawing.Size(100, 20);
            this.txtMin.TabIndex = 6;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(120, 162);
            this.txtMax.Name = "txtMax";
            this.txtMax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMax.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMax.Properties.Mask.EditMask = "d";
            this.txtMax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMax.Size = new System.Drawing.Size(100, 20);
            this.txtMax.TabIndex = 7;
            // 
            // FrmAddSource
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 291);
            this.Name = "FrmAddSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddSource";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAddSource_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlLock)).EndInit();
            this.groupControlLock.ResumeLayout(false);
            this.groupControlLock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMax.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMax;
        private DevExpress.XtraEditors.TextEdit txtMin;
        private DevExpress.XtraEditors.TextEdit txtNum;
        private DevExpress.XtraEditors.ComboBoxEdit comboType;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}