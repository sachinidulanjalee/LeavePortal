using LeavePortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.BL
{
    public class EmployeeValidationBL
    {
        private DesignationBL oDesignationBL = new DesignationBL();
        private EmployeeProfileBL oEmployeeProfileBL = new EmployeeProfileBL();

        public bool ValidateDesignation( int designationId)
        {
            bool retVal = false;
            try
            {
                DesignationDTO oDesignationDTO = oDesignationBL.DesignationSearchById( designationId);
                if (oDesignationDTO != null)
                {
                    if (oDesignationDTO.DesignationID == designationId)
                        retVal = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retVal;
        }

    }
}
