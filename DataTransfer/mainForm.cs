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


namespace DataTransfer
{
    public partial class mainForm : Form
    {
        private string sourceFile = System.Windows.Forms.Application.StartupPath + "/clarity.xls";
        private string testFile = System.Windows.Forms.Application.StartupPath + "/test.xls";
        private DJK.Model.djk_SourceData modelSourceData = new DJK.Model.djk_SourceData();
        private DJK.DAL.djk_SourceData dalSourceData = new DJK.DAL.djk_SourceData();
        public mainForm()
        {
            InitializeComponent();
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out   int ID);

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
                        textBox1.AppendText("文件保存成功---耗时"+time+"秒" + "\n");
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
                    MatrixParser mp= new MatrixParser();
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
                            if (infoData.ReturnType.ToString() == "System.Double"||infoData.ReturnType.ToString()== "System.Nullable`1[System.Double]")
                            {
                                TestData td = new TestData();
                                if (infoData.ReturnType.ToString() == "System.Nullable`1[System.Double]")
                                {
                                    if(infoData.Invoke(obj, null)==null){
                                        td.value = "";
                                    }
                                    else
                                    {
                                        td.value = infoData.Invoke(obj, null).ToString() ;
                                        string hh = "";
                                    }
                                }
                                else
                                {
                                    td.value = infoData.Invoke(obj, null).ToString() ;
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
                        string sqlUpdate = "update djk_SourceData set isExported=1,exportDate='"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"' where id=" + sourceId;
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
    }
}
