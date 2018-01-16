namespace DJKUI
{
    partial class FrmStart
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
            this.testBtn2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.testBtn2)).BeginInit();
            this.SuspendLayout();
            // 
            // testBtn2
            // 
            this.testBtn2.BackColor = System.Drawing.Color.Transparent;
            this.testBtn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.testBtn2.Location = new System.Drawing.Point(402, 322);
            this.testBtn2.Name = "testBtn2";
            this.testBtn2.Size = new System.Drawing.Size(218, 50);
            this.testBtn2.TabIndex = 2;
            this.testBtn2.TabStop = false;
            this.testBtn2.Click += new System.EventHandler(this.testBtn2_Click);
            // 
            // FrmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::DJKUI.Properties.Resources.start;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.testBtn2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmStart";
            this.Text = "FrmInfo";
            ((System.ComponentModel.ISupportInitialize)(this.testBtn2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox testBtn2;
    }
}