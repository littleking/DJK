using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JKTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            killP();
            Thread.Sleep(200);
            string name = "test1113";
            string birthday = "2018-07-20";
            string location = "wh";
            string sex = "男";
            string sql = string.Format("INSERT INTO patient VALUES (NULL, '{0}', '{1}', '{2}', '中国', NULL, NULL, NULL, NULL, NULL, 0, 0, 0, '{3}', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 0, 0, 0, 0, 10, 0, 0, 76, 88, 85, 91, 98, 64, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 1, 1, 1, 1, 1, 2, NULL, NULL, NULL);", name, birthday, location, sex);
            string clearSql = "Delete from patient";
            string dbpath = "C:\\Clasp32\\DATA\\data.db3";
            try
            {
                AgentDll.exec_sql(dbpath, clearSql);
                WriteLog("清除成功");
                Thread.Sleep(100);
                AgentDll.exec_sql(dbpath, sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("dbAgent数据插入失败" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog("dbAgent数据插入失败"+ex.ToString());
                return;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder("Conmain.exe"), new StringBuilder(""), new StringBuilder(@"C:\clasp32\program"), 1);
            }
            catch(Exception ex)
            {
                MessageBox.Show("直接启动失败" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog("直接启动失败" + ex.ToString());
            }
        }

        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                AgentDll.launchEx(false);
            }catch(Exception ex)
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
    }
}
