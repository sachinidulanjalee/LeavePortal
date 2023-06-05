using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Model
{
    public class ParamsDTO
    {
        public string ColumnName { get; set; }

        public string Operator { get; set; }

        public object Value { get; set; }
    }
}
