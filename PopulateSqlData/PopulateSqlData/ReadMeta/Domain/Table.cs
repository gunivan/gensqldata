using Newtonsoft.Json;
using PopulateSqlData.ReadMeta.Domain.Column;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain
{
    public class Table
    {
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("is_top_master")]
        public Boolean IsTopMaster { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("children")]
        public List<Table> Children { get; set; }
        [JsonProperty("cols")]
        public List<ColumnBase> Columns { get; set; }

        [JsonProperty("max_recs")]
        public int MaxRecords { get; set; }
        public Table()
        {
            Children = new List<Table>();
            Columns = new List<ColumnBase>();
        }
        public Table(String name)
            : this()
        {
            Name = name;
        }

        public DataTable Generate(DataTable table)
        {
            var row = table.NewRow();
            try
            {
                foreach (var col in Columns)
                {
                    col.Generate(row);
                }
                lock (table)
                {
                    table.Rows.Add(row);
                }
            }
            catch (Exception e)
            {
                LogUtils.Logs.Error(e.Message);
            }
            return table;
        }
        public override string ToString()
        {
            var children = new StringBuilder();
            foreach (var table in Children)
            {
                children.Append(table.Name + " ");
            }
            return String.Format("Name:{0}\r\n\tChildren:{1}", Name, children);
        }
    }
}
