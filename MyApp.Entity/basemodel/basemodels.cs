using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Entity.basemodel
{
    public class basemodels
    {
        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; } 
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; } 
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }

    }
}
