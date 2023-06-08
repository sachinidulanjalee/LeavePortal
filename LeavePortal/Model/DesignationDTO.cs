using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Model
{
    public class DesignationDTO
    {
        public int DesignationID { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public string StatusText { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedUser { get; set; }


        public string CreatedMachine { get; set; }


        public DateTime ModifiedDateTime { get; set; }

        public string ModifiedUser { get; set; }

        public string ModifiedMachine { get; set; }
    }
}
