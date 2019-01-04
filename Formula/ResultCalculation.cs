using DJK.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula
{
    public class ResultCalculation
    {
        List<TestData> mpList;
        List<TestData> ipList;
        private string verifyCode;
        private string healthData;
        private DJK.DAL.admin_MedicalData dalData;
        private DJK.DAL.admin_MedicalSource dalSource;
        private DJK.DAL.admin_Clarity dalClarity;
        private DJK.Model.djk_cloudData modelData;
        private DJK.DAL.djk_cloudData dal;

        public ResultCalculation(string vcode)
        {
            verifyCode = vcode;
            dalClarity = new DJK.DAL.admin_Clarity();
            dalData = new DJK.DAL.admin_MedicalData();
            dalSource = new DJK.DAL.admin_MedicalSource();
            modelData = new DJK.Model.djk_cloudData();
            dal = new DJK.DAL.djk_cloudData();

        }

        public string getResult()
        {
            modelData = dal.GetModel(verifyCode);
            if (modelData == null)
            {
                return "";
            }
            healthData = modelData.healthData;
            TestDatas tds = JsonConvert.DeserializeObject<TestDatas>(healthData);
            mpList = tds.MatrixDatas;
            ipList = tds.InfoDatas;
            string rtn = "";
            List<DJK.Model.admin_MedicalData> result = new List<DJK.Model.admin_MedicalData>();
            List<TestData> resultList = new List<TestData>();
            result = dalData.getModelList();
            foreach (DJK.Model.admin_MedicalData model in result)
            {
                if (model.DataFormula != null && model.DataFormula > 0)
                {
                    int formula = (int)model.DataFormula;
                    int dataMin = (int)(model.DataMin == null ? 0 : model.DataMin);
                    int dataMax = (int)(model.DataMax == null ? 5 : model.DataMax);
                    model.DataValue = getDataValue(formula, model.ID, dataMin, dataMax);
                    TestData td = new TestData();
                    td.no = model.Code;
                    td.name = model.Item;
                    td.value = model.DataValue.ToString();
                    resultList.Add(td);
                }
                rtn =JsonConvert.SerializeObject(resultList);
            }

            return rtn;
        }

        private double getDataValue(int formula, int medicalID, int dataMin, int dataMax)
        {
            double rtn = 0;
            List<DJK.Model.admin_MedicalSource> sourceList = dalSource.getModelList(medicalID);
            List<double> resultList = new List<double>();
            foreach (DJK.Model.admin_MedicalSource model in sourceList)
            {
                DJK.Model.admin_Clarity clarity = dalClarity.GetModel(model.SourceID);
                string tableType = clarity.SourceTable;
                int sourceNum = (int)clarity.SourceNum;
                int sourceMin = (int)(clarity.SourceMin == null ? 0 : clarity.SourceMin);
                int sourceMax = (int)(clarity.SourceMax == null ? 150 : clarity.SourceMax);
                double sourceValue = 0;
                try
                {
                    if (tableType == "info")
                    {
                        sourceValue = double.Parse(ipList[sourceNum - 1].value);
                    }
                    else
                    {
                        sourceValue = double.Parse(mpList[sourceNum - 1].value);
                    }
                }
                catch (Exception ex)
                {
                    sourceValue = 0;
                }
                double sourceResult = getSourceResult(sourceMin, sourceMax, sourceValue, dataMin, dataMax);
                resultList.Add(sourceResult);
            }
            if (resultList.Count == 0)
            {
                rtn = 0;
            }
            else
            {
                switch (formula)
                {
                    case 1:
                        rtn = MathEx.getMax(resultList);
                        break;
                    case 2:
                        rtn = MathEx.getMax(resultList);
                        break;
                    default:
                        rtn = 0;
                        break;
                }
            }
            return rtn;
        }

        private double getSourceResult(int min, int max, double value, int dataMin, int dataMax)
        {
            double rtn = 0;
            double half = (max - min) / 2;
            double d = MathEx.RoundUp(Math.Abs(half - value) / half * dataMax, 1);
            rtn = d > dataMax ? dataMax : (d < dataMin ? dataMin : d);
            return rtn;
        }
    }

}
