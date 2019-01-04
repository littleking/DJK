using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Configuration;
using System.Threading;
using System.Data;
using DevExpress.XtraEditors;
using System.Xml;

namespace QiYuan
{
    public class DataProcess
    {
        private string reportFile;
        private string sourceFile;
        private string testFile;
        private string dataFile;
        //private string resultFile = System.Windows.Forms.Application.StartupPath + "/result.xlsm";
        private string resultFile = "c:/clasp32/data" + "/result.xlsm";
        private string risksFile = System.Windows.Forms.Application.StartupPath + "/risks.xml";
        private string infoFile = System.Windows.Forms.Application.StartupPath + "/info.xml";
        private string sourceFileName;
        private string verifyCode;
        private ValidateJson vjList;
        private KGMWebService.GmWebServletClient webService;
        private bool isAdult;

        public DataProcess(string reportFile, string sourceFile, string testFile, string dataFile)
        {
            this.reportFile = reportFile;
            this.sourceFile = sourceFile;
            this.testFile = testFile;
            this.dataFile = dataFile;
            this.sourceFileName = "";
            this.verifyCode = "";
            string ws = ConfigurationManager.AppSettings["WSAddress"].ToString();
            webService = new KGMWebService.GmWebServletClient("GmWebServletImplPort", ws);
            isAdult = true;
        }

        public DataProcess()
        {
            this.sourceFileName = "";
            this.verifyCode = "";
            string ws = ConfigurationManager.AppSettings["WSAddress"].ToString();
            webService = new KGMWebService.GmWebServletClient("GmWebServletImplPort", ws);
            isAdult = true;
        }

        private string GetRiskData(string verifyCode)
        {
            string data = "";
            XmlDocument xmlDocument = new XmlDocument();
            if (File.Exists(risksFile))
            {
                RiskList rl = new RiskList();
                rl.verifyCode = verifyCode;
                List<RiskData> riskDataList = new List<RiskData>();
                xmlDocument.Load(risksFile);
                XmlElement xmlElement = xmlDocument.DocumentElement;
                XmlNodeList nodeList = xmlElement.ChildNodes;
                XmlNodeList nodeList2 = nodeList[1].ChildNodes;
                foreach (XmlNode item in nodeList2)
                {
                    RiskData rd = new RiskData();
                    rd.name = item.Attributes["Name"].Value;
                    rd.no = item.Attributes["No"].Value;
                    rd.value = item.Attributes["Value"].Value;
                    riskDataList.Add(rd);
                }
                rl.riskDatas = riskDataList;
                data = JsonConvert.SerializeObject(rl);
            }
            return data;
        }

        public string GetInfoData(string verifyCode)
        {
            string data = "";
            XmlDocument xmlDocument = new XmlDocument();
            RiskList rl = new RiskList();
            rl.verifyCode = verifyCode;
            List<RiskData> riskDataList = new List<RiskData>();
            if (File.Exists(infoFile))
            {
                xmlDocument = new XmlDocument();
                xmlDocument.Load(infoFile);
                XmlElement xmlElement = xmlDocument.DocumentElement;
                XmlNodeList nodeList = xmlElement.ChildNodes;
                XmlNodeList nodeList2 = nodeList[1].ChildNodes;
                foreach (XmlNode item in nodeList2)
                {
                    RiskData rd = new RiskData();
                    rd.name = item.Attributes["Name"].Value;
                    rd.no = item.Attributes["No"].Value;
                    string value = "";
                    try
                    {
                        value = item.Attributes["Value"].Value;
                    }
                    catch (Exception ex)
                    {
                        value = "";
                    }
                    rd.value = value;
                    riskDataList.Add(rd);
                }
            }
            int count = riskDataList.Count + 2;
            if (File.Exists(risksFile))
            {
                xmlDocument = new XmlDocument();
                xmlDocument.Load(risksFile);
                XmlElement xmlElement = xmlDocument.DocumentElement;
                XmlNodeList nodeList = xmlElement.ChildNodes;
                XmlNodeList nodeList2 = nodeList[1].ChildNodes;
                foreach (XmlNode item in nodeList2)
                {
                    RiskData rd = new RiskData();
                    rd.name = item.Attributes["Name"].Value;
                    rd.no = count + "";
                    rd.value = item.Attributes["Value"].Value;
                    riskDataList.Add(rd);
                    count++;
                }
            }
            rl.riskDatas = riskDataList;
            data = JsonConvert.SerializeObject(rl);
            return data;
        }

