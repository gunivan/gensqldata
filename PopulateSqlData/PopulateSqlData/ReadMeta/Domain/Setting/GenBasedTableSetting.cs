using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain.Setting
{
    public class GenBasedTableSetting : GenSetting
    {
        [JsonProperty("table")]
        public String tableName { get; set; }  

        [JsonProperty("columns")]        
        public List<String> Columns { get; set; }

        [JsonProperty("values")]
        public List<object> Values { get; set; }

        public GenBasedTableSetting()
        {
            Columns = new List<string>();
        }
    }
}
