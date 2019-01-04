using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace YGL
{
    public class SettingHelper
    {
        private static string xmlFile = System.Windows.Forms.Application.StartupPath + @"\Setting.xml";
        private static string colKey = "key";
        private static string colVal = "value";
        /// <summary>
        /// 加载XML文件
        /// </summary>
        /// <returns></returns>
        public static DataSet LoadXml()
        {
            if (!File.Exists(xmlFile))
            {
                return null;
            }
            DataSet dsXml = new DataSet();
            dsXml.ReadXml(xmlFile);
            return dsXml;
        }
        ///<summary> 
        ///读取配置文件里的信息
        ///</summary> 
        ///<param name="strKey"></param> 
        ///<returns></returns> 
        public static string ReadSetting(string strKey)
        {
            DataSet dsXml = LoadXml();
            if (dsXml == null || dsXml.Tables.Count == 0)
            {
                return string.Empty;
            }
            DataRow[] row = dsXml.Tables[0].Select("key='" + strKey + "'");
            if (row.Length == 0)
            {
                return string.Empty;
            }
            return row[0]["value"].ToString();
        }
        /// <summary>
        /// 读取配置文件里的等待时间
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static int ReadTime(string strKey)
        {
            DataSet dsXml = LoadXml();
            if (dsXml == null || dsXml.Tables.Count == 0)
            {
                return 0;
            }
            DataRow[] row = dsXml.Tables[0].Select("key='" + strKey + "'");
            if (row.Length == 0)
            {
                return 0;
            }
            string time = row[0]["value"].ToString();
            int rtn = int.Parse(time);
            return rtn;
        }

        ///<summary>  
        ///修改配置文件里的信息
        ///</summary>  
        ///<param name="newKey"></param>  
        ///<param name="newValue"></param>  
        public static void WriteSetting(string strKey, string strValue)
        {
            DataSet dsXml = LoadXml();
            if (dsXml == null || dsXml.Tables.Count == 0)
            {
                return;
            }
            DataTable dataXml = dsXml.Tables[0];
            string format = "key='{0}'";
            DataRow[] rowsXml = dataXml.Select(string.Format(format, strKey));
            //没有节点，则增加一个节点
            if (rowsXml.Length == 0)
            {
                DataRow dr = dataXml.NewRow();
                dr[colKey] = strKey;
                dr[colVal] = strValue;
                dataXml.Rows.Add(dr);
            }
            //赋值
            for (int i = 0; i < rowsXml.Length; i++)
            {
                if (i == 0)
                    rowsXml[i][colVal] = strValue;
                else
                    rowsXml[i].Delete();
            }
            dsXml.WriteXml(xmlFile);
        }
    }
}
