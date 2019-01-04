using System;
namespace DJK.Model
{
    /// <summary>
    /// djk_cloudData:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class djk_cloudData
    {
        public djk_cloudData()
        { }
        #region Model
        private int _id;
        private DateTime? _saveddate;
        private string _healthdata;
        private string _verifycode;
        private string _deviceno;
        private string _orgnizationid;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? savedDate
        {
            set { _saveddate = value; }
            get { return _saveddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string healthData
        {
            set { _healthdata = value; }
            get { return _healthdata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string verifyCode
        {
            set { _verifycode = value; }
            get { return _verifycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string deviceNo
        {
            set { _deviceno = value; }
            get { return _deviceno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string orgnizationID
        {
            set { _orgnizationid = value; }
            get { return _orgnizationid; }
        }
        #endregion Model

    }
}

