using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain.Setting
{
    public class GenBitSetting : GenSetting
    {
        [JsonProperty("value")]
        [DefaultValue(true)]
        public Boolean Value { get; set; }
    }
}
