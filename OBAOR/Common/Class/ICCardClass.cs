using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace OBAOR
{
    public class ICCardClass
    {
        #region 身份证类国腾（termb.dll）
        /// <summary>
        /// 初始化串口;
        /// </summary>
        /// <param name="iPort"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int InitComm(int iPort);
        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int CloseComm();
        /// <summary>
        /// 卡认证
        /// </summary>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int Authenticate();
        /// <summary>
        /// 读卡操作。
        /// </summary>
        /// <param name="iActive"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int Read_Content(int iActive);
        /// <summary>
        /// 得到姓名信息
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleName(Byte[] buf, int iLen);
        /// <summary>
        /// 得到性别信息
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleSex(Byte[] buf, int iLen);
        /// <summary>
        /// 得到民族信息
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleNation(Byte[] buf, int iLen);
        /// <summary>
        /// 得到发证机关信息
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetDepartment(Byte[] buf, int iLen);
        /// <summary>
        /// 得到出生日期
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleBirthday(Byte[] buf, int iLen);
        /// <summary>
        /// 得到地址信息
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleAddress(Byte[] buf, int iLen);
        /// <summary>
        /// 得到有效启始日期
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetStartDate(Byte[] buf, int iLen);
        /// <summary>
        /// 得到有效截止日期
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetEndDate(Byte[] buf, int iLen);

        /// <summary>
        /// 得到卡号信息
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleIDCode(Byte[] buf, int iLen);

        /// <summary>
        /// 得到图片信息
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        [DllImport("termb.DLL", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPhotoBMP(Byte[] buf, int iLen);

        #endregion

        #region 第二代身份证读值方法
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public static string GetName()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetPeopleName(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }

        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        public static string GetSex()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetPeopleSex(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }

        /// <summary>
        /// 民族
        /// </summary>
        /// <returns></returns>
        public static string GetNation()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetPeopleNation(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        /// <returns></returns>
        public static string GetBirthday()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];

            int dwRet = GetPeopleBirthday(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");

            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);

        }
        /// <summary>
        /// 地址
        /// </summary>
        /// <returns></returns>
        public static string GetAddress()
        {

            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetPeopleAddress(asciiBytes, 100);

            Encoding gb2312 = Encoding.GetEncoding("gb2312");

            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);

        }
        /// <summary>
        /// 得到发证机关信息
        /// </summary>
        /// <returns></returns>
        public static string GetDepartmentIC()
        {

            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetDepartment(asciiBytes, 100);

            Encoding gb2312 = Encoding.GetEncoding("gb2312");

            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }
        /// <summary>
        /// 有效开始日期
        /// </summary>
        /// <returns></returns>
        public static string GetStartDateIC()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetStartDate(asciiBytes, 100);

            Encoding gb2312 = Encoding.GetEncoding("gb2312");

            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);

        }

        /// <summary>
        /// 结束日期
        /// </summary>
        /// <returns></returns>
        public static string GetEndDateIC()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetEndDate(asciiBytes, 100);

            Encoding gb2312 = Encoding.GetEncoding("gb2312");

            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);

        }

        /// <summary>
        /// 获得卡号信息
        /// </summary>
        /// <returns></returns>
        public static string GetIDCode()
        {
            Byte[] asciiBytes = null;
            asciiBytes = new Byte[100];
            int dwRet = GetPeopleIDCode(asciiBytes, 100);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, dwRet)];
            gb2312.GetChars(asciiBytes, 0, dwRet, asciiChars, 0);
            return new string(asciiChars);
        }


        #endregion
    }
}