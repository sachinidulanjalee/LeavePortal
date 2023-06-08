using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Model
{
    public class EmployeeProfileDTO
    {
       
       public long EmpNo { get; set; }

       
        public int Title { get; set; }


        public string Description { get; set; }

      
        public string ShortName { get; set; }

        
        public string EmployeeNameandNo { get; set; }

      
        public string FullName { get; set; }

       
        public string SurName { get; set; }

      
        public int Designation { get; set; }

        public string DesignationText { get; set; }

        public string NICNo { get; set; }

        public int EPFNo { get; set; }

        public int ETFNo { get; set; }

        public int Gender { get; set; }

        public int Religion { get; set; }


        public int Nationality { get; set; }


        public int CivilStatus { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfJoining { get; set; }


        public DateTime DateOfLeaving { get; set; }


        public long ReportingTo { get; set; }

        public string Email { get; set; }


        public string HomeTelephone { get; set; }


        public string Mobile { get; set; }

        public byte[] EmployeePhoto { get; set; }


        public int LabourAct { get; set; }
        public int Status { get; set; }

        public int EmployeesCount { get; set; }

        public string StatusText { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedUser { get; set; }

        public string CreatedMachine { get; set; }


        public DateTime ModifiedDateTime { get; set; }

        public string ModifiedUser { get; set; }

        public string ModifiedMachine { get; set; }

        public int AuthorizedType { get; set; }
        public int AuthorizedLevel { get; set; }

    }
}
