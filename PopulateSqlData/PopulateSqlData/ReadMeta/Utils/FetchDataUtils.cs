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
        public static List<List<Object>> Fetch(long num, String table, Pair param, params String[] columns)
        {
            var list = new List<List<Object>>();
            var mDt = new DataTable();
            var sb = new StringBuilder();
            sb.AppendFormat("Select top {0} ", num);
            if (columns.Length <= 0)
            {
                sb.Append("*,");
            }
            else
            {
                foreach (var col in columns)
                {
                    sb.AppendFormat("{0},", columns);
                };
                sb.Remove(sb.Length - 1, 1);
            }
            sb.AppendFormat(" From [{0}]", table);
            Sql.Fill(sb.ToString(), mDt, param);
            foreach (DataRow row in mDt.Rows)
            {
                var item = new List<Object>();
                foreach (var col in columns)
                {
                    item.Add(row[col]);
                }
                list.Add(item);
            }
            return list;
        }
    }
}
