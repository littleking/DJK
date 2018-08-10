using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DJK.DAL;
using DJK.Model;
using System.Data;

namespace Formula
{
    public class FormulaCalculation
    {
        private DJK.DAL.admin_MedicalData dalData;
        private DJK.DAL.admin_MedicalSource dalSource;
        private DJK.DAL.admin_Clarity dalClarity;
        private DJK.Model.admin_MedicalData modelData;
        private DJK.Model.admin_MedicalSource modelSource;
        private List<MatrixParser> mpList;
        private List<InfoParser> ipList;
        public FormulaCalculation(List<MatrixParser> mList, List<InfoParser> iList)
        {
            dalData = new DJK.DAL.admin_MedicalData();
            dalSource = new DJK.DAL.admin_MedicalSource();
            dalClarity = new DJK.DAL.admin_Clarity();
            modelData = new DJK.Model.admin_MedicalData();
            modelSource = new DJK.Model.admin_MedicalSource();
            mpList = mList;
            ipList = iList;
        }

        public List<DJK.Model.admin_MedicalData> getResult()
        {
            List<DJK.Model.admin_MedicalData> result = new List<DJK.Model.admin_MedicalData>();
            result = dalData.getModelList();
            foreach(DJK.Model.admin_MedicalData model in result)
            {
                if (model.DataFormula != null && model.DataFormula > 0)
                {
                    int formula = (int)model.DataFormula;
                    int dataMin = (int)(model.DataMin == null ? 0 : model.DataMin);
                    int dataMax = (int)(model.DataMax == null ? 5 : model.DataMax);
                    model.DataValue = getDataValue(formula, model.ID,dataMin,dataMax);
                }
            }
            return result;
        }

        private double getDataValue(int formula, int medicalID, int dataMin, int dataMax)
        {
            double rtn = 0;
            List<DJK.Model.admin_MedicalSource> sourceList = dalSource.getModelList(medicalID);
            List<double> resultList = new List<double>();
            foreach(DJK.Model.admin_MedicalSource model in sourceList)
            {
                DJK.Model.admin_Clarity clarity = dalClarity.GetModel(model.SourceID);
                string tableType = clarity.SourceTable;
                int sourceNum = (int)clarity.SourceNum;
                int sourceMin = (int)(clarity.SourceMin==null?0:clarity.SourceMin);
                int sourceMax = (int)(clarity.SourceMax == null ? 150 : clarity.SourceMax);
                double sourceValue = 0;
                try
                {
                    if (tableType == "info")
                    {
                        sourceValue = double.Parse(ipList[sourceNum-1].Value);
                    }
                    else
                    {
                        sourceValue = double.Parse(mpList[sourceNum-1].Value);
                    }
                }catch(Exception ex)
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
