using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain.Column
{
    class NormalColumn : ColumnBase
    {
        public NormalColumn()
        {
            CanRestartSequence = true;
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
