using Newtonsoft.Json;
using PopulateSqlData.ReadMeta.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        [JsonProperty("ref_table")]
        public String RefTableName { get; set; }

        [JsonProperty("ref_col")]
        public String RefColumnName { get; set; }

        [JsonIgnore]
        public int CurrentIndex { get; set; }

        public List<List<Object>> Store { get; set; }
        public ReferenceColumn()
        {
            CanNull = false;
            Store = new List<List<object>>();
            CurrentIndex = -1;
        }

        public override object NextValue()
        {
            if (CurrentIndex <= -1 || Store.Count <= 0)
            {
                //fetch in database 
                Store = FetchDataUtils.Fetch(1000, RefTableName, null, RefColumnName);
                Debug.Print(Store.Count + "");
            }
            else
                if (CurrentIndex >= Store.Count && CanRestartSequence)
                {
                    CurrentIndex = 0;
                }
            if (CurrentIndex < 0)
                CurrentIndex = 0;
            return Store[CurrentIndex++];
        }
        public override System.Data.DataRow Generate(System.Data.DataRow row)
        {
            lock (this)
            {
                var list = NextValue() as List<Object>;                
                row[Name] =  list[0];
            }
            return row;
        }
    }
}
