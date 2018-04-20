using System;
namespace DJK.Model
{
    /// <summary>
    /// admin_clarity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class admin_Clarity
    {
        public admin_Clarity()
        { }
        #region Model
        private int _id;
        private string _sourcetable;
        private int? _sourcenum;
        private int? _sourcemin = 0;
        private int? _sourcemax = 150;
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
        public string SourceTable
        {
            set { _sourcetable = value; }
            get { return _sourcetable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SourceNum
        {
            set { _sourcenum = value; }
            get { return _sourcenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SourceMin
        {
            set { _sourcemin = value; }
            get { return _sourcemin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SourceMax
        {
            set { _sourcemax = value; }
            get { return _sourcemax; }
        }
        #endregion Model

    }
}


