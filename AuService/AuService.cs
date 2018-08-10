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
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AuService
{
    public partial class AuService : ServiceBase
    {

        private static string encryptKey = "%dn*";
        public AuService()
        {
            InitializeComponent();
            #region 定时器事件  
            System.Timers.Timer aTimer = new System.Timers.Timer();       //System.Timers，不是form的  
            aTimer.Elapsed += new ElapsedEventHandler(TimedEvent);
            aTimer.Interval = 10 * 1000 * 1;    //配置文件中配置的秒数  
            aTimer.Enabled = true;

            #endregion
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }

        private static void TimedEvent(object source, ElapsedEventArgs e)         //运行期间执行  
        {
            checkProcess();
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
                        WriteLog("程序授权已过期。");
                        //MessageBox.Show("程序授权已过期或出现错误！请联系管理员更新授权文件。");
                        Interop.ShowMessageBox("程序授权已过期或出现错误！请联系管理员更新授权文件。", "授权过期");
                    }
                }
            }
        }

        private static bool checkOurProcess()
        {
            string keyPath = System.Windows.Forms.Application.StartupPath + "/key.v";
            if (File.Exists(keyPath))
            {
                using (FileStream filestream = new FileStream(keyPath, FileMode.Open))
                {
                    byte[] bt = new byte[filestream.Length];
                    filestream.Read(bt, 0, bt.Length);
                    string kData = System.Text.Encoding.Unicode.GetString(bt);
                    string keyData = Decrypt(kData);
                    string key = keyData.Substring(30, 10);
                    DateTime dt = DateTime.Now;
                    try
                    {
                        dt = DateTime.Parse(key);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    DateTime tDate = DateTime.Now;
                    if (tDate > dt)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        private static void WriteLog(string readme)
        {
            try
            {
                string logPath = System.Windows.Forms.Application.StartupPath + "/Log/";
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
        /// <summary>  
        /// 解密字符串   
        /// </summary>  
        /// <param name="str">要解密的字符串</param>  
        /// <returns>解密后的字符串</returns>  
        private static string Decrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象    

            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

            byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串  

            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

            //使用内存流实例化解密流对象       
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);

            CStream.Write(data, 0, data.Length);      //向解密流中写入数据     

            CStream.FlushFinalBlock();               //释放解密流      

            return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串  
        }

        private static string Encrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   

            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    

            byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串  

            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      

            //使用内存流实例化加密流对象   
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);

            CStream.Write(data, 0, data.Length);  //向加密流中写入数据      

            CStream.FlushFinalBlock();              //释放加密流      

            return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串  
        }
    }
}

