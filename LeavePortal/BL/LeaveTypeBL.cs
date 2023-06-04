using DMSSWE;
using DMSSWE.DATA;
using LeavePortal.Common;
using LeavePortal.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.BL
{
    public  class LeaveTypeBL
    {
        #region Insert 
        public int LeaveTypeInsert(LeaveTypeDTO oLeaveTypeDTO)
        {
            int result = 0;
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" IF NOT EXISTS( SELECT * FROM LeaveType WHERE LeaveCode=?LeaveCode ) ");
                    sb.AppendLine(" BEGIN ");
                    sb.AppendLine("      INSERT INTO LeaveType VALUES(");
                    sb.AppendLine("      ?LeaveCode,");
                    sb.AppendLine("      ?Name,");
                    sb.AppendLine("      ?Abbreviation,");
                    sb.AppendLine("      ?LeaveEntitlementMode,");
                    sb.AppendLine("      ?IsDeductFromQuota,");
                    sb.AppendLine("      ?DayMode,");
                    sb.AppendLine("      ?Entitlement,");
                    sb.AppendLine("      ?Status,");
                    sb.AppendLine("      ?CreatedDateTime,");
                    sb.AppendLine("      ?CreatedUser,");
                    sb.AppendLine("      ?CreatedMachine,");
                    sb.AppendLine("      ?ModifiedDateTime,");
                    sb.AppendLine("      ?ModifiedUser,");
                    sb.AppendLine("      ?ModifiedMachine)");
                    sb.AppendLine(" END ");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = oLeaveTypeDTO.LeaveCode });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Name", Value = oLeaveTypeDTO.Name });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Abbreviation", Value = oLeaveTypeDTO.Abbreviation });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveEntitlementMode", Value = oLeaveTypeDTO.LeaveEntitlementMode });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "IsDeductFromQuota", Value = oLeaveTypeDTO.IsDeductFromQuota });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "DayMode", Value = oLeaveTypeDTO.DayMode });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Entitlement", Value = oLeaveTypeDTO.Entitlement });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Status", Value = oLeaveTypeDTO.Status });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = oLeaveTypeDTO.CreatedDateTime });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedUser", Value = oLeaveTypeDTO.CreatedUser });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedMachine", Value = oLeaveTypeDTO.CreatedMachine });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oLeaveTypeDTO.ModifiedDateTime });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedUser", Value = oLeaveTypeDTO.ModifiedUser });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedMachine", Value = oLeaveTypeDTO.ModifiedMachine });
                    result = oCloudConnection.ExecuteQuery();
                }
                return result;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        #endregion Insert

        #region Search
        private static StringBuilder LeaveTypeSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("LeaveCode,");
            sb.AppendLine("Name,");
            sb.AppendLine("Abbreviation,");
            sb.AppendLine("IsDeductFromQuota,");
            sb.AppendLine("DayMode,");
            sb.AppendLine("Entitlement,");
            sb.AppendLine("LeaveEntitlementMode,");
            sb.AppendLine("Status,");
            sb.AppendLine("CreatedDateTime,");
            sb.AppendLine("CreatedUser,");
            sb.AppendLine("CreatedMachine,");
            sb.AppendLine("ModifiedDateTime,");
            sb.AppendLine("ModifiedUser,");
            sb.AppendLine("ModifiedMachine");
            sb.AppendLine(" FROM LeaveType ");
            sb.AppendLine(" WHERE 1=1 ");
            return sb;
        }

        public List<LeaveTypeDTO> LeaveDatagridLoadData()
        {
            List<LeaveTypeDTO> results = new List<LeaveTypeDTO>();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = LeaveTypeSearch();

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LeaveTypeDTO result = new LeaveTypeDTO();
                            result.LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode");
                            result.Name = Helper.GetDataValue<string>(dr, "Name");
                            result.Abbreviation = Helper.GetDataValue<string>(dr, "Abbreviation");
                            result.IsDeductFromQuota = Helper.GetDataValue<int>(dr, "IsDeductFromQuota");
                            result.DayMode = Helper.GetDataValue<int>(dr, "DayMode");
                            result.Entitlement = Helper.GetDataValue<decimal>(dr, "Entitlement");
                            result.LeaveEntitlementMode = Helper.GetDataValue<int>(dr, "LeaveEntitlementMode");
                            result.Status = Helper.GetDataValue<int>(dr, "Status");

                            results.Add(result);
                        }
                        dr.Close();
                    }
                    return results;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LeaveTypeDTO LeaveTypeSearchById(int leaveCode)
        {
            LeaveTypeDTO result = new LeaveTypeDTO();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = LeaveTypeSearch();
                    sb.AppendLine(" AND (LeaveCode=?LeaveCode)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = leaveCode });

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode");
                            result.Name = Helper.GetDataValue<string>(dr, "Name");
                            result.Abbreviation = Helper.GetDataValue<string>(dr, "Abbreviation");
                            result.IsDeductFromQuota = Helper.GetDataValue<int>(dr, "IsDeductFromQuota");
                            result.DayMode = Helper.GetDataValue<int>(dr, "DayMode");
                            result.Entitlement = Helper.GetDataValue<decimal>(dr, "Entitlement");
                            result.LeaveEntitlementMode = Helper.GetDataValue<int>(dr, "LeaveEntitlementMode");
                            result.Status = Helper.GetDataValue<int>(dr, "Status");
                            result.CreatedDateTime = Helper.GetDataValue<DateTime>(dr, "CreatedDateTime");
                            result.CreatedUser = Helper.GetDataValue<string>(dr, "CreatedUser");
                            result.CreatedMachine = Helper.GetDataValue<string>(dr, "CreatedMachine");
                            result.ModifiedDateTime = Helper.GetDataValue<DateTime>(dr, "ModifiedDateTime");
                            result.ModifiedUser = Helper.GetDataValue<string>(dr, "ModifiedUser");
                            result.ModifiedMachine = Helper.GetDataValue<string>(dr, "ModifiedMachine");
                        }
                        dr.Close();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }
        #endregion Search
    }
}
