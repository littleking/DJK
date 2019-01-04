using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Configuration;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Diagnostics;
using System.Xml;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace JKJC
{
    public partial class FrmMain : XtraForm
    {
        //private string reportFile = System.Windows.Forms.Application.StartupPath + "/report.xlsm";
        //private string resultFile = System.Windows.Forms.Application.StartupPath + "/result.xlsm";
        //private string sourceFile = System.Windows.Forms.Application.StartupPath + "/clarity.xls";
        private string reportFile = "c:/clasp32/data" + "/test.xlsm";
        private string resultFile = "c:/clasp32/data" + "/result.xlsm";
        private string sourceFile = "c:/clasp32/data" + "/clarity.xls";
        private string dataFile = System.Windows.Forms.Application.StartupPath + "/data.xml";
        private string testFile = "c:/clarity.xls";
        private ValidateJson vjList;
        private KGMWebService.GmWebServletClient webService;
        private string latestTime;
        Thread timeThread;
        private string verifyCode;
        private bool isRunning;
        private bool isAdult;
        private string sourceFileName;
        private System.Timers.Timer autoTimer;
        System.Timers.Timer timer = new System.Timers.Timer();
        private TestHelper th;

        public FrmMain()
        {
            InitializeComponent();
            killP();
            //copyTemp();;
            th = new TestHelper();
            Thread thRun = new Thread(new ThreadStart(Run));
            thRun.Start();
            verifyCode = "";
            latestTime = "";
            this.txtSex.SelectedIndex = -1;
            txtSex.Properties.Items.Add("男");
            txtSex.Properties.Items.Add("女");
            this.txtOrder.Text = "";
            this.txtBirthDay.Text = "";
            this.txtBirthPlace.Text = "";
            isRunning = false;
            isAdult = true;
            testFile = ConfigurationManager.AppSettings["sourceAddress"];
            string ws = ConfigurationManager.AppSettings["WSAddress"].ToString();
            string time = ConfigurationManager.AppSettings["RunningTime"].ToString();
            int rtime = int.Parse(time);
            webService = new KGMWebService.GmWebServletClient("GmWebServletImplPort", ws);
            this.lblStore.Text = CurrentUser.storeName.Length>25?CurrentUser.storeName.Substring(0,25):CurrentUser.storeName;
            
            timeThread = new Thread(new ThreadStart(updateTime));
            timeThread.IsBackground = true;
            timeThread.Start();

            autoTimer = new System.Timers.Timer();
            autoTimer.AutoReset = false;
            autoTimer.Interval = 1000 * 60 * rtime;
            autoTimer.Elapsed += timer_Elapsed;
            //StartService();
            runBat();

            timer.Interval = 2 * 60 * 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_ElapsedUpload);

            timer_Elapsed(null, null);
            timer.Start();

        }

        private void StartService()
        {
            if (ServiceHelper.GetServiceStatus("JKService") != System.ServiceProcess.ServiceControllerStatus.Running)
            {
                ServiceHelper.StartService("JKService");
            }
        }

        public void timer_ElapsedUpload(object sender, System.Timers.ElapsedEventArgs e)
        {
            uploadInfo();
        }

        private void uploadInfo()
        {
            string code = "";
            bool isCorrect = false;
            string errormsg = "";

            if (File.Exists(testFile))
            {
                if (File.Exists(sourceFile))
                {
                    File.Delete(sourceFile);
                }
                File.Copy(testFile, sourceFile);
                FileInfo fileInfo = new FileInfo(sourceFile);

                string timeStr = ReadAppSetting("ChangeTime");// ConfigurationManager.AppSettings["ChangeTime"].ToString();
                //文件没有更新，不处理
                if (timeStr.Length == 0)
                {
                    SetValue("ChangeTime", fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    File.Delete(sourceFile);
                    return;
                }

                DateTime dtNow = DateTime.Parse(fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                DateTime dtOld = DateTime.Parse(ReadAppSetting("ChangeTime"));

                //有最新文件，开始上传数据
                if (DateTime.Compare(dtNow, dtOld) > 0)
                {
                    latestTime = dtNow.ToString("yyyy-MM-dd HH:mm:ss");
                    SetValue("ChangeTime", latestTime);
                    Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                    //MessageBox.Show(excel.Version);
                    excel.Visible = false;
                    excel.Workbooks.Open(sourceFile, Type.Missing, Type.Missing, Type.Missing, "halleluja", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


                    Excel.Worksheet ws = (Excel.Worksheet)excel.Worksheets[2];
                    string name = ((Excel.Range)ws.Cells[3, 3]).Text.ToString();
                    sourceFileName = name;
                    excel.Quit();

                    IntPtr t = new IntPtr(excel.Hwnd);
                    int k = 0;
                    GetWindowThreadProcessId(t, out k);
                    System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                    p.Kill();

                    if (name.IndexOf("_") > 0)
                    {
                        string[] nameCode = name.Split('_');
                        if (nameCode.Length == 2)
                        {
                            code = nameCode[1].Trim() ;
                            verifyCode = code;
                            try
                            {
                                string strOrder = webService.isExistOrder(code, CurrentUser.UserName);
                                if (strOrder.Length > 2)
                                {
                                    vjList = getValidate(strOrder);
                                    if (vjList.name.Length > 0)
                                    {
                                        isCorrect = true;
                                    }
                                    string pType = vjList.peopleType;
                                    //pType = "1";
                                    if (pType == "1")
                                    {
                                        isAdult = false;
                                    }
                                    else
                                    {
                                        isAdult = true;
                                    }


                                }
                                else if (strOrder == "-1")
                                {
                                    errormsg = "验证码不存在，或者被使用,";
                                }
                                else if (strOrder == "-2")
                                {
                                    errormsg = "门店用户未设置所属门店,";
                                }
                                else if (strOrder == "-3")
                                {
                                    errormsg = "订单预约门店与使用门店不同,";
                                }
                                else if (strOrder == "-4")
                                {
                                    errormsg = "订单状态不可用,";
                                }
                            }
                            catch (Exception ex)
                            {
                                string er = ex.ToString();
                            }

                        }
                        else
                        {
                            errormsg = "验证码录入有误,";
                        }
                    }
                    else
                    {
                        errormsg = "验证码录入有误,";
                    }

                }
                //没有更新文件
                else
                {
                    File.Delete(sourceFile);
                    WriteLog("没有更新文件，数据没有上传！");
                    return;
                }

                //上传文件到服务器
                //verifyCode = "hahahaha";
                FTPUpLoad();

                //有更新文件，但是文件有问题
                if (!isCorrect)
                {
                    File.Delete(sourceFile);
                    //SetValue("ChangeTime", latestTime);
                    WriteLog(sourceFileName + "-" + errormsg + "文件存在问题，数据没有上传！");
                    MessageBox.Show(sourceFileName + "-" + errormsg + "数据没有上传！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //SetValue("ChangeTime", latestTime);
                WriteLog("开始上传数据");
                //copyTemp();
                copyStream();
                //上传数据
                Thread thdSub = new Thread(new ThreadStart(ThreadFun));
                thdSub.Start();
            }
        }

        public void FTPUpLoad()
        {
            string FTPIP = ConfigurationManager.AppSettings["FTPIP"].ToString();
            string FTPDirectory = ConfigurationManager.AppSettings["FTPDirectory"].ToString() + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/";
            string FTPID = ConfigurationManager.AppSettings["FTPID"].ToString();
            string FTPPWD = ConfigurationManager.AppSettings["FTPPWD"].ToString();
            FTPHelper ftp = new FTPHelper(FTPIP, FTPDirectory, FTPID, FTPPWD);
            string filename = verifyCode + ".xls";
            string copyname = System.Windows.Forms.Application.StartupPath + "/" + filename;
            try
            {
                // 遍历所有的文件和目录
                if (System.IO.File.Exists(sourceFile))
                {

                    FileInfo fi = new FileInfo(sourceFile);
                    fi.CopyTo(copyname, true);
                    //通过FTP文件
                    ftp.Upload(copyname);
                    WriteLog(filename + "发送成功");
                }
            }
            catch (Exception ex)
            {
                WriteLog(filename + "发送失败");
                string bakPath = System.Windows.Forms.Application.StartupPath + "/sourceBak/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/";
                if (!Directory.Exists(bakPath))
                    Directory.CreateDirectory(bakPath);
                FileInfo file = new FileInfo(sourceFile);
                file.CopyTo(bakPath + filename, true);
                if (File.Exists(copyname))
                {
                    File.Delete(copyname);
                }
                WriteLog(ex.Message);
            }
        }

        private void copyTemp()
        {
            string tempFile = "";
            isAdult = true;
            if (isAdult)
            {
                tempFile = System.Windows.Forms.Application.StartupPath + "/tempreport/report.xlsm";
                dataFile = System.Windows.Forms.Application.StartupPath + "/data.xml";
            }
            else
            {
                tempFile = System.Windows.Forms.Application.StartupPath + "/tempreport/report_kid.xlsm";
                dataFile = System.Windows.Forms.Application.StartupPath + "/data_kid.xml";
            }
            if (File.Exists(reportFile))
            {
                File.Delete(reportFile);
            }
            File.Copy(tempFile, reportFile);
        }

        private void copyStream()
        {
            if (File.Exists(reportFile))
            {
                File.Delete(reportFile);
            }
            string temp= System.Windows.Forms.Application.StartupPath + "/DevExpress.Map.v16.2.dll";
            FileStream filestream = new FileStream(temp, FileMode.Open);
            byte[] bt = new byte[filestream.Length];
            filestream.Read(bt, 0, bt.Length);
            string base64Str = System.Text.Encoding.Default.GetString(bt);
            var contents = Convert.FromBase64String(base64Str);
            using (var fss = new FileStream(reportFile, FileMode.Create, FileAccess.Write))
            {
                fss.Write(contents, 0, contents.Length);
                fss.Flush();
            }
        }

        private void ThreadFun()
        {
            try
            {
                Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                excel.Visible = false;
                excel.Workbooks.Open(reportFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                IntPtr t = new IntPtr(excel.Hwnd);
                int k = 0;
                GetWindowThreadProcessId(t, out k);
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                p.Kill();
            }
            catch (Exception ex)
            {
                File.Delete(sourceFile);
                if (File.Exists(reportFile))
                {
                    File.Delete(reportFile);
                }
                WriteLog(sourceFileName + "-Excel权限问题或没有安装，数据没有上传!");
                MessageBox.Show("Excel问题导致上传失败,请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            File.Delete(sourceFile);

            bool uploaded = false;
            int loadCount = 0;
            while (!uploaded && loadCount < 3)
            {
                uploaded = uploadData();
                loadCount++;
                string tt = uploaded ? "-数据上传成功!" : "-数据上传失败!";
                WriteLog(sourceFileName + tt + "-" + loadCount);
            }
            //if (uploaded)
            //{
            //    WriteLog(sourceFileName + "-数据上传成功!");
            //}
            //else
            //{
            //    WriteLog(sourceFileName + "-数据上传失败!");
            //}
            Thread.Sleep(3000);
            File.Delete(resultFile);
            WriteLog("上传数据结束");
            if (!uploaded)
            {
                if (File.Exists(reportFile))
                {
                    File.Delete(reportFile);
                }
                MessageBox.Show(sourceFileName + "---数据上传失败,请联系管理员查找原因！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private string ReadXlsToBase64(string path)
        {
            string rtn = "";
            try
            {
                FileStream filestream = new FileStream(path, FileMode.Open);
                byte[] bt = new byte[filestream.Length];

                //调用read读取方法  
                filestream.Read(bt, 0, bt.Length);
                string base64Str = Convert.ToBase64String(bt);
                filestream.Close();
                rtn = base64Str;

            }
            catch (Exception ex)
            {
                return rtn;
            }
            return rtn;


        }

        private bool uploadData()
        {
            bool goodData = true;
            bool uploaded = false;
            int errI = 0;
            string base64Str = ReadXlsToBase64(resultFile);
            try
            {
                Thread.Sleep(3000);
                XSSFWorkbook xssfworkbook = new XSSFWorkbook(new FileStream(resultFile,
                                                     FileMode.Open));
                ISheet sheetI = xssfworkbook.GetSheet("Data code");
                IRow irow = sheetI.GetRow(0);
                string name = irow.GetCell(2).ToString();
                IRow irow2 = sheetI.GetRow(1);
                string time = irow2.GetCell(2).DateCellValue.ToString();
                DateTime ddd = DateTime.Parse(time);
                string ttime = ddd.ToString("yyyy-MM-dd HH:mm:ss");
                DataList dl = new DataList();
                dl.orderid = vjList.orderId;
                dl.testDate = ttime;
                dl.testUser = name;
                dl.verifyCode = verifyCode;

                //保存matrix
                //sheetI = xssfworkbook.GetSheet("Matrix");
                //List<MatrixData> matrixList = new List<MatrixData>();
                //for (int i = 2; i <= 10764; i++)
                //{
                //    IRow dataRow = sheetI.GetRow(i);
                //    string code = dataRow.GetCell(0).ToString();
                //    string value = dataRow.GetCell(1) == null ? "" : dataRow.GetCell(1).ToString();
                //    if (value.Length == 0 || value == "#N/A")
                //    {
                //        value = "0";
                //        continue;
                //    }
                //    MatrixData md = new MatrixData();
                //    md.code = code;
                //    md.value = value;
                //    matrixList.Add(md);
                //}
                //dl.matrixDatas = matrixList;
                /////////////////////////////////////////////////


                List<TestData> listData = new List<TestData>();
                DataSet ds = LoginHelper.LoadData(dataFile);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        string dataSheet = dr[0].ToString();
                        int startRow = int.Parse(dr[1].ToString());
                        int endRow = int.Parse(dr[2].ToString());
                        int codeC = int.Parse(dr[3].ToString());
                        int keyC = int.Parse(dr[4].ToString());
                        int valueC = int.Parse(dr[5].ToString());
                        for (int i = startRow; i <= endRow; i++)
                        {
                            errI = i;
                            ISheet sheet = xssfworkbook.GetSheet(dataSheet);
                            IRow dataRow = sheet.GetRow(i);
                            string code = dataRow.GetCell(codeC).ToString();
                            string key = dataRow.GetCell(keyC).ToString();
                            string value = dataRow.GetCell(valueC) == null ? "" : dataRow.GetCell(valueC).ToString();
                            if (value.Length == 0 || value == "#N/A")
                            {
                                //goodData = false;
                                value = "0";
                                continue;
                            }
                            TestData td = new TestData();
                            td.id = key;
                            td.value = value;
                            td.code = code;
                            listData.Add(td);
                        }
                    }
                }
                dl.testDatas = listData;
                string rtnJson = JsonConvert.SerializeObject(dl);
                //StreamWriter strmsave = new StreamWriter("E:\\newtest.txt", false, System.Text.Encoding.Default);
                //strmsave.Write(rtnJson);
                //strmsave.Close();
                if (rtnJson.Length > 0)
                {
                    string saveStr = webService.saveScheduling(rtnJson);
                    if (saveStr == "1")
                    {
                        uploaded = true;
                    }
                }
                if (base64Str.Length > 0)
                {
                    string xlsOut = webService.fileOutXls(base64Str, verifyCode, dl.orderid, ttime);
                    if (xlsOut == "1")
                    {
                        LogHelper.WriteLog(verifyCode + "---" + "base64上传成功");
                    }
                    else
                    {
                        LogHelper.WriteLog(verifyCode + "---" + "base64上传失败");
                    }
                }
            }
            catch (Exception ex)
            {
                string errorStr = errI.ToString();
                WriteLog("上传数据失败");//ex.ToString());
                uploaded = false;

            }
            return uploaded;
        }

        private void Run()
        {
            while (true)
            {
                if (!isRunning)
                {
                    killP();
                }
                Thread.Sleep(1 * 10 * 1000);//五分钟
            }
        }

        public string ReadAppSetting(string key)
        {
            string xPath = "/configuration/appSettings//add[@key='" + key + "']";
            XmlDocument doc = new XmlDocument();
            string exeFileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            doc.Load(exeFileName + ".exe.config");
            XmlNode node = doc.SelectSingleNode(xPath);
            return node.Attributes["value"].Value.ToString();
        }

        public static void SetValue(string AppKey, string AppValue)
        {
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");

            System.Xml.XmlNode xNode;
            System.Xml.XmlElement xElem1;
            System.Xml.XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//appSettings");

            xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
            if (xElem1 != null) xElem1.SetAttribute("value", AppValue);
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("key", AppKey);
                xElem2.SetAttribute("value", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
        }

        #region Property
        private static FrmMain mInstance = null;
        /// <summary>
        /// FrmMain的唯一实例体
        /// </summary>
        public static FrmMain Instance
        {
            get
            {
                return mInstance;
            }
            set
            {
                mInstance = value;
            }
        }
        #endregion

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out   int ID);



        private delegate bool IncreaseHandle(int nValue);
        private delegate void CloseBar();
        private IncreaseHandle myIncrease = null;
        private CloseBar closeBar = null;


        private void pbClose_Click(object sender, EventArgs e)
        {
            killP();
            Environment.Exit(0);
            this.Dispose();
            Application.Exit();
        }

        [DllImport("user32")]
        public static extern int ReleaseCapture();
        [DllImport("user32")]
        public static extern int SendMessage(IntPtr hwnd, int msg, int wp, int lp);
        /// <summary>
        /// 是否允许移动
        /// </summary>
        bool IsMove = false;
        /// <summary>
        /// 判断鼠标是否在可移动范围内按下
        /// </summary>
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Rectangle rect = new Rectangle(1, 1, this.Width - 70, mInstance.Height);   //允许拖动的矩形范围
                this.IsMove = rect.Contains(new Point(e.X, e.Y));                       //鼠标按下的点是否在允许拖动范围内
            }
        }
        /// <summary>
        /// 鼠标弹起时取消移动
        /// </summary>
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsMove = false;
        }
        /// <summary>
        /// 移动窗体
        /// </summary>
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMove && e.Button == System.Windows.Forms.MouseButtons.Left && this.WindowState != FormWindowState.Maximized)
            {
                ReleaseCapture();
                SendMessage(Handle, 274, 61440 + 9, 0);
                return;
            }
        }

        private void pbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.notifyIcon1.Visible = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.ShowInTaskbar = true;  //显示在系统任务栏
                this.WindowState = FormWindowState.Normal;  //还原窗体
                notifyIcon1.Visible = false;  //托盘图标隐藏
            }
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)//最小化        
            {
                this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                myMenu.Show();
            }
        }

        private void quit_Click(object sender, EventArgs e)
        {
            killP();
            this.notifyIcon1.Dispose();
            Environment.Exit(0);
            Application.Exit();
        }

        private void display_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
        }

        private void updateTime()
        {
            while (true)
            {
                string dt = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
                refreshTime(dt);
                Thread.Sleep(1000);
            }
        }

        private void refreshOrder()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    txtOrder.Text = "";
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void enableButtons()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    pbClose.Enabled = true;
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    pbMin.Enabled = true;
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    btnValidate.Visible = true;
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    Refresh();
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    BringToFront();
                });
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void disableButtons()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    pbClose.Enabled = false;
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    pbMin.Enabled = false;
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    btnValidate.Visible = false;
                });
                this.Invoke((MethodInvoker)delegate()
                {
                    Refresh();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void killP()
        {
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processList)
            {
                if (process.ProcessName.ToUpper() == "CONMAIN")
                {
                    process.Kill(); //结束进程
                    isRunning = false;
                }
            }
        }

        private bool pExist()
        {
            bool rtn = false;
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processList)
            {
                if (process.ProcessName.ToUpper() == "CONMAIN")
                {
                    rtn = true;
                    return rtn;
                }
            }
            return rtn;
        }

        private void refreshTime(string str)
        {
            try
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        lblTime.Text = str;
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateInfo()
        {
            bool rtn = true;
            if (pExist())
            {
                killP();
            }
            if (this.txtOrder.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            else if (this.txtOrder.Text.IndexOf("_")<= 0)
            {
                XtraMessageBox.Show("姓名中需要包含校验码，用下划线隔开!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            else if (this.txtSex.SelectedIndex < 0)
            {
                XtraMessageBox.Show("请选择性别", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            else if (this.txtBirthDay.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入出生日期", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            else if (this.txtBirthPlace.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入出生地", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            if (rtn)
            {
                DataProcess dp = new DataProcess();
                string msg = dp.validOrder(this.txtOrder.Text.Trim());
                if (msg.Length > 0)
                {
                    XtraMessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rtn = false;
                }
            }
            return rtn;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {

            try
            {
                if (ValidateInfo())
                {
                    Patient.w_name = txtOrder.Text.Trim();
                    Patient.w_birth_day = txtBirthDay.Text;
                    Patient.w_location = txtBirthPlace.Text.Trim();
                    Patient.w_sex = txtSex.Text == "男" ? "Male" : "Female";
                    string sql = string.Format("INSERT INTO patient VALUES (NULL, '{0}', '{1}', '{2}', '中国', NULL, NULL, NULL, NULL, NULL, 0, 0, 0, '{3}', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 0, 0, 0, 0, 10, 0, 0, 76, 88, 85, 91, 98, 64, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 1, 1, 1, 1, 1, 2, NULL, NULL, NULL);", Patient.w_name, Patient.w_birth_day, Patient.w_location, Patient.w_sex);
                    string clearSql = "Delete from patient";
                    string dbpath = "C:\\Clasp32\\DATA\\data.db3";
                    bool findScio = false;
                    try
                    {
                        th.ExecSql(dbpath, clearSql);
                        Thread.Sleep(100);
                        th.ExecSql(dbpath, sql);
                    }
                    catch (Exception ex)
                    {
                        //XtraMessageBox.Show("数据保存失败，请联系管理员!" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        XtraMessageBox.Show("检测程序启动失败，请联系管理员!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        WriteLog(ex.ToString());
                        return;
                    }
                    disableButtons();

                    startCon();
                    enableButtons();

                }
            }
            catch (Exception ex)
            {
                frmValidate frmV = new frmValidate("授权验证失败，请重试！", "", "");
                //WriteLog(ex.ToString());
                splashScreenManager1.CloseWaitForm();
                DialogResult dr = frmV.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    enableButtons();
                }
            }
        }

        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);

        private void startCon()
        {
            isRunning = true;
            if (!pExist())
            {   
                //需要打开的地方插入此段代码
                splashScreenManager1.ShowWaitForm();
                th.TestLaunch(true);
                //ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder("Conmain.exe"), new StringBuilder(""), new StringBuilder(@"C:\clasp32\program"), 1);
                Thread.Sleep(4000);
                autoTimer.Enabled = true;
                autoTimer.Start();
                splashScreenManager1.CloseWaitForm();
                WriteLog("校验成功，程序启动！");
            }
            else
            {
                autoTimer.Stop();
                autoTimer.Start();
                WriteLog("校验成功，程序时间重置！");
            }
            txtOrder.Text = "";
            txtBirthDay.Text = "";
            txtBirthPlace.Text = "";
            txtSex.SelectedIndex = -1;
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.notifyIcon1.Visible = true;

        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            autoTimer.Stop();
            autoTimer.Enabled = false;
            killP();
            WriteLog("程序强制关闭！");
        }

        private string readCard()
        {
            string rtn = "0";
            try
            {

                #region 打开端口
                if (icdev > 0)
                {
                    st = dc_exit(icdev);
                    icdev = -1;
                }
                icdev = dc_init(100, 115200);
                if (icdev < 0)
                {
                    MessageBox.Show("连接读卡器失败", "提示");
                    return rtn;
                }
                #endregion

                #region 载入密码
                byte[] data = GetByteArray(CurrentUser.CardMima);

                st = dc_load_key(icdev, 0, 2, data);
                if (st != 0)
                {
                    MessageBox.Show("读卡器初始失败，请重启程序再试！", "提示");
                    return rtn;
                }
                #endregion


                #region 寻卡
                StringBuilder strsnr = new StringBuilder(20);
                st = dc_card_double_hex(icdev, '0', strsnr);
                if (st != 0)
                {
                    MessageBox.Show("没有读取到卡，请重试！", "提示");
                    return rtn;
                }
                #endregion

                #region 校验密码
                st = dc_authentication(icdev, 0, 2);
                if (st != 0)
                {
                    MessageBox.Show("读卡时校验失败，请重试", "提示");
                    return rtn;
                }
                #endregion

                #region
                StringBuilder rbuff = new StringBuilder(32);
                st = dc_read_hex(icdev, 8, rbuff);
                if (st != 0)
                {
                    MessageBox.Show("读卡失败", "提示");
                    return rtn;
                }
                st = dc_beep(icdev, 10);
                rtn = rbuff.ToString();
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误，请重试！", "提示");
                return rtn;
            }
            return rtn.Substring(0,19);
        }

        //转换秘钥
        private byte[] GetByteArray(string shex)
        {
            string[] ssArray = new string[6];
            ssArray[0] = shex.Substring(0, 2);
            ssArray[1] = shex.Substring(2, 2);
            ssArray[2] = shex.Substring(4, 2);
            ssArray[3] = shex.Substring(6, 2);
            ssArray[4] = shex.Substring(8, 2);
            ssArray[5] = shex.Substring(10, 2);
            List<byte> bytList = new List<byte>();
            foreach (var s in ssArray)
            {
                //将十六进制的字符串转换成数值
                bytList.Add(Convert.ToByte(s, 16));
            }
            //返回字节数组
            return bytList.ToArray();
        }

        #region 读卡方法
        [DllImport("dcrf32.dll")]
        public static extern int dc_init(Int16 port, Int32 baud);  //初试化
        [DllImport("dcrf32.dll")]
        public static extern short dc_exit(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern short dc_beep(int icdev, uint _Msec);
        [DllImport("dcrf32.dll")]
        public static extern short dc_card_double_hex(int icdev, char _Mode, [MarshalAs(UnmanagedType.LPStr)] StringBuilder Snr);  //从卡中读数据(转换为16进制)

        [DllImport("dcrf32.dll")]
        public static extern short dc_read(int icdev, int adr, [Out] byte[] sdata);  //从卡中读数据
        [DllImport("dcrf32.dll")]
        public static extern short dc_read(int icdev, int adr, [MarshalAs(UnmanagedType.LPStr)] StringBuilder sdata);  //从卡中读数据

        [DllImport("dcrf32.dll")]
        public static extern short dc_read_hex(int icdev, int adr, ref byte sdata);  //从卡中读数据(转换为16进制)
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_hex(int icdev, int adr, [MarshalAs(UnmanagedType.LPStr)] StringBuilder sdata);  //从卡中读数

        [DllImport("dcrf32.dll")]
        public static extern short dc_write(int icdev, int adr, [In] string sdata);  //向卡中写入数据
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_hex(int icdev, int adr, [In] string sdata);  //向卡中写入数据(转换为16进制)

        [DllImport("dcrf32.dll")]
        public static extern short dc_load_key(int icdev, int mode, int addr, [In] byte[] sdata);  //载入密码
        [DllImport("dcrf32.dll")]
        public static extern short dc_authentication(int icdev, int mode, int addr);  //验证密码
        [DllImport("dcrf32.dll")]
        public static extern short dc_authentication_passaddr(int icdev, int mode, int addr, [In] byte[] sdata);  //验证密码
        
        private int icdev = -1;
        private short st = -1;


        #endregion

        private ValidateJson getValidate(string strJson)
        {
            ValidateJson vj = new ValidateJson();
            try
            {
                vj = JsonConvert.DeserializeObject<ValidateJson>(strJson);
            }
            catch (Exception ex)
            {
                string ss = ex.ToString();
            }
            return vj;
        }



        private OrderList getOrder(string strJson)
        {
            OrderList vj = new OrderList();
            try
            {
                vj = JsonConvert.DeserializeObject<OrderList>(strJson);
            }
            catch (Exception ex)
            {
                string ss = ex.ToString();
            }
            return vj;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            //string url = ConfigurationManager.AppSettings["adminAddress"]; ;
            //OpenDefaultBrowserUrl(url);
        }

        /// <summary>
        /// 打开系统默认浏览器（用户自己设置了默认浏览器）
        /// </summary>
        /// <param name="url"></param>
        private void OpenDefaultBrowserUrl(string url)
        {
            try
            {
                // 方法1
                //从注册表中读取默认浏览器可执行文件路径
                RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
                if (key != null)
                {
                    string s = key.GetValue("").ToString();
                    //s就是你的默认浏览器，不过后面带了参数，把它截去，不过需要注意的是：不同的浏览器后面的参数不一样！
                    //"D:\Program Files (x86)\Google\Chrome\Application\chrome.exe" -- "%1"
                    var lastIndex = s.IndexOf(".exe", StringComparison.Ordinal);
                    if (lastIndex == -1)
                    {
                        lastIndex = s.IndexOf(".EXE", StringComparison.Ordinal);
                    }
                    var path = s.Substring(1, lastIndex + 3);
                    var result = Process.Start(path, url);
                    if (result == null)
                    {
                        // 方法2
                        // 调用系统默认的浏览器 
                        var result1 = Process.Start("explorer.exe", url);
                        if (result1 == null)
                        {
                            // 方法3
                            Process.Start(url);
                        }
                    }
                }
                else
                {
                    // 方法2
                    // 调用系统默认的浏览器 
                    var result1 = Process.Start("explorer.exe", url);
                    if (result1 == null)
                    {
                        // 方法3
                        Process.Start(url);
                    }
                }
            }
            catch
            {
                OpenIe(url);
            }
        }

        /// <summary>
        /// 用IE打开浏览器
        /// </summary>
        /// <param name="url"></param>
        private void OpenIe(string url)
        {
            try
            {
                Process.Start("iexplore.exe", url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // IE浏览器路径安装：C:\Program Files\Internet Explorer
                // at System.Diagnostics.process.StartWithshellExecuteEx(ProcessStartInfo startInfo)注意这个错误
                try
                {
                    if (File.Exists(@"C:\Program Files\Internet Explorer\iexplore.exe"))
                    {
                        ProcessStartInfo processStartInfo = new ProcessStartInfo
                        {
                            FileName = @"C:\Program Files\Internet Explorer\iexplore.exe",
                            Arguments = url,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };
                        Process.Start(processStartInfo);
                    }
                    else
                    {
                        if (File.Exists(@"C:\Program Files (x86)\Internet Explorer\iexplore.exe"))
                        {
                            ProcessStartInfo processStartInfo = new ProcessStartInfo
                            {
                                FileName = @"C:\Program Files (x86)\Internet Explorer\iexplore.exe",
                                Arguments = url,
                                UseShellExecute = false,
                                CreateNoWindow = true
                            };
                            Process.Start(processStartInfo);
                        }
                        else
                        {
                            MessageBox.Show("系统没找到浏览器");
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        //修改注册表
        private void addReg()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser;
                RegistryKey software12 = key.CreateSubKey("Software\\Microsoft\\Office\\12.0\\Excel\\Security");
                RegistryKey software15 = key.CreateSubKey("Software\\Microsoft\\Office\\15.0\\Excel\\Security");

                RegistryKey security12 = key.OpenSubKey("Software\\Microsoft\\Office\\12.0\\Excel\\Security", true); //该项必须已存在
                RegistryKey security15 = key.OpenSubKey("Software\\Microsoft\\Office\\15.0\\Excel\\Security", true); //该项必须已存在
                security12.SetValue("AccessVBOM", "00000001");
                security15.SetValue("AccessVBOM", "00000001");
                security12.SetValue("vbawarnings", "00000001");
                security15.SetValue("vbawarnings", "00000001");
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
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

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            killP();
            Environment.Exit(0);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            checkSheet();
        }

        private void checkSheet()
        {
            if (this.txtOrder.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.txtOrder.Text.IndexOf("_") <= 0)
            {
                XtraMessageBox.Show("请输入正确校验码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataProcess dp = new DataProcess();
            string result = dp.getResult(this.txtOrder.Text.ToString().Trim());
            if (result == "-1")
            {
                XtraMessageBox.Show("校验码不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == "-2")
            {
                XtraMessageBox.Show("没有自检信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FrmCheckSheet cs = new FrmCheckSheet(result);
                cs.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            copyStream();
        }
    }
}
