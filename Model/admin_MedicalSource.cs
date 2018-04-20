using System;
namespace DJK.Model
{
    /// <summary>
    /// admin_MedicalSource:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class admin_MedicalSource
    {
        public admin_MedicalSource()
        { }
        #region Model
        private int _id;
        private int? _medicalid;
        private string _source;
        private string _sourcetable;
        private int _sourcenum;
        private int _sourceid;
        private double? _sourcevalue;
        private double? _sourceresult;
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
        public int? MedicalID
        {
            set { _medicalid = value; }
            get { return _medicalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }

        public string SourceTable
        {
            set { _sourcetable = value; }
            get { return _sourcetable; }
        }

        public int SourceNum
        {
            set { _sourcenum = value; }
            get { return _sourcenum; }
        }

        public int SourceID
        {
            set { _sourceid = value; }
            get { return _sourceid; }
        }

        public double? SourceValue
        {
            set { _sourcevalue = value; }
            get { return _sourcevalue; }
        }

        public double? SourceResult
        {
            set { _sourceresult = value; }
            get { return _sourceresult; }
        }
        #endregion Model

    }
}

