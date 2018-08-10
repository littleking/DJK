using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Collections;

namespace JKApp
{
    public class LoginHelper
    {
        private static string xmlFile = System.Windows.Forms.Application.StartupPath + @"\Login.xml";
        private static string defaultKeepPwd = "0";
        private static string defaultAutoLogin = "0";
        private static string defaultPosPrintType = "1";
        private static string defaultSkin = "Office 2007 Blue";
        private static string defaultAutoLock = "0";


        /// <summary>
        /// 加载XML文件
        /// </summary>
        /// <returns></returns>
        public static DataSet LoadXml()
        {
            DataSet dsXml = new DataSet("Login");
            if (!File.Exists(xmlFile))
            {
                DataTable newData = new DataTable("User");
                newData.Columns.Add("Account");
                newData.Columns.Add("Password");
                newData.Columns.Add("KeepPwd");
                newData.Columns.Add("AutoLogin");
                newData.Columns.Add("PosPrintType");
                newData.Columns.Add("Skin");
                newData.Columns.Add("AutoLock");
                dsXml.Tables.Add(newData);
                return dsXml;
            }
            dsXml.ReadXml(xmlFile);
            return dsXml;
        }
        public static DataSet LoadData(string dataFile)
        {
            DataSet dsXml = new DataSet("TestData");
            if (!File.Exists(dataFile))
            {
                DataTable newData = new DataTable("Data");
                newData.Columns.Add("SheetName");
                newData.Columns.Add("StartRow");
                newData.Columns.Add("EndRow");
                newData.Columns.Add("Code");
                newData.Columns.Add("Value");
                newData.Columns.Add("Key");
                dsXml.Tables.Add(newData);
                return dsXml;
            }
            dsXml.ReadXml(dataFile);
            return dsXml;
        }
        ///<summary> 
        ///读取配置文件里的信息
        ///</summary> 
        ///<param name="strAccount"></param> 
        ///<param name="strValue"></param> 
        ///<returns></returns> 
        public static string ReadByAccount(string strAccount, string strValue)
        {
            DataSet dsXml = LoadXml();
            if (dsXml == null || dsXml.Tables.Count == 0)
            {
                return string.Empty;
            }
            DataRow[] row = dsXml.Tables[0].Select("Account='" + strAccount + "'");
            if (row.Length == 0)
            {
                return string.Empty;
            }
            return row[0][strValue].ToString();
        }
        ///<summary> 
        ///读取配置文件里的信息
        ///</summary> 
        ///<param name="strAccount"></param> 
        ///<param name="strValue"></param> 
        ///<returns></returns> 
        public static DataRow ReadByAccount(string strAccount)
        {
            DataSet dsXml = LoadXml();
            if (dsXml == null || dsXml.Tables.Count == 0)
            {
                return null;
            }
            DataRow[] row = dsXml.Tables[0].Select("Account='" + strAccount + "'");
            if (row.Length == 0)
            {
                return null;
            }
            return row[0];
        }
        ///<summary>  
        ///修改配置文件里的信息
        ///</summary>  
        ///<param name="newKey"></param>  
        ///<param name="newValue"></param>  
        public static void WriteByAccount(string strAccount, string strPassword, string strKeepPwd, string strAutoLogin, string strPosPrintType, string strSkin, string strAutoLock)
        {
            DataSet dsXml = LoadXml();
            if (dsXml == null || dsXml.Tables.Count == 0)
            {
                return;
            }
            DataTable dataXml = dsXml.Tables[0];
            string format = "Account='{0}'";
            DataRow[] rowsXml = dataXml.Select(string.Format(format, strAccount));
            //没有节点，则增加一个节点
            if (rowsXml.Length > 0)
            {
                defaultKeepPwd = rowsXml[0]["KeepPwd"].ToString();
                defaultAutoLogin = rowsXml[0]["AutoLogin"].ToString();
                defaultPosPrintType = rowsXml[0]["PosPrintType"].ToString();
                defaultSkin = rowsXml[0]["Skin"].ToString();
                defaultAutoLock = rowsXml[0]["AutoLock"].ToString();
                //移除行
                dsXml.Tables[0].Rows.Remove(rowsXml[0]);
            }
            //dsXml，并置于第一个
            DataRow newRow = dsXml.Tables[0].NewRow();
            newRow["Account"] = strAccount;
            newRow["Password"] = strPassword;
            newRow["KeepPwd"] = string.IsNullOrEmpty(strKeepPwd) ? defaultKeepPwd : strKeepPwd;
            newRow["AutoLogin"] = string.IsNullOrEmpty(strAutoLogin) ? defaultAutoLogin : strAutoLogin;
            newRow["PosPrintType"] = string.IsNullOrEmpty(strPosPrintType) ? defaultPosPrintType : strPosPrintType;
            newRow["Skin"] = string.IsNullOrEmpty(strSkin) ? defaultSkin : strSkin;
            newRow["AutoLock"] = string.IsNullOrEmpty(strAutoLock) ? defaultAutoLock : strAutoLock;
            dsXml.Tables[0].Rows.InsertAt(newRow, 0);
            //写入Xml
            dsXml.WriteXml(xmlFile);
        }
        ///<summary>  
        ///修改配置文件里的信息
        ///</summary>  
        ///<param name="newKey"></param>  
        ///<param name="newValue"></param>  
        public static void WriteByAccount(string strAccount, string strKey, string strValue)
        {
            DataSet dsXml = LoadXml();
            if (dsXml == null || dsXml.Tables.Count == 0)
            {
                return;
            }
            DataTable dataXml = dsXml.Tables[0];
            string format = "Account='{0}'";
            DataRow[] rowsXml = dataXml.Select(string.Format(format, strAccount));
            //没有节点，则增加一个节点
            if (rowsXml.Length == 0)
            {
                DataRow dr = dataXml.NewRow();
                dr[strKey] = strValue;
                dataXml.Rows.Add(dr);
            }
            //赋值
            for (int i = 0; i < rowsXml.Length; i++)
            {
                if (i == 0)
                    rowsXml[i][strKey] = strValue;
                else
                    rowsXml[i].Delete();
            }
            dsXml.WriteXml(xmlFile);
        }
        ///<summary>  
        ///修改配置文件里的信息
        ///</summary>  
        ///<param name="newKey"></param>  
        ///<param name="newValue"></param>  
        public static void WriteByAccount(string strAccount, Hashtable tabData)
        {
            DataSet dsXml = LoadXml();
            if (dsXml == null || dsXml.Tables.Count == 0)
            {
                return;
            }
            DataTable dataXml = dsXml.Tables[0];
            string format = "Account='{0}'";
            DataRow[] rowsXml = dataXml.Select(string.Format(format, strAccount));
            //没有节点，则增加一个节点
            if (rowsXml.Length == 0)
            {
                DataRow dr = dataXml.NewRow();
                foreach (System.Collections.DictionaryEntry item in tabData)
                {
                    dr[item.Key.ToString()] = item.Value.ToString();
                }
                dataXml.Rows.Add(dr);
            }
            //赋值
            for (int i = 0; i < rowsXml.Length; i++)
            {
                if (i == 0)
                {
                    foreach (System.Collections.DictionaryEntry item in tabData)
                    {
                        rowsXml[i][item.Key.ToString()] = item.Value.ToString();
                    }
                }
                else
                    rowsXml[i].Delete();
            }
            dsXml.WriteXml(xmlFile);
        }
    }
}
