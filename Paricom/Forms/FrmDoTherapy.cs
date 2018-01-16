using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paricom
{
    public partial class FrmDoTherapy : FrmBase
    {
        public FrmDoTherapy()
        {
            InitializeComponent();
            
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Visible = true;
            this.pictureBox1.Enabled = false;
            PlayVideo();
            Task.Factory.StartNew(() =>
            {
                StartTool();

            }).ContinueWith(x =>
            {
                this.pictureBox1.Enabled = true;
                this.Invoke((MethodInvoker)(() =>
                {
                    FrmMain.Instance.XtraTabOpen("FrmTherapyFinish", "信息");
                }));
            });
        }

        private void PlayVideo()
        {
            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"/media2.avi";
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Ctlcontrols.play();
            
        }

        private void StartTool()
        {
            try
            {
                Thread.Sleep(60*1000);
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }
    }
}
