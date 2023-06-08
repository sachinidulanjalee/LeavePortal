using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Model
{
    public class ApplicableLeaveTypesDTO
    {



        public int LabourAct { get; set; }


        public string LabourActText { get; set; }


        public int LeaveCode { get; set; }


        public string LeaveCodeText { get; set; }


        public int AllocationPeriod { get; set; }


        public string AllocationPeriodText { get; set; }


        public DateTime CreatedDateTime { get; set; }


        public string CreatedBy { get; set; }

        public string CreatedMachine { get; set; }


        public DateTime ModifiedDateTime { get; set; }


        public string ModifiedBy { get; set; }


        public string ModifiedMachine { get; set; }
    }
}
