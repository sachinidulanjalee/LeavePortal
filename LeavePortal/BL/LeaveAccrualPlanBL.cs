using DMSSWE;
using DMSSWE.DATA;
using LeavePortal.Common;
using LeavePortal.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LeavePortal.BL
{
    public class LeaveAccrualPlanBL : CommonBL
    {
        #region Search

        public List<LeaveAccrualPlanDTO> AccrualLeaveDatagridLoadData()
        {
            List<LeaveAccrualPlanDTO> results = new List<LeaveAccrualPlanDTO>();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append("select A.LeaveAccrualType, CASE A.LeaveAccrualType WHEN 1 THEN 'First Year' WHEN 2 THEN 'Second Year' WHEN 3 THEN 'Third Year Onwards' END AS LeaveAccrualTypeText, ");
                    varname1.Append("   A.LeaveCode, B.Name, A.IsEntitle, A.IsProrate, A.FirstQuarterEntitlement, ");
                    varname1.Append("   A.SecondQuarterEntitlement, A.ThiredQuarterEntitlement, A.FourthQuarterEntitlement ");
                    varname1.Append("   from LeaveAccrualPlan A LEFT JOIN LeaveType B on A.LeaveCode = B.LeaveCode");
                    varname1.Append("     where 1=1");

                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LeaveAccrualPlanDTO result = new LeaveAccrualPlanDTO();
                            result.LeaveAccrualType = Helper.GetDataValue<int>(dr, "LeaveAccrualType");
                            // result.LeaveAccrualTypeText = Enum.GetName(typeof(LeaveAccrualType), Helper.GetDataValue<int>(dr, "LeaveAccrualType"));
                            result.LeaveAccrualTypeText = Helper.GetDataValue<string>(dr, "LeaveAccrualTypeText");
                            result.LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode");
                            result.LeaveCodeText = Helper.GetDataValue<string>(dr, "Name");
                            result.IsEntitle = Helper.GetDataValue<int>(dr, "IsEntitle");
                            // result.IsEntitleText = Enum.GetName(typeof(DaycrossMode), Helper.GetDataValue<int>(dr, "IsEntitle"));
                            result.IsProrate = Helper.GetDataValue<int>(dr, "IsProrate");
                            // result.IsProrateText = Enum.GetName(typeof(DaycrossMode), Helper.GetDataValue<int>(dr, "IsProrate"));
                            result.FirstQuarterEntitlement = Helper.GetDataValue<int>(dr, "FirstQuarterEntitlement");
                            result.SecondQuarterEntitlement = Helper.GetDataValue<int>(dr, "SecondQuarterEntitlement");
                            result.ThiredQuarterEntitlement = Helper.GetDataValue<int>(dr, "ThiredQuarterEntitlement");
                            result.FourthQuarterEntitlement = Helper.GetDataValue<int>(dr, "FourthQuarterEntitlement");

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

        public LeaveAccrualPlanDTO LeaveAccrualPlanSearchById(int leaveAccrualType, int leaveCode)
        {
            LeaveAccrualPlanDTO result = new LeaveAccrualPlanDTO();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT ");
                    sb.AppendLine("LeaveAccrualType,");
                    sb.AppendLine("LeaveCode,");
                    sb.AppendLine("IsEntitle,");
                    sb.AppendLine("IsProrate,");
                    sb.AppendLine("FirstQuarterEntitlement,");
                    sb.AppendLine("SecondQuarterEntitlement,");
                    sb.AppendLine("ThiredQuarterEntitlement,");
                    sb.AppendLine("FourthQuarterEntitlement,");
                    sb.AppendLine("CreatedDateTime,");
                    sb.AppendLine("CreatedUser,");
                    sb.AppendLine("CreatedMachine,");
                    sb.AppendLine("ModifiedDateTime,");
                    sb.AppendLine("ModifiedUser,");
                    sb.AppendLine("ModifiedMachine");
                    sb.AppendLine(" FROM LeaveAccrualPlan ");
                    sb.AppendLine(" WHERE 1=1 ");
                    sb.AppendLine(" AND (LeaveAccrualType=?LeaveAccrualType)");
                    sb.AppendLine(" AND (LeaveCode=?LeaveCode)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveAccrualType", Value = leaveAccrualType });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = leaveCode });

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.LeaveAccrualType = Helper.GetDataValue<int>(dr, "LeaveAccrualType");
                            result.LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode");
                            result.IsEntitle = Helper.GetDataValue<int>(dr, "IsEntitle");
                            result.IsProrate = Helper.GetDataValue<int>(dr, "IsProrate");
                            result.FirstQuarterEntitlement = Helper.GetDataValue<int>(dr, "FirstQuarterEntitlement");
                            result.SecondQuarterEntitlement = Helper.GetDataValue<int>(dr, "SecondQuarterEntitlement");
                            result.ThiredQuarterEntitlement = Helper.GetDataValue<int>(dr, "ThiredQuarterEntitlement");
                            result.FourthQuarterEntitlement = Helper.GetDataValue<int>(dr, "FourthQuarterEntitlement");
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

        public List<LeaveAccrualPlanDTO> ApplicableLeaveTypeSearch(List<ParamsDTO> oParamsDTOs)
        {
            List<LeaveAccrualPlanDTO> results = new List<LeaveAccrualPlanDTO>();
            try
            {
                string query = base.GenerateQueryFromListArray(oParamsDTOs);

                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select LeaveAccrualPlan.LeaveAccrualType, LeaveAccrualPlan.LeaveCode, LeaveType.Name, LeaveAccrualPlan.IsEntitle, LeaveAccrualPlan.IsProrate, LeaveAccrualPlan.FirstQuarterEntitlement, ");
                    sb.AppendLine("   LeaveAccrualPlan.SecondQuarterEntitlement, LeaveAccrualPlan.ThiredQuarterEntitlement, LeaveAccrualPlan.FourthQuarterEntitlement ");
                    sb.AppendLine("   from LeaveAccrualPlan LeaveAccrualPlan LEFT JOIN LeaveType LeaveType on LeaveAccrualPlan.LeaveCode = LeaveType.LeaveCode");
                    sb.AppendLine("     where 1=1");
                    sb.AppendLine(query);

                    oCloudConnection.CommandText = sb.ToString();

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LeaveAccrualPlanDTO result = new LeaveAccrualPlanDTO();
                            result.LeaveAccrualType = Helper.GetDataValue<int>(dr, "LeaveAccrualType");
                            result.LeaveAccrualTypeText = Enum.GetName(typeof(LeaveAccrualType), Helper.GetDataValue<int>(dr, "LeaveAccrualType"));
                            result.LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode");
                            result.LeaveCodeText = Helper.GetDataValue<string>(dr, "Name");
                            result.IsEntitle = Helper.GetDataValue<int>(dr, "IsEntitle");
                            result.IsProrate = Helper.GetDataValue<int>(dr, "IsProrate");
                            result.FirstQuarterEntitlement = Helper.GetDataValue<int>(dr, "FirstQuarterEntitlement");
                            result.SecondQuarterEntitlement = Helper.GetDataValue<int>(dr, "SecondQuarterEntitlement");
                            result.ThiredQuarterEntitlement = Helper.GetDataValue<int>(dr, "ThiredQuarterEntitlement");
                            result.FourthQuarterEntitlement = Helper.GetDataValue<int>(dr, "FourthQuarterEntitlement");

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

        public bool IsLeaveAcrualTypeExists(int LeaveAccrualType, int LeaveCode)
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
                    varname1.Append("	     AND (LeaveAccrualType=?LeaveAccrualType)");
                    varname1.Append("	     AND (LeaveCode=?LeaveCode)");
                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveAccrualType", Value = LeaveAccrualType });
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

        #region Insert

        public int LeaveAccrualPlanInsert(LeaveAccrualPlanDTO oLeaveAccrualPlanDTO)
        {
            int result = 0;
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" INSERT INTO LeaveAccrualPlan VALUES(");
                    sb.AppendLine("?LeaveAccrualType,");
                    sb.AppendLine("?LeaveCode,");
                    sb.AppendLine("?IsEntitle,");
                    sb.AppendLine("?IsProrate,");
                    sb.AppendLine("?FirstQuarterEntitlement,");
                    sb.AppendLine("?SecondQuarterEntitlement,");
                    sb.AppendLine("?ThiredQuarterEntitlement,");
                    sb.AppendLine("?FourthQuarterEntitlement,");
                    sb.AppendLine("?CreatedDateTime,");
                    sb.AppendLine("?CreatedUser,");
                    sb.AppendLine("?CreatedMachine,");
                    sb.AppendLine("?ModifiedDateTime,");
                    sb.AppendLine("?ModifiedUser,");
                    sb.AppendLine("?ModifiedMachine)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveAccrualType", Value = oLeaveAccrualPlanDTO.LeaveAccrualType });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = oLeaveAccrualPlanDTO.LeaveCode });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "IsEntitle", Value = oLeaveAccrualPlanDTO.IsEntitle });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "IsProrate", Value = oLeaveAccrualPlanDTO.IsProrate });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "FirstQuarterEntitlement", Value = oLeaveAccrualPlanDTO.FirstQuarterEntitlement });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "SecondQuarterEntitlement", Value = oLeaveAccrualPlanDTO.SecondQuarterEntitlement });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ThiredQuarterEntitlement", Value = oLeaveAccrualPlanDTO.ThiredQuarterEntitlement });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "FourthQuarterEntitlement", Value = oLeaveAccrualPlanDTO.FourthQuarterEntitlement });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = oLeaveAccrualPlanDTO.CreatedDateTime });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedUser", Value = oLeaveAccrualPlanDTO.CreatedUser });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedMachine", Value = oLeaveAccrualPlanDTO.CreatedMachine });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oLeaveAccrualPlanDTO.ModifiedDateTime });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedUser", Value = oLeaveAccrualPlanDTO.ModifiedUser });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedMachine", Value = oLeaveAccrualPlanDTO.ModifiedMachine });
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

        #endregion Insert

        #region Delete

        public int LeaveAccrualPlanDelete(LeaveAccrualPlanDTO oLeaveAccrualPlanDTO)
        {
            int result = 0;
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" DELETE FROM LeaveAccrualPlan");
                    sb.AppendLine(" WHERE 1=1");
                    sb.AppendLine(" AND (LeaveAccrualType=?LeaveAccrualType)");
                    sb.AppendLine(" AND (LeaveCode=?LeaveCode)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveAccrualType", Value = oLeaveAccrualPlanDTO.LeaveAccrualType });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = oLeaveAccrualPlanDTO.LeaveCode });
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

        #region Update

        public int LeaveAccrualPlanUpdate(LeaveAccrualPlanDTO oLeaveAccrualPlanDTO)
        {
            int result = 0;
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" UPDATE LeaveAccrualPlan");
                    sb.AppendLine(" SET ");
                    sb.AppendLine("IsEntitle=?IsEntitle,");
                    sb.AppendLine("IsProrate=?IsProrate,");
                    sb.AppendLine("FirstQuarterEntitlement=?FirstQuarterEntitlement,");
                    sb.AppendLine("SecondQuarterEntitlement=?SecondQuarterEntitlement,");
                    sb.AppendLine("ThiredQuarterEntitlement=?ThiredQuarterEntitlement,");
                    sb.AppendLine("FourthQuarterEntitlement=?FourthQuarterEntitlement,");
                    sb.AppendLine("CreatedDateTime=?CreatedDateTime,");
                    sb.AppendLine("CreatedUser=?CreatedUser,");
                    sb.AppendLine("CreatedMachine=?CreatedMachine,");
                    sb.AppendLine("ModifiedDateTime=?ModifiedDateTime,");
                    sb.AppendLine("ModifiedUser=?ModifiedUser,");
                    sb.AppendLine("ModifiedMachine=?ModifiedMachine");
                    sb.AppendLine(" WHERE 1=1");
                    sb.AppendLine(" AND (LeaveAccrualType=?LeaveAccrualType)");
                    sb.AppendLine(" AND (LeaveCode=?LeaveCode)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveAccrualType", Value = oLeaveAccrualPlanDTO.LeaveAccrualType });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = oLeaveAccrualPlanDTO.LeaveCode });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "IsEntitle", Value = oLeaveAccrualPlanDTO.IsEntitle });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "IsProrate", Value = oLeaveAccrualPlanDTO.IsProrate });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "FirstQuarterEntitlement", Value = oLeaveAccrualPlanDTO.FirstQuarterEntitlement });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "SecondQuarterEntitlement", Value = oLeaveAccrualPlanDTO.SecondQuarterEntitlement });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ThiredQuarterEntitlement", Value = oLeaveAccrualPlanDTO.ThiredQuarterEntitlement });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "FourthQuarterEntitlement", Value = oLeaveAccrualPlanDTO.FourthQuarterEntitlement });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = oLeaveAccrualPlanDTO.CreatedDateTime });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedUser", Value = oLeaveAccrualPlanDTO.CreatedUser });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedMachine", Value = oLeaveAccrualPlanDTO.CreatedMachine });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oLeaveAccrualPlanDTO.ModifiedDateTime });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedUser", Value = oLeaveAccrualPlanDTO.ModifiedUser });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedMachine", Value = oLeaveAccrualPlanDTO.ModifiedMachine });
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
    }
}