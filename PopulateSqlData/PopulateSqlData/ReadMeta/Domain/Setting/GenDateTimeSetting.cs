using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain.Setting
{
    public class GenDateTimeSetting : GenSetting
    {
        [JsonProperty("min")]
        public DateTime Min { get; set; }

        [JsonProperty("max")]
        public DateTime Max { get; set; }
        public GenDateTimeSetting()
        {
            Min = DateTime.Now;
            Max = DateTime.Now.AddDays(1000);
        }
    }
}
