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
using System.Diagnostics;
using System.Configuration;

namespace Paricom
{
    public partial class FrmDoTest : FrmBase
    {
        private TestHelper th;
        public FrmDoTest()
        {
            InitializeComponent();
            th = new TestHelper();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 5 * 60 * 1000 / 100;

        }

        private void DeleteSource()
        {
            string testFile = ConfigurationManager.AppSettings["sourceAddress"];
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Visible = true;
            this.pictureBox1.Enabled = false;
            PlayVideo();
            DeleteSource();
            StartProgress();
            Task.Factory.StartNew(() =>
            {
                StartTool();
                GetReport();
                this.progressBarTest.Position = 100;
                this.progressBarTest.PerformStep();

            }).ContinueWith(x =>
            {
                this.pictureBox1.Enabled = true;
                this.Invoke((MethodInvoker)(() =>
                {
                    this.progressBarTest.Visible = false;
                    this.progressBarTest.Position = 0;
                    timer1.Stop();
                    FrmMain.Instance.XtraTabOpen("FrmTestFinish", "信息");
                }));
            });
        }

        private void StartProgress()
        {
            this.progressBarTest.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressBarTest.Position = 0;
            this.progressBarTest.Properties.Minimum = 0;
            this.progressBarTest.Properties.Maximum = 100;
            this.progressBarTest.Properties.Step = 1;
            this.progressBarTest.Visible = true;
            timer1.Enabled = true;
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBarTest.Position!=100)
            {
                progressBarTest.PerformStep();
            }
            else
            {
                timer1.Stop();
            }
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
                
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show(ex.ToString(), "错误");
            }
        }

        private void GetReport()
        {
            string reportFile = System.Windows.Forms.Application.StartupPath + "/report.xlsm";
            string sourceFile = System.Windows.Forms.Application.StartupPath + "/clarity.xls";
            string dataFile = System.Windows.Forms.Application.StartupPath + "/data.xml";
            string testFile = ConfigurationManager.AppSettings["sourceAddress"];
            FileInfo fileInfo = new FileInfo(testFile);
            SysVar.dtNow = DateTime.Parse(fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
            //有最新文件，开始上传数据
            if (DateTime.Compare(SysVar.dtNow, SysVar.dtOld) > 0)
            {
                SysVar.dtOld = SysVar.dtNow;
                DataProcess dp = new DataProcess(reportFile, sourceFile, testFile, dataFile);
                dp.uploadInfo();
            }
            else
            {
                XtraMessageBox.Show("测试数据没有生成，请重新测试，如果还是不成功请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        



    }
}
