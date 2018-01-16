using System;
namespace DJK.Model
{
    /// <summary>
    /// djk_SourceData:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class djk_SourceData
    {
        public djk_SourceData()
        { }
        #region Model
        private int _id;
        private DateTime? _savedate = DateTime.Now;
        private string _infodata;
        private string _matrixdata;
        private string _serialcode;
        private string _companyid;
        private string _machinecode;
        private string _sex;
        private int? _isexported = 0;
        private DateTime? _exportdate;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 保存时间
        /// </summary>
        public DateTime? saveDate
        {
            set { _savedate = value; }
            get { return _savedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string infoData
        {
            set { _infodata = value; }
            get { return _infodata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string matrixData
        {
            set { _matrixdata = value; }
            get { return _matrixdata; }
        }
        /// <summary>
        /// 验证码
        /// </summary>
        public string serialCode
        {
            set { _serialcode = value; }
            get { return _serialcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string companyID
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string machineCode
        {
            set { _machinecode = value; }
            get { return _machinecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isExported
        {
            set { _isexported = value; }
            get { return _isexported; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? exportDate
        {
            set { _exportdate = value; }
            get { return _exportdate; }
        }
        #endregion Model

    }
}

