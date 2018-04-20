using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DJK.DBUtility;//Please add references
namespace DJK.DAL
{
    /// <summary>
    /// 数据访问类:admin_clarity
    /// </summary>
    public partial class admin_Clarity
    {
        public admin_Clarity()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from admin_clarity");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DJK.Model.admin_Clarity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.SourceTable != null)
            {
                strSql1.Append("SourceTable,");
                strSql2.Append("'" + model.SourceTable + "',");
            }
            if (model.SourceNum != null)
            {
                strSql1.Append("SourceNum,");
                strSql2.Append("" + model.SourceNum + ",");
            }
            if (model.SourceMin != null)
            {
                strSql1.Append("SourceMin,");
                strSql2.Append("" + model.SourceMin + ",");
            }
            if (model.SourceMax != null)
            {
                strSql1.Append("SourceMax,");
                strSql2.Append("" + model.SourceMax + ",");
            }
            strSql.Append("insert into admin_clarity(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DJK.Model.admin_Clarity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update admin_clarity set ");
            if (model.SourceTable != null)
            {
                strSql.Append("SourceTable='" + model.SourceTable + "',");
            }
            else
            {
                strSql.Append("SourceTable= null ,");
            }
            if (model.SourceNum != null)
            {
                strSql.Append("SourceNum=" + model.SourceNum + ",");
            }
            else
            {
                strSql.Append("SourceNum= null ,");
            }
            if (model.SourceMin != null)
            {
                strSql.Append("SourceMin=" + model.SourceMin + ",");
            }
            else
            {
                strSql.Append("SourceMin= null ,");
            }
            if (model.SourceMax != null)
            {
                strSql.Append("SourceMax=" + model.SourceMax + ",");
            }
            else
            {
                strSql.Append("SourceMax= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where ID=" + model.ID + "");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from admin_clarity ");
            strSql.Append(" where ID=" + ID + "");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       /// <summary>
                /// 批量删除数据
                /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from admin_clarity ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DJK.Model.admin_Clarity GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ID,SourceTable,SourceNum,SourceMin,SourceMax ");
            strSql.Append(" from admin_clarity ");
            strSql.Append(" where ID=" + ID + "");
            DJK.Model.admin_Clarity model = new DJK.Model.admin_Clarity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DJK.Model.admin_Clarity DataRowToModel(DataRow row)
        {
            DJK.Model.admin_Clarity model = new DJK.Model.admin_Clarity();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["SourceTable"] != null)
                {
                    model.SourceTable = row["SourceTable"].ToString();
                }
                if (row["SourceNum"] != null && row["SourceNum"].ToString() != "")
                {
                    model.SourceNum = int.Parse(row["SourceNum"].ToString());
                }
                if (row["SourceMin"] != null && row["SourceMin"].ToString() != "")
                {
                    model.SourceMin = int.Parse(row["SourceMin"].ToString());
                }
                if (row["SourceMax"] != null && row["SourceMax"].ToString() != "")
                {
                    model.SourceMax = int.Parse(row["SourceMax"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,SourceTable,SourceNum,SourceMin,SourceMax ");
            strSql.Append(" FROM admin_clarity ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetAlltList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ID as MedicalID,SourceTable+Convert(varchar(50),SourceNum) as Source,SourceTable,SourceNum ");
            strSql.Append(" FROM admin_clarity order by SourceTable,SourceNum");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,SourceTable,SourceNum,SourceMin,SourceMax ");
            strSql.Append(" FROM admin_clarity ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM admin_clarity ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from admin_clarity T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		*/

        #endregion  Method

        #region  MethodEx

        public bool checkCurrent(string dataType, string num)
        {
            return DbHelperSQL.Exists("select * from admin_clarity where SourceTable = '" + dataType + "' and SourceNum=" + num);
        }


        public string getCurrent(string dataType)
        {
            string code = "";
            Object maxCode = DbHelperSQL.GetSingle("select max(sourceNum) as currentNum from admin_clarity where sourceTable='" + dataType + "'");
            if (maxCode != null)
            {
                string rtn = maxCode.ToString();
                int lastIndex = int.Parse(rtn) + 1;
                code = lastIndex.ToString();
            }
            else
            {
                code = "1";
            }
            return code;
            #endregion  MethodEx
        }
    }
}

