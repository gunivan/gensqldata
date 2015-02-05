using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain.Setting
{
    public class GenStringSetting : GenSetting
    {
        [JsonProperty("is_identity")]
        [DefaultValue(false)]
        public bool IsIdentity { get; set; }

        [JsonProperty("is_collections")]
        [DefaultValue(false)]
        public bool IsCollections { get; set; }

        [JsonProperty("value")]
        [DefaultValue("")]
        public String Value { get; set; }

        [JsonProperty("min")]
        [DefaultValue(1)]
        public int Min { get; set; }
        [JsonProperty("max")]
        [DefaultValue(20)]
        public int Max { get; set; }

        [JsonIgnore]
        public String[] TemplateString { get; set; }
        public GenStringSetting()
        {
            Min = 10;
            Max = 20;
            IsRandom = true;
        }
    }
}
