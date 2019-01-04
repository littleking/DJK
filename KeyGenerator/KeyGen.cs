using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyGenerator
{
    public partial class KeyGen : Form
    {

        private static string encryptKey = "%dn*";
        //private static string preKey = "dfgfdgergdfgcfaaasdfdswesddsdd";
        //private static string postKey = "cvfdgvbvbvbdfe3433fdfw@df";

        //private static string encryptKey = "%ghe";
        private static string preKey = "dfgfdgergdfgcfaaasdfdswesddsdd";
        private static string postKey = "cvfdgvbvbvbdfe3433fdfw@df";

        public KeyGen()
        {
            InitializeComponent();
            this.dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempPath = ShowSaveFileDialog();
            if (tempPath.Length > 0)
            {
                try
                {
                    string expiredDate = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    string alldata = preKey + expiredDate + postKey;
                    string encryptedDate = Encrypt(alldata);
                    //string path = SelectPath();
                    //string tempPath = path + "\\" + "v.key";

                    FileStream fs = new FileStream(tempPath, FileMode.Create);
                    byte[] data = System.Text.Encoding.Unicode.GetBytes(encryptedDate);
                    //开始写入  
                    fs.Write(data, 0, data.Length);
                    //清空缓冲区、关闭流  
                    fs.Flush();
                    fs.Close();
                    MessageBox.Show("key文件生成成功!");
                }catch(Exception ex)
                {
                    MessageBox.Show("key生成失败!" + ex.ToString());
                    
                }
            }
        }

        private string SelectPath()
        {
            string path = string.Empty;
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.Description = "请选择保存目录";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            return path;
        }

        private string ShowSaveFileDialog()
        {
            string localFilePath = "";
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            // sfd.Filter = "Excel表格（*.xls）|*.xls";
            sfd.FileName = "key.v";
            //设置默认文件类型显示顺序 
            //sfd.FilterIndex = 1;
            sfd.OverwritePrompt = true;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;
            sfd.Title = "保存文件"; 

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                //获取文件路径，不带文件名 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 

                //给文件名前加上时间 
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt; 

                //在文件名里加字符 
                //saveFileDialog1.FileName.Insert(1,"dameng"); 

                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件 

                ////fs输出带文字或图片的文件，就看需求了 
            }

            return localFilePath;
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

        private void button2_Click(object sender, EventArgs e)
        {
            string keyPath = System.Windows.Forms.Application.StartupPath + "/v.key";
            if (File.Exists(keyPath))
            {
                FileStream filestream = new FileStream(keyPath, FileMode.Open);
                byte[] bt = new byte[filestream.Length];
                filestream.Read(bt, 0, bt.Length);
                string kData  = System.Text.Encoding.Unicode.GetString(bt);
                string keyData = Decrypt(kData);
                string key = keyData.Substring(30, 10);
                string haha = "";
            }
        }

        static string Decrypt(string str)
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
    }
}
