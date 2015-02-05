using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain.Column
{
    [JsonObject]
    class ReferenceColumn : ColumnBase
    {
         [JsonProperty("cnst_name")]
        public String CnstName { get; set; }
         [JsonIgnore]
         public int CurrentIndex { get; set; }
         [JsonProperty("ref_table")]
         public String RefTableName { get; set; }
         [JsonProperty("ref_col")]
        public String RefColumnName { get; set; }
        public ReferenceColumn()
        {
            CanNull = false;
        }

        public override object NextValue()
        {
            return base.NextValue();
        }
        public override System.Data.DataRow Generate(System.Data.DataRow row)
        {
            return base.Generate(row);
        }
    }
}
