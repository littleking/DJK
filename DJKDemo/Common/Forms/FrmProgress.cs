using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DJKUI
{
    public partial class FrmProgress : DevExpress.XtraEditors.XtraForm
    {
        public FrmProgress()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"/nodynoeh.m1v";
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }


        private void FrmProgress_Shown(object sender, EventArgs e)
        {
            //Action waitA = () => WaitProgress();
            //Thread.Sleep(30000);
            //FrmMain.Instance.XtraTabOpen("FrmFinish", "信息");
        }

        private void WaitProgress()
        {
            Thread.Sleep(30000);
            FrmMain.Instance.Invoke((Action)(() => FrmMain.Instance.XtraTabOpen("FrmFinish", "信息")));
            //FrmMain.Instance.XtraTabOpen("FrmFinish", "信息");
        }


        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                //FrmMain.Instance.XtraTabOpen("FrmFinish", "信息");
            }
        }
    }
}
