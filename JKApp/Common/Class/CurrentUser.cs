using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JKApp
{
    public class CurrentUser
    {
        /// <summary>
        /// 门店编码
        /// </summary>
        public static string storeCode = "";
        /// <summary>
        /// 门店名称
        /// </summary>
        public static string storeName = "";
        /// <summary>
        /// 门店负责人
        /// </summary>
        public static string storeManager = "";
        /// <summary>
        /// 门店电话
        /// </summary>
        public static string storeTel = "";
        /// <summary>
        /// 门店传真
        /// </summary>
        public static string storeFax = "";
        /// <summary>
        /// 门店地址
        /// </summary>
        public static string storeAddress = "";
        /// <summary>
        /// 门店所属省
        /// </summary>
        public static string storeProvince = "";
        /// <summary>
        /// 门店所属市
        /// </summary>
        public static string storeCity = "";
        /// <summary>
        /// 门店所属区
        /// </summary>
        public static string storeArea = "";
        /// <summary>
        /// 门店介绍
        /// </summary>
        public static string storeContent = "";
        /// <summary>
        /// 登录用户ID
        /// </summary>
        public static string UserID = "";
        /// <summary>
        /// 登录用户编码
        /// </summary>
        public static string UserCode = "";
        /// <summary>
        /// 登录用户名
        /// </summary>
        public static string UserName = "";
        /// <summary>
        /// 登录用户密码（已加密）
        /// </summary>
        public static string UserPassword = "";
        /// <summary>
        /// 卡秘钥
        /// </summary>
        public static string CardMima = "FFFFFFFFFFFF";
    }

    #region 数据结构

    public class RemoteAddress
    {
        public string ip { get; set; }  
        public string port { get; set; }
    }
    public struct ValidateJson
    {
        public string name { get; set; }  //属性的名字，必须与json格式字符串中的"key"值一样。
        public string orderDate { get; set; }
        public string orderTime { get; set; }

        public string orderId { get; set; }

        public string peopleType { get; set; }
    }

    public struct BindResponse
    {
        public string isOk { get; set; }  //属性的名字，必须与json格式字符串中的"key"值一样。
        public string msg { get; set; }

    }

    public class RiskData
    {
        public string no{ get; set; }
        public string name { get; set; }

        public string value { get; set; }
    }

    public class RemoteJson
    {
        public string deviceName { get; set; }

        public string verifyCode { get; set; }

        public string userName { get; set; }

        public string patientName { get; set; }

        public string patientLocation { get; set; }

        public string patientDOB { get; set; }

        public string patientSex { get; set; }

        public string deviceSN { get; set; }

    }

    public class EmotionData
    {
        public string no { get; set; }
        public string name { get; set; }

        public string value { get; set; }
    }

    public class TestData
    {
        public string id { get; set; }
        public string value { get; set; }

        public string code { get; set; }
    }

    public class MatrixData
    {
        public string value { get; set; }

        public string code { get; set; }
    }

    public class OrderData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string orderDate { get; set; }
        public string orderTime { get; set; }
        public string verifyCode { get; set; }
        public string serviceName { get; set; }


    }

    public class LoginData
    {
        public string storeName { get; set; }
        public string dianpu_shitika_miyue { get; set; }
    }

    public class RiskList
    {
        public string verifyCode { get; set; }

        public List<RiskData> riskDatas { get; set; }
    }


    public class DataList
    {
        public string verifyCode { get; set; }

        public string orderid { get; set; }

        public string testUser { get; set; }

        public string testDate { get; set; }

        public List<TestData> testDatas { get; set; }

        //public List<MatrixData> matrixDatas { get; set; }
    }

    public class OrderList
    {
        public List<OrderData> datas{ get; set; }
    }

    public class DatasItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 您最想关注您身体下列哪方面问题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 失眠
        /// </summary>
        public string result { get; set; }
    }

    public class HealthResult
    {
        /// <summary>
        /// 
        /// </summary>
        public List<DatasItem> datas { get; set; }
    }
    #endregion
}
