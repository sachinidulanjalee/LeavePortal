using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Model
{
    public partial class EmpLeaveEntitlementDTO
    {
       
        public int LeaveCode { get; set; }


        public long EmpNo { get; set; }


        public string Name { get; set; }

        public DateTime StartDate { get; set; }


        public string StartDateText { get; set; }


        public DateTime EndDate { get; set; }


        public string EndDateText { get; set; }

        public decimal Amount { get; set; }


        public decimal Used { get; set; }


        public decimal Balance { get; set; }


        public int LeaveYear { get; set; }


        public decimal CarryForwardAmount { get; set; }


        public DateTime CreatedDateTime { get; set; }


        public string CreatedUser { get; set; }


        public string CreatedMachine { get; set; }

        public DateTime ModifiedDateTime { get; set; }


        public string ModifiedUser { get; set; }

        public string ModifiedMachine { get; set; }
    }

    public partial class EmpLeaveEntitlementDTO
    {
        public string StartEndDate { get; set; }
    }
}
