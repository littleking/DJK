using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DJK.DBUtility;//Please add references
using System.Collections.Generic;

namespace DJK.DAL
{
    /// <summary>
    /// 数据访问类:admin_MedicalData
    /// </summary>
    public partial class admin_MedicalData
    {
        public admin_MedicalData()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from admin_MedicalData");
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
        public int Add(DJK.Model.admin_MedicalData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into admin_MedicalData(");
            strSql.Append("Item,Description,ParentID,Code,Sort,IsRoot,DataFormula,DataMin,DataMax)");
            strSql.Append(" values (");
            strSql.Append("@Item,@Description,@ParentID,@Code,@Sort,@IsRoot,@DataFormula,@DataMin,@DataMax)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Item", SqlDbType.NVarChar,255),
                    new SqlParameter("@Description", SqlDbType.NVarChar,255),
                    new SqlParameter("@ParentID", SqlDbType.Int,4),
                    new SqlParameter("@Code", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@IsRoot", SqlDbType.Int,4),
                    new SqlParameter("@DataFormula", SqlDbType.Int,4),
                    new SqlParameter("@DataMin", SqlDbType.Int,4),
                    new SqlParameter("@DataMax", SqlDbType.Int,4)};
            parameters[0].Value = model.Item;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Code;
            parameters[4].Value = model.Sort;
            parameters[5].Value = model.IsRoot;
            parameters[6].Value = model.DataFormula;
            parameters[7].Value = model.DataMin;
            parameters[8].Value = model.DataMax;

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
        public bool Update(DJK.Model.admin_MedicalData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update admin_MedicalData set ");
            strSql.Append("Item=@Item,");
            strSql.Append("Description=@Description,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Code=@Code,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("IsRoot=@IsRoot,");
            strSql.Append("DataFormula=@DataFormula,");
            strSql.Append("DataMin=@DataMin,");
            strSql.Append("DataMax=@DataMax");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Item", SqlDbType.NVarChar,255),
                    new SqlParameter("@Description", SqlDbType.NVarChar,255),
                    new SqlParameter("@ParentID", SqlDbType.Int,4),
                    new SqlParameter("@Code", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@IsRoot", SqlDbType.Int,4),
                    new SqlParameter("@DataFormula", SqlDbType.Int,4),
                    new SqlParameter("@DataMin", SqlDbType.Int,4),
                    new SqlParameter("@DataMax", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Item;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Code;
            parameters[4].Value = model.Sort;
            parameters[5].Value = model.IsRoot;
            parameters[6].Value = model.DataFormula;
            parameters[7].Value = model.DataMin;
            parameters[8].Value = model.DataMax;
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
            strSql.Append("delete from admin_MedicalData ");
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
            strSql.Append("delete from admin_MedicalData ");
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

        public List<DJK.Model.admin_MedicalData> getModelList()
        {
            List<DJK.Model.admin_MedicalData> list = new List<Model.admin_MedicalData>();
            DataSet ds = GetList("");
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                DJK.Model.admin_MedicalData model = new DJK.Model.admin_MedicalData();
                model = DataRowToModel(dr);
                list.Add(model);
            }

            return list;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DJK.Model.admin_MedicalData GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Item,Description,ParentID,Code,Sort,IsRoot,DataFormula,DataMin,DataMax from admin_MedicalData ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            DJK.Model.admin_MedicalData model = new DJK.Model.admin_MedicalData();
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
        public DJK.Model.admin_MedicalData DataRowToModel(DataRow row)
        {
            DJK.Model.admin_MedicalData model = new DJK.Model.admin_MedicalData();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Item"] != null)
                {
                    model.Item = row["Item"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Sort"] != null && row["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(row["Sort"].ToString());
                }
                if (row["IsRoot"] != null && row["IsRoot"].ToString() != "")
                {
                    model.IsRoot = int.Parse(row["IsRoot"].ToString());
                }
                if (row["DataFormula"] != null && row["DataFormula"].ToString() != "")
                {
                    model.DataFormula = int.Parse(row["DataFormula"].ToString());
                }
                if (row["DataMin"] != null && row["DataMin"].ToString() != "")
                {
                    model.DataMin = int.Parse(row["DataMin"].ToString());
                }
                if (row["DataMax"] != null && row["DataMax"].ToString() != "")
                {
                    model.DataMax = int.Parse(row["DataMax"].ToString());
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
            strSql.Append("select ID,Item,Description,ParentID,Code,Sort,IsRoot,DataFormula,DataMin,DataMax ");
            strSql.Append(" FROM admin_MedicalData ");
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
            strSql.Append(" ID,Item,Description,ParentID,Code,Sort,IsRoot,DataFormula,DataMin,DataMax ");
            strSql.Append(" FROM admin_MedicalData ");
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
            strSql.Append("select count(1) FROM admin_MedicalData ");
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
            strSql.Append(")AS Row, T.*  from admin_MedicalData T ");
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
			parameters[0].Value = "admin_MedicalData";
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
        public string getMaxCode(int pid,string currentCode)
        {
            string code = "";
            Object maxCode = DbHelperSQL.GetSingle("select Max(code) as code from admin_medicalData where parentID=" + pid);
            if (maxCode != null)
            {
                string rtn = maxCode.ToString();
                int lastIndex = int.Parse(rtn.Substring(rtn.Length - 1, 1)) + 1;
                code = rtn.Substring(0, rtn.Length - 1);
                code = code + lastIndex;
            }
            else
            {
                code = currentCode + "_" + 1;
            }
            return code;
        }
        #endregion  ExtensionMethod
    }
}

