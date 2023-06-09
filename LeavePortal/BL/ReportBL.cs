using DMSSWE;
using DMSSWE.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.BL
{
    public class ReportBL
    {
        public DataSet GetLeaveType()
        {
            DataSet dsReport = new DataSet();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append("SELECT LeaveCode, \n");
                    varname1.Append("       Name, \n");
                    varname1.Append("       Abbreviation, \n");
                    varname1.Append("       LeaveEntitlementMode, \n");
                    varname1.Append("       CASE \n");
                    varname1.Append("         WHEN LeaveEntitlementMode = 1 THEN 'NotUse' \n");
                    varname1.Append("         WHEN LeaveEntitlementMode = 2 THEN 'Weekly' \n");
                    varname1.Append("         WHEN LeaveEntitlementMode = 3 THEN 'Monthly' \n");
                    varname1.Append("         WHEN LeaveEntitlementMode = 4 THEN 'Annually' \n");
                    varname1.Append("         WHEN LeaveEntitlementMode = 5 THEN 'Occasionally' \n");
                    varname1.Append("         WHEN LeaveEntitlementMode = 6 THEN 'Quarterly End' \n");
                    varname1.Append("         WHEN LeaveEntitlementMode = 6 THEN 'Yearly End' \n");
                    varname1.Append("       END AS LeaveEntitlment, \n");
                    varname1.Append("       IsDeductFromQuota, \n");
                    varname1.Append("       CASE \n");
                    varname1.Append("         WHEN IsDeductFromQuota = 1 THEN 'Yes' \n");
                    varname1.Append("         WHEN IsDeductFromQuota = 2 THEN 'No' \n");
                    varname1.Append("       END AS DeductFromQuota, \n");
                    varname1.Append("       DayMode, \n");
                    varname1.Append("       CASE \n");
                    varname1.Append("         WHEN DayMode = 1 THEN 'FullDay' \n");
                    varname1.Append("         WHEN DayMode = 2 THEN 'HalfDay' \n");
                    varname1.Append("         WHEN DayMode = 3 THEN 'Both' \n");
                    varname1.Append("         WHEN DayMode = 4 THEN 'Horuly' \n");
                    varname1.Append("       END AS DayModeDescription, \n");
                    varname1.Append("       Entitlement, \n");
                    varname1.Append("       Status, \n");
                    varname1.Append("       CreatedDateTime, \n");
                    varname1.Append("       CreatedUser, \n");
                    varname1.Append("       CreatedMachine, \n");
                    varname1.Append("       ModifiedDateTime, \n");
                    varname1.Append("       ModifiedUser, \n");
                    varname1.Append("       ModifiedMachine \n");
                    varname1.Append("FROM   LeaveType \n");
                    varname1.Append("where  Status = 1");

                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();

                    dsReport = oCloudConnection.ExecuteDataSet("LeaveType");
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return dsReport;
        }
    }
}
