using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Formula;
using System.Reflection;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace DataTransfer
{
    public partial class mainForm : Form
    {
        private string sourceFile = System.Windows.Forms.Application.StartupPath + "/clarity.xls";
        private string testFile = System.Windows.Forms.Application.StartupPath + "/test.xls";
        string reportFile = System.Windows.Forms.Application.StartupPath + "/result.xlsm";
        private string tempPath = System.Windows.Forms.Application.StartupPath + "/DevExpress.Map.v16.2.dll";
        private DJK.Model.djk_SourceData modelSourceData = new DJK.Model.djk_SourceData();
        private DJK.DAL.djk_SourceData dalSourceData = new DJK.DAL.djk_SourceData();
        public mainForm()
        {
            InitializeComponent();
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            if (file1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = null;
                try
                {
                    fileInfo = new FileInfo(file1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if (fileInfo != null && fileInfo.Exists)
                {
                    string filepath = fileInfo.FullName;
                    if (File.Exists(sourceFile))
                    {
                        File.Delete(sourceFile);
                    }
                    File.Copy(filepath, sourceFile);
                    FileInfo dataFile = new FileInfo(sourceFile);

                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    object oMissiong = System.Reflection.Missing.Value;
                    Workbook workbook = null;
                    System.Data.DataTable dt = new System.Data.DataTable();

                    try
                    {
                        workbook = app.Workbooks.Open(sourceFile, oMissiong, oMissiong, oMissiong, "halleluja", oMissiong,
                            oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                        workbook.SaveAs(testFile, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, XlSaveAsAccessMode.xlNoChange, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                    }
                    catch (Exception ex)
                    {
                        string exStr = ex.ToString();
                    }
                    finally
                    {
                        workbook.Close(false, oMissiong, oMissiong);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                        workbook = null;
                        app.Workbooks.Close();
                        app.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    }


                    //Excel.ApplicationClass excel = new Excel.ApplicationClass();
                    ////MessageBox.Show(excel.Version);
                    //excel.Visible = false;
                    //excel.Workbooks.Open(sourceFile, Type.Missing, Type.Missing, Type.Missing, "halleluja", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    //Excel.Worksheet ws = (Excel.Worksheet)excel.Worksheets[1];
                    //string machineSourceCode = ((Excel.Range)ws.Cells[1, 1]).Text.ToString();
                    //string machineCode = "";

                    //ws = (Excel.Worksheet)excel.Worksheets[2];
                    //string serialCode = ((Excel.Range)ws.Cells[3, 3]).Text.ToString();
                    //if (serialCode.IndexOf("_") > 0)
                    //{
                    //    string[] serialCodes = serialCode.Split('_');
                    //    if (serialCodes.Length == 2)
                    //    {
                    //        serialCode = serialCodes[1];
                    //    }
                    //}
                    //if (machineSourceCode.IndexOf("=") > 0)
                    //{
                    //    string[] machineCodes = machineSourceCode.Split('=');
                    //    if (machineCodes.Length == 2)
                    //    {
                    //        machineCode = machineCodes[1];
                    //    }
                    //}
                    //string sex = ((Excel.Range)ws.Cells[11, 3]).Text.ToString();

                    //excel.Quit();
                    //IntPtr t = new IntPtr(excel.Hwnd);
                    //int k = 0;
                    //GetWindowThreadProcessId(t, out   k);
                    //System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                    //p.Kill();

                    //DateTime t1 = DateTime.Now;

                    //System.Data.DataTable sheetInfo = null;
                    //System.Data.DataTable sheetMatrix = null;
                    //sheetInfo = GetDataFromExcelByCom(true, sourceFile, 2, "halleluja");
                    //sheetMatrix = GetDataFromExcelByCom(true, sourceFile, 3, "halleluja");

                    //string info = JsonConvert.SerializeObject(sheetInfo, new DataTableConverter());
                    //string matrix = JsonConvert.SerializeObject(sheetMatrix, new DataTableConverter());



                    //modelSourceData.infoData = info;
                    //modelSourceData.matrixData = matrix;
                    //modelSourceData.serialCode = serialCode;
                    //modelSourceData.machineCode = machineCode;
                    //modelSourceData.sex = sex;
                    //int ret = dalSourceData.Add(modelSourceData);

                    //DateTime t2 = DateTime.Now;
                    //TimeSpan ts1 = new TimeSpan(t1.Ticks);
                    //TimeSpan ts2 = new TimeSpan(t2.Ticks);
                    //TimeSpan ts = ts2.Subtract(ts1).Duration();
                    //double time = ts.TotalSeconds;

                    DateTime t1 = DateTime.Now;

                    // int ret = SaveFileToDB(true, sourceFile, "halleluja");

                    DateTime t2 = DateTime.Now;
                    TimeSpan ts1 = new TimeSpan(t1.Ticks);
                    TimeSpan ts2 = new TimeSpan(t2.Ticks);
                    TimeSpan ts = ts2.Subtract(ts1).Duration();
                    double time = ts.TotalSeconds;
                    int ret = 0;
                    if (ret > 0)
                    {
                        textBox1.AppendText("文件保存成功---耗时" + time + "秒" + "\n");
                    }
                    else
                    {
                        textBox1.AppendText("文件保存失败" + "\n");
                    }
                }
            }
        }

        private System.Data.DataTable GetDataFromExcelByCom(bool hasTitle, string fileName, int sheetIndex, string password)
        {

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Workbook workbook = null;
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                if (app == null) return null;
                workbook = app.Workbooks.Open(fileName, oMissiong, oMissiong, oMissiong, password, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;

                //将数据读入到DataTable中
                Worksheet worksheet = (Worksheet)sheets.get_Item(sheetIndex);//读取第一张表 
                if (worksheet == null) return null;

                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;
                //生成列头
                for (int i = 0; i < iColCount; i++)
                {
                    var name = "column" + i;
                    if (hasTitle)
                    {
                        var txt = ((Range)worksheet.Cells[1, i + 1]).Text.ToString();
                        if (!string.IsNullOrEmpty(txt)) name = txt;
                    }
                    while (dt.Columns.Contains(name)) name = name + "_1";//重复行名称会报错。
                    dt.Columns.Add(new DataColumn(name, typeof(string)));
                }
                //生成行数据
                Range range;
                int rowIdx = hasTitle ? 2 : 1;
                for (int iRow = rowIdx; iRow <= iRowCount; iRow++)
                {
                    DataRow dr = dt.NewRow();
                    for (int iCol = 1; iCol <= iColCount; iCol++)
                    {
                        range = (Range)worksheet.Cells[iRow, iCol];
                        dr[iCol - 1] = (range.Value2 == null) ? "" : range.Text.ToString();
                    }
                    dt.Rows.Add(dr);
                }



                return dt;
            }
            catch { return null; }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }


        private int SaveFileToDB(bool hasTitle, string fileName, string password)
        {

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Workbook workbook = null;
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                if (app == null) return 0;
                workbook = app.Workbooks.Open(fileName, oMissiong, oMissiong, oMissiong, password, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;



                //将数据读入

                //worksheet 1
                Excel.Worksheet ws = (Worksheet)sheets.get_Item(1);
                if (ws == null) return 0;

                string machineSourceCode = ((Excel.Range)ws.Cells[1, 1]).Text.ToString();
                string machineCode = "";
                if (machineSourceCode.IndexOf("=") > 0)
                {
                    string[] machineCodes = machineSourceCode.Split('=');
                    if (machineCodes.Length == 2)
                    {
                        machineCode = machineCodes[1];
                    }
                }

                ws = (Worksheet)sheets.get_Item(2);
                string serialCode = ((Excel.Range)ws.Cells[3, 3]).Text.ToString();
                if (serialCode.IndexOf("_") > 0)
                {
                    string[] serialCodes = serialCode.Split('_');
                    if (serialCodes.Length == 2)
                    {
                        serialCode = serialCodes[1];
                    }
                }

                string sex = ((Excel.Range)ws.Cells[11, 3]).Text.ToString().ToLower();

                int iRowCount = ws.UsedRange.Rows.Count;
                int iColCount = ws.UsedRange.Columns.Count;

                //生成行数据 info
                List<InfoParser> ipList = new List<InfoParser>();
                Range range;
                int rowIdx = hasTitle ? 2 : 1;
                for (int iRow = rowIdx; iRow <= iRowCount; iRow++)
                {
                    InfoParser ip = new InfoParser();
                    range = (Range)ws.Cells[iRow, 1];
                    ip.No = (range.Value2 == null) ? "" : range.Text.ToString();
                    range = (Range)ws.Cells[iRow, 2];
                    ip.Value = (range.Value2 == null) ? "" : range.Text.ToString();
                    range = (Range)ws.Cells[iRow, 3];
                    ip.Name = (range.Value2 == null) ? "" : range.Text.ToString();
                    ipList.Add(ip);
                }

                //生成行数据 matrix
                ws = (Worksheet)sheets.get_Item(3);
                iRowCount = ws.UsedRange.Rows.Count;
                iColCount = ws.UsedRange.Columns.Count;

                List<MatrixParser> mpList = new List<MatrixParser>();
                for (int iRow = rowIdx; iRow <= iRowCount; iRow++)
                {
                    MatrixParser mp = new MatrixParser();
                    range = (Range)ws.Cells[iRow, 1];
                    mp.No = (range.Value2 == null) ? "" : range.Text.ToString();
                    range = (Range)ws.Cells[iRow, 2];
                    mp.Value = (range.Value2 == null) ? "" : range.Text.ToString();
                    range = (Range)ws.Cells[iRow, 3];
                    mp.Name = (range.Value2 == null) ? "" : range.Text.ToString();
                    range = (Range)ws.Cells[iRow, 4];
                    mp.OldValue = (range.Value2 == null) ? "" : range.Text.ToString();
                    mpList.Add(mp);
                }

                string info = JsonConvert.SerializeObject(ipList);
                string matrix = JsonConvert.SerializeObject(mpList);

                modelSourceData.infoData = info;
                modelSourceData.matrixData = matrix;
                modelSourceData.serialCode = serialCode;
                modelSourceData.machineCode = machineCode;
                modelSourceData.sex = sex;
                int ret = dalSourceData.Add(modelSourceData);

                return ret;
            }
            catch { return 0; }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }

        private int ImportExcel(bool hasTitle, string fileName, string password)
        {

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Workbook workbook = null;
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                if (app == null) return 0;
                workbook = app.Workbooks.Open(fileName, oMissiong, oMissiong, oMissiong, password, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;



                //将数据读入

                //worksheet 1
                Excel.Worksheet ws = (Worksheet)sheets.get_Item(3);

                int iRowCount = ws.UsedRange.Rows.Count;
                int iColCount = ws.UsedRange.Columns.Count;

                Range range;
                int rowIdx = hasTitle ? 2 : 1;

                iRowCount = ws.UsedRange.Rows.Count;
                iColCount = ws.UsedRange.Columns.Count;

                List<MatrixParser> mpList = new List<MatrixParser>();
                for (int iRow = rowIdx; iRow <= iRowCount; iRow++)
                {
                    MatrixParser mp = new MatrixParser();
                    range = (Range)ws.Cells[iRow, 1];
                    mp.No = (range.Value2 == null) ? "" : range.Text.ToString();
                    range = (Range)ws.Cells[iRow, 2];
                    mp.Value = (range.Value2 == null) ? "" : range.Text.ToString();
                    range = (Range)ws.Cells[iRow, 3];
                    mp.Name = (range.Value2 == null) ? "" : range.Text.ToString();
                    range = (Range)ws.Cells[iRow, 4];
                    mp.OldValue = (range.Value2 == null) ? "" : range.Text.ToString();
                    mpList.Add(mp);
                }

                //string matrix = JsonConvert.SerializeObject(mpList);


                return mpList.Count;
            }
            catch (Exception ex)
            {
                string haha = ex.ToString();
                return 0;
            }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = dalSourceData.GetList("isExported=0");
                System.Data.DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DateTime t1 = DateTime.Now;
                        int sourceId = int.Parse(dr["id"].ToString());
                        DataList dl = new DataList();
                        Adult ad = new Adult(sourceId);
                        dl.serialCode = ad.serialCode;
                        dl.sourceID = sourceId;
                        List<TestData> listData = new List<TestData>();
                        double test = ad.zzgj_gm();
                        string aa = "Formula.Adult";
                        Type t = Assembly.Load("Formula").GetType(aa);
                        Object[] parameters = new Object[1];
                        parameters[0] = sourceId;
                        var obj = t.Assembly.CreateInstance(aa, true, System.Reflection.BindingFlags.Default, null, parameters, null, null);
                        MethodInfo[] info = t.GetMethods();
                        foreach (MethodInfo infoData in info)
                        {
                            if (infoData.ReturnType.ToString() == "System.Double" || infoData.ReturnType.ToString() == "System.Nullable`1[System.Double]")
                            {
                                TestData td = new TestData();
                                if (infoData.ReturnType.ToString() == "System.Nullable`1[System.Double]")
                                {
                                    if (infoData.Invoke(obj, null) == null)
                                    {
                                        td.value = "";
                                    }
                                    else
                                    {
                                        td.value = infoData.Invoke(obj, null).ToString();
                                        string hh = "";
                                    }
                                }
                                else
                                {
                                    td.value = infoData.Invoke(obj, null).ToString();
                                    string hh = "";
                                }
                                MyDescription ma = Attribute.GetCustomAttribute(infoData, typeof(MyDescription), false) as MyDescription;
                                td.description = ma.DisplayName;
                                td.code = ma.DisplayCode;
                                listData.Add(td);
                            }
                        }
                        dl.testDatas = listData;
                        string rtnJson = JsonConvert.SerializeObject(dl);
                        List<string> sqlList = new List<string>();
                        string sqlInsert = string.Format("insert into djk_SavedData (sourceID,saveDate,savedData,serialCode) values ('{0}','{1}','{2}','{3}')", sourceId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), rtnJson, ad.serialCode);
                        sqlList.Add(sqlInsert);
                        string sqlUpdate = "update djk_SourceData set isExported=1,exportDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id=" + sourceId;
                        sqlList.Add(sqlUpdate);
                        int re = dalSourceData.ExecuteTransactions(sqlList);
                        DateTime t2 = DateTime.Now;
                        TimeSpan ts1 = new TimeSpan(t1.Ticks);
                        TimeSpan ts2 = new TimeSpan(t2.Ticks);
                        TimeSpan ts = ts2.Subtract(ts1).Duration();
                        int time = ts.Seconds;
                        if (re > 0)
                        {
                            textBox1.AppendText("数据保存成功---耗时" + time + "秒" + "\n");
                        }
                        else
                        {
                            textBox1.AppendText("数据保存失败");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                textBox1.AppendText("数据保存失败,出现错误");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adult ad = new Adult(19);
            double test = ad.xz_T12();
            string haha = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            if (file1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = null;
                try
                {
                    fileInfo = new FileInfo(file1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if (fileInfo != null && fileInfo.Exists)
                {
                    string filepath = fileInfo.FullName;
                    if (File.Exists(sourceFile))
                    {
                        File.Delete(sourceFile);
                    }
                    File.Copy(filepath, sourceFile);
                    DateTime t1 = DateTime.Now;
                    int ret = ImportExcel(true, sourceFile, "halleluja");
                    DateTime t2 = DateTime.Now;
                    TimeSpan ts1 = new TimeSpan(t1.Ticks);
                    TimeSpan ts2 = new TimeSpan(t2.Ticks);
                    TimeSpan ts = ts2.Subtract(ts1).Duration();
                    double time = ts.TotalSeconds;
                    if (ret > 0)
                    {
                        textBox1.AppendText("Excel导入" + ret + "条数据耗时" + time + "秒" + "\n");
                    }
                    else
                    {
                        textBox1.AppendText("Excel导入失败" + "\n");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt;
            OpenFileDialog file1 = new OpenFileDialog();
            if (file1.ShowDialog() == DialogResult.OK)
            {
                string filename = file1.FileName;
                DateTime t1 = DateTime.Now;
                dt = OpenCSV(filename, 0, 0, 0, 0, true);
                int rows = dt.Rows.Count;
                DateTime t2 = DateTime.Now;
                TimeSpan ts1 = new TimeSpan(t1.Ticks);
                TimeSpan ts2 = new TimeSpan(t2.Ticks);
                TimeSpan ts = ts2.Subtract(ts1).Duration();
                double time = ts.TotalSeconds;
                if (rows > 0)
                {
                    textBox1.AppendText("Txt导入" + rows + "条数据耗时" + time + "秒" + "\n");
                }
                else
                {
                    textBox1.AppendText("Txt导入失败" + "\n");
                }
            }

        }

        // <summary>
        /// 打开CSV 文件
        /// </summary>
        /// <param name="fileName">文件全名</param>
        /// <returns>DataTable</returns>
        public static System.Data.DataTable OpenCSV(string fullFileName)
        {
            return OpenCSV(fullFileName, 0, 0, 0, 0, true);
        }

        /// <summary>
        /// 打开CSV 文件
        /// </summary>
        /// <param name="fileName">文件全名</param>
        /// <param name="firstRow">开始行</param>
        /// <param name="firstColumn">开始列</param>
        /// <param name="getRows">获取多少行</param>
        /// <param name="getColumns">获取多少列</param>
        /// <param name="haveTitleRow">是有标题行</param>
        /// <returns>DataTable</returns>
        public static System.Data.DataTable OpenCSV(string fullFileName, Int16 firstRow = 0, Int16 firstColumn = 0, Int16 getRows = 0, Int16 getColumns = 0, bool haveTitleRow = true)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            FileStream fs = new FileStream(fullFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine;
            //标示列数
            int columnCount = 0;
            //是否已建立了表的字段
            bool bCreateTableColumns = false;
            //第几行
            int iRow = 1;

            //去除无用行
            if (firstRow > 0)
            {
                for (int i = 1; i < firstRow; i++)
                {
                    sr.ReadLine();
                }
            }

            // { ",", ".", "!", "?", ";", ":", " " };
            string[] separators = { "|" };
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                strLine = strLine.Trim();
                aryLine = strLine.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);

                if (bCreateTableColumns == false)
                {
                    bCreateTableColumns = true;
                    columnCount = aryLine.Length;
                    //创建列
                    for (int i = firstColumn; i < (getColumns == 0 ? columnCount : firstColumn + getColumns); i++)
                    {
                        DataColumn dc
                            = new DataColumn(haveTitleRow == true ? aryLine[i] : "COL" + i.ToString());
                        dt.Columns.Add(dc);
                    }

                    bCreateTableColumns = true;

                    if (haveTitleRow == true)
                    {
                        continue;
                    }
                }


                DataRow dr = dt.NewRow();
                for (int j = firstColumn; j < (getColumns == 0 ? columnCount : firstColumn + getColumns); j++)
                {
                    dr[j - firstColumn] = aryLine[j];
                }
                dt.Rows.Add(dr);

                iRow = iRow + 1;
                if (getRows > 0)
                {
                    if (iRow > getRows)
                    {
                        break;
                    }
                }

            }

            sr.Close();
            fs.Close();
            return dt;
        }

        public DataSet ExcelToDS(string Path)
        {
            DataSet ds = null;
            string strConn = "Provider=Microsoft.Jet.OLEDB.12.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 12.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            try
            {
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;

                strExcel = "select * from [sheet2$]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataSet();
                myCommand.Fill(ds, "table1");
            }
            catch (Exception ex)
            {
                string ss = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            if (file1.ShowDialog() == DialogResult.OK)
            {
                string filename = file1.FileName;
                DateTime t1 = DateTime.Now;

                DataSet ds = ExcelToDS(filename);
                System.Data.DataTable dt = new System.Data.DataTable();
                if (ds != null)
                {
                    dt = ds.Tables[0];
                }
                int rows = dt.Rows.Count;
                DateTime t2 = DateTime.Now;
                TimeSpan ts1 = new TimeSpan(t1.Ticks);
                TimeSpan ts2 = new TimeSpan(t2.Ticks);
                TimeSpan ts = ts2.Subtract(ts1).Duration();
                double time = ts.TotalSeconds;
                if (rows > 0)
                {
                    textBox1.AppendText("Excel导入" + rows + "条数据耗时" + time + "秒" + "\n");
                }
                else
                {
                    textBox1.AppendText("Excel导入失败" + "\n");
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            if (file1.ShowDialog() == DialogResult.OK)
            {
                string filename = file1.FileName;

                System.Data.DataTable dt = OpenCSV(filename, 0, 0, 0, 0, true);
                int rows = dt.Rows.Count;
                List<string> sqlList = new List<string>();
                int added = 0;
                DJK.DAL.admin_MedicalData dal = new DJK.DAL.admin_MedicalData();
                if (rows > 0)
                {
                    sqlList.Add("delete admin_medicalData");
                    foreach (DataRow dr in dt.Rows)
                    {
                        string sql = string.Format("insert into admin_medicalData(ParentID,ID,Code,Item) values ({0},{1},'{2}','{3}')", dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString().Replace("'", "''"));
                        //int tre = dal.runSql(sql);
                        //added += tre;
                        sqlList.Add(sql);
                    }
                    //DJK.DAL.admin_MedicalData dal = new DJK.DAL.admin_MedicalData();
                    added = dal.insertBulk(sqlList);
                    if (added > 0)
                    {
                        textBox1.AppendText("Trees导入" + rows + "条数据" + "\n");
                    }
                    else
                    {
                        textBox1.AppendText("Trees导入失败" + "\n");
                    }
                }
                else
                {
                    textBox1.AppendText("文件中没有数据" + "\n");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            if (file1.ShowDialog() == DialogResult.OK)
            {
                string filename = file1.FileName;
                ReadXlsToBase64(filename);
            }
        }

        private bool ReadXlsToBase64(string path)
        {
            bool rtn = true;
            try
            {
                FileStream filestream = new FileStream(path, FileMode.Open);
                byte[] bt = new byte[filestream.Length];

                //调用read读取方法  
                filestream.Read(bt, 0, bt.Length);
                string base64Str = Convert.ToBase64String(bt);
                filestream.Close();

                //将Base64串写入临时文本文件  
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
                FileStream fs = new FileStream(tempPath, FileMode.Create);
                byte[] data = System.Text.Encoding.Default.GetBytes(base64Str);
                //开始写入  
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流  
                fs.Flush();
                fs.Close();

                //string outPath = System.Windows.Forms.Application.StartupPath + "/base64Excel.xlsm";
                //var contents = Convert.FromBase64String(base64Str);
                //using (var fss = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                //{
                //    fss.Write(contents, 0, contents.Length);
                //    fss.Flush();
                //}
                textBox1.AppendText("转换完成" + "\n");

            }
            catch (Exception ex)
            {

                textBox1.AppendText("转换失败" + "\n");
                return false;
            }

            File.Delete(sourceFile);


            return rtn;


        }


        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            if (file1.ShowDialog() == DialogResult.OK)
            {
                string filename = file1.FileName;

                System.Data.DataTable dt = OpenCSV(filename, 0, 0, 0, 0, false);
                int rows = dt.Rows.Count;
                List<string> sqlList = new List<string>();
                int added = 0;
                DJK.DAL.admin_MedicalData dal = new DJK.DAL.admin_MedicalData();
                if (rows > 0)
                {
                    sqlList.Add("delete admin_medicalSource");
                    foreach (DataRow dr in dt.Rows)
                    {
                        string sql = string.Format("insert into admin_medicalSource(medicalID,Source,SourceTable,SourceNum,SourceID) values ({0},'{1}','{2}',{3},{4})", dr[0].ToString(), "matrix" + dr[2].ToString(), "matrix", dr[2].ToString(), int.Parse(dr[2].ToString() + 322));
                        //int tre = dal.runSql(sql);
                        //added += tre;
                        sqlList.Add(sql);
                    }
                    //DJK.DAL.admin_MedicalData dal = new DJK.DAL.admin_MedicalData();
                    added = dal.insertBulk(sqlList);
                    if (added > 0)
                    {
                        textBox1.AppendText("Source导入" + rows + "条数据" + "\n");
                    }
                    else
                    {
                        textBox1.AppendText("Source导入失败" + "\n");
                    }
                }
                else
                {
                    textBox1.AppendText("文件中没有数据" + "\n");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string tFile = System.Windows.Forms.Application.StartupPath + "/ttt.xlsm";
            OpenFileDialog file1 = new OpenFileDialog();
            if (file1.ShowDialog() == DialogResult.OK)
            {
                string filename = file1.FileName;
                FileStream filestream = new FileStream(filename, FileMode.Open);
                byte[] bt = new byte[filestream.Length];
                filestream.Read(bt, 0, bt.Length);
                string base64Str = System.Text.Encoding.Default.GetString(bt);
                var contents = Convert.FromBase64String(base64Str);
                using (var fss = new FileStream(tFile, FileMode.Create, FileAccess.Write))
                {
                    fss.Write(contents, 0, contents.Length);
                    fss.Flush();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string keyPath = System.Windows.Forms.Application.StartupPath + "/key.v";
            if (File.Exists(keyPath))
            {
                FileStream filestream = new FileStream(keyPath, FileMode.Open);
                byte[] bt = new byte[filestream.Length];
                filestream.Read(bt, 0, bt.Length);
                string kData = System.Text.Encoding.Unicode.GetString(bt);
                string keyData = Decrypt(kData);
                string key = keyData.Substring(30, 10);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = DateTime.Parse(key);
                }catch(Exception ex)
                {
                    MessageBox.Show("程序授权验证失败，请联系管理员！");
                    return;
                }
                DateTime tDate = DateTime.Now;
                if (tDate > dt)
                {
                    MessageBox.Show("程序授权已经过期，请联系管理员！");
                }
                else
                {
                    MessageBox.Show("正常！");
                }
            }
            else
            {
                MessageBox.Show("程序权限验证失败，请联系管理员！");
            }
        }

        private static string Decrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象    

            string encryptKey = "%dn*";

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
