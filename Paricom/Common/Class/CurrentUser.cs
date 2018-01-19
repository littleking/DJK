﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paricom
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

    public class TestData
    {
        public string id { get; set; }
        public string value { get; set; }

        public string code { get; set; }
    }

    public class OrderData
    {
        public string orderId { get; set; }
        public string orderDate { get; set; }
        public string jiaoyanNum { get; set; }
        public string lianxiren { get; set; }
    }

    public class LoginData
    {
        public string storeName { get; set; }
        public string dianpu_shitika_miyue { get; set; }
    }



    public class DataList
    {
        public string verifyCode { get; set; }

        public string orderid { get; set; }

        public string testUser { get; set; }

        public string testDate { get; set; }

        public List<TestData> testDatas { get; set; }
    }

    public class OrderList
    {
        public string isOk { get; set; }

        public List<OrderData> testDatas { get; set; }
    }
    #endregion
}
