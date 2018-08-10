using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using DevExpress.XtraEditors;
using System.Text;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace JHHY
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Process instance = RunningInstance();
            if (instance == null)
            {


                //#if(!DEBUG)
                //                #region 检查升级
                //                try
                //                {

                //                    bool b = IsAppUpdate();
                //                    if (b)
                //                    {
                //                        //启动升级
                //                        ShellExecute(IntPtr.Zero, "Open", "AppUpdate.exe", null, Application.StartupPath, 1);
                //                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                //                    }
                //                }
                //                catch (System.Exception ex)
                //                {
                //                    XtraMessageBox.Show("启动升级模块失败,请及时联系武汉威仕达软件工程有限公司");
                //                    return;
                //                }
                //                #endregion
                //#endif


                #region 捕获全局异常
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                #endregion

                try
                {
                    //第三方皮肤
                    DevExpress.UserSkins.BonusSkins.Register();
                    DevExpress.Skins.SkinManager.EnableFormSkins();

                }
                catch { }

                #region 应用程序的主入口点
                //调用“更换用户”的方法 执行以下代码报错
                if (!SysVar.IsChangeUser)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                }
                //获取客户端系统名称
                string strTitle = SettingHelper.ReadSetting("ClientTitle");
                //得到本地版本号
                System.Reflection.AssemblyName name = System.Reflection.AssemblyName.GetAssemblyName(SettingHelper.ReadSetting("ClientName"));
                string clientVersion = name.Version.ToString();
                //SysVar.SysTitle = strTitle + "　" + clientVersion;
                SysVar.SysTitle = strTitle;
                //启动登陆
                //FrmLogin myLogin = new FrmLogin();

                //Starter starter = new Starter();
                //starter.Show();
                SysVar.IsChangeUser = true;
                SysVar.dtNow = DateTime.Now;
                SysVar.dtOld = DateTime.Now;

                SysVar.isLocal = false;
                //SysVar.isLocal = true;

                //FrmInfo frmM = new FrmInfo();
                //Application.Run(frmM);


                //SplashScreenManager.ShowForm(typeof(SplashStart));
                //Thread.Sleep(3000);
                //FrmInfo i = new FrmInfo();
                //FrmInfo.Instance = i;
                //SplashScreenManager.CloseForm();
                //Application.Run(i);

                FrmInfo i = new FrmInfo();
                FrmInfo.Instance = i;
                if (!SysVar.isLocal)
                {
                    FrmLogin myLogin = new FrmLogin();
                    if (myLogin.ShowDialog() != DialogResult.OK)
                    {
                        myLogin.Dispose();
                        Application.Exit();
                        return;
                    }
                }
                Application.Run(i);





                #endregion
            }
            else
            {
                HandleRunningInstance(instance);
            }
        }

        private static void BeginInvoke(MethodInvoker methodInvoker)
        {
            throw new NotImplementedException();
        }

        #region 调用其他程序
        /// <summary>
        /// 调用其他程序
        /// </summary>
        [DllImport("Shell32.dll")]
        public static extern int ShellExecute(
            IntPtr hwnd,
            string lpOperation,      //多为"open"
            string lpFile,           //文件名称
            string lpParameters,
            string lpDirectory,      //文件路径
            int nShowCmd
        );
        #endregion

        #region 启动检测是否需要升级
        /// <summary>
        /// 启动检测是否需要升级
        /// </summary>
        /// <returns></returns>
        public static bool IsAppUpdate()
        {
            bool update = false;
            //得到版本地址
            string strUpdateUrl = SettingHelper.ReadSetting("AppUpdateURL");
            //得到服务器文件
            try
            {
                //得到服务器版本号
                WebRequest wRequest = WebRequest.Create(strUpdateUrl);
                WebResponse wResponse = wRequest.GetResponse();
                Stream stream = wResponse.GetResponseStream();
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
                string strResult = reader.ReadToEnd();
                string serverVersion = strResult.Split('|')[0];

                //写入服务器版本信息
                Ini.IniWriteValue("Config", "AvailableVersion", serverVersion);
                Ini.IniWriteValue("Config", "ApplicationUrl", strResult.Split('|')[1]);
                Ini.IniWriteValue("Config", "ApplicationLog", strResult.Split('|')[2]);
                //返回
                return update;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("请检查升级地址是否正确！\n" + strUpdateUrl + "\n" + ex.ToString(), "错误");
                return false;
            }
        }
        #endregion


        #region 捕获全局异常
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            XtraMessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            XtraMessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            //记录错误日志
            Record(sb.ToString());
            string ss = "程序出现错误，请联系管理员！";
            return ss;
            //return sb.ToString();
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="ex"></param>
        static void Record(string strError)
        {
            string filename = Application.StartupPath + @"\Error.Log";
            FileStream fs = File.Open(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(strError);
            sw.Close();
        }
        #endregion

        #region  确保程序只运行一个实例
        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表 
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程 
                if (process.Id != current.Id)
                {
                    //保证要打开的进程同已经存在的进程来自同一文件路径
                    if (System.Reflection.Assembly.GetExecutingAssembly().Location.Replace('/', '\'') == current.MainModule.FileName)
                    {
                        //返回已经存在的进程
                        return process;
                    }
                }
            }
            return null;
        }

        private static void HandleRunningInstance(Process instance)
        {
            MessageBox.Show("程序已经在运行！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowWindowAsync(instance.MainWindowHandle, 1);  //调用api函数，正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端
        }
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);
        #endregion


    }
}
