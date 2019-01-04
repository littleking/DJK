using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DJK.DBUtility;//Please add references
namespace DJK.DAL
{
    /// <summary>
    /// 数据访问类:djk_cloudData
    /// </summary>
    public partial class djk_cloudData
    {
        public djk_cloudData()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from djk_cloudData");
            strSql.Append(" where ID=" + ID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DJK.Model.djk_cloudData model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.savedDate != null)
            {
                strSql1.Append("savedDate,");
                strSql2.Append("'" + model.savedDate + "',");
            }
            if (model.healthData != null)
            {
                strSql1.Append("healthData,");
                strSql2.Append("'" + model.healthData + "',");
            }
            if (model.verifyCode != null)
            {
                strSql1.Append("verifyCode,");
                strSql2.Append("'" + model.verifyCode + "',");
            }
            if (model.deviceNo != null)
            {
                strSql1.Append("deviceNo,");
                strSql2.Append("'" + model.deviceNo + "',");
            }
            if (model.orgnizationID != null)
            {
                strSql1.Append("orgnizationID,");
                strSql2.Append("'" + model.orgnizationID + "',");
            }
            strSql.Append("insert into djk_cloudData(");
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
        public bool Update(DJK.Model.djk_cloudData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update djk_cloudData set ");
            if (model.savedDate != null)
            {
                strSql.Append("savedDate='" + model.savedDate + "',");
            }
            else
            {
                strSql.Append("savedDate= null ,");
            }
            if (model.healthData != null)
            {
                strSql.Append("healthData='" + model.healthData + "',");
            }
            else
            {
                strSql.Append("healthData= null ,");
            }
            if (model.verifyCode != null)
            {
                strSql.Append("verifyCode='" + model.verifyCode + "',");
            }
            else
            {
                strSql.Append("verifyCode= null ,");
            }
            if (model.deviceNo != null)
            {
                strSql.Append("deviceNo='" + model.deviceNo + "',");
            }
            else
            {
                strSql.Append("deviceNo= null ,");
            }
            if (model.orgnizationID != null)
            {
                strSql.Append("orgnizationID='" + model.orgnizationID + "',");
            }
            else
            {
                strSql.Append("orgnizationID= null ,");
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
            strSql.Append("delete from djk_cloudData ");
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
            strSql.Append("delete from djk_cloudData ");
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
        public DJK.Model.djk_cloudData GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ID,savedDate,healthData,verifyCode,deviceNo,orgnizationID ");
            strSql.Append(" from djk_cloudData ");
            strSql.Append(" where ID=" + ID + "");
            DJK.Model.djk_cloudData model = new DJK.Model.djk_cloudData();
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

        public DJK.Model.djk_cloudData GetModel(string verifyCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ID,savedDate,healthData,verifyCode,deviceNo,orgnizationID ");
            strSql.Append(" from djk_cloudData ");
            strSql.Append(" where verifyCode=" + verifyCode + "");
            DJK.Model.djk_cloudData model = new DJK.Model.djk_cloudData();
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
        public DJK.Model.djk_cloudData DataRowToModel(DataRow row)
        {
            DJK.Model.djk_cloudData model = new DJK.Model.djk_cloudData();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["savedDate"] != null && row["savedDate"].ToString() != "")
                {
                    model.savedDate = DateTime.Parse(row["savedDate"].ToString());
                }
                if (row["healthData"] != null)
                {
                    model.healthData = row["healthData"].ToString();
                }
                if (row["verifyCode"] != null)
                {
                    model.verifyCode = row["verifyCode"].ToString();
                }
                if (row["deviceNo"] != null)
                {
                    model.deviceNo = row["deviceNo"].ToString();
                }
                if (row["orgnizationID"] != null)
                {
                    model.orgnizationID = row["orgnizationID"].ToString();
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
            strSql.Append("select ID,savedDate,healthData,verifyCode,deviceNo,orgnizationID ");
            strSql.Append(" FROM djk_cloudData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" ID,savedDate,healthData,verifyCode,deviceNo,orgnizationID ");
            strSql.Append(" FROM djk_cloudData ");
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
            strSql.Append("select count(1) FROM djk_cloudData ");
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
            strSql.Append(")AS Row, T.*  from djk_cloudData T ");
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

        #endregion  MethodEx
    }
}

