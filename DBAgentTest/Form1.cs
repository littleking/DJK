using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace DBAgentTest
{
    public partial class Form1 : Form
    {

        private string infoFile = System.Windows.Forms.Application.StartupPath + "/info.xml";
        private string matrixFile = System.Windows.Forms.Application.StartupPath + "/matrix.xml";
        private string risksFile = System.Windows.Forms.Application.StartupPath + "/risks.xml";
        private TestHelper th;
        public Form1()
        {
            InitializeComponent();
            th = new TestHelper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "test1113";
            string birthday = "2018-07-21";
            string location = "wh";
            string sex = "Male";
            string sql = string.Format("INSERT INTO patient VALUES (NULL, '{0}', '{1}', '{2}', '中国', NULL, NULL, NULL, NULL, NULL, 0, 0, 0, '{3}', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 0, 0, 0, 0, 10, 0, 0, 76, 88, 85, 91, 98, 64, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 1, 1, 1, 1, 1, 2, NULL, NULL, NULL);", name, birthday, location, sex);
            string clearSql = "Delete from patient";
            string dbpath = "C:\\Clasp32\\DATA\\data.db3";
            try
            {
                AgentDll.exec_sql(dbpath, clearSql);
                AgentDll.exec_sql(dbpath, sql);
                MessageBox.Show("数据插入成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("dbAgent数据插入失败" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog("dbAgent数据插入失败" + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder("Conmain.exe"), new StringBuilder(""), new StringBuilder(@"C:\clasp32\program"), 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("直接启动失败" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog("直接启动失败" + ex.ToString());
            }
        }

        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                AgentDll.launchEx(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agent启动失败" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog("Agent启动失败" + ex.ToString());
            }
        }

        private void killP()
        {
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processList)
            {
                if (process.ProcessName.ToUpper() == "CONMAIN")
                {
                    process.Kill(); //结束进程
                }
            }
        }

        private void ExportXML()
        {
            string dbpath = "C:\\Clasp32\\DATA\\data.db3";
            try
            {
                if (File.Exists(infoFile))
                {
                    File.Delete(infoFile);
                }
                if (File.Exists(matrixFile))
                {
                    File.Delete(matrixFile);
                }
                Thread.Sleep(200);
                AgentDll.dump_table(dbpath, "Info", infoFile);
                Thread.Sleep(200);
                AgentDll.dump_table(dbpath, "Conscida", matrixFile);
                Thread.Sleep(200);
                AgentDll.dump_table(dbpath, "Risks", risksFile);
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                string str = ex.ToString();
            }
        }

        public static void WriteLog(string readme)
        {
            try
            {
                string logPath = System.Windows.Forms.Application.StartupPath + "/log/";
                if (!Directory.Exists(logPath))
                    Directory.CreateDirectory(logPath);

                string filename = logPath + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                using (StreamWriter sw = new StreamWriter(filename, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + readme);
                    sw.Close();
                }
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                AgentDll.exit_target();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agent关闭进程失败" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog("Agent关闭进程失败" + ex.ToString());
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ExportXML();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AgentDll.btn_Continue();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                AgentDll.launchEx(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Agent启动失败" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog("Agent启动失败" + ex.ToString());
            }
        }

        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processList)
            {
                if (process.ProcessName.ToUpper() == "CONMAIN")
                {
                    IntPtr intptr = process.Handle;
                    ShowWindow(intptr, 1);
                }
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DoTest();
        }

        private void DoTest()
        {
            StartTool();
               
        }

        private void StartTool()
        {
            try
            {
                th.TestToStart();
                Thread.Sleep(2000);
                th.TestStart();
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            th.Emotion();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            th.Nutrition();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            th.Risk();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            th.ExportReport();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bool isCon = AgentDll.check_dev_con();
            if (isCon)
            {
                MessageBox.Show("设备已经连接");

            }
            else
            {
                MessageBox.Show("设备没有连接");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AgentDll.btn_tformcomport_close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bool rtn = false;
            StringBuilder buf = new StringBuilder(1024);
            AgentDll.btn_check_head_band(buf);
            string txt = buf.ToString();
            if (txt == "HEAD_OK")
            {
                rtn = true;
            }
            if (rtn)
            {
                MessageBox.Show("头部绑带正常");

            }
            else
            {
                MessageBox.Show("头部绑带不正常");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processList)
            {
                if (process.ProcessName.ToUpper() == "CONMAIN")
                {
                    IntPtr intptr = process.Handle;
                    ShowWindow(intptr, 0);
                }
            }
        }


    }
}
