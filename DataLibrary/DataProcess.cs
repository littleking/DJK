using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataLibrary
{
    public class DataProcess
    {
        private string reportFile;
        private string sourceFile;
        private string testFile;
        private string tempFile;
        public DataProcess(string reportFile,string sourceFile,string testFile,string tempFile)
        {
            this.reportFile = reportFile;
            this.sourceFile = sourceFile;
            this.testFile = testFile;
            this.tempFile = tempFile;
        }



        public bool CreateReport()
        {
            bool rtn = false;
            try
            {
                if (File.Exists(sourceFile))
                {
                    File.Delete(sourceFile);
                }
                File.Copy(testFile, sourceFile);
                if (File.Exists(reportFile))
                {
                    File.Delete(reportFile);
                }
                File.Copy(tempFile, reportFile);
                Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                excel.Visible = false;
                excel.Workbooks.Open(reportFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                IntPtr t = new IntPtr(excel.Hwnd);
                int k = 0;
                GetWindowThreadProcessId(t, out k);
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                p.Kill();
                rtn = true;
                File.Delete(sourceFile);
            }
            catch (Exception ex)
            {
                File.Delete(sourceFile);
                //WriteLog(sourceFileName + "-Excel权限问题或没有安装，数据没有上传!");
                //MessageBox.Show("Excel问题导致上传失败,请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }

            return rtn;
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

    }
}
