using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Model
{
    public class LeaveRequestHeaderDTO : EmpAttendanceModelDescription
    {
        public int CompanyID { get; set; }

        public long EmpNo { get; set; }

        public int LeaveCode { get; set; }

        public int WhichHalf { get; set; }

        public string WhichHalfText { get; set; }

        public string LeaveCodeText { get; set; }

        public string LeaveChitNumber { get; set; }

        public string EmployeeName { get; set; }

        public DateTime RequestDate { get; set; }

        public string RequestDateText { get; set; }

        public DateTime LeaveDate { get; set; }

        public string LeaveDateText { get; set; }

        public string LeaveStartTimeText { get; set; }

        public string LeaveEndTimeText { get; set; }

        public DateTime StartDate { get; set; } //this nullable change done by didula 2020-04-01

        public DateTime EndDate { get; set; } //this nullable change done by didula 2020-04-01

        public decimal NoOfHoursDays { get; set; }

        public string Remarks { get; set; }

        public long CoveringEmpCode { get; set; }

        public string ContactNoDuringLeave { get; set; }

        public int LeaveStatus { get; set; }

        public string LeaveStatusText { get; set; }

        public string AuthorizedUser { get; set; }

        public DateTime? AuthorizedDate { get; set; }

        public string DenialReason { get; set; }

        public int IsDocumentSubmitted { get; set; }

        public byte[] LeaveDocument { get; set; }

        public DateTime? CancelledDate { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedUser { get; set; }

        public string CreatedMachine { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public string ModifiedUser { get; set; }

        public string ModifiedMachine { get; set; }
    }
}
    public abstract class EmpAttendanceModelDescription
    {
        public string Shiftcode { get; set; }
        public decimal Balance { get; set; }
        public long AuthUser { get; set; }
        public int DeptCode { get; set; }
    }
