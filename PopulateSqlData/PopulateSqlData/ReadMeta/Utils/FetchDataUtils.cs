using HaVaData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Utils
{
    public class FetchDataUtils
    {
        public static List<List<Object>> Fetch(String table, Pair param, params String[] columns)
        {
            var list = new List<List<Object>>();
            var mDt = new DataTable();
            var sb = new StringBuilder();
            if (columns.Length <= 0)
            {
                sb.Append("*,");
            }
            else
            {
                foreach (var col in columns)
                {
                    sb.AppendFormat("{0},", columns);
                }
            }
            Sql.GetTable(mDt, table, sb.ToString(0, sb.Length - 1), param);
            foreach (DataRow row in mDt.Rows)
            {
                var item = new List<Object>();
                foreach (var col in columns)
                {
                    item.Add(row[col]);
                }
            }
            return list;
        }
    }
}
