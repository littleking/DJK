namespace UI
{
    partial class FrmTest
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
            this.testBtn2 = new System.Windows.Forms.PictureBox();
            this.testBtn3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.testBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testBtn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testBtn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // testBtn
            // 
            this.testBtn.BackColor = System.Drawing.Color.Transparent;
            this.testBtn.Location = new System.Drawing.Point(443, 402);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(141, 50);
            this.testBtn.TabIndex = 0;
            this.testBtn.TabStop = false;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click);
            // 
            // testBtn2
            // 
            this.testBtn2.BackColor = System.Drawing.Color.Transparent;
            this.testBtn2.Location = new System.Drawing.Point(430, 160);
            this.testBtn2.Name = "testBtn2";
            this.testBtn2.Size = new System.Drawing.Size(141, 50);
            this.testBtn2.TabIndex = 1;
            this.testBtn2.TabStop = false;
            this.testBtn2.Click += new System.EventHandler(this.testBtn2_Click);
            // 
            // testBtn3
            // 
            this.testBtn3.BackColor = System.Drawing.Color.Transparent;
            this.testBtn3.Location = new System.Drawing.Point(507, 646);
            this.testBtn3.Name = "testBtn3";
            this.testBtn3.Size = new System.Drawing.Size(141, 50);
            this.testBtn3.TabIndex = 2;
            this.testBtn3.TabStop = false;
            this.testBtn3.Click += new System.EventHandler(this.testBtn3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(705, 646);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 50);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(483, 321);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 50);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::UI.Properties.Resources.main;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.testBtn3);
            this.Controls.Add(this.testBtn2);
            this.Controls.Add(this.testBtn);
            this.MaximizeBox = false;
            this.Name = "FrmTest";
            this.Text = "测量";
            ((System.ComponentModel.ISupportInitialize)(this.testBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testBtn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testBtn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox testBtn;
        private System.Windows.Forms.PictureBox testBtn2;
        private System.Windows.Forms.PictureBox testBtn3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

