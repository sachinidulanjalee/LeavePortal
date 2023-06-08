using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Model
{
    public class LeaveRequestDetailDTO : EmpAttendanceModelDescription
    {
        public int CompanyID { get; set; }

        public long EmpNo { get; set; }

        public DateTime LeaveDate { get; set; }

        public int DaySequence { get; set; }

        public int LeaveCode { get; set; }

        public string LeaveCodeText { get; set; }

        public string LeaveChitNumber { get; set; }

        public int DayMode { get; set; }

        public int WhichHalf { get; set; }

        public DateTime LeaveStart { get; set; }

        public DateTime LeaveEnd { get; set; }

        public decimal NoOfHoursDays { get; set; }

        public string ShiftCode { get; set; }

        public int AuthStatus { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedUser { get; set; }

        public string CreatedMachine { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public string ModifiedUser { get; set; }

        public string ModifiedMachine { get; set; }

      
    }
    public abstract class EmpAttendanceModelDescription
    {
        public decimal Balance { get; set; }


    }
}
