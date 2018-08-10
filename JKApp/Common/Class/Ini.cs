using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace JKApp
{
    /// <summary>
    /// 配置INI
    /// </summary>
    public class Ini
    {
        public Ini()
        {
        }
        //声明读写INI文件的API函数 
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        public static string IniReadValue(string Section, string Key)
        {
            StringBuilder sb = new StringBuilder(255);
            /*返回值1为成功,0为失败,如果失败返回0默认为简体中文*/
            int i = GetPrivateProfileString(Section, Key, "", sb, 255, System.AppDomain.CurrentDomain.BaseDirectory + @"Version.ini");
            return sb.ToString();

        }

        public static void IniWriteValue(string Section, string Key, string values)
        {
            WritePrivateProfileString(Section, Key, values, System.AppDomain.CurrentDomain.BaseDirectory + @"Version.ini");
        }
    }
}
