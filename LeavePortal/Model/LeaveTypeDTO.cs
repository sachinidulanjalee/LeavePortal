using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Model
{
    public class LeaveTypeDTO
    {
        public int LeaveCode { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int LeaveEntitlementMode { get; set; }
        public int IsDeductFromQuota { get; set; }
        public int DayMode { get; set; }
        public decimal Entitlement { get; set; }
        public int Status { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public string CreatedUser { get; set; }
        public string CreatedMachine { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public string ModifiedMachine { get; set; }
    }
}
