using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CloudOperator
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public UpdateTxt updateTxt;
        public delegate void UpdateTxt(string msg);
        private string jsonMsg;
        private int operatorStatus; // 0：不在线,1:在线,2:等待设备连接,3:连接中
        private string usbPort;
        private string connectedDeviceName;
        private string waitedDeviceName;
        private System.Timers.Timer msgTimer;
        private System.Timers.Timer deviceTimer;


        public FrmMain()
        {
            InitializeComponent();
            updateTxt = new UpdateTxt(SendMessage);
            deviceTimer = new System.Timers.Timer(1000 * 30);
            deviceTimer.Elapsed += new System.Timers.ElapsedEventHandler(deviceTimer_Tick); //到达时间的时候执行事件；   
            deviceTimer.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；
            msgTimer = new System.Timers.Timer(1000 * 30);   //实例化Timer类，设置间隔时间为10000毫秒；   
            msgTimer.Elapsed += new System.Timers.ElapsedEventHandler(msgTimer_Tick); //到达时间的时候执行事件；   
            msgTimer.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；
            jsonMsg = "";
            operatorStatus = 0;
            usbPort = "";
            connectedDeviceName = "";
            waitedDeviceName = "";
            this.btnDisconnect.Enabled = false;
            this.btnConnect.Enabled = false;   
        }
        /// <summary>
        /// status:0:服务未启动,1:无设备连接,2:设备等待连接,3:无效设备等待连接,4:设备已连接,5:连接中断
        /// </summary>
        /// <returns></returns>
        private int CheckDevice()
        {
            string result = "";
            int rtn = 0;
            string cmd = @"usbrcd.exe -list";
            CmdHelper.RunCmd(cmd, out result);
            if (result.Length == 0)
            {
                rtn = 0;
            }
            else
            {
                List<string> msglist = GetResult(result);
                if (msglist.Count == 2)
                {
                    rtn = 1;
                }
                else if(msglist.Count == 8)
                {
                    if (msglist[2].Contains("callback connection") && msglist[7].Contains("available for connection"))
                    {
                        usbPort = getUsbPort(msglist);
                        connectedDeviceName = getDeviceName(msglist);
                        if (waitedDeviceName != "" && waitedDeviceName == connectedDeviceName)
                        {
                            rtn = 2;
                        }
                        else
                        {
                            rtn = 3;
                        }
                    }
                    else if (msglist[2].Contains("callback connection") && msglist[7].Contains("connected"))
                    {
                        rtn= 4;
                    }
                }
                else
                {
                    rtn = 5;
                }
            }
            return rtn;
        }

        private string getUsbPort(List<string> msglist)
        {
            string line1 = msglist[2];
            string line2 = msglist[5];
            string iport = line1.Split(':')[0].Trim();
            string uport = line2.Split(':')[0].Trim();
            uport = uport.Substring(uport.Length - 1);
            return iport + "-" + uport;
        }

        private string getDeviceName(List<string> msglist)
        {
            string rtn = "";
            string line = msglist[5];
            rtn = line.Split(':')[1].Trim();
            return rtn;
        }

        public void SendMessage(string msg)
        {
            string tt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtOutput.AppendText(tt+": "+msg + "\r\n");
            txtOutput.ScrollToCaret();


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string result = "";
            string cmd = @"usbrcd.exe -list";
            CmdHelper.RunCmd(cmd, out result);
            if (result.Length == 0)
            {
                this.BeginInvoke(updateTxt, "本机远程服务未启动。。。");
                //txtOutput.AppendText("远程服务未启动\r\n");
            }
            else
            {
                string msg = GetResultString(result);
                List<string> msglist = GetResult(result);
                this.BeginInvoke(updateTxt, msg);
                //txtOutput.AppendText(msg + "\r\n");
            }
        }


        private List<string> GetResult(string msg)
        {
            List<string> rtn = new List<string>();
            string[] msgArray = msg.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < msgArray.Length; i++)
            {
                if (!msgArray[i].Contains("====="))
                    rtn.Add(msgArray[i]);
            }
            return rtn;
        }

        private string GetResultString(string msg)
        {
            StringBuilder sb = new StringBuilder();
            string[] msgArray = msg.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < msgArray.Length; i++)
            {
                if(!msgArray[i].Contains("====="))
                    sb.Append(msgArray[i] + "\r\n");
            }
            return sb.ToString();
        }

        private void resetOperator()
        {
            jsonMsg = "";
            operatorStatus = 0;
            usbPort = "";
            connectedDeviceName = "";
            waitedDeviceName = "";
            this.btnDisconnect.Enabled = false;
            this.btnConnect.Enabled = false;
            this.btnOnline.Enabled = true;
            msgTimer.Enabled = false;
            deviceTimer.Enabled = false;
        }

        private void deviceTimer_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            // status:0:服务未启动,1:无设备连接,2:设备等待连接,3:无效设备等待连接,4:设备已连接,5:连接中断
            int dStatus = CheckDevice();
            if (operatorStatus == 2)
            {
                if (dStatus == 2)
                {
                    this.btnConnect.Enabled = true;
                    this.BeginInvoke(updateTxt, "远程设备已接入，可以连接。。。");
                    XtraMessageBox.Show("远程设备已准备好，请连接远程设备", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dStatus == 3)
                {
                    this.BeginInvoke(updateTxt, connectedDeviceName+" :无效设备连入中。。。。");
                    
                }
                else if (dStatus == 1)
                {
                    this.BeginInvoke(updateTxt,  "远程设备信息已接收，等待远程设备接入。。。。");

                }
            }
            else if (operatorStatus == 3)
            {
                if (dStatus == 0)
                {
                    resetOperator();
                    this.BeginInvoke(updateTxt, "本机远程服务出现错误，连接已中断。。。");
                    XtraMessageBox.Show("本机远程服务未启动，本次连接中断", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (dStatus == 5)
                {
                    this.BeginInvoke(updateTxt, "意外原因导致本次连接中断。。。");
                    XtraMessageBox.Show("意外原因导致本次连接中断。。。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                else if(dStatus == 4)
                {
                    this.BeginInvoke(updateTxt, "远程设备连接中。。。");
                }
            }
        }

        private void menuSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSetting fs = new FrmSetting();
            fs.ShowDialog();
        }

        private void btnOnline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string result = "";
            string cmd = @"usbrcd.exe -list";
            CmdHelper.RunCmd(cmd, out result);
            //先检查服务是否启动
            if (result.Length == 0)
            {
                operatorStatus = 0;
                this.BeginInvoke(updateTxt, "本机远程服务未启动。。。");
                XtraMessageBox.Show("本机远程服务未启动", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //txtOutput.AppendText("远程服务未启动\r\n");
            }
            else
            {
                this.btnOnline.Enabled = false;
                operatorStatus = 1; //上线中
                this.BeginInvoke(updateTxt, "已上线，等待远程设备信息。。。。");
                if (jsonMsg == "")
                {
                    msgTimer.Enabled = true;
                    string haha = "";
                }
                else
                {
                    operatorStatus = 2;
                    this.BeginInvoke(updateTxt, "远程设备信息已接收，等待远程设备接入。。。。");
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            jsonMsg = "FT232R USB UART";
            waitedDeviceName = "FT232R USB UART";
        }


        private void msgTimer_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            msgTick();
        }

        private void msgTick()
        {
            if (operatorStatus == 1)
            {
                if (jsonMsg != "")
                {

                    operatorStatus = 2;
                    this.BeginInvoke(updateTxt, "远程设备信息已接收，等待远程设备接入。。。。");
                    deviceTimer.Enabled = true; 
                    msgTimer.Enabled = false;
                }
                else
                {
                    this.BeginInvoke(updateTxt, "已上线，等待远程设备信息。。。。");
                }
            }
        }

        private void btnConnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string result = "";
            string cmd = @"usbrcd.exe -connect "+usbPort;
            CmdHelper.RunCmd(cmd, out result);
            List<string> msgList = GetResult(result);
            if (msgList[0]== "USB device connected")
            {
                operatorStatus = 3;
                this.btnConnect.Enabled = false;
                this.btnDisconnect.Enabled = true;
                this.BeginInvoke(updateTxt, "远程设备连接成功。。。。");
            }
        }

        private void btnDisconnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string result = "";
            string cmd = @"usbrcd.exe -disconnect " + usbPort;
            CmdHelper.RunCmd(cmd, out result);
            List<string> msgList = GetResult(result);
            if (msgList[0]== "USB device disconnected")
            {
                resetOperator();
                this.BeginInvoke(updateTxt, "远程连接已经断开。。。。");
            }
        }
    }
}
