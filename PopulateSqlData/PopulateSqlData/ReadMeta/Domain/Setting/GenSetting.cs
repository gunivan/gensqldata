using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain.Setting
{
    public class GenSetting
    {      
        [JsonProperty("id_random")]
        [DefaultValue(true)]
        public Boolean IsRandom { get; set; }

        [JsonProperty("gen_based_table")]
        public Boolean GenBasedTable { get; set; }

        [JsonProperty("table_2_fetch")]
        public String TableToFetch { get; set; }

        [JsonProperty("col_2_fetch")]
        public String ColumnToFetch { get; set; }
    }
}
