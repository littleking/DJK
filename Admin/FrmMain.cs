using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DJK.DAL;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Formula;
using DJK.Model;

namespace Admin
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {

        private string sourceFile = System.Windows.Forms.Application.StartupPath + "/clarity.xls";
        List<MatrixParser> mpList;
        List<InfoParser> ipList;
        public FrmMain()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            FrmDataManage manage = new FrmDataManage();
            manage.Show();
        }

        private void CalculateData()
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
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormCaption("正在加载数据");
                    splashScreenManager1.SetWaitFormDescription(" 请等待。。。");
                    SaveFileToDB(true, sourceFile, "halleluja");
                    splashScreenManager1.SetWaitFormCaption("正在计算");
                    FrmCalculation frmCal = new FrmCalculation(mpList, ipList);
                    splashScreenManager1.CloseWaitForm();
                    frmCal.Show();

                }
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CalculateData();
            //DJK.DAL.admin_Clarity dal = new admin_Clarity();
            //DJK.Model.admin_Clarity model = new DJK.Model.admin_Clarity();
            //int infoTotal = 332;
            //int matrixTotal = 10766;
            //for (int i = 1; i <= infoTotal; i++)
            //{
            //    model = new DJK.Model.admin_Clarity();
            //    model.SourceNum = i;
            //    model.SourceTable = "info";
            //    dal.Add(model);
            //}
            //for (int j = 1; j <= matrixTotal; j++)
            //{
            //    model = new DJK.Model.admin_Clarity();
            //    model.SourceNum = j;
            //    model.SourceTable = "matrix";
            //    dal.Add(model);
            //}


        }


        private void button2_Click(object sender, EventArgs e)
        {
            FrmSourceManage frmSource = new FrmSourceManage();
            frmSource.Show();
        }

        private void SaveFileToDB(bool hasTitle, string fileName, string password)
        {

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Workbook workbook = null;
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                if (app == null) return;
                workbook = app.Workbooks.Open(fileName, oMissiong, oMissiong, oMissiong, password, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;



                //将数据读入

                //worksheet 1
                Microsoft.Office.Interop.Excel.Worksheet ws = (Worksheet)sheets.get_Item(1);
                if (ws == null) return ;

                string machineSourceCode = ((Range)ws.Cells[1, 1]).Text.ToString();
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
                string serialCode = ((Microsoft.Office.Interop.Excel.Range)ws.Cells[3, 3]).Text.ToString();
                if (serialCode.IndexOf("_") > 0)
                {
                    string[] serialCodes = serialCode.Split('_');
                    if (serialCodes.Length == 2)
                    {
                        serialCode = serialCodes[1];
                    }
                }

                string sex = ((Range)ws.Cells[11, 3]).Text.ToString().ToLower();

                int iRowCount = ws.UsedRange.Rows.Count;
                int iColCount = ws.UsedRange.Columns.Count;

                //生成行数据 info
                ipList = new List<InfoParser>();
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

                mpList = new List<MatrixParser>();
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

                

                string dsd = "";


            }
            catch(Exception ex)
            {
                string exxx = ex.ToString();
                return ;
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

        private void button3_Click(object sender, EventArgs e)
        {
            CalculateData();
        }
    }
}
