using System;
namespace DJK.Model
{
    /// <summary>
    /// djk_SavedData:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class djk_SavedData
    {
        public djk_SavedData()
        { }
        #region Model
        private int _id;
        private int? _sourceid;
        private DateTime? _savedate;
        private string _saveddata;
        private string _serialcode;
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
        public int? sourceID
        {
            set { _sourceid = value; }
            get { return _sourceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? saveDate
        {
            set { _savedate = value; }
            get { return _savedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string savedData
        {
            set { _saveddata = value; }
            get { return _saveddata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string serialCode
        {
            set { _serialcode = value; }
            get { return _serialcode; }
        }
        #endregion Model

    }
}

