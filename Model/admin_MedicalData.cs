using System;
using System.Collections.Generic;

namespace DJK.Model
{
    /// <summary>
    /// admin_MedicalData:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class admin_MedicalData
    {
        public admin_MedicalData()
        { }
        #region Model
        private int _id;
        private string _item;
        private string _description;
        private int? _parentid;
        private string _code;
        private int? _sort = 0;
        private int? _isroot = 0;
        private int? _dataformula = 0;
        private int? _datamin;
        private int? _datamax;
        private List<admin_MedicalSource> _sourcelist;
        private double? _datavalue;
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
        public string Item
        {
            set { _item = value; }
            get { return _item; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsRoot
        {
            set { _isroot = value; }
            get { return _isroot; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DataFormula
        {
            set { _dataformula = value; }
            get { return _dataformula; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DataMin
        {
            set { _datamin = value; }
            get { return _datamin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DataMax
        {
            set { _datamax = value; }
            get { return _datamax; }
        }

        public List<admin_MedicalSource> SourceList
        {
            set { _sourcelist = value; }
            get { return _sourcelist; }
        }

        public double? DataValue
        {
            set { _datavalue = value; }
            get { return _datavalue; }
        }
        #endregion Model

    }
}