        public string validOrder(string orderName)
        {
            string rtn = "";
            if (orderName.IndexOf("_") > 0)
            {
                string[] nameCode = orderName.Split('_');
                if (nameCode.Length == 2)
                {
                    string code = nameCode[1];
                    verifyCode = code;
                    try
                    {
                        string strOrder = webService.isExistOrder(code, CurrentUser.UserName);
                        if (strOrder.Length > 2)
                        {
                            vjList = getValidate(strOrder);
                            if (vjList.name.Length > 0)
                            {
                                return rtn;
                            }
                            string pType = vjList.peopleType;

                        }
                        else if (strOrder == "-1")
                        {
                            rtn = "验证码不存在，或者被使用,";
                        }
                        else if (strOrder == "-2")
                        {
                            rtn = "门店用户未设置所属门店,";
                        }
                        else if (strOrder == "-3")
                        {
                            rtn = "订单预约门店与使用门店不同,";
                        }
                        else if (strOrder == "-4")
                        {
                            rtn = "订单状态不可用,";
                        }
                    }
                    catch (Exception ex)
                    {
                        rtn = "验证时出错";
                        string er = ex.ToString();
                        LogHelper.WriteLog(ex.ToString());
                    }

                }
                else
                {
                    rtn = "验证码录入有误,";
                }
            }
            else
            {
                rtn = "验证码录入有误,";
            }
            return rtn;
        }

        public string getInfoByID(string id)
        {
            string rtn = "";
            try
            {
                rtn = webService.getOrderInfoByPeopleNo(CurrentUser.UserName, id);
            }
            catch (Exception ex)
            {
                string er = ex.ToString();
                LogHelper.WriteLog(ex.ToString());
            }
            return rtn;
        }
        public string validCode(string verifyCode)
        {
            string rtn = "";
            try
            {
                string strOrder = webService.isExistOrder(verifyCode, CurrentUser.UserName);
                if (strOrder.Length > 2)
                {
                    vjList = getValidate(strOrder);
                    if (vjList.name.Length > 0)
                    {
                        return rtn;
                    }
                    string pType = vjList.peopleType;

                }
                else if (strOrder == "-1")
                {
                    rtn = "验证码不存在，或者被使用,";
                }
                else if (strOrder == "-2")
                {
                    rtn = "门店用户未设置所属门店,";
                }
                else if (strOrder == "-3")
                {
                    rtn = "订单预约门店与使用门店不同,";
                }
                else if (strOrder == "-4")
                {
                    rtn = "订单状态不可用,";
                }
            }
            catch (Exception ex)
            {
                rtn = "验证时出错";
                string er = ex.ToString();
                LogHelper.WriteLog(ex.ToString());
            }
            return rtn;
        }

