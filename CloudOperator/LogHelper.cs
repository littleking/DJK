using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CloudOperator
{
    public class LogHelper
    {
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
    }
}
