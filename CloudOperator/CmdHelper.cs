using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CloudOperator
{
    public class CmdHelper
    {
        private static string CmdPath = @"C:\Windows\System32\cmd.exe";

        /// <summary>
        /// 执行cmd命令
        /// 多命令请使用批处理命令连接符：
        /// <![CDATA[
        /// &:同时执行两个命令
        /// |:将上一个命令的输出,作为下一个命令的输入
        /// &&：当&&前的命令成功时,才执行&&后的命令
        /// ||：当||前的命令失败时,才执行||后的命令]]>
        /// 其他请百度
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="output"></param>
        public static void RunCmd(string cmd, out string output)
        {
            try
            {
                cmd = cmd.Trim().TrimEnd('&') + "&exit";//说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
                using (Process p = new Process())
                {
                    p.StartInfo.FileName = CmdPath;
                    p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动
                    p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
                    p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
                    p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
                    p.StartInfo.CreateNoWindow = true;          //不显示程序窗口
                    p.Start();//启动程序

                    //向cmd窗口写入命令
                    p.StandardInput.WriteLine(cmd);
                    p.StandardInput.AutoFlush = true;

                    //获取cmd窗口的输出信息
                    output = p.StandardOutput.ReadToEnd();

                    int P = output.IndexOf(cmd) + cmd.Length + 4;
                    if (P > output.Length)
                    {
                        output = "";
                    }
                    else
                    {
                        output = output.Substring(P, output.Length - P - 3);
                    }


                    p.WaitForExit();//等待程序执行完退出进程
                    p.Close();
                }
            }catch (Exception ex)
            {
                string msg = ex.ToString();
                output = "";
            }
        }
    }

    public class EmotionData
    {
        public string no { get; set; }
        public string name { get; set; }

        public string value { get; set; }
    }

    public class RemoteJson
    {
        public string deviceName { get; set; }

        public string verifyCode { get; set; }

        public string userName { get; set; }

        public string patientName { get; set; }

        public string patientLocation { get; set; }

        public string patientDOB { get; set; }

        public string patientSex { get; set; }

        public string deviceSN { get; set; }

    }

    public class RiskData
    {
        public string no { get; set; }
        public string name { get; set; }

        public string value { get; set; }
    }

    public class RiskList
    {
        public string verifyCode { get; set; }

        public List<RiskData> riskDatas { get; set; }
    }

    public class DataList
    {
        public string verifyCode { get; set; }

        public string orderid { get; set; }

        public string testUser { get; set; }

        public string testDate { get; set; }

        public List<TestData> testDatas { get; set; }

        //public List<MatrixData> matrixDatas { get; set; }
    }

    public class TestData
    {
        public string id { get; set; }
        public string value { get; set; }

        public string code { get; set; }
    }

    public struct ValidateJson
    {
        public string name { get; set; }  //属性的名字，必须与json格式字符串中的"key"值一样。
        public string orderDate { get; set; }
        public string orderTime { get; set; }

        public string orderId { get; set; }

        public string peopleType { get; set; }
    }

    public class Patient
    {
        public Patient()
        {

        }

        public static string w_name;
        public static string w_birth_day;
        public static string w_location;
        public static string w_sex;
        public static string w_code;
        public static string w_username;
        public static string w_deviceSN;
        public static string w_deviceCode;

    }

    public class PortSetting
    {
        public PortSetting()
        {

        }

        public static string remoteIP;
        public static string remotePort;
        public static string localIP;
        public static string localPort;
        public static string devicePort;

    }

    public class MatrixData
    {
        public string value { get; set; }

        public string code { get; set; }
    }

    public class OrderData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string orderDate { get; set; }
        public string orderTime { get; set; }
        public string verifyCode { get; set; }
        public string serviceName { get; set; }


    }

    public class OrderList
    {
        public List<OrderData> datas { get; set; }
    }

    public class DatasItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 您最想关注您身体下列哪方面问题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 失眠
        /// </summary>
        public string result { get; set; }
    }

    public class HealthResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<DatasItem> datas { get; set; }
    }
}