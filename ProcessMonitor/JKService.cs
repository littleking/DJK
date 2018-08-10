using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProcessMonitor
{
    public partial class JKService : ServiceBase
    {
        public JKService()
        {
            InitializeComponent();
            #region 定时器事件  
            Timer aTimer = new Timer();       //System.Timers，不是form的  
            aTimer.Elapsed += new ElapsedEventHandler(TimedEvent);
            aTimer.Interval = 10 * 1000 * 1;    //配置文件中配置的秒数  
            aTimer.Enabled = true;

            #endregion
        }

        protected override void OnStart(string[] args)
        {
            WriteLog("服务启动。");

        }

        protected override void OnStop()
        {
            WriteLog("服务关闭。");
        }

        private static void TimedEvent(object source, ElapsedEventArgs e)         //运行期间执行  
        {
            checkProcess();
        }

        private static void WriteLog(string readme)
        {
            try
            {
                string logPath = System.Windows.Forms.Application.StartupPath + "/Servicelog/";
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

        private static void checkProcess()
        {
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processList)
            {
                if (process.ProcessName.ToUpper() == "CONMAIN")
                {
                    if (!checkOurProcess())
                    {
                        process.Kill(); //结束进程
                        WriteLog("结束非法服务进程。");
                    }
                }
            }
        }

        private static bool checkOurProcess()
        {
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processList)
            {
                if (process.ProcessName.ToUpper() == "JKJC")
                {
                    return true;
                }
            }
            return false;
        }


    }
}
