using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace QiYuan
{
    public partial class FrmInfo : XtraForm
    {
        private TestHelper th;

        public FrmInfo()
        {
            InitializeComponent();
            checkWaitedSource();
            runBat();
            th = new TestHelper();
            //this.labelControl1.Text = "健康检测系统运用高科技手段有效检测不同人群在身、心、灵多层面的健康风险，并精准评估，\r\n靶向调理，形成健康追踪、无创干预、慢病管理、诊疗指导等全方位的健康管理体系。";
            this.txtSex.SelectedIndex = -1;
            txtSex.Properties.Items.Add("男");
            txtSex.Properties.Items.Add("女");
            this.txtName.Text = "";
            this.txtBirthDay.Text = "";
            this.txtBirthPlace.Text = "";
            string tempFolder = System.Windows.Forms.Application.StartupPath + "/temp/";
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }
            //checkWaitedSource();
        }


        public void checkWaitedSource()
        {
            string bakPath = System.Windows.Forms.Application.StartupPath + "/waitedSource/";
            if (Directory.Exists(bakPath))
            {
                DirectoryInfo Dir = new DirectoryInfo(bakPath);
                FileInfo[] fi = Dir.GetFiles();
                if (fi.Length > 0)
                {
                    simpleButton4.Visible = true;
                    simpleButton4.Text = fi.Length + "份健康档案未处理";
                }
                else
                {
                    simpleButton4.Visible = false;
                }
            }
        }

        private void StartTool()
        {
            try
            {
                th.TestLaunch(this.checkEdit1.Checked);
                Thread.Sleep(2000);
                //th.TestLaunch(false);
                //th.CloseBandTest();
                //Thread.Sleep(6000);
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                XtraMessageBox.Show("检测程序无法启动，请联系管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
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

        private bool ValidateInfo()
        {
            bool rtn = true;
            if (this.txtCode.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入校验码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            if (this.txtName.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DataProcess dp = new DataProcess();
            string msg = dp.validCode(this.txtCode.Text.Trim());
            if (msg.Length > 0)
            {
                XtraMessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            return rtn;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
        * 窗体移动API
*/
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




        private void FrmInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }

        #region Property
        private static FrmInfo mInstance = null;
        /// <summary>
        /// FrmMain的唯一实例体
        /// </summary>
        public static FrmInfo Instance
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

        private void FrmInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            killP();
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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmTest test = new FrmTest();
            test.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ValidateInfo())
            {
                killP();
                Patient.w_name = txtName.Text.Trim();
                Patient.w_birth_day = txtBirthDay.Text;
                Patient.w_location = txtBirthPlace.Text.Trim();
                Patient.w_sex = txtSex.Text == "男" ? "Male" : "Female";
                Patient.w_code = txtCode.Text.Trim();
                string sql = string.Format("INSERT INTO patient VALUES (NULL, '{0}', '{1}', '{2}', '中国', NULL, NULL, NULL, NULL, NULL, 0, 0, 0, '{3}', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, 0, 0, 0, 0, 10, 0, 0, 76, 88, 85, 91, 98, 64, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, 0, 0, 1, 1, 1, 1, 1, 2, NULL, NULL, NULL);", Patient.w_name, Patient.w_birth_day, Patient.w_location, Patient.w_sex);
                string clearSql = "Delete from patient";
                string dbpath = "C:\\Clasp32\\DATA\\data.db3";
                bool findScio = false;
                this.simpleButton1.Enabled = false;
                try
                {
                    th.ExecSql(dbpath, clearSql);
                    Thread.Sleep(100);
                    th.ExecSql(dbpath, sql);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("1:" + ex.ToString());
                    this.simpleButton1.Enabled = true;
                    XtraMessageBox.Show("数据保存失败，请联系管理员!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool hasDev = true;
                splashScreenManager2.ShowWaitForm();
                Task.Factory.StartNew(() =>
                {
                    th.TestLaunch(this.checkEdit1.Checked);
                    Thread.Sleep(15000);
                    if (!th.TestDevice())
                    {
                        killP();
                        this.simpleButton1.Enabled = true;
                        splashScreenManager2.CloseWaitForm();
                        XtraMessageBox.Show("检测设备初始化未完成，请重试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hasDev = false;
                        return;
                    }
                    string testMsg = "";
                    bool bandCheck = false;
                    while (!bandCheck)
                    {
                        Thread.Sleep(200);
                        if (!th.TestBand(out testMsg))
                        {
                            splashScreenManager2.CloseWaitForm();
                            if (XtraMessageBox.Show(testMsg + "绑带检测未通过，是否重新检测？选Yes将重试，选No将跳过绑带检测", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                            {
                                splashScreenManager2.ShowWaitForm();
                            }
                            else
                            {
                                th.CloseBandTest();
                                bandCheck = true;
                            }
                        }
                        else
                        {
                            th.CloseBandTest();
                            bandCheck = true;
                        }
                    }


                    //int count = 0;
                    //while (!findScio)
                    //{
                    //    try
                    //    {
                    //        th.TestLaunch(this.checkEdit1.Checked);
                    //        //findScio = true;
                    //        Thread.Sleep(15000);
                    //        if (th.TestLF())
                    //        {
                    //            th.CloseBandTest();
                    //            Thread.Sleep(8000);
                    //            findScio = true;
                    //        }
                    //        else
                    //        {
                    //            splashScreenManager2.SetWaitFormCaption("设备和人体通讯异常，第" + (count + 1) + "次重试中");
                    //            count++;
                    //            killP();
                    //            Thread.Sleep(3000);
                    //        }
                    //        if (count == 3)
                    //        {
                    //            this.simpleButton1.Enabled = true;
                    //            splashScreenManager2.CloseWaitForm();
                    //            //this.pictureBox1.Enabled = true;
                    //            if (XtraMessageBox.Show("绑带检测未通过，是否跳过绑带检查并继续?", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    //            {
                    //                splashScreenManager2.ShowWaitForm();
                    //                splashScreenManager2.SetWaitFormCaption(" 请等待。。。");
                    //                th.TestLaunch(this.checkEdit1.Checked);
                    //                Thread.Sleep(8000);
                    //                th.CloseBandTest();
                    //                Thread.Sleep(8000);
                    //                findScio = true;
                    //            }
                    //            else
                    //            {
                    //                XtraMessageBox.Show("绑带检测未通过，请检查绑带后重新开始！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //                return;
                    //            }
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        this.simpleButton1.Enabled = true;
                    //        string haha = ex.ToString();
                    //        XtraMessageBox.Show("检测程序无法启动，请联系管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        LogHelper.WriteLog("2:" + haha);
                    //        Application.Exit();
                    //    }
                    //}

                }).ContinueWith(x =>
                {
                    if (!hasDev)
                    {
                        return;
                    }
                    if (splashScreenManager2.IsSplashFormVisible)
                    {
                        splashScreenManager2.CloseWaitForm();
                    }
                    this.Invoke((MethodInvoker)(() =>
                    {
                        this.txtSex.SelectedIndex = -1;
                        this.txtCode.Text = "";
                        this.txtName.Text = "";
                        this.txtBirthDay.Text = "";
                        this.txtBirthPlace.Text = "";
                        this.simpleButton1.Enabled = true;
                        //this.pictureBox1.Enabled = true;
                        //FrmMain.Instance.XtraTabOpen("FrmTest", "信息");
                        FrmTest frmTest = new FrmTest();
                        frmTest.Show();
                        FrmInfo.Instance.Hide();
                    }));
                });

            }
        }


        private void testUpload()
        {
            //string reportFile = System.Windows.Forms.Application.StartupPath + "/report.xlsm";
            //string sourceFile = System.Windows.Forms.Application.StartupPath + "/clarity.xls";
            Patient.w_code = txtCode.Text.Trim();
            string reportFile = "c:/clasp32/data" + "/test.xlsm";
            string sourceFile = "c:/clasp32/data" + "/clarity.xls";
            string dataFile = System.Windows.Forms.Application.StartupPath + "/data.xml";
            string testFile = ConfigurationManager.AppSettings["sourceAddress"];
            DataProcess dp = new DataProcess(reportFile, sourceFile, testFile, dataFile);
            string infoStr = dp.GetInfoData(txtCode.Text.Trim());
            StreamWriter strmsave = new StreamWriter("E:\\InfoTestTxt.txt", false, System.Text.Encoding.Default);
            strmsave.Write(infoStr);
            strmsave.Close();
        }


        private void checkSheet()
        {
            if (this.txtCode.Text.Length == 0)
            {
                XtraMessageBox.Show("请输入校验码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataProcess dp = new DataProcess();
            string result = dp.getResult(this.txtCode.Text.ToString().Trim());
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            checkSheet();
        }


        private int iPort;
        private int port;

        private bool getICCard()
        {
            bool rtn = false;
            #region 注意，在这里，用户必须有应用程序当前目录的读写权限，（wz.txt：保存的是身份证的信息；zp.bmp：保存的是身份证照片；zp.wlt：保存的是图片二进制信息；）
            FileInfo objFile = new FileInfo("wz.txt");
            if (objFile.Exists)
            {
                objFile.Attributes = FileAttributes.Normal;
                objFile.Delete();
            }

            //string filename = string.Empty;//复制相片路
            //objFile = new FileInfo("zp.bmp");
            //if (objFile.Exists)
            //{
            //    objFile.Attributes = FileAttributes.Normal;
            //    filename = Application.StartupPath + @"\photo\" + Guid.NewGuid().ToString() + "ZP.bmp";
            //    File.Copy(Application.StartupPath + @"\ZP.bmp", filename, true);
            //    objFile.Delete();
            //}

            objFile = new FileInfo("zp.wlt");
            if (objFile.Exists)
            {
                objFile.Attributes = FileAttributes.Normal;
                objFile.Delete();
            }
            #endregion
            #region 获取连接端口
            String sText;
            iPort = 0;
            bool bolAuthent = false; //标记变量判断身份证卡是否寻找到
            if (port <= 0)
            {
                for (iPort = 1001; iPort < 1017; iPort++)
                {
                    //初始化端口方法返回是不是等于1
                    if (ICCardClass.InitComm(iPort) == 1)
                    {
                        //寻卡 129
                        if (ICCardClass.Authenticate() == 1)
                        {
                            bolAuthent = true;
                            /*
                             * Read_Content(1);//读卡方法里面参数的解释：
                             * 1    读基本信息    形成文字信息文件WZ.TXT、相片文件XP.WLT和ZP.BMP
                             * 2    只读文字信息    形成文字信息文件WZ.TXT和相片文件XP.WLT
                             * 3    读最新住址信息    形成最新住址文件NEWADD.TXT
                             * 5    读芯片管理号    形成二进制文件IINSNDN.bin
                            */
                            ICCardClass.Read_Content(1);
                            sText = "读卡器连接在" + iPort + "USB端口上";
                            port = iPort;
                            ICCardClass.CloseComm();//关闭端口
                        }
                        else
                        {
                            bolAuthent = false;
                        }

                    }
                    ICCardClass.CloseComm();
                }
                #endregion 

                #region 读二代身份证
                int nRet = ICCardClass.InitComm(port);
                if (nRet == 1)
                {
                    //寻卡
                    if (bolAuthent == true)
                    {

                        //  GetPhotoBMPIC();
                        Identity.i_name = ICCardClass.GetName();//姓名
                        Identity.i_sex = ICCardClass.GetSex();//性别
                        Identity.i_code = ICCardClass.GetIDCode();//身份证号
                        Identity.i_address = ICCardClass.GetAddress();
                        string birth = ICCardClass.GetBirthday();//出生日期
                        Identity.i_birth_day = birth.Substring(0, 4) + "-" + birth.Substring(4, 2) + "-" + birth.Substring(6);
                        rtn = true;
                    }
                    else
                    {
                        sText = "请把身份证放好，再重试！";
                        XtraMessageBox.Show(sText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    port = 0;//把端口初始化为0
                }
                else
                {
                    sText = "对不起，打开端口错误!请把身份证拿起，再重试！";
                    MessageBox.Show(sText, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ICCardClass.CloseComm();
                #endregion
            }
            return rtn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getICCard();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Identity.i_address = null;
            Identity.i_birth_day = null;
            Identity.i_code = null;
            Identity.i_name = null;
            Identity.i_sex = null;
            OrderList ol = new OrderList();
            if (getICCard())
            {
                //if (true) { 
                DataProcess dp = new DataProcess();
                string name = Identity.i_code;
                string msg = dp.getInfoByID(name);
                if (msg.Length == 0)
                {
                    XtraMessageBox.Show("验证身份证时出错，请重试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (msg == "-1")
                {
                    XtraMessageBox.Show("没有未使用的订单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (msg == "-2")
                {
                    XtraMessageBox.Show("未找到联系人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (msg == "-3")
                {
                    XtraMessageBox.Show("未查询到诊疗师信息或者未绑定门店！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ol = getOrder(msg);
                    List<OrderData> olist = ol.datas;
                    OrderSelect osFrm = new OrderSelect(olist);
                    if (osFrm.ShowDialog() == DialogResult.OK)
                    {
                        txtCode.Text = osFrm.verifyCode;
                        txtBirthDay.Text = Identity.i_birth_day;
                        txtName.Text = Identity.i_name;
                        txtSex.Text = Identity.i_sex;
                        //txtBirthPlace.Text = getPlace("北京市市辖区朝阳区");
                        txtBirthPlace.Text = getPlace(Identity.i_address);
                        osFrm.Close();
                    }
                }
            }
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

        private string getPlace(string address)
        {
            if (address == null)
            {
                return "";
            }
            string rtn = "";
            Regex rx = new Regex(@"(?<province>[^省]+自治区+市|.*?省|.*?自治区|.*?行政区|.*?市)(?<city>[^市]+自治州|.*?地区|.*?行政单位|.+盟|市辖区|.*?市|.*?县|.*?区)(?<county>[^县]+县|.+区|.+市|.+旗|.+海域|.+岛)?(?<town>[^区]+区|.+镇)?(?<village>.*)");
            foreach (Match match in rx.Matches(address))
            {
                GroupCollection groups = match.Groups;
                int i = groups.Count;
                if (i > 1)
                {
                    if (i == 2)
                    {
                        rtn = groups[1].Value;
                    }
                    //else if(i>3)
                    //{
                    //    rtn = groups[1].Value+ groups[2].Value+groups[3].Value;
                    //}
                    else
                    {
                        rtn = groups[1].Value + groups[2];
                    }
                    return rtn;
                }
            }
            return rtn;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            testUpload();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("是否开始上传健康档案？", "重新上传", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.simpleButton4.Enabled = false;
                splashScreenManager2.ShowWaitForm();
                splashScreenManager2.SetWaitFormCaption("健康档案正在处理上传中。。。");
                int[] result = new int[3];
                Task.Factory.StartNew(() =>
                {
                    result = uploadSource();

                }).ContinueWith(x =>
                {

                    this.Invoke((MethodInvoker)(() =>
                    {
                        splashScreenManager2.CloseWaitForm();
                        XtraMessageBox.Show(result[0] + "份健康档案成功上传," + result[1] + "份健康档案上传失败," + result[2] + "份健康档案无效或已处理", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        checkWaitedSource();
                        this.simpleButton4.Enabled = true;
                    }));
                });
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
                //splashScreenManager2.SetWaitFormCaption("待处理健康档案数为" + fi.Length+"。。。");
                //Thread.Sleep(2000);
                int i = 1;
                foreach (FileInfo file in fi)
                {
                    int rtn = SourceProcess(file);
                    splashScreenManager2.SetWaitFormCaption("第" + i + "个健康档案正在处理上传中。。。");
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
            if (fileDetail.Length == 2)
            {
                verifyCode = fileDetail[0];
                string fileType = fileDetail[1];
                //文件有问题，删除文件
                if (fileType != "bak")
                {
                    File.Delete(file.FullName);
                    return -1;
                }
                DataProcess dpN = new DataProcess();
                string msg = dpN.validCode(verifyCode);
                //校验码有问题，删除文件
                if (msg.Length > 0)
                {
                    File.Delete(file.FullName);
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
            bool rtn = dp.uploadInfo(1, verifyCode);
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
    }
}
