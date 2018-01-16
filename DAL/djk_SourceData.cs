using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DJK.DBUtility;
using System.Collections.Generic;//Please add references
namespace DJK.DAL
{
    /// <summary>
    /// 数据访问类:djk_SourceData
    /// </summary>
    public partial class djk_SourceData
    {
        public djk_SourceData()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from djk_SourceData");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DJK.Model.djk_SourceData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into djk_SourceData(");
            strSql.Append("saveDate,infoData,matrixData,serialCode,companyID,machineCode,sex,isExported,exportDate)");
            strSql.Append(" values (");
            strSql.Append("@saveDate,@infoData,@matrixData,@serialCode,@companyID,@machineCode,@sex,@isExported,@exportDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@saveDate", SqlDbType.DateTime),
					new SqlParameter("@infoData", SqlDbType.NText),
					new SqlParameter("@matrixData", SqlDbType.NText),
					new SqlParameter("@serialCode", SqlDbType.NVarChar,50),
					new SqlParameter("@companyID", SqlDbType.NVarChar,50),
					new SqlParameter("@machineCode", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.NVarChar,50),
					new SqlParameter("@isExported", SqlDbType.Int,4),
					new SqlParameter("@exportDate", SqlDbType.DateTime)};
            parameters[0].Value = model.saveDate;
            parameters[1].Value = model.infoData;
            parameters[2].Value = model.matrixData;
            parameters[3].Value = model.serialCode;
            parameters[4].Value = model.companyID;
            parameters[5].Value = model.machineCode;
            parameters[6].Value = model.sex;
            parameters[7].Value = model.isExported;
            parameters[8].Value = model.exportDate;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(DJK.Model.djk_SourceData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update djk_SourceData set ");
            strSql.Append("saveDate=@saveDate,");
            strSql.Append("infoData=@infoData,");
            strSql.Append("matrixData=@matrixData,");
            strSql.Append("serialCode=@serialCode,");
            strSql.Append("companyID=@companyID,");
            strSql.Append("machineCode=@machineCode,");
            strSql.Append("sex=@sex,");
            strSql.Append("isExported=@isExported,");
            strSql.Append("exportDate=@exportDate");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@saveDate", SqlDbType.DateTime),
					new SqlParameter("@infoData", SqlDbType.NText),
					new SqlParameter("@matrixData", SqlDbType.NText),
					new SqlParameter("@serialCode", SqlDbType.NVarChar,50),
					new SqlParameter("@companyID", SqlDbType.NVarChar,50),
					new SqlParameter("@machineCode", SqlDbType.NVarChar,50),
					new SqlParameter("@sex", SqlDbType.NVarChar,50),
					new SqlParameter("@isExported", SqlDbType.Int,4),
					new SqlParameter("@exportDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.saveDate;
            parameters[1].Value = model.infoData;
            parameters[2].Value = model.matrixData;
            parameters[3].Value = model.serialCode;
            parameters[4].Value = model.companyID;
            parameters[5].Value = model.machineCode;
            parameters[6].Value = model.sex;
            parameters[7].Value = model.isExported;
            parameters[8].Value = model.exportDate;
            parameters[9].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from djk_SourceData ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from djk_SourceData ");
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
        public DJK.Model.djk_SourceData GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,saveDate,infoData,matrixData,serialCode,companyID,machineCode,sex,isExported,exportDate from djk_SourceData ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            DJK.Model.djk_SourceData model = new DJK.Model.djk_SourceData();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        public DJK.Model.djk_SourceData DataRowToModel(DataRow row)
        {
            DJK.Model.djk_SourceData model = new DJK.Model.djk_SourceData();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["saveDate"] != null && row["saveDate"].ToString() != "")
                {
                    model.saveDate = DateTime.Parse(row["saveDate"].ToString());
                }
                if (row["infoData"] != null)
                {
                    model.infoData = row["infoData"].ToString();
                }
                if (row["matrixData"] != null)
                {
                    model.matrixData = row["matrixData"].ToString();
                }
                if (row["serialCode"] != null)
                {
                    model.serialCode = row["serialCode"].ToString();
                }
                if (row["companyID"] != null)
                {
                    model.companyID = row["companyID"].ToString();
                }
                if (row["machineCode"] != null)
                {
                    model.machineCode = row["machineCode"].ToString();
                }
                if (row["sex"] != null)
                {
                    model.sex = row["sex"].ToString();
                }
                if (row["isExported"] != null && row["isExported"].ToString() != "")
                {
                    model.isExported = int.Parse(row["isExported"].ToString());
                }
                if (row["exportDate"] != null && row["exportDate"].ToString() != "")
                {
                    model.exportDate = DateTime.Parse(row["exportDate"].ToString());
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
            strSql.Append("select ID,saveDate,infoData,matrixData,serialCode,companyID,machineCode,sex,isExported,exportDate ");
            strSql.Append(" FROM djk_SourceData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int ExecuteTransactions(List<string> list)
        {
            return DbHelperSQL.ExecuteSqlTran(list);
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
            strSql.Append(" ID,saveDate,infoData,matrixData,serialCode,companyID,machineCode,sex,isExported,exportDate ");
            strSql.Append(" FROM djk_SourceData ");
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
            strSql.Append("select count(1) FROM djk_SourceData ");
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
            strSql.Append(")AS Row, T.*  from djk_SourceData T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "djk_SourceData";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

