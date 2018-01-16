namespace UI
{
    partial class FrmMain
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
            this.panel_content = new System.Windows.Forms.Panel();
            this.tab_con = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panel_content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tab_con)).BeginInit();
            this.tab_con.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_content
            // 
            this.panel_content.Controls.Add(this.tab_con);
            this.panel_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_content.Location = new System.Drawing.Point(0, 0);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(1024, 768);
            this.panel_content.TabIndex = 0;
            // 
            // tab_con
            // 
            this.tab_con.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_con.Location = new System.Drawing.Point(0, 0);
            this.tab_con.Name = "tab_con";
            this.tab_con.SelectedTabPage = this.xtraTabPage1;
            this.tab_con.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tab_con.Size = new System.Drawing.Size(1024, 768);
            this.tab_con.TabIndex = 0;
            this.tab_con.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1018, 762);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1018, 762);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panel_content);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.panel_content.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tab_con)).EndInit();
            this.tab_con.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_content;
        public DevExpress.XtraTab.XtraTabControl tab_con;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
    }
}