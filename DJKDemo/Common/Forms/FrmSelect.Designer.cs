namespace DJKUI
{
    partial class FrmSelect
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
            this.testBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.testBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // testBtn
            // 
            this.testBtn.BackColor = System.Drawing.Color.Transparent;
            this.testBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.testBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.testBtn.Location = new System.Drawing.Point(878, 641);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(116, 106);
            this.testBtn.TabIndex = 1;
            this.testBtn.TabStop = false;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click_1);
            // 
            // FrmSelect
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.None;
            this.BackgroundImageStore = global::DJKUI.Properties.Resources.select1;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.testBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmSelect";
            this.Text = "检测项目";
            ((System.ComponentModel.ISupportInitialize)(this.testBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox testBtn;
    }
}

