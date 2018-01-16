using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLibrary;
using System.Diagnostics;

namespace Paricom
{
    public partial class FrmDoTest : FrmBase
    {
        private TestHelper th;
        public FrmDoTest()
        {
            InitializeComponent();
            th = new TestHelper();
            
        }

        private void DeleteSource()
        {
            if (File.Exists(SysVar.TestFile))
            {
                File.Delete(SysVar.TestFile);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Visible = true;
            this.pictureBox1.Enabled = false;
            PlayVideo();
            DeleteSource();
            Task.Factory.StartNew(() =>
            {
                StartTool();

            }).ContinueWith(x =>
            {
                this.pictureBox1.Enabled = true;
                this.Invoke((MethodInvoker)(() =>
                {
                    FrmMain.Instance.XtraTabOpen("FrmTestFinish", "信息");
                }));
            });
        }

        private void PlayVideo()
        {
            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"/media1.avi";
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Ctlcontrols.play();
            
        }

        private void StartTool()
        {
            try
            {
                th.TestStart();
                //GetReport();
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }

        private bool GetReport()
        {
            string reportFile = System.Windows.Forms.Application.StartupPath + "/report.xlsm";
            string tempFile = System.Windows.Forms.Application.StartupPath + "/temp/report.xlsm";
            string sourceFile = System.Windows.Forms.Application.StartupPath + "/clarity.xls";
            FileInfo fileInfo = new FileInfo(SysVar.TestFile);
            SysVar.dtNow = DateTime.Parse(fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
            runBat();
            //有最新文件，开始上传数据
            if (DateTime.Compare(SysVar.dtNow, SysVar.dtOld) > 0)
            {
                SysVar.dtOld = SysVar.dtNow;
                DataProcess dp = new DataProcess(reportFile, sourceFile, SysVar.TestFile, tempFile);
                return dp.CreateReport();
            }
            return false;
        }

        private void runBat()
        {
            Process proc = null;
            try
            {
                string targetDir = Application.StartupPath;
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = "run.bat";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }



    }
}
