using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain.Column
{
    [JsonObject]
    class PrimaryColumn : ColumnBase
    {
        public PrimaryColumn()
        {
            CanNull = false;
            CanRestartSequence = false;
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
