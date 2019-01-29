using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Diagnostics;

namespace CloudOperator
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public UpdateTxt updateTxt;
        public delegate void UpdateTxt(string msg);
        private string jsonMsg;
        private int operatorStatus; // 0：不在线,1:在线,2:等待设备连接,3:连接中，4：检测中
        private string usbPort;
        private string connectedSN;
        private string waitedSN;
        private System.Timers.Timer msgTimer;
        private System.Timers.Timer deviceTimer;
        private bool suspend;
        private TestHelper th;
        private DateTime dtTest;
        private DateTime dtTimeOut;


        public FrmMain()
        {
            InitializeComponent();
            runBat();
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
            connectedSN = "";
            waitedSN = "";
            this.btnDisconnect.Enabled = false;
            this.btnConnect.Enabled = false;
            dtTest = DateTime.Now;
            th = new TestHelper();
            dtTimeOut = DateTime.Now;
        }

        private void runBat()
        {
            Process proc = null;
            try
            {
                string targetDir = Application.StartupPath;
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = "run.bat";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
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
                        connectedSN = getDeviceSN(msglist);
                        if (waitedSN != "" && waitedSN == connectedSN)
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

        private string getDeviceSN(List<string> msglist)
        {
            string rtn = "";
            string line = msglist[6];
            rtn = line.Split(':')[3].Trim();
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
            connectedSN = "";
            waitedSN = "";
            this.btnDisconnect.Enabled = false;
            this.btnConnect.Enabled = false;
            this.btnOnline.Enabled = true;
            msgTimer.Enabled = false;
            deviceTimer.Enabled = false;
            dtTest = DateTime.Now;
            killP();
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
                    connectRemoteDevice();
                    //XtraMessageBox.Show("远程设备已准备好，请连接远程设备", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dStatus == 3)
                {
                    this.BeginInvoke(updateTxt, connectedSN+" :无效设备连入中。。。。");
                    
                }
                else if (dStatus == 1)
                {
                    if (dtTimeOut < DateTime.Now)
                    {
                        resetOperator();
                        this.BeginInvoke(updateTxt, "等待远程连接超时，服务重启。。。");
                        Thread.Sleep(5000);
                        autoStart();
                    }
                    else
                    {
                        this.BeginInvoke(updateTxt, "远程设备信息已接收，等待远程设备接入。。。。");
                    }

                }
            }
            else if (operatorStatus == 3||operatorStatus == 4)
            {
                if (dStatus == 0)
                {
                    resetOperator();
                    this.BeginInvoke(updateTxt, "本机远程服务出现错误，连接已中断。。。");
                    //XtraMessageBox.Show("本机远程服务未启动，本次连接中断", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Thread.Sleep(5000);
                    autoStart();
                }
                else if (dStatus == 1)
                {
                    resetOperator();
                    this.BeginInvoke(updateTxt, "意外原因导致本次连接中断。。。");
                    //XtraMessageBox.Show("意外原因导致本次连接中断。。。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Thread.Sleep(5000);
                    autoStart();
                }
                else if (dStatus == 5)
                {
                    resetOperator();
                    this.BeginInvoke(updateTxt, "意外原因导致本次连接中断。。。");
                    //XtraMessageBox.Show("意外原因导致本次连接中断。。。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Thread.Sleep(5000);
                    autoStart();
                }
                else if(dStatus == 4)
                {

                    if (operatorStatus == 4)
                    {
                        //超时，终止连接
                        if (dtTest < DateTime.Now)
                        {
                            disconnectDevice();
                            this.BeginInvoke(updateTxt, "连接时间已到，远程设备自动中断，检测结束！！");
                            Thread.Sleep(5000);
                            autoStart();
                            //XtraMessageBox.Show("连接时间已到，远程设备自动中断，检测结束", "结束", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        this.BeginInvoke(updateTxt, "远程设备连接中。。。");
                    }
                }
            }
        }

        private void menuSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSetting fs = new FrmSetting();
            fs.ShowDialog();
        }

        private void autoStart()
        {
            try
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
                    Task.Factory.StartNew(() =>
                    {
                        this.btnOnline.Enabled = false;
                        operatorStatus = 1; //上线中
                        this.BeginInvoke(updateTxt, "上线中。。。。");
                        msgTimer.Enabled = true;
                    }).ContinueWith(x =>
                    {
                        msgTick();
                    });
                    
                    
                    //if (jsonMsg == "")
                    //{
                    //    msgTimer.Enabled = true;
                    //    string haha = "";
                    //}
                    //else
                    //{
                    //    operatorStatus = 2;
                    //    this.BeginInvoke(updateTxt, "远程设备信息已接收，等待远程设备接入。。。。");
                    //}
                }
            }catch(Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }

        private void btnOnline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            autoStart();   
        }

        private bool updateStatus(string status)
        {
            bool rtn = false; ;
            string statusAddress = ConfigurationManager.AppSettings["StatusAddress"].ToString();
            string ip = ReadAppSetting("OperatorIP");
            string port = ReadAppSetting("OperatorPort");
            using (var httpClient = new HttpClient())
            {
                //get
                string uri = statusAddress + "?ip=" + ip + "&port=" + port + "&ttype=" + status;
                string data = "";
                try
                {
                    var url = new Uri(uri);
                    // response
                    var response = httpClient.GetAsync(url).Result;
                    data = response.Content.ReadAsStringAsync().Result.ToString();
                    rtn = true;
                }
                catch (Exception ex)
                {
                    rtn = false;

                }
                return rtn;
            }

        }

        private string getRemoteDevice()
        {
            string rtn = "";
            string controlAddress = ConfigurationManager.AppSettings["ControlAddress"].ToString();
            string ip = ReadAppSetting("OperatorIP");
            string port = ReadAppSetting("OperatorPort");
            string localIP = ReadAppSetting("LocalIP");
            string localPort = ReadAppSetting("LocalPort");
            RemoteJson rj = new RemoteJson();
            using (var httpClient = new HttpClient())
            {
                //get
                string uri = controlAddress + "?ip=" + ip + "&port=" + port + "&localIp=" + localIP + "&localPort=" + localPort;
                string data = "";
                try
                {
                    var url = new Uri(uri);
                    // response
                    var response = httpClient.GetAsync(url).Result;
                    data = response.Content.ReadAsStringAsync().Result.ToString();
                }catch(Exception ex)
                {
                    rtn = "调度服务出错";
                    return rtn;

                }
                if (data == "{}")
                {
                    rtn = "";
                }
                else
                {
                    // JObject jo = (JObject)JsonConvert.DeserializeObject(data);
                    //string decodeRtn = jo["json"].ToString();
                    //rtn = jo["json"].ToString(); //HttpUtility.UrlDecode(decodeRtn, System.Text.Encoding.GetEncoding("utf-8"));
                    rtn = data;
                }
                return rtn;
            }
        }

        private string decodeStr(string str)
        {
            return HttpUtility.UrlDecode(str, System.Text.Encoding.GetEncoding("utf-8"));
        }

        private string ReadAppSetting(string key)
        {
            string rtn = "";
            try
            {
                string xPath = "/configuration/appSettings//add[@key='" + key + "']";
                XmlDocument doc = new XmlDocument();
                string exeFileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                doc.Load(exeFileName + ".exe.config");
                XmlNode node = doc.SelectSingleNode(xPath);
                return node.Attributes["value"].Value.ToString();
            }
            catch (Exception ex)
            {
                return rtn;
            }
        }



        private void msgTimer_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            msgTick();
        }

        private void msgTick()
        {
            try
            {
                if (operatorStatus == 1)
                {
                    jsonMsg = getRemoteDevice();
                    if (jsonMsg == "调度服务出错")
                    {
                        this.BeginInvoke(updateTxt, "调度服务出错。。。。");
                    }
                    else
                    {
                        if (jsonMsg != "")
                        {
                            RemoteJson rj = JsonConvert.DeserializeObject<RemoteJson>(jsonMsg);
                            waitedSN = rj.deviceSN;
                            Patient.w_birth_day = rj.patientDOB;
                            Patient.w_code = rj.verifyCode;
                            Patient.w_location = FromBase64(rj.patientLocation);
                            Patient.w_name = FromBase64(rj.patientName);
                            Patient.w_sex = rj.patientSex;
                            Patient.w_username = rj.userName;
                            Patient.w_deviceSN = rj.deviceSN;
                            Patient.w_deviceCode = FromBase64(rj.deviceName);

                            operatorStatus = 2;
                            this.BeginInvoke(updateTxt, "远程设备信息已接收，等待远程设备" + waitedSN + "接入。。。。");
                            deviceTimer.Enabled = true;
                            msgTimer.Enabled = false;
                            dtTimeOut = DateTime.Now.AddMinutes(3);


                            string result = "";
                            string cmd = @"usbrcd.exe -list";
                            CmdHelper.RunCmd(cmd, out result);
                            List<string> msglist = GetResult(result);
                            if (msglist.Count == 8)
                            {
                                if (msglist[2].Contains("callback connection") && msglist[7].Contains("available for connection"))
                                {
                                    usbPort = getUsbPort(msglist);
                                    connectedSN = getDeviceSN(msglist);
                                    if (waitedSN != "" && waitedSN == connectedSN)
                                    {
                                        this.btnConnect.Enabled = true;
                                        this.BeginInvoke(updateTxt, "远程设备已接入，可以连接。。。");
                                        connectRemoteDevice();
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.BeginInvoke(updateTxt, "已上线，等待远程设备信息。。。。");
                        }
                    }
                }
            }catch(Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }

        private void connectRemoteDevice()
        {
            string result = "";
            string cmd = @"usbrcd.exe -connect " + usbPort;
            CmdHelper.RunCmd(cmd, out result);
            List<string> msgList = GetResult(result);
            if (msgList[0] == "USB device connected")
            {
                operatorStatus = 3;
                this.btnConnect.Enabled = false;
                this.btnDisconnect.Enabled = true;
                this.BeginInvoke(updateTxt, "远程设备连接成功。。。。");
                checkCOM(Patient.w_deviceSN);
                DataProcess dp = new DataProcess();
                int orderType = dp.getTL(Patient.w_code);
                startTest(orderType);  //1检测，2理疗
            }
            else
            {
                LogHelper.WriteLog(usbPort + "----" + msgList[0]);
            }
        }

        private void btnConnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            connectRemoteDevice();
        }

        private void startTest(int testType)
        {
            LogHelper.WriteLog(Patient.w_code + "-" + Patient.w_name + " 开始检测");
            updateStatus("2");
            try
            {
                operatorStatus = 4;
                string tt = ReadAppSetting("TestTimeOut");
                int ttt = int.Parse(tt);
                dtTest = DateTime.Now.AddMinutes(ttt);

                if (testType == 1)
                {
                    DoTest();
                }
                else
                {

                    DoTherapy();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.ToString());
            }
        }

        private bool startClasp()
        {
            string sql = string.Format("INSERT INTO patient VALUES (NULL, '{0}', '{1}', '{2}', '中国', NULL, NULL, NULL, NULL, NULL, 0, 0, 0, '{3}', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 0, 0, 0, 0, 10, 0, 0, 76, 88, 85, 91, 98, 64, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 1, 1, 1, 1, 1, 2, NULL, NULL, NULL);", Patient.w_name, Patient.w_birth_day, Patient.w_location, Patient.w_sex);
            string clearSql = "Delete from patient";
            string dbpath = "C:\\Clasp32\\DATA\\data.db3";
            try
            {
                this.BeginInvoke(updateTxt, "检测程序初始化。。。");
                th.ExecSql(dbpath, clearSql);
                Thread.Sleep(100);
                th.ExecSql(dbpath, sql);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("1:" + ex.ToString());
                this.BeginInvoke(updateTxt, "数据保存失败，请联系管理员!");
                XtraMessageBox.Show("数据保存失败，请联系管理员!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void DoTherapy()
        {
            try
            {
                bool start = false;
                Task.Factory.StartNew(() =>
                {
                    if (startClasp())
                    {
                        start = true;
                        Thread.Sleep(500);
                        this.BeginInvoke(updateTxt, "启动并校验检测仪。。。。");
                        th.TestLaunch(true);
                        Thread.Sleep(15000);
                        th.CloseBandTest();
                        Thread.Sleep(3000);
                    }
                }).ContinueWith(x =>
                {
                    if (start)
                    {
                        th.TestToStart();
                        DataProcess dp = new DataProcess();
                        int rtn = dp.setUsed(Patient.w_code);
                        LogHelper.WriteLog(Patient.w_deviceSN + "-" + Patient.w_code + "执行结果为" + rtn);
                        if (operatorStatus == 4)
                        {
                            this.BeginInvoke(updateTxt, "校验结束，可以开始调理。。。。");
                        }
                    }
                    else
                    {
                        updateStatus("-1");
                        disconnectDevice();
                    }
                });
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                LogHelper.WriteLog(haha);
                //XtraMessageBox.Show(ex.ToString(), "错误");
                this.BeginInvoke(updateTxt, ex.ToString());

            }
        }

        private void DoTest()
        {
            try
            {

                DeleteSource();
                
                bool start = false;
                bool startTest = false;
                Task.Factory.StartNew(() =>
                {
                    if (startClasp())
                    {
                        startTest = true;
                        this.BeginInvoke(updateTxt, "校验检测设备。。。。");
                        start = StartTool();
                    }
                    suspend = true;

                }).ContinueWith(x =>
                {
                    if (startTest)
                    {
                        if (!start)
                        {
                            this.Invoke((MethodInvoker)(() =>
                            {
                                killP();
                                updateStatus("-1");
                                //updateTxt("报告数据处理失败，本次数据没有上传，请稍后重新上传数据或重新检测！");
                                XtraMessageBox.Show("报告数据处理失败！", "错误");
                            }));
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)(() =>
                            {
                                //检测结束
                                updateStatus("3");
                                updateTxt("本次检测已经完成！！");
                                //XtraMessageBox.Show("本次检测已经完成!！！", "完成");

                            }));
                        }
                    }
                    else
                    {
                        updateStatus("-1");
                    }

                    disconnectDevice();
                    Thread.Sleep(5000);
                    autoStart();
                });
            } 
            catch (Exception ex)
            {
                this.BeginInvoke(updateTxt, ex.ToString());
                LogHelper.WriteLog(ex.ToString());
            }
        }

        private void DeleteSource()
        {
            string testFile = "c:/Clasp32/clarity.xls";
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }

        private bool StartTool()
        {
            bool rtn = false;
            try
            {
                bool showAPP = false;
                string isHide = ReadAppSetting("ShowHide");
                if (isHide == "1")
                {
                    showAPP = true;
                }
                Thread.Sleep(500);
                th.TestLaunch(showAPP);
                Thread.Sleep(15000);
                th.CloseBandTest();
                Thread.Sleep(3000);
                th.TestToStart();
                this.BeginInvoke(updateTxt, "检测中。。。");
                th.TestStart();
                Thread.Sleep(5000);
                if (operatorStatus != 4)
                {
                    this.BeginInvoke(updateTxt, "检测报告生成失败，本次检测未完成。。。");
                    return false;
                }
                this.BeginInvoke(updateTxt, "数据处理中。。。");
                ExportXml();
                rtn = GetReport();
                //rtn = false;
                if (!rtn)
                {
                    // splashScreenManager1.CloseWaitForm();
                    string msg = "";
                    if (saveSource())
                    {
                        msg = "数据已保存，请稍后重新上传数据或重新检测!";
                        this.BeginInvoke(updateTxt, "数据已保存，请稍后重新上传数据或重新检测!");
                        LogHelper.WriteLog(Patient.w_code + "_" + "本地数据保存成功。");
                    }
                    else
                    {
                        msg = "数据在本地保存失败，请稍后重新检测!";
                        this.BeginInvoke(updateTxt, "数据在本地保存失败，请稍后重新检测!");
                        LogHelper.WriteLog(Patient.w_code + "_" + "本地数据保存失败。");
                    }
                    //splashScreenManager1.SetWaitFormCaption("报告数据处理失败，本次数据没有上传，请稍后重新上传数据或重新检测！");
                    //XtraMessageBox.Show("报告数据处理失败，本次数据没有上传，请稍后重新上传数据或重新检测！", "错误");
                    return rtn;
                }
                return true;
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                LogHelper.WriteLog(haha);
                //XtraMessageBox.Show(ex.ToString(), "错误");
                return false;
            }
        }

        private bool saveSource()
        {
            string sourceFile = "c:/clasp32/clarity.xls";
            if (!File.Exists(sourceFile))
            {
                return false;
            }
            string bakPath = System.Windows.Forms.Application.StartupPath + "/WaitedSource/";
            if (!Directory.Exists(bakPath))
                Directory.CreateDirectory(bakPath);
            string filename = Patient.w_code +"."+Patient.w_username+Patient.w_deviceCode+ ".bak";
            string savePath = bakPath + filename;
            string sourcePath = bakPath + "clarity.xls";
            if (File.Exists(sourcePath))
            {
                File.Delete(sourcePath);
            }
            FileInfo file = new FileInfo(sourceFile);
            file.CopyTo(sourcePath, true);
            bool saved = ReadXlsToBase64(savePath, sourcePath);
            return saved;
        }

        private string FromBase64(string str)
        {
            str = str.Replace('@', '+');
            byte[] c = Convert.FromBase64String(str);
            string a = System.Text.Encoding.Default.GetString(c);
            return a;
        }


        private bool ReadXlsToBase64(string savePath, string sourcePath)
        {
            bool rtn = true;
            try
            {
                FileStream filestream = new FileStream(sourcePath, FileMode.Open);
                byte[] bt = new byte[filestream.Length];

                //调用read读取方法  
                filestream.Read(bt, 0, bt.Length);
                string base64Str = Convert.ToBase64String(bt);
                filestream.Close();

                //将Base64串写入临时文本文件  
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }
                FileStream fs = new FileStream(savePath, FileMode.Create);
                byte[] data = System.Text.Encoding.Default.GetBytes(base64Str);
                //开始写入  
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流  
                fs.Flush();
                fs.Close();

            }
            catch (Exception ex)
            {
                return false;
            }

            File.Delete(sourcePath);


            return rtn;


        }

        private bool GetReport()
        {
            bool rtn = false;
            //string reportFile = System.Windows.Forms.Application.StartupPath + "/report.xlsm";
            //string sourceFile = System.Windows.Forms.Application.StartupPath + "/clarity.xls";
            string reportFile = "c:/clasp32/data" + "/test.xlsm";
            string sourceFile = "c:/clasp32/data" + "/clarity.xls";
            string dataFile = System.Windows.Forms.Application.StartupPath + "/data.xml";
            string testFile = ConfigurationManager.AppSettings["sourceAddress"];
            FileInfo fileInfo = new FileInfo(testFile);
            if (File.Exists(testFile))
            {
                //SysVar.dtOld = SysVar.dtNow;
                DataProcess dp = new DataProcess(reportFile, sourceFile, testFile, dataFile);
                rtn = dp.uploadInfo(0, "",Patient.w_deviceCode);
            }
            else
            {
                rtn = false;
                // XtraMessageBox.Show("测试数据没有生成，请重新测试，如果还是不成功请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogHelper.WriteLog("测试数据没有生成，请重新测试，如果还是不成功请联系管理员！");
            }
            return rtn;
        }

        private void disconnectDevice()
        {
            string result = "";
            string cmd = @"usbrcd.exe -disconnect " + usbPort;
            CmdHelper.RunCmd(cmd, out result);
            List<string> msgList = GetResult(result);
            if (msgList.Count > 0)
            {
                if (msgList[0] == "USB device disconnected")
                {
                    resetOperator();
                    this.BeginInvoke(updateTxt, "远程连接已经断开。。。。");
                }
            }
        }

        private void btnDisconnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (operatorStatus == 4)
            {
                updateStatus("3");
            }
            if (operatorStatus == 3)
            {
                updateStatus("-1");
            }
            disconnectDevice();
        }

        private void ExportXml()
        {
            killP();
            Thread.Sleep(2000);
            th.ExportXML();

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

        private void btnOffline_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (operatorStatus !=4)
            {
                killP();
                disconnectDevice();
                resetOperator();
                this.BeginInvoke(updateTxt, "已下线。。。。");

            }
            else
            {
                XtraMessageBox.Show("正在检测中，无法下线！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            killP();
            disconnectDevice();
        }

        private void barSubItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSetting fs = new FrmSetting();
            fs.ShowDialog();
        }

        private void barSubItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AgentDll.launchEx(true);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSetting fs = new FrmSetting();
            fs.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AgentDll.launchEx(true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("检测程序安装不正确，无法启动！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool checkWaitedSource()
        {
            string bakPath = System.Windows.Forms.Application.StartupPath + "/waitedSource/";
            if (Directory.Exists(bakPath))
            {
                DirectoryInfo Dir = new DirectoryInfo(bakPath);
                FileInfo[] fi = Dir.GetFiles();
                if (fi.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnUpload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkWaitedSource())
            {
                if (XtraMessageBox.Show("是否开始上传健康档案？", "重新上传", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.BeginInvoke(updateTxt, "健康档案正在处理上传中。。。");
                    int[] result = new int[3];
                    Task.Factory.StartNew(() =>
                    {
                        result = uploadSource();

                    }).ContinueWith(x =>
                    {

                        this.Invoke((MethodInvoker)(() =>
                        {
                            this.BeginInvoke(updateTxt, result[0] + "份健康档案成功上传," + result[1] + "份健康档案上传失败," + result[2] + "份健康档案无效或已处理");
                        }));
                    });
                }
            }
            else
            {
                XtraMessageBox.Show("没有未上传的健康档案！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int[] uploadSource()
        {
            int[] result = new int[3];
            string bakPath = System.Windows.Forms.Application.StartupPath + "/WaitedSource/";
            if (Directory.Exists(bakPath))
            {
                DirectoryInfo Dir = new DirectoryInfo(bakPath);
                FileInfo[] fi = Dir.GetFiles();
                int i = 1;
                foreach (FileInfo file in fi)
                {
                    int rtn = SourceProcess(file);
                    this.BeginInvoke(updateTxt, "第" + i + "个健康档案正在处理上传中。。。");
                    if (rtn == 1) //成功上传
                    {
                        result[0]++;
                    }
                    else if (rtn == 0)//上传失败
                    {
                        result[1]++;
                    }
                    else //不正确的数据文件被删除
                    {
                        result[2]++;
                    }
                    i++;
                }
            }
            return result;
        }

        private int SourceProcess(FileInfo file)
        {
            string filename = file.Name;
            string[] fileDetail = filename.Split('.');
            string verifyCode = "";
            string userName = "";
            string deviceCode = "";
            if (fileDetail.Length == 4)
            {
                verifyCode = fileDetail[0];
                userName = fileDetail[1];
                deviceCode = fileDetail[2];
                string fileType = fileDetail[3];
                //文件有问题，删除文件
                if (fileType != "bak")
                {
                    File.Delete(file.FullName);
                    return -1;
                }
                DataProcess dpN = new DataProcess();
                string msg = dpN.validCode(verifyCode,userName,deviceCode);
                //校验码有问题，删除文件
                if (msg.Length > 0)
                {
                    if (msg != "验证时出错")
                    {
                        File.Delete(file.FullName);
                    }
                    return -1;
                }
            }
            else
            {

                File.Delete(file.FullName);
                return -1; //文件有问题
            }

            //开始处理文件
            string testFile = System.Windows.Forms.Application.StartupPath + "/WaitedSource/clarity.xls";
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
            string tempSource = file.FullName;
            copyStream(testFile, tempSource);

            string reportFile = "c:/clasp32/data" + "/test.xlsm";
            string sourceFile = "c:/clasp32/data" + "/clarity.xls";
            string dataFile = System.Windows.Forms.Application.StartupPath + "/data.xml";
            DataProcess dp = new DataProcess(reportFile, sourceFile, testFile, dataFile);
            bool rtn = dp.uploadInfo(1, verifyCode,deviceCode);
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
            if (rtn)
            {
                File.Delete(file.FullName);
                return 1; //成功
            }
            else
            {
                return 0; //失败
            }

        }

        private void copyStream(string resultFile, string temp)
        {
            if (File.Exists(resultFile))
            {
                File.Delete(resultFile);
            }
            FileStream filestream = new FileStream(temp, FileMode.Open);
            byte[] bt = new byte[filestream.Length];
            filestream.Read(bt, 0, bt.Length);
            string base64Str = System.Text.Encoding.Default.GetString(bt);
            var contents = Convert.FromBase64String(base64Str);
            using (var fss = new FileStream(resultFile, FileMode.Create, FileAccess.Write))
            {
                fss.Write(contents, 0, contents.Length);
                fss.Flush();
            }
        }


        private void checkCOM(string deviceSN)
        {
            RegHelper rh = new RegHelper();
            if (rh.checkCOM("COM1", deviceSN))
            {
                this.BeginInvoke(updateTxt, deviceSN + "---端口修改为COM1");
            }
        }
    }
}
