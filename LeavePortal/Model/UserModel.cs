using System;
using System.Collections.Generic;
using System.Text;

namespace LeavePortal.Model
{
    public class UserModel 
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public int UserType { get; set; }

        public string Email { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int MaximumAttemps { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedMachine { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public string ModifiedMachine { get; set; }
    }

}