        public string getResult(string orderName)
        {
            string rtn = "";

            verifyCode = orderName;
            try
            {
                rtn = webService.getResult(verifyCode);
                // rtn = "{\"datas\":[{\"key\":\"77a0f0b6ab0f4948bd30a2025a38b339\",\"title\":\"您最想关注您身体下列哪方面问题\",\"result\":\"失眠\"},{\"key\":\"a4b528e3ccb84db0877b9f2765187215\",\"title\":\"有何主要的症状\",\"result\":\"12\"},{\"key\":\"fe839cc388734bce8fb0876edb06dd5e\",\"title\":\"您是否安装心脏起搏器\",\"result\":\"是\"}]}";
            }
            catch (Exception ex)
            {
                rtn = "";
                string er = ex.ToString();
                LogHelper.WriteLog(ex.ToString());
            }

            return rtn;
        }
        public bool uploadInfo(int type, string vCode)   //type 0: 正常上传， type 1: 补充上传
        {
            bool rtn = false;
            string code = "";
            bool isCorrect = false;
            string errormsg = "";
            string name = "";

            if (File.Exists(testFile))
            {
                if (File.Exists(sourceFile))
                {
                    File.Delete(sourceFile);
                }
                File.Copy(testFile, sourceFile);
                FileInfo fileInfo = new FileInfo(sourceFile);

                //有最新文件，开始上传数据
                //先检查数据源中的校验码是否正确
                Excel.ApplicationClass excel = new Excel.ApplicationClass();
                //MessageBox.Show(excel.Version);
                excel.Visible = false;
                excel.Workbooks.Open(sourceFile, Type.Missing, Type.Missing, Type.Missing, "halleluja", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


                Excel.Worksheet ws = (Excel.Worksheet)excel.Worksheets[2];
                name = ((Excel.Range)ws.Cells[3, 3]).Text.ToString();
                sourceFileName = name;
                excel.Quit();

                IntPtr t = new IntPtr(excel.Hwnd);
                int k = 0;
                GetWindowThreadProcessId(t, out k);
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                p.Kill();

                if (type == 0)
                {
                    if (Patient.w_code != "")
                    {
                        code = Patient.w_code;
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
                                //if (pType == "1")
                                //{
                                //    isAdult = false;
                                //}
                                //else
                                //{
                                //    isAdult = true;
                                //}


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
                            LogHelper.WriteLog(ex.ToString());
                        }

                    }
                    else
                    {
                        errormsg = "验证码录入有误,";
                    }
                }
                else
                {
                    verifyCode = vCode;
                    isCorrect = true;
                }


                //上传文件到服务器
                //verifyCode = "hahahaha";
                FTPUpLoad();

                //有更新文件，但是文件有问题
                if (!isCorrect)
                {
                    File.Delete(sourceFile);
                    //SetValue("ChangeTime", latestTime);
                    LogHelper.WriteLog(sourceFileName + "-" + errormsg + "文件存在问题，云端处理数据失败！");
                    //XtraMessageBox.Show(sourceFileName + "-" + errormsg + "云端处理数据失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                //SetValue("ChangeTime", latestTime);
                LogHelper.WriteLog("开始云端处理数据");
                //copyTemp();
                string temp = System.Windows.Forms.Application.StartupPath + "/DevExpress.Map.v16.2.dll";
                copyStream(reportFile, temp);
                //上传数据
                //Thread thdSub = new Thread(new ThreadStart(ThreadFun));
                //thdSub.Start();
                rtn = ThreadFun();
            }
            return rtn;
        }

        private void copyStreamBak()
        {
            if (File.Exists(reportFile))
            {
                File.Delete(reportFile);
            }
            string temp = System.Windows.Forms.Application.StartupPath + "/DevExpress.Map.v16.2.dll";
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

        private bool ThreadFun()
        {
            bool rtn = true;
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
                if (File.Exists(reportFile))
                {
                    File.Delete(reportFile);
                }
                File.Delete(sourceFile);
                LogHelper.WriteLog(sourceFileName + "-Excel权限问题或没有安装，云端处理数据失败!");
                // XtraMessageBox.Show("Excel问题导致云端处理数据失败,请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            File.Delete(sourceFile);

            bool uploaded = false;
            int loadCount = 0;
            while (!uploaded && loadCount < 3)
            {
                uploaded = uploadData();
                loadCount++;
                string tt = uploaded ? "-云端处理数据成功!" : "-云端处理数据失败!";
                LogHelper.WriteLog(sourceFileName + tt + "-" + loadCount);
            }

            File.Delete(resultFile);
            LogHelper.WriteLog("云端处理数据结束");
            if (!uploaded)
            {
                LogHelper.WriteLog(sourceFileName + "---云端数据处理分析失败,请联系管理员查找原因！！！");
                //XtraMessageBox.Show(sourceFileName + "---云端数据处理分析失败,请联系管理员查找原因！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }
            else
            {
                LogHelper.WriteLog("云端数据处理成功！");
                //XtraMessageBox.Show("云端数据处理成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = true;
            }
            return rtn;


        }

        private bool uploadData()
        {
            bool goodData = true;
            bool uploaded = false;
            int errI = 0;
            string base64Str = ReadXlsToBase64(resultFile);
            string riskStr = GetRiskData(verifyCode);
            FileStream input = new FileStream(resultFile, FileMode.Open);
            int haha = 0;
            try
            {
                XSSFWorkbook xssfworkbook = new XSSFWorkbook(input);
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
                sheetI = xssfworkbook.GetSheet("Matrix");
                List<MatrixData> matrixList = new List<MatrixData>();

                for (int i = 3; i <= 10765; i++)
                {
                    haha = i;
                    IRow dataRow = sheetI.GetRow(i);
                    if (dataRow.Cells.Count <= 1)
                    {
                        continue;
                    }
                    string code = dataRow.GetCell(2).ToString();
                    string value = dataRow.GetCell(3) == null ? "" : dataRow.GetCell(3).ToString();
                    if (value.Length == 0 || value == "#N/A")
                    {
                        value = "0";
                        continue;
                    }
                    MatrixData md = new MatrixData();
                    md.code = code;
                    md.value = value;
                    matrixList.Add(md);
                }
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
                            if (dataRow == null)
                            {
                                continue;
                            }
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
                //StreamWriter strmsave = new StreamWriter("E:\\NewTestTxt.txt", false, System.Text.Encoding.Default);
                //strmsave.Write(rtnJson);
                //strmsave.Close();

                if (riskStr.Length > 0)
                {
                    string txtOut = webService.jsonOutTxt(riskStr, verifyCode);
                    if (txtOut == "1")
                    {
                        LogHelper.WriteLog(verifyCode + "---" + "risks上传成功");
                    }
                    else
                    {
                        LogHelper.WriteLog(verifyCode + "---" + "risks上传失败" + txtOut);
                    }
                }
                if (rtnJson.Length > 0)
                {
                    string saveStr = webService.datacodeOutJson(rtnJson, verifyCode);// .saveScheduling(rtnJson);
                    if (saveStr == "1")
                    {
                        LogHelper.WriteLog(verifyCode + "---" + "DataCode上传成功");
                    }
                    else
                    {
                        LogHelper.WriteLog(verifyCode + "---" + "DataCode上传失败" + saveStr);
                    }
                }
                if (base64Str.Length > 0)
                {
                    string xlsOut = webService.fileOutXls(base64Str, verifyCode, dl.orderid, ttime);
                    if (xlsOut == "1")
                    {
                        uploaded = true;
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
                if (File.Exists(reportFile))
                {
                    File.Delete(reportFile);
                }
                string errorStr = errI.ToString();
                LogHelper.WriteLog("上传数据错误" + "---------" + errorStr);

                uploaded = false;
            }
            finally
            {
                input.Close();
            }
            return uploaded;
        }

        private void copyTemp()
        {
            string tempFile = "";
            //if (isAdult)
            //{
            //    tempFile = System.Windows.Forms.Application.StartupPath + "/temp/report_adult.xlsm";
            //    dataFile = System.Windows.Forms.Application.StartupPath + "/data.xml";
            //}
            //else
            //{
            //    tempFile = System.Windows.Forms.Application.StartupPath + "/temp/report_kid.xlsm";
            //    dataFile = System.Windows.Forms.Application.StartupPath + "/data_kid.xml";
            //}
            tempFile = System.Windows.Forms.Application.StartupPath + "/tempreport/report.xlsm";
            dataFile = System.Windows.Forms.Application.StartupPath + "/data.xml";
            if (File.Exists(reportFile))
            {
                File.Delete(reportFile);
            }
            File.Copy(tempFile, reportFile);
        }

        public bool CreateReport()
        {
            bool rtn = false;
            try
            {
                if (File.Exists(sourceFile))
                {
                    File.Delete(sourceFile);
                }
                File.Copy(testFile, sourceFile);
                copyTemp();
                Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                excel.Visible = false;
                excel.Workbooks.Open(reportFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                IntPtr t = new IntPtr(excel.Hwnd);
                int k = 0;
                GetWindowThreadProcessId(t, out k);
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                p.Kill();
                rtn = true;
                File.Delete(sourceFile);
            }
            catch (Exception ex)
            {
                File.Delete(sourceFile);
                //WriteLog(sourceFileName + "-Excel权限问题或没有安装，数据没有上传!");
                //MessageBox.Show("Excel问题导致上传失败,请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rtn = false;
            }

            return rtn;
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
                    LogHelper.WriteLog(filename + "发送成功");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(filename + "发送失败");
                string bakPath = System.Windows.Forms.Application.StartupPath + "/sourceBak/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/";
                if (!Directory.Exists(bakPath))
                    Directory.CreateDirectory(bakPath);
                FileInfo file = new FileInfo(sourceFile);
                file.CopyTo(bakPath + filename, true);
                if (File.Exists(copyname))
                {
                    File.Delete(copyname);
                }
                LogHelper.WriteLog(ex.Message);
            }
        }


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

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

    }
}
