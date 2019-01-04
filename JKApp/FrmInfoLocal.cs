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
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace JKApp
{
    public partial class FrmInfoLocal : XtraForm
    {
        private TestHelper th;
        private static string encryptKey = "%ghe";

        public FrmInfoLocal()
        {
            InitializeComponent();
            runBat();
            th = new TestHelper();
            this.labelControl1.Text = "健康检测系统运用高科技手段有效检测不同人群在身、心、灵多层面的健康风险，并精准评估，\r\n靶向调理，形成健康追踪、无创干预、慢病管理、诊疗指导等全方位的健康管理体系。";
            this.txtSex.SelectedIndex = -1;
            txtSex.Properties.Items.Add("男");
            txtSex.Properties.Items.Add("女");
            this.txtName.Text = "";
            this.txtBirthDay.Text = "";
            this.txtBirthPlace.Text = "";
            string tempFolder = "c:/clasp32/data/temp/";
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }
        }

        private string Decrypt(string str)
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

        private bool checkOurProcess()
        {
            try
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
            }catch(Exception ex)
            {
                return false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!checkOurProcess())
            {
                XtraMessageBox.Show("程序授权已过期或出现错误！请联系管理员更新授权文件。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ValidateInfo())
            {
                killP();
                Patient.w_name = txtName.Text.Trim();
                Patient.w_birth_day = txtBirthDay.Text;
                Patient.w_location = txtBirthPlace.Text.Trim();
                Patient.w_sex = txtSex.Text == "男" ? "Male" : "Female";
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
                splashScreenManager1.ShowWaitForm();
                Task.Factory.StartNew(() =>
                {
                    th.TestLaunch(this.checkEdit1.Checked);
                    Thread.Sleep(15000);
                    if (!th.TestDevice())
                    {
                        killP();
                        this.simpleButton1.Enabled = true;
                        splashScreenManager1.CloseWaitForm();
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
                            splashScreenManager1.CloseWaitForm();
                            if (XtraMessageBox.Show(testMsg + "绑带检测未通过，是否重新检测？选Yes将重试，选No将跳过绑带检测", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                            {
                                splashScreenManager1.ShowWaitForm();
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

                }).ContinueWith(x =>
                            {
                                if (!hasDev)
                                {
                                    return;
                                }
                                if (splashScreenManager1.IsSplashFormVisible)
                                {
                                    splashScreenManager1.CloseWaitForm();
                                }
                                this.Invoke((MethodInvoker)(() =>
                    {
                        this.txtSex.SelectedIndex = -1;
                        this.txtName.Text = "";
                        this.txtBirthDay.Text = "";
                        this.txtBirthPlace.Text = "";
                        this.simpleButton1.Enabled = true;
                        //this.pictureBox1.Enabled = true;
                        //FrmMain.Instance.XtraTabOpen("FrmTest", "信息");
                        FrmTestLocal frmTest = new FrmTestLocal();
                        frmTest.Show();
                        FrmInfoLocal.Instance.Hide();
                    }));
                            });

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
        private static FrmInfoLocal mInstance = null;
        /// <summary>
        /// FrmInfoLocal的唯一实体
        /// </summary>
        public static FrmInfoLocal Instance
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

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Identity.i_address = null;
            Identity.i_birth_day = null;
            Identity.i_code = null;
            Identity.i_name = null;
            Identity.i_sex = null;
            if (getICCard())
            {
                txtBirthDay.Text = Identity.i_birth_day;
                txtName.Text = Identity.i_name;
                txtSex.Text = Identity.i_sex;
                txtBirthPlace.Text = getPlace(Identity.i_address);

            }
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
    }
}
