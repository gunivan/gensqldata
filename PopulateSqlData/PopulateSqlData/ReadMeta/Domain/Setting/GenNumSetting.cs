using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain.Setting
{
    public class GenNumSetting : GenSetting
    {
        [JsonProperty("num_type")]
        public String NumType { get; set; }  

        [JsonProperty("min")]
        [DefaultValue(1)]
        public Decimal Min { get; set; }

        [JsonProperty("max")]
        [DefaultValue(1000)]
        public Decimal Max { get; set; }

        public GenNumSetting()
        {
            NumType = typeof(long).ToString();
            Min = 0;
            Max = 1000;
        }
    }
}
