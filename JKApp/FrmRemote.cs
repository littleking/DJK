using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JKApp
{
    public partial class FrmRemote : XtraForm
    {
        private string deviceName;
        private string deviceNo;
        private int deviceStatus;//0:初始状态,1:设备共享，2：连接建立，等待接入，3:连接成功
        private string usbCode;
        private string remoteAdd;
        private System.Timers.Timer txtTimer;
        public UpdateTxt updateTxt;
        public delegate void UpdateTxt(string msg);
        private bool deviceReady;
        public FrmRemote()
        {
            InitializeComponent();
            updateTxt = new UpdateTxt(SendMessage);
            deviceName = "";
            deviceNo = "";
            deviceStatus = 0;
            usbCode = "";
            remoteAdd = "";
            deviceReady = true;
            txtTimer = new System.Timers.Timer(500);   
            txtTimer.Elapsed += new System.Timers.ElapsedEventHandler(txtTimer_Tick); //到达时间的时候执行事件；   
        }

        public void resetDevice(int waitSeconds,string msgbox)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(waitSeconds * 1000);
            }).ContinueWith(x =>
            {
                string cmd = "usbrdd.exe -closecallback " + remoteAdd;
                string result = "";
                CmdHelper.RunCmd(cmd, out result);
                cmd = "usbrdd.exe -unshare " + usbCode;
                CmdHelper.RunCmd(cmd, out result);
                deviceName = "";
                deviceNo = "";
                deviceStatus = 0;
                usbCode = "";
                remoteAdd = "";
                txtTimer.Enabled = false;
                if (!msgbox.Contains("结束"))
                {
                    this.BeginInvoke(updateTxt, "开始前请先连接设备，并确保绑带已经绑好");
                }
                this.Invoke((MethodInvoker)(() =>
                {
                    this.txtLabel.ForeColor = Color.WhiteSmoke;
                    btnTest.Enabled = true;
                    simpleButton2.Visible = false;
                    btnBack.Visible = true;
                }));
                if (msgbox.Length > 0&&msgbox!="close")
                {
                    XtraMessageBox.Show(msgbox, "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (msgbox == "close")
                {
                    System.Environment.Exit(0);
                }
            });

        }


        public void SendMessage(string msg)
        {
            txtLabel.Text = msg;
        }

        private void txtTimer_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            if (this.txtLabel.ForeColor == Color.WhiteSmoke)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    this.txtLabel.ForeColor = Color.FromArgb(7, 112, 48);
                   
                }));
                //this.BeginInvoke(this.txtLabel.BackColor = Color.Aqua;);
                //this.txtLabel.Font = new Font("微软雅黑", 25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            }
            else
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    this.txtLabel.ForeColor = Color.WhiteSmoke;
                   
                }));
                //this.txtLabel.BackColor = Color.WhiteSmoke;
                //this.txtLabel.Font = new Font("圆幼", 20F, FontStyle.Bold, GraphicsUnit.Point, 134);
            }
        }

        private void resetLabel()
        {
            this.Invoke((MethodInvoker)(() =>
            {
                txtTimer.Enabled = false;
                txtLabel.Text = "开始前请先连接设备，并确保绑带已经绑好";
                txtLabel.ForeColor = Color.WhiteSmoke;
                this.btnTest.Enabled = true;
                this.btnBack.Visible = true;
                this.simpleButton2.Visible = false;
            }));
        }

        private void shareDevice()
        {
            string result = "";
            string cmd = @"usbrdd.exe -list";
            CmdHelper.RunCmd(cmd, out result);
            List<string> msglist = GetResult(result);
            for (int i = 0; i < msglist.Count; i++)
            {
                if (msglist[i].Contains("FT232R USB UART"))
                {
                    if (msglist[i + 2].Trim() == "Status: plugged")
                    {
                        cmd = "usbrdd.exe -share " + usbCode;
                        CmdHelper.RunCmd(cmd, out result);
                        string msg = GetResultString(result);
                        if (msg.Replace("\r\n","") == "USB device has been shared")
                        {
                            deviceStatus = 1;
                        }
                    }
                    else if (msglist[i + 2].Trim() == "Status: plugged, shared")
                    {
                        deviceStatus = 1;
                    }
                    return;
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            doTest();
            
        }

        private List<string> GetResult(string msg)
        {
            List<string> rtn = new List<string>();
            string[] msgArray = msg.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < msgArray.Length; i++)
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
                if (!msgArray[i].Contains("====="))
                    sb.Append(msgArray[i] + "\r\n");
            }
            return sb.ToString();
        }

        private bool checkSetup()
        {
            bool rtn = true;
            if (!checkService("usbrdsrv")||!checkDriver("tusbdbus"))
            {
                rtn = false;
            }
            return rtn;
        }

        private bool checkDevice()
        {
            bool rtn = false;
            string result = "";
            string cmd = @"usbrdd.exe -list";
            CmdHelper.RunCmd(cmd, out result);
            List<string> msglist = GetResult(result);
            if (msglist.Count > 0)
            {
                for(int i = 0; i < msglist.Count; i++)
                {
                    if(msglist[i].Contains("FT232R USB UART"))
                    {
                        if(msglist[i + 2].Contains("not plugged"))
                        {
                            return false;
                        }
                        if (msglist[i].Split(':').Length > 1)
                        {
                            deviceName = msglist[i].Split(':')[1].Trim();
                            usbCode= msglist[i].Split(':')[0].Trim();
                        }
                        if (msglist[i+1].Split(':').Length > 3)
                        {
                            deviceNo = msglist[i+1].Split(':')[3].Trim();
                        }
                        deviceStatus = 1;
                        rtn = true;
                        return rtn;
                    }
                }
            }

            return rtn;
        }

        private bool checkDriver(string driverName)
        {
            string result = "";
            string cmd = @"sc query "+ driverName;
            CmdHelper.RunCmd(cmd, out result);
            string msg = GetResultString(result);
            if (msg.Contains("指定的服务未安装"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkService(string serviceName)
        {
            bool rtn = true;
            var serviceControllers = ServiceController.GetServices();
            var server = serviceControllers.FirstOrDefault(service => service.ServiceName.ToUpper() == serviceName.ToUpper());
            if (server == null)
            {
                return false;
            }
            if (server != null && server.Status != ServiceControllerStatus.Running)
            {
                server.Start(); 
            }
            return rtn;
        }

        private void doTest()
        {
            //this.BeginInvoke(updateTxt, "设备自检中。。。");
            //txtTimer.Enabled = true;
            //btnTest.Enabled = false;      
            //if(!checkSetup())
            //{
            //    XtraMessageBox.Show("驱动未安装！请先安装驱动再使用本程序！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    resetLabel();
            //    return;
            //}
            //if (!checkDevice())
            //{
            //    XtraMessageBox.Show("检测设备没有连接，请先启动检测设备！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    resetLabel();
            //    return;
            //}
            deviceReady = true;
            Task.Factory.StartNew(() =>
            {
                this.BeginInvoke(updateTxt, "设备自检中。。。");
                this.Invoke((MethodInvoker)(() =>
                {
                    txtTimer.Enabled = true;
                    btnTest.Enabled = false;
                    btnBack.Visible = false;
                    simpleButton2.Visible = true;

                }));
                
                if (!checkSetup())
                {
                    XtraMessageBox.Show("驱动未安装！请先安装驱动再使用本程序！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    resetLabel();
                    deviceReady = false;
                    return;
                }
                if (!checkDevice())
                {
                    XtraMessageBox.Show("检测设备没有连接，请先启动检测设备！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    resetLabel();
                    deviceReady = false;
                    return;
                }
                //共享设备
                shareDevice();
            }).ContinueWith(x =>
            {
                if (deviceReady)
                {
                    if (deviceStatus == 1)
                    {
                        this.BeginInvoke(updateTxt, "获取远程检测师信息。。。");
                        remoteAdd = getRemoteAdd();
                        if (remoteAdd == "")
                        {
                                resetDevice(30, "没有空闲的远程检测师，请稍后再试！");

                                //XtraMessageBox.Show("没有空闲的远程检测师，请稍后再试！", "忙碌", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (remoteAdd == "调度服务出错")
                        {
                            resetDevice(30, "调度服务出错，请稍后再试！");
                        }
                        else
                        {
                            this.BeginInvoke(updateTxt, "等待与远程检测师建立连接。。。");
                            string cmd = "usbrdd.exe -createcallback " + remoteAdd;
                            string result = "";
                            CmdHelper.RunCmd(cmd, out result);
                            string msg = GetResultString(result);
                            if (msg.Replace("\r\n", "") == "Callback connection to remote USB client has been added")
                            {
                                deviceStatus = 2;
                                DateTime dt1 = DateTime.Now;
                                DateTime dt2 = dt1.AddMinutes(3);
                                bool isConnected = false;
                                while (!isConnected && dt2 > dt1)
                                {
                                    dt1 = DateTime.Now;
                                    cmd = "usbrdd.exe -list";
                                    CmdHelper.RunCmd(cmd, out result);
                                    string msgC = GetResultString(result);
                                    string ip = remoteAdd.Split(':')[0];
                                    if (msgC.Contains("in use by " + ip))
                                    {
                                        isConnected = true;
                                    }
                                }
                                if (!isConnected)
                                {
                                    resetDevice(1, "等待远程连接超时，请稍后再试！");
                                    //XtraMessageBox.Show("等待远程连接超时，请稍后再试！", "超时", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    deviceStatus = 3;
                                    this.BeginInvoke(updateTxt, "远程连接成功，检测中。。。");
                                    //XtraMessageBox.Show("远程连接成功，检测开始！", "检测中", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    string outMsg = "本次远程连接已结束！";
                                    while (isConnected)
                                    {
                                        cmd = "usbrdd.exe -list";
                                        CmdHelper.RunCmd(cmd, out result);
                                        string msgC = GetResultString(result);
                                        string ip = remoteAdd.Split(':')[0];
                                        if (msgC.Contains("in use by " + ip))
                                        {
                                            isConnected = true;
                                        }
                                        else
                                        {
                                            if (msgC.Contains("not plugged"))
                                            {
                                                outMsg = "远程连接已经断开。。。。！";
                                            }
                                            isConnected = false;
                                        }
                                        Thread.Sleep(10 * 1000);
                                    }
                                    if (!isConnected)
                                    {
                                        resetDevice(1, outMsg);
                                        this.BeginInvoke(updateTxt, outMsg);
                                        this.Invoke((MethodInvoker)(() =>
                                        {
                                            this.btnTest.Visible = false;
                                            this.btnFinish.Visible = true;
                                            this.txtLabel.Text = outMsg;
                                        }));   
                                        //XtraMessageBox.Show("本次远程连接已结束！", "结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //GoBack();
                                    }
                                }
                            }
                            else
                            {
                                resetDevice(30, "远程连接失败，请稍后再试！");
                                //XtraMessageBox.Show("远程连接失败，请稍后再试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        resetDevice(30, "远程连接初始化失败，请重新接入设备再试！");
                        //XtraMessageBox.Show("远程连接初始化失败，请重新接入设备再试！", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            });

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("检测程序将被强制关闭!", "关闭", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                txtTimer.Enabled = false;
                resetDevice(1, "close");
                //System.Environment.Exit(0);
            }

        }

        private void GoBack()
        {
            this.Close();
            FrmInfo.Instance.Show();
        }

        private string encodeStr(string msg)
        {
            return System.Web.HttpUtility.UrlEncode(System.Web.HttpUtility.HtmlEncode(msg), Encoding.GetEncoding("utf-8"));
        }

        private string ToBase64(string str)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            //转成 Base64 形式的 System.String  
            string a = Convert.ToBase64String(b);

            a = a.Replace('+', '@');

            //byte[] c = Convert.FromBase64String(a);
            //string d = System.Text.Encoding.Default.GetString(c);

            return a;
        }

        private string fileToStr(string temp)
        {
            string base64Str = "";
            ;
            try
            {
                if (File.Exists(temp))
                {
                    FileStream filestream = new FileStream(temp, FileMode.Open);
                    byte[] bt = new byte[filestream.Length];
                    filestream.Read(bt, 0, bt.Length);
                    base64Str = System.Text.Encoding.Default.GetString(bt);
                }
            }
            catch (Exception ex)
            {
                base64Str = "";
            }
            return base64Str;
        }

        private string getRemoteAdd()
        {
            string rtn = "";
            string controlAddress = ConfigurationManager.AppSettings["ControlAddress"].ToString();
            using (var httpClient = new HttpClient())
            {
                RemoteJson rj = new RemoteJson();
                string file = System.Windows.Forms.Application.StartupPath + "/HealthTesting.lic";
                string lic = fileToStr(file);
                rj.deviceName = lic;  //授权文件
                rj.userName = CurrentUser.UserName;
                rj.verifyCode = Patient.w_code;
                rj.patientName = Patient.w_name;
                rj.patientSex = Patient.w_sex;
                rj.patientDOB = Patient.w_birth_day;
                rj.patientLocation = Patient.w_location;
                rj.deviceSN = deviceNo;
                string json = JsonConvert.SerializeObject(rj);
                string encodeJson = json;// System.Web.HttpUtility.UrlEncode(System.Web.HttpUtility.HtmlEncode(json), Encoding.GetEncoding("utf-8"));
                string para = string.Format("?deviceName={0}&userName={1}&verifyCode={2}&patientName={3}&patientSex={4}&patientDOB={5}&patientLocation={6}&deviceSN={7}", ToBase64(rj.deviceName), rj.userName, rj.verifyCode, ToBase64(rj.patientName), rj.patientSex, rj.patientDOB, ToBase64(rj.patientLocation), rj.deviceSN);
                //get
                //string uri = controlAddress + "?emp=" + deviceNo + "&empjson=" + encodeJson;
                string uri = controlAddress + para;
                //post
                //string uri = controlAddress;
                //var body = new FormUrlEncodedContent(new Dictionary<string, string>
                //{
                //    { "emp", deviceNo},
                //    { "empjson", encodeJson},
                //});

                var url = new Uri(uri);
                string data = "";
                try
                {
                    //Get
                    var response = httpClient.GetAsync(url).Result;
                    //Post
                    //var response = httpClient.PostAsync(url, body).Result;
                    data = response.Content.ReadAsStringAsync().Result.ToString();



                    if (data == "{}")
                    {
                        rtn = "";
                    }
                    else
                    {
                        RemoteAddress ra = new RemoteAddress();
                        ra = JsonConvert.DeserializeObject<RemoteAddress>(data);
                        rtn = ra.ip + ":" + ra.port;
                    }
                }catch (Exception ex)
                {
                    rtn = "调度服务出错";
                    return rtn;
                }
            }
            return rtn;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0xB;




        private void FrmRemote_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }
    }
}
