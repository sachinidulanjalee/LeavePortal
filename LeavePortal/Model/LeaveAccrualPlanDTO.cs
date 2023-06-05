using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Model
{
    public class LeaveAccrualPlanDTO : LeaveAccrualPlanDescription
    {

        public int LeaveAccrualType { get; set; }

        public int LeaveCode { get; set; }

        public int IsEntitle { get; set; }


        public int IsProrate { get; set; }
      

        public int FirstQuarterEntitlement { get; set; }

        public int SecondQuarterEntitlement { get; set; }

        public int ThiredQuarterEntitlement { get; set; }

        public int FourthQuarterEntitlement { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedUser { get; set; }

        public string CreatedMachine { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public string ModifiedUser { get; set; }

        public string ModifiedMachine { get; set; }
    }

    public abstract class LeaveAccrualPlanDescription
    {
        public string LeaveAccrualTypeText { get; set; }

        public string LeaveCodeText { get; set; }

        public string IsEntitleText { get; set; }

        public string IsProrateText { get; set; }

    }
}
