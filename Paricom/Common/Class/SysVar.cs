using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Paricom
{
    /// <summary>
    /// 系统全局变量
    /// </summary>
    public class SysVar
    {
        public SysVar()
        {



        }

        /// <summary>
        /// 枚举转换为DataTable
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static DataTable EnumToDataTable(Type enumType, string key, string val)
        {

            string[] Names = System.Enum.GetNames(enumType);
            Array Values = System.Enum.GetValues(enumType);

            DataTable table = new DataTable();
            table.Columns.Add(key, System.Type.GetType("System.String"));
            table.Columns.Add(val, System.Type.GetType("System.String"));
            table.Columns[key].Unique = true;
            for (int i = 0; i < Values.Length; i++)
            {
                DataRow DR = table.NewRow();
                DR[key] = Names[i].ToString().Trim();
                DR[val] = (int)Values.GetValue(i);
                table.Rows.Add(DR);
            }
            return table;
        }



        /// <summary>
        /// 是否属于更改用户
        /// </summary>
        public static bool IsChangeUser = false;
        /// <summary>
        /// 客户端完整标题（标题 + 版本号）
        /// </summary>
        public static string SysTitle = string.Empty;

        public static DateTime dtNow;

        public static DateTime dtOld;

        public static bool isLocal;



    }
}
