using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateSqlData.ReadMeta.Domain
{
   public class GenerateDatabase
    {
        public String Server { get; set; }
        public String Database { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }        
    }
}
