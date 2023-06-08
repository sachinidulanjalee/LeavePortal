using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Model
{
    public class ExpEmployeeProfileDTO : EmployeeProfileDTO
    {

        public int ItemType { get; set; }

        public int ItemCode { get; set; }

        public int DACode { get; set; }

    }
}
