namespace CloudOperator
{
    partial class FrmSetting
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
            this.txtIP = new DevExpress.XtraEditors.TextEdit();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.txtLocalPort = new DevExpress.XtraEditors.TextEdit();
            this.txtLocalIP = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtDevicePort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDevicePort.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(38, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "远程IP:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(38, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "远程端口:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(94, 36);
            this.txtIP.Name = "txtIP";
            this.txtIP.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtIP.Size = new System.Drawing.Size(111, 20);
            this.txtIP.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(94, 85);
            this.txtPort.Name = "txtPort";
            this.txtPort.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtPort.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPort.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPort.Size = new System.Drawing.Size(111, 20);
            this.txtPort.TabIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(38, 279);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "取消";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(144, 279);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "保存";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(94, 182);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtLocalPort.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtLocalPort.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtLocalPort.Size = new System.Drawing.Size(111, 20);
            this.txtLocalPort.TabIndex = 9;
            // 
            // txtLocalIP
            // 
            this.txtLocalIP.Location = new System.Drawing.Point(94, 133);
            this.txtLocalIP.Name = "txtLocalIP";
            this.txtLocalIP.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtLocalIP.Size = new System.Drawing.Size(111, 20);
            this.txtLocalIP.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(38, 185);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "本地端口:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(38, 133);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "本地IP：";
            // 
            // txtDevicePort
            // 
            this.txtDevicePort.Location = new System.Drawing.Point(94, 229);
            this.txtDevicePort.Name = "txtDevicePort";
            this.txtDevicePort.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtDevicePort.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDevicePort.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDevicePort.Size = new System.Drawing.Size(111, 20);
            this.txtDevicePort.TabIndex = 11;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(38, 232);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 14);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "设备端口:";
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 314);
            this.Controls.Add(this.txtDevicePort);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtLocalPort);
            this.Controls.Add(this.txtLocalIP);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetting";
            this.Text = "设置";
            ((System.ComponentModel.ISupportInitialize)(this.txtIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocalIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDevicePort.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtIP;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit txtLocalPort;
        private DevExpress.XtraEditors.TextEdit txtLocalIP;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtDevicePort;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}