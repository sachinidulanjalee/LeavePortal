using DMSSWE;
using DMSSWE.DATA;
using LeavePortal.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LeavePortal.BL
{
    public class LeaveTypeBL : CommonBL
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

        //common query
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

        //load data grid values to leave type form
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

        //search query
        public List<LeaveTypeDTO> LeaveTypeSearch(List<ParamsDTO> oParamsDTOs)
        {
            List<LeaveTypeDTO> results = new List<LeaveTypeDTO>();
            try
            {
                string query = base.GenerateQueryFromListArray(oParamsDTOs);

                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = LeaveTypeSearch();
                    sb.AppendLine(query);

                    oCloudConnection.CommandText = sb.ToString();

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
                            result.CreatedDateTime = Helper.GetDataValue<DateTime>(dr, "CreatedDateTime");
                            result.CreatedUser = Helper.GetDataValue<string>(dr, "CreatedUser");
                            result.CreatedMachine = Helper.GetDataValue<string>(dr, "CreatedMachine");
                            result.ModifiedDateTime = Helper.GetDataValue<DateTime>(dr, "ModifiedDateTime");
                            result.ModifiedUser = Helper.GetDataValue<string>(dr, "ModifiedUser");
                            result.ModifiedMachine = Helper.GetDataValue<string>(dr, "ModifiedMachine");
                            results.Add(result);
                        }
                        dr.Close();
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public List<DropListDTO> LeaveTypeSearchForDropDown(int Status)
        {
            List<DropListDTO> results = new List<DropListDTO>();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("    SELECT ");
                    sb.AppendLine("   LeaveCode,");
                    sb.AppendLine("   Name");
                    sb.AppendLine("   FROM LeaveType ");
                    sb.AppendLine("   WHERE 1=1 ");
                    sb.AppendLine("   AND (Status=?Status)");
                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Status", Value = Status });

                    results.Add(new DropListDTO { Value = "", Text = "--Select--" });
                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DropListDTO result = new DropListDTO();
                            result.Value = Helper.GetDataValue<int>(dr, "LeaveCode").ToString();
                            result.Text = Helper.GetDataValue<string>(dr, "Name");
                            results.Add(result);
                        }
                        dr.Close();
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public bool IsLeaveTypeExistsApplicableLeaveTypes(string LeaveCode)
        {
            int result = 0;
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append(" SELECT COUNT(*) ");
                    varname1.Append(" FROM   ApplicableLeaveTypes  ");
                    varname1.Append(" WHERE  (1=1) ");
                    varname1.Append("	     AND (LeaveCode=?LeaveCode)");
                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = LeaveCode });
                    result = Convert.ToInt32(oCloudConnection.ExecuteScalar());
                }
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsLeaveTypeExistsLeaveAccrualPlan(string LeaveCode)
        {
            int result = 0;
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append(" SELECT COUNT(*) ");
                    varname1.Append(" FROM   LeaveAccrualPlan  ");
                    varname1.Append(" WHERE  (1=1) ");
                    varname1.Append("	     AND (LeaveCode=?LeaveCode)");
                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = LeaveCode });
                    result = Convert.ToInt32(oCloudConnection.ExecuteScalar());
                }
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Search

        #region Update
        public int LeaveTypeUpdate(LeaveTypeDTO oLeaveTypeDTO)
        {
            int result = 0;
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" UPDATE LeaveType");
                    sb.AppendLine(" SET ");
                    sb.AppendLine("Name=?Name,");
                    sb.AppendLine("Abbreviation=?Abbreviation,");
                    sb.AppendLine("IsDeductFromQuota=?IsDeductFromQuota,");
                    sb.AppendLine("DayMode=?DayMode,");
                    sb.AppendLine("Entitlement=?Entitlement,");
                    sb.AppendLine("LeaveEntitlementMode=?LeaveEntitlementMode,");
                    sb.AppendLine("Status=?Status,");
                    sb.AppendLine("CreatedDateTime=?CreatedDateTime,");
                    sb.AppendLine("CreatedUser=?CreatedUser,");
                    sb.AppendLine("CreatedMachine=?CreatedMachine,");
                    sb.AppendLine("ModifiedDateTime=?ModifiedDateTime,");
                    sb.AppendLine("ModifiedUser=?ModifiedUser,");
                    sb.AppendLine("ModifiedMachine=?ModifiedMachine");
                    sb.AppendLine(" WHERE 1=1");
                    sb.AppendLine(" AND (LeaveCode=?LeaveCode)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = oLeaveTypeDTO.LeaveCode });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Name", Value = oLeaveTypeDTO.Name });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Abbreviation", Value = oLeaveTypeDTO.Abbreviation });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "IsDeductFromQuota", Value = oLeaveTypeDTO.IsDeductFromQuota });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "DayMode", Value = oLeaveTypeDTO.DayMode });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Entitlement", Value = oLeaveTypeDTO.Entitlement });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveEntitlementMode", Value = oLeaveTypeDTO.LeaveEntitlementMode });
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
                Logger.Write(ex);
                throw ex;
            }
        }
        #endregion Update


        #region Delete

        public int LeaveTypeDelete(LeaveTypeDTO oLeaveTypeDTO)
        {
            int result = 0;
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" DELETE FROM LeaveType");
                    sb.AppendLine(" WHERE 1=1");
                    sb.AppendLine(" AND (LeaveCode=?LeaveCode)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = oLeaveTypeDTO.LeaveCode });
                    result = oCloudConnection.ExecuteQuery();
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        #endregion Delete
    }
}