namespace Admin
{
    partial class FrmMedicalData
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
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtItem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabInfo = new DevExpress.XtraTab.XtraTabPage();
            this.tabSource = new DevExpress.XtraTab.XtraTabPage();
            this.groupControlRight = new DevExpress.XtraEditors.GroupControl();
            this.listBoxControlRight = new DevExpress.XtraEditors.ListBoxControl();
            this.searchControlRight = new DevExpress.XtraEditors.SearchControl();
            this.groupControlOp = new DevExpress.XtraEditors.GroupControl();
            this.simpleBtnDown = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleBtnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.simpleBtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlLeft = new DevExpress.XtraEditors.GroupControl();
            this.listBoxControlLeft = new DevExpress.XtraEditors.ListBoxControl();
            this.searchControlLeft = new DevExpress.XtraEditors.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlRight)).BeginInit();
            this.groupControlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControlRight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOp)).BeginInit();
            this.groupControlOp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlLeft)).BeginInit();
            this.groupControlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControlLeft.Properties)).BeginInit();
            this.SuspendLayout();

            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(124, 54);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("宋体", 11F);
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Properties.NullValuePrompt = "请输入编号";
            this.txtCode.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtCode.Properties.ShowNullValuePromptWhenFocused = true;
            this.txtCode.Size = new System.Drawing.Size(167, 22);
            this.txtCode.TabIndex = 2;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(124, 93);
            this.txtItem.Name = "txtItem";
            this.txtItem.Properties.Appearance.Font = new System.Drawing.Font("宋体", 11F);
            this.txtItem.Properties.Appearance.Options.UseFont = true;
            this.txtItem.Properties.NullValuePrompt = "请输入描述";
            this.txtItem.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtItem.Properties.ShowNullValuePromptWhenFocused = true;
            this.txtItem.Size = new System.Drawing.Size(167, 22);
            this.txtItem.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 11F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(39, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 15);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "编  号：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 11F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(39, 97);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 15);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "描  述：";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabInfo;
            this.xtraTabControl1.Size = new System.Drawing.Size(419, 368);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabInfo,
            this.tabSource});
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.labelControl2);
            this.tabInfo.Controls.Add(this.txtCode);
            this.tabInfo.Controls.Add(this.txtItem);
            this.tabInfo.Controls.Add(this.labelControl1);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Size = new System.Drawing.Size(413, 339);
            this.tabInfo.Text = "基本信息";
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.groupControlRight);
            this.tabSource.Controls.Add(this.groupControlOp);
            this.tabSource.Controls.Add(this.groupControlLeft);
            this.tabSource.Name = "tabSource";
            this.tabSource.Size = new System.Drawing.Size(1014, 319);
            this.tabSource.Text = "数据源";
            // 
            // groupControlRight
            // 
            this.groupControlRight.Controls.Add(this.listBoxControlRight);
            this.groupControlRight.Controls.Add(this.searchControlRight);
            this.groupControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControlRight.Location = new System.Drawing.Point(844, 0);
            this.groupControlRight.Name = "groupControlRight";
            this.groupControlRight.Size = new System.Drawing.Size(170, 319);
            this.groupControlRight.TabIndex = 2;
            this.groupControlRight.Text = "数据源";
            // 
            // listBoxControlRight
            // 
            this.listBoxControlRight.AllowDrop = true;
            this.listBoxControlRight.Cursor = System.Windows.Forms.Cursors.Default;
            this.listBoxControlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControlRight.Location = new System.Drawing.Point(2, 41);
            this.listBoxControlRight.Name = "listBoxControlRight";
            this.listBoxControlRight.Size = new System.Drawing.Size(166, 276);
            this.listBoxControlRight.TabIndex = 2;
            this.listBoxControlRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxControlRight_DragDrop);
            this.listBoxControlRight.DragOver += new System.Windows.Forms.DragEventHandler(this.listBoxControlRight_DragOver);
            // 
            // searchControlRight
            // 
            this.searchControlRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControlRight.Location = new System.Drawing.Point(2, 21);
            this.searchControlRight.Name = "searchControlRight";
            this.searchControlRight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControlRight.Size = new System.Drawing.Size(166, 20);
            this.searchControlRight.TabIndex = 0;
            // 
            // groupControlOp
            // 
            this.groupControlOp.Controls.Add(this.simpleBtnDown);
            this.groupControlOp.Controls.Add(this.simpleButton2);
            this.groupControlOp.Controls.Add(this.simpleBtnRemove);
            this.groupControlOp.Controls.Add(this.simpleBtnAdd);
            this.groupControlOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlOp.Location = new System.Drawing.Point(170, 0);
            this.groupControlOp.Name = "groupControlOp";
            this.groupControlOp.Size = new System.Drawing.Size(844, 319);
            this.groupControlOp.TabIndex = 1;
            this.groupControlOp.Text = "操作";
            // 
            // simpleBtnDown
            // 
            this.simpleBtnDown.Location = new System.Drawing.Point(17, 197);
            this.simpleBtnDown.Name = "simpleBtnDown";
            this.simpleBtnDown.Size = new System.Drawing.Size(40, 23);
            this.simpleBtnDown.TabIndex = 3;
            this.simpleBtnDown.Text = "下移";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(17, 145);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(40, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "上移";
            // 
            // simpleBtnRemove
            // 
            this.simpleBtnRemove.Location = new System.Drawing.Point(17, 93);
            this.simpleBtnRemove.Name = "simpleBtnRemove";
            this.simpleBtnRemove.Size = new System.Drawing.Size(40, 23);
            this.simpleBtnRemove.TabIndex = 1;
            this.simpleBtnRemove.Text = "删除";
            // 
            // simpleBtnAdd
            // 
            this.simpleBtnAdd.Location = new System.Drawing.Point(17, 41);
            this.simpleBtnAdd.Name = "simpleBtnAdd";
            this.simpleBtnAdd.Size = new System.Drawing.Size(40, 23);
            this.simpleBtnAdd.TabIndex = 0;
            this.simpleBtnAdd.Text = "添加";
            // 
            // groupControlLeft
            // 
            this.groupControlLeft.Controls.Add(this.listBoxControlLeft);
            this.groupControlLeft.Controls.Add(this.searchControlLeft);
            this.groupControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControlLeft.Location = new System.Drawing.Point(0, 0);
            this.groupControlLeft.Name = "groupControlLeft";
            this.groupControlLeft.Size = new System.Drawing.Size(170, 319);
            this.groupControlLeft.TabIndex = 0;
            this.groupControlLeft.Text = "原始数据";
            // 
            // listBoxControlLeft
            // 
            this.listBoxControlLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.listBoxControlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControlLeft.Location = new System.Drawing.Point(2, 41);
            this.listBoxControlLeft.Name = "listBoxControlLeft";
            this.listBoxControlLeft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxControlLeft.Size = new System.Drawing.Size(166, 276);
            this.listBoxControlLeft.TabIndex = 1;
            this.listBoxControlLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxControlLeft_MouseDown);
            this.listBoxControlLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxControlLeft_MouseMove);
            // 
            // searchControlLeft
            // 
            this.searchControlLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControlLeft.Location = new System.Drawing.Point(2, 21);
            this.searchControlLeft.Name = "searchControlLeft";
            this.searchControlLeft.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControlLeft.Size = new System.Drawing.Size(166, 20);
            this.searchControlLeft.TabIndex = 0;
            // 
            // FrmMedicalData
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 407);
            this.Name = "FrmMedicalData";
            this.Text = "FrmMedicalData";

            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabInfo.PerformLayout();
            this.tabSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlRight)).EndInit();
            this.groupControlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControlRight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOp)).EndInit();
            this.groupControlOp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlLeft)).EndInit();
            this.groupControlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControlLeft.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtItem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabInfo;
        private DevExpress.XtraTab.XtraTabPage tabSource;
        private DevExpress.XtraEditors.GroupControl groupControlRight;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlRight;
        private DevExpress.XtraEditors.SearchControl searchControlRight;
        private DevExpress.XtraEditors.GroupControl groupControlOp;
        private DevExpress.XtraEditors.SimpleButton simpleBtnDown;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleBtnRemove;
        private DevExpress.XtraEditors.SimpleButton simpleBtnAdd;
        private DevExpress.XtraEditors.GroupControl groupControlLeft;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlLeft;
        private DevExpress.XtraEditors.SearchControl searchControlLeft;
    }
}