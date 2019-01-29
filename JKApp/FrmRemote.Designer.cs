namespace JKApp
{
    partial class FrmRemote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRemote));
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.txtLabel = new DevExpress.XtraEditors.LabelControl();
            this.btnFinish = new DevExpress.XtraEditors.SimpleButton();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Appearance.Font = new System.Drawing.Font("Tahoma", 25F);
            this.btnTest.Appearance.Options.UseFont = true;
            this.btnTest.Location = new System.Drawing.Point(364, 153);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(156, 83);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "检测";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(856, 12);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(65, 24);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "关闭";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txtLabel
            // 
            this.txtLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.txtLabel.Appearance.Options.UseFont = true;
            this.txtLabel.Location = new System.Drawing.Point(200, 329);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(532, 33);
            this.txtLabel.TabIndex = 4;
            this.txtLabel.Text = "开始前请先连接设备，并确保绑带已经绑好";
            // 
            // btnFinish
            // 
            this.btnFinish.Appearance.Font = new System.Drawing.Font("Tahoma", 25F);
            this.btnFinish.Appearance.Options.UseFont = true;
            this.btnFinish.Location = new System.Drawing.Point(364, 153);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(156, 83);
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Text = "结束";
            this.btnFinish.Visible = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(856, 42);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(65, 24);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "返回";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmRemote
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(112)))), ((int)(((byte)(48)))));
            this.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 525);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnFinish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRemote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRemote";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmRemote_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnTest;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl txtLabel;
        private DevExpress.XtraEditors.SimpleButton btnFinish;
        private DevExpress.XtraEditors.SimpleButton btnBack;
    }
}