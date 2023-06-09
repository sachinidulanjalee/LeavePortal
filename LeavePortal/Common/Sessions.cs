using LeavePortal.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal
{
   public  class Sessions
    {


        public static List<LeaveTypeDTO> LstlstLeaveTypeDTO
        {
            get { return lstlstLeaveTypeDTO; }
            set { lstlstLeaveTypeDTO = value; }
        }
        private static List<LeaveTypeDTO> lstlstLeaveTypeDTO = new List<LeaveTypeDTO>() { };

        static string LeaveType;
        static decimal Entitlment;
        static decimal Used;
        static decimal Balance;
        static int LeaveCode;
        static string StartDate;
        static string EndDate;
        static string Year;
        static string rptName;
        static string progressThread;

        public static string leaevType
        {

            get
            {
                return LeaveType;
            }
            set
            {
                LeaveType = value;
            }

        }
        public static string entitlment
        {

            get
            {
                return Entitlment.ToString();
            }
            set
            {
              Entitlment= Convert.ToDecimal(value);
            }

        }
        public static string used
        {

            get
            {
                return Used.ToString();
            }
            set
            {
                Used = Convert.ToDecimal(value);
            }

        }
        public static string balance
        {

            get
            {
                return Balance.ToString();
            }
            set
            {
                Balance = Convert.ToDecimal(value);
            }

        }
        public static int leaveCode
        {

            get
            {
                return LeaveCode;
            }
            set
            {
                LeaveCode = value;
            }

        }

        public static string endDate
        {

            get
            {
                return EndDate;
            }
            set
            {
                EndDate = value;
            }

        }
        public static string startDate
        {

            get
            {
                return StartDate;
            }
            set
            {
                StartDate = value;
            }

        }

        public static string year
        {

            get
            {
                return Year;
            }
            set
            {
                Year = value;
            }

        }
        public static string RptName
        {

            get
            {
                return rptName;
            }
            set
            {
                rptName = value;
            }

        }
        public static string ProgressThread
        {

            get
            {
                return progressThread;
            }
            set
            {
                progressThread = value;
            }

        }
        public static List<LeaveRequestDetailDTO> LeaveRequestDetailDTOs
        {
            get { return lstleaveRequestDetailDTO; }
            set { lstleaveRequestDetailDTO = value; }
        }
        private static List<LeaveRequestDetailDTO> lstleaveRequestDetailDTO = new List<LeaveRequestDetailDTO>() { };

        public static LeaveRequestHeaderDTO LeaveRequestHeaderDTOs
        {
            get { return lstleaveRequestHeaderDTO; }
            set { lstleaveRequestHeaderDTO = value; }
        }
        private static LeaveRequestHeaderDTO lstleaveRequestHeaderDTO = new LeaveRequestHeaderDTO () ;

        public static List<EmpLeaveEntitlementDTO> empLeaveEntitlementDTOAdd
        {
            get { return EmpLeaveEntitlementDTOAdd; }
            set { EmpLeaveEntitlementDTOAdd = value; }
        }
        private static List<EmpLeaveEntitlementDTO> EmpLeaveEntitlementDTOAdd = new List<EmpLeaveEntitlementDTO>() { };

        public static List<EmpLeaveEntitlementDTO> EmpLeaveEntitlementDTOUpdate
        {
            get { return empLeaveEntitlementDTOUpdate; }
            set { empLeaveEntitlementDTOUpdate = value; }
        }
        private static List<EmpLeaveEntitlementDTO> empLeaveEntitlementDTOUpdate = new List<EmpLeaveEntitlementDTO>() { };

        public static DataSet dsReport
        {
            get { return dsreport; }
            set { dsreport = value; }
        }
        private static DataSet dsreport = new DataSet();
        public static DataSet ReportData
        {
            get { return reportData; }
            set { reportData = value; }
        }
        private static DataSet reportData = new DataSet();
    }
}
