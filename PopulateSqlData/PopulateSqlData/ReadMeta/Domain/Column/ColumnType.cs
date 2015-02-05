using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain.Column
{
    public enum ColumnType
    {
        Reference = 0,
        PrimaryUnique,
        ReferenceUnique,
        Normal
    }
}
