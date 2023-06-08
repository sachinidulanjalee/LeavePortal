using DMSSWE;
using DMSSWE.DATA;
using LeavePortal.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.BL
{
    public class LeaveEntitlementGenarateBL
    {
        #region Search

        public List<ApplicableLeaveTypesDTO> GetApplicableLeaveTypesSearchbyLabourAct(CloudConnection oCloudConnection, int labourAct)
        {
            List<ApplicableLeaveTypesDTO> results = new List<ApplicableLeaveTypesDTO>();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" SELECT ");
                sb.AppendLine(" LabourAct,");
                sb.AppendLine(" LeaveCode,");
                sb.AppendLine(" AllocationPeriod");
                sb.AppendLine("  FROM ApplicableLeaveTypes ");
                sb.AppendLine(" WHERE 1=1 ");
                sb.AppendLine(" AND (LabourAct=?LabourAct)");

                oCloudConnection.CommandText = sb.ToString();
                oCloudConnection.Parameters.Clear();
                oCloudConnection.Parameters.Add(new Parameter { Name = "LabourAct", Value = labourAct });

                using (IDataReader dr = oCloudConnection.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ApplicableLeaveTypesDTO result = new ApplicableLeaveTypesDTO();
                        result.LabourAct = Helper.GetDataValue<int>(dr, "LabourAct");
                        result.LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode");
                        result.AllocationPeriod = Helper.GetDataValue<int>(dr, "AllocationPeriod");
                        results.Add(result);
                    }
                    dr.Close();
                }
                return results;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public LeaveTypeDTO LeaveTypeSearchById(CloudConnection oCloudConnection, int leaveCode)
        {
            LeaveTypeDTO result = new LeaveTypeDTO();
            try
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
                return result;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public LeaveAccrualPlanDTO LeaveAccrualPlanSearchById(CloudConnection oCloudConnection, int leaveAccrualType, int leaveCode)
        {
            LeaveAccrualPlanDTO result = new LeaveAccrualPlanDTO();
            try
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
                return result;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public EmpLeaveEntitlementDTO EmpLeaveEntitlementSearchById(CloudConnection oCloudConnection,  int leaveCode, long empNo, DateTime startDate, DateTime endDate)
        {
            EmpLeaveEntitlementDTO result = new EmpLeaveEntitlementDTO();
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" SELECT ");
                sb.AppendLine("LeaveCode,");
                sb.AppendLine("EmpNo,");
                sb.AppendLine("StartDate,");
                sb.AppendLine("EndDate,");
                sb.AppendLine("Amount,");
                sb.AppendLine("Used,");
                sb.AppendLine("LeaveYear,");
                sb.AppendLine("CarryForwardAmount,");
                sb.AppendLine("CreatedDateTime,");
                sb.AppendLine("CreatedUser,");
                sb.AppendLine("CreatedMachine,");
                sb.AppendLine("ModifiedDateTime,");
                sb.AppendLine("ModifiedUser,");
                sb.AppendLine("ModifiedMachine");
                sb.AppendLine(" FROM EmpLeaveEntitlement ");
                sb.AppendLine(" WHERE 1=1 ");
                sb.AppendLine(" AND (LeaveCode=?LeaveCode)");
                sb.AppendLine(" AND (EmpNo=?EmpNo)");
                sb.AppendLine(" AND (convert(varchar(10), StartDate, 120)=?StartDate)");
                sb.AppendLine(" AND (convert(varchar(10), EndDate, 120)=?EndDate)");


                oCloudConnection.CommandText = sb.ToString();
                oCloudConnection.Parameters.Clear();
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = leaveCode });
                oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = empNo });
                oCloudConnection.Parameters.Add(new Parameter { Name = "StartDate", Value = startDate.ToString("yyyy-MM-dd") });
                oCloudConnection.Parameters.Add(new Parameter { Name = "EndDate", Value = endDate.ToString("yyyy-MM-dd") });

                using (IDataReader dr = oCloudConnection.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode");
                        result.EmpNo = Helper.GetDataValue<long>(dr, "EmpNo");
                        result.StartDate = Helper.GetDataValue<DateTime>(dr, "StartDate");
                        result.EndDate = Helper.GetDataValue<DateTime>(dr, "EndDate");
                        result.Amount = Helper.GetDataValue<decimal>(dr, "Amount");
                        result.Used = Helper.GetDataValue<decimal>(dr, "Used");
                        result.LeaveYear = Helper.GetDataValue<int>(dr, "LeaveYear");
                        result.CarryForwardAmount = Helper.GetDataValue<decimal>(dr, "CarryForwardAmount");
                        result.CreatedDateTime = Helper.GetDataValue<DateTime>(dr, "CreatedDateTime");
                        result.CreatedUser = Helper.GetDataValue<string>(dr, "CreatedUser");
                        result.CreatedMachine = Helper.GetDataValue<string>(dr, "CreatedMachine");
                        result.ModifiedDateTime = Helper.GetDataValue<DateTime>(dr, "ModifiedDateTime");
                        result.ModifiedUser = Helper.GetDataValue<string>(dr, "ModifiedUser");
                        result.ModifiedMachine = Helper.GetDataValue<string>(dr, "ModifiedMachine");
                    }
                    dr.Close();
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

        #region Insert

        public void EmpLeaveEntitlementInsert(CloudConnection oCloudConnection, EmpLeaveEntitlementDTO oEmpLeaveEntitlementDTO)
        {
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" IF NOT EXISTS(SELECT *  FROM EmpLeaveEntitlement WHERE LeaveCode=?LeaveCode AND EmpNo=?EmpNo AND StartDate=?StartDate AND EndDate=?EndDate )");
                sb.AppendLine(" BEGIN ");
                sb.AppendLine("     INSERT INTO EmpLeaveEntitlement VALUES(");
                sb.AppendLine("     ?LeaveCode,");
                sb.AppendLine("     ?EmpNo,");
                sb.AppendLine("     ?StartDate,");
                sb.AppendLine("     ?EndDate,");
                sb.AppendLine("     ?Amount,");
                sb.AppendLine("     ?Used,");
                sb.AppendLine("     ?LeaveYear,");
                sb.AppendLine("     ?CarryForwardAmount,");
                sb.AppendLine("     ?CreatedDateTime,");
                sb.AppendLine("     ?CreatedUser,");
                sb.AppendLine("     ?CreatedMachine,");
                sb.AppendLine("     ?ModifiedDateTime,");
                sb.AppendLine("     ?ModifiedUser,");
                sb.AppendLine("     ?ModifiedMachine)");
                sb.AppendLine(" END ");

                oCloudConnection.CommandText = sb.ToString();
                oCloudConnection.Parameters.Clear();
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = oEmpLeaveEntitlementDTO.LeaveCode });
                oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = oEmpLeaveEntitlementDTO.EmpNo });
                oCloudConnection.Parameters.Add(new Parameter { Name = "StartDate", Value = oEmpLeaveEntitlementDTO.StartDate.ToString("yyyy-MM-dd") });
                oCloudConnection.Parameters.Add(new Parameter { Name = "EndDate", Value = oEmpLeaveEntitlementDTO.EndDate.ToString("yyyy-MM-dd") });
                oCloudConnection.Parameters.Add(new Parameter { Name = "Amount", Value = oEmpLeaveEntitlementDTO.Amount });
                oCloudConnection.Parameters.Add(new Parameter { Name = "Used", Value = oEmpLeaveEntitlementDTO.Used });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveYear", Value = oEmpLeaveEntitlementDTO.LeaveYear });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CarryForwardAmount", Value = oEmpLeaveEntitlementDTO.CarryForwardAmount });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = oEmpLeaveEntitlementDTO.CreatedDateTime });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedUser", Value = oEmpLeaveEntitlementDTO.CreatedUser });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedMachine", Value = oEmpLeaveEntitlementDTO.CreatedMachine });
                oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oEmpLeaveEntitlementDTO.ModifiedDateTime });
                oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedUser", Value = oEmpLeaveEntitlementDTO.ModifiedUser });
                oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedMachine", Value = oEmpLeaveEntitlementDTO.ModifiedMachine });
                oCloudConnection.ExecuteQuery();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }


        #endregion Insert

        #region Delete


        #endregion Delete

        #region Update

        public int UpdateEmpLeaveEntitlement(CloudConnection oCloudConnection, int CompanyID, int LeaveCode, long EmpNo, DateTime StartDate, DateTime EndDate, decimal CarryForwardAmount)
        {
            int result = 0;
            try
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" UPDATE EmpLeaveEntitlement");
                sb.AppendLine(" SET ");
                sb.AppendLine(" CarryForwardAmount=?CarryForwardAmount ");
                sb.AppendLine(" WHERE 1=1");
                sb.AppendLine(" AND (CompanyID=?CompanyID)");
                sb.AppendLine(" AND (LeaveCode=?LeaveCode)");
                sb.AppendLine(" AND (EmpNo=?EmpNo)");
                sb.AppendLine(" AND (convert(varchar(10), StartDate, 120)=?StartDate)");
                sb.AppendLine(" AND (convert(varchar(10), EndDate, 120)=?EndDate)");


                oCloudConnection.CommandText = sb.ToString();
                oCloudConnection.Parameters.Clear();
                oCloudConnection.Parameters.Add(new Parameter { Name = "CompanyID", Value = CompanyID });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = LeaveCode });
                oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = EmpNo });
                oCloudConnection.Parameters.Add(new Parameter { Name = "StartDate", Value = StartDate.ToString("yyyy-MM-dd") });
                oCloudConnection.Parameters.Add(new Parameter { Name = "EndDate", Value = EndDate.ToString("yyyy-MM-dd") });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CarryForwardAmount", Value = CarryForwardAmount });
                result = oCloudConnection.ExecuteQuery();
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
