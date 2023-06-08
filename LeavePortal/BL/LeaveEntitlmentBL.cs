using DMSSWE;
using DMSSWE.DATA;
using LeavePortal.Common;
using LeavePortal.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.BL
{
    public class LeaveEntitlementBL
    {
        private EmployeeProfileBL EmployeeProfileBL = new EmployeeProfileBL();
        private LeaveEntitlementGenarateBL oLeaveEntitlementGenarateBL = new LeaveEntitlementGenarateBL();

        protected int GetExperiance(int year, DateTime doj)
        {
            int result = year - doj.Year;

            if (result == 0)
            {
                return (int)LeaveAccrualType.FirstYear;
            }
            else if (result == 1)
            {
                return (int)LeaveAccrualType.SecondYear;
            }
            else
            {
                return (int)LeaveAccrualType.ThirdYearOnwards;
            }
        }
        public ResultDTO GenarateLeaveEntitlement(ArrayList aryEmpCode, int year, string userid)
        {
            ResultDTO oResultDTO = new ResultDTO();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    foreach (var employee in aryEmpCode)
                    {
                        decimal globleEntitlement = 0;
                        long employeId = Convert.ToInt64(employee);

                        EmployeeProfileDTO oEmpDTO = EmployeeProfileBL.EmployeeProfileSearchById(employeId);
                        if (oEmpDTO != null)
                        {
                            int experiance = GetExperiance(year, oEmpDTO.DateOfJoining.Date);
                            List<ApplicableLeaveTypesDTO> oAppLeaveTypesDTOs = oLeaveEntitlementGenarateBL.GetApplicableLeaveTypesSearchbyLabourAct(oCloudConnection,oEmpDTO.LabourAct );
                            if (oAppLeaveTypesDTOs.Count > 0)
                            {
                                foreach (var AppLeaveTypesDTO in oAppLeaveTypesDTOs)
                                {
                                    LeaveTypeDTO oLeaveTypeDTO = oLeaveEntitlementGenarateBL.LeaveTypeSearchById(oCloudConnection, AppLeaveTypesDTO.LeaveCode);
                                    if (oLeaveTypeDTO != null)
                                    {
                                        if (oLeaveTypeDTO.Entitlement >= 0)
                                        {
                                            LeaveAccrualPlanDTO oLeaveAccrualPlanDTO = oLeaveEntitlementGenarateBL.LeaveAccrualPlanSearchById(oCloudConnection, experiance, oLeaveTypeDTO.LeaveCode);
                                            if (oLeaveAccrualPlanDTO != null)
                                            {
                                                if (oLeaveAccrualPlanDTO.IsEntitle == (int)YesNo.Yes)
                                                {
                                                    if (oLeaveAccrualPlanDTO.IsProrate == (int)YesNo.Yes)
                                                    {
                                                        switch (DateTimeUtility.GetQuarter((DateTimeUtility.Month)oEmpDTO.DateOfJoining.Month))
                                                        {
                                                            case DateTimeUtility.Quarter.First:
                                                                globleEntitlement = oLeaveAccrualPlanDTO.FirstQuarterEntitlement;
                                                                break;

                                                            case DateTimeUtility.Quarter.Second:
                                                                globleEntitlement = oLeaveAccrualPlanDTO.SecondQuarterEntitlement;
                                                                break;

                                                            case DateTimeUtility.Quarter.Third:
                                                                globleEntitlement = oLeaveAccrualPlanDTO.ThiredQuarterEntitlement;
                                                                break;

                                                            case DateTimeUtility.Quarter.Fourth:
                                                                globleEntitlement = oLeaveAccrualPlanDTO.FourthQuarterEntitlement;
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        globleEntitlement = oLeaveTypeDTO.Entitlement;
                                                    }

                                                    DateTime firstDayOfYear = new DateTime(1 / 1 / 1999);
                                                    DateTime lastDayOfYear = new DateTime(1 / 1 / 1999);

                                                    int _EntitlementStartMonth = 0;
                                                    switch (AppLeaveTypesDTO.AllocationPeriod)
                                                    {
                                                        case (int)LeaveAllocationPeriod.Calendar_Year:
                                                            firstDayOfYear = (experiance == 0) ? oEmpDTO.DateOfJoining.Date : DateTimeUtility.GetStartOfYear(year);
                                                            lastDayOfYear = DateTimeUtility.GetEndOfYear(year);
                                                            _EntitlementStartMonth = 0;
                                                            break;

                                                        case (int)LeaveAllocationPeriod.Joined_Year:
                                                            firstDayOfYear = new DateTime((year), oEmpDTO.DateOfJoining.Date.Month, oEmpDTO.DateOfJoining.Date.Day);
                                                            lastDayOfYear = new DateTime((year), oEmpDTO.DateOfJoining.Date.Month, oEmpDTO.DateOfJoining.Date.Day).AddYears(1).AddDays(-1).Date;
                                                            _EntitlementStartMonth = firstDayOfYear.Month;
                                                            break;
                                                    }

                                                    switch (oLeaveTypeDTO.LeaveEntitlementMode)
                                                    {
                                                        case (int)LeaveEntitlemant.Monthly:
                                                            DateTime _MonthlyStartDate = new DateTime(oEmpDTO.DateOfJoining.Year, 1, 1);
                                                            int _AllocationStart = (AppLeaveTypesDTO.AllocationPeriod != (int)LeaveAllocationPeriod.Calendar_Year) ? oEmpDTO.DateOfJoining.Month : 0;
                                                            int __MonthlyEndMonth = 12 + _AllocationStart;
                                                            for (int month = _EntitlementStartMonth; __MonthlyEndMonth > month; month++)
                                                            {
                                                                EmpLeaveEntitlementDTO oEmpLeaveEntMonthDTO = new EmpLeaveEntitlementDTO();
                                                                oEmpLeaveEntMonthDTO.LeaveCode = oLeaveTypeDTO.LeaveCode;
                                                                oEmpLeaveEntMonthDTO.EmpNo = employeId;
                                                                oEmpLeaveEntMonthDTO.StartDate = (AppLeaveTypesDTO.AllocationPeriod == (int)LeaveAllocationPeriod.Calendar_Year) ? DateTimeUtility.GetStartOfMonth(firstDayOfYear.Date.AddMonths(month).Month, firstDayOfYear.Date.AddMonths(month).Year).Date : new DateTime(_MonthlyStartDate.Date.AddMonths(month).Year, _MonthlyStartDate.Date.AddMonths(month).Month, _MonthlyStartDate.Date.AddMonths(month).Day).Date;
                                                                oEmpLeaveEntMonthDTO.EndDate = (AppLeaveTypesDTO.AllocationPeriod == (int)LeaveAllocationPeriod.Calendar_Year) ? DateTimeUtility.GetEndOfMonth(firstDayOfYear.Date.AddMonths(month).Month, firstDayOfYear.Date.AddMonths(month).Year).Date : new DateTime(_MonthlyStartDate.Date.AddMonths(month + 1).Year, _MonthlyStartDate.Date.AddMonths(month + 1).Month, _MonthlyStartDate.Date.AddMonths(month + 1).Day).AddDays(-1).Date;
                                                                oEmpLeaveEntMonthDTO.Amount = globleEntitlement;
                                                                oEmpLeaveEntMonthDTO.Used = 0;
                                                                oEmpLeaveEntMonthDTO.LeaveYear = year;
                                                                oEmpLeaveEntMonthDTO.CarryForwardAmount = 0;
                                                                oEmpLeaveEntMonthDTO.CreatedDateTime = DateTime.UtcNow;
                                                                oEmpLeaveEntMonthDTO.CreatedMachine = Environment.MachineName;
                                                                oEmpLeaveEntMonthDTO.CreatedUser = userid; //GlobalVariables.userId;
                                                                oEmpLeaveEntMonthDTO.ModifiedDateTime = DateTime.UtcNow;
                                                                oEmpLeaveEntMonthDTO.ModifiedMachine = Environment.MachineName;
                                                                oEmpLeaveEntMonthDTO.ModifiedUser = userid; //GlobalVariables.userId;

                                                                EmpLeaveEntitlementDTO oEmpLeaveEntitlementMnthDTO = oLeaveEntitlementGenarateBL.EmpLeaveEntitlementSearchById(oCloudConnection, oEmpLeaveEntMonthDTO.LeaveCode, oEmpLeaveEntMonthDTO.EmpNo, oEmpLeaveEntMonthDTO.StartDate, oEmpLeaveEntMonthDTO.EndDate);
                                                                if (oEmpLeaveEntitlementMnthDTO != null)
                                                                {
                                                                    oLeaveEntitlementGenarateBL.EmpLeaveEntitlementInsert(oCloudConnection, oEmpLeaveEntMonthDTO);
                                                                }
                                                            }
                                                            oResultDTO.MessageId = (int)YesNo.Yes;
                                                            oResultDTO.Message = "Successfully Generated !";
                                                            break;

                                                        case (int)LeaveEntitlemant.Annually:
                                                            EmpLeaveEntitlementDTO oEmpLeaveEntitAnnualDTO = new EmpLeaveEntitlementDTO();
                                                            oEmpLeaveEntitAnnualDTO.LeaveCode = oLeaveTypeDTO.LeaveCode;
                                                            oEmpLeaveEntitAnnualDTO.EmpNo = employeId;
                                                            oEmpLeaveEntitAnnualDTO.StartDate = firstDayOfYear.Date;
                                                            oEmpLeaveEntitAnnualDTO.EndDate = lastDayOfYear.Date;
                                                            oEmpLeaveEntitAnnualDTO.Amount = globleEntitlement;
                                                            oEmpLeaveEntitAnnualDTO.Used = 0;
                                                            oEmpLeaveEntitAnnualDTO.LeaveYear = year;
                                                            oEmpLeaveEntitAnnualDTO.CarryForwardAmount = 0;
                                                            oEmpLeaveEntitAnnualDTO.CreatedDateTime = DateTime.UtcNow;
                                                            oEmpLeaveEntitAnnualDTO.CreatedMachine = Environment.MachineName;
                                                            oEmpLeaveEntitAnnualDTO.CreatedUser = userid;//GlobalVariables.userId;
                                                            oEmpLeaveEntitAnnualDTO.ModifiedDateTime = DateTime.UtcNow;
                                                            oEmpLeaveEntitAnnualDTO.ModifiedMachine = Environment.MachineName;
                                                            oEmpLeaveEntitAnnualDTO.ModifiedUser = userid; //GlobalVariables.userId;

                                                            EmpLeaveEntitlementDTO oEmpLeaveEntitlementYearDTO = oLeaveEntitlementGenarateBL.EmpLeaveEntitlementSearchById(oCloudConnection, oEmpLeaveEntitAnnualDTO.LeaveCode, oEmpLeaveEntitAnnualDTO.EmpNo, oEmpLeaveEntitAnnualDTO.StartDate, oEmpLeaveEntitAnnualDTO.EndDate);
                                                            if (oEmpLeaveEntitlementYearDTO != null)
                                                            {
                                                                oLeaveEntitlementGenarateBL.EmpLeaveEntitlementInsert(oCloudConnection, oEmpLeaveEntitAnnualDTO);
                                                                //if (oLeaveTypeDTO.IsCarryForward == (int)YesNo.Yes)
                                                                //{
                                                                //    decimal gLECFAmount = 0;
                                                                //    for (int i = oLeaveTypeDTO.YearsCarriedForward; i >= 1; i--)
                                                                //    {
                                                                //        decimal gCFAmount = 0;
                                                                //        EmpLeaveEntitlementDTO oEmpLeaveEntitlementAnnualDTO = oLeaveEntitlementGenarateBL.EmpLeaveEntitlementSearchById(oCloudConnection, CompanyID, oLeaveTypeDTO.LeaveCode, employeId, firstDayOfYear.AddYears(-i), lastDayOfYear.AddYears(-i));
                                                                //        if (oEmpLeaveEntitlementAnnualDTO.EmpNo != null)
                                                                //        {
                                                                //            if (oLeaveTypeDTO.CarryForwardLimit != 0)
                                                                //            {
                                                                //                if (oEmpLeaveEntitlementAnnualDTO.Amount - oEmpLeaveEntitlementAnnualDTO.Used >= oLeaveTypeDTO.CarryForwardLimit)
                                                                //                {
                                                                //                    gCFAmount = oLeaveTypeDTO.CarryForwardLimit;
                                                                //                    gLECFAmount += gCFAmount;
                                                                //                }
                                                                //                else
                                                                //                {
                                                                //                    gCFAmount = oEmpLeaveEntitlementAnnualDTO.Amount - oEmpLeaveEntitlementAnnualDTO.Used;
                                                                //                    gLECFAmount += gCFAmount;
                                                                //                }
                                                                //            }
                                                                //            LeaveCarryForwaredDTO oLeaveCarryForwaredDTO = new LeaveCarryForwaredDTO();
                                                                //            oLeaveCarryForwaredDTO.CompanyID = CompanyID;
                                                                //            oLeaveCarryForwaredDTO.LeaveCode = oLeaveTypeDTO.LeaveCode;
                                                                //            oLeaveCarryForwaredDTO.EmpNo = employeId;
                                                                //            oLeaveCarryForwaredDTO.Year = (year - i) + 1;
                                                                //            oLeaveCarryForwaredDTO.Amount = gCFAmount;
                                                                //            oLeaveCarryForwaredDTO.CreatedDateTime = DateTime.UtcNow;
                                                                //            oLeaveCarryForwaredDTO.CreatedMachine = Environment.MachineName;
                                                                //            oLeaveCarryForwaredDTO.CreatedUser = userid; //GlobalVariables.userId;
                                                                //            oLeaveCarryForwaredDTO.ModifiedDateTime = DateTime.UtcNow;
                                                                //            oLeaveCarryForwaredDTO.ModifiedMachine = Environment.MachineName;
                                                                //            oLeaveCarryForwaredDTO.ModifiedUser = userid; //GlobalVariables.userId;

                                                                //            oLeaveEntitlementGenarateBL.LeaveCarryForwaredDelete(oCloudConnection, oLeaveCarryForwaredDTO);
                                                                //            oLeaveEntitlementGenarateBL.LeaveCarryForwaredInsert(oCloudConnection, oLeaveCarryForwaredDTO);
                                                                //        }
                                                                //    }
                                                                //    oLeaveEntitlementGenarateBL.UpdateEmpLeaveEntitlement(oCloudConnection, CompanyID, oLeaveTypeDTO.LeaveCode, employeId, firstDayOfYear, lastDayOfYear, gLECFAmount);
                                                                //}
                                                            }
                                                            oResultDTO.MessageId = (int)YesNo.Yes;
                                                            oResultDTO.Message = "Successfully Generated !";
                                                            break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message);
            }

            return oResultDTO;
        }

        #region Insert

        public int EmpLeaveEntitlementInsert(EmpLeaveEntitlementDTO oEmpLeaveEntitlementDTO)
        {
            int result = 0;
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    result = EmpLeaveEntitlementInsert(oCloudConnection, oEmpLeaveEntitlementDTO);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }

            return result;
        }

        public int EmpLeaveEntitlementInsert(CloudConnection oCloudConnection, EmpLeaveEntitlementDTO oEmpLeaveEntitlementDTO)
        {
            int result;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" INSERT INTO EmpLeaveEntitlement VALUES(");
                sb.AppendLine("?CompanyID,");
                sb.AppendLine("?LeaveCode,");
                sb.AppendLine("?EmpNo,");
                sb.AppendLine("?StartDate,");
                sb.AppendLine("?EndDate,");
                sb.AppendLine("?Amount,");
                sb.AppendLine("?Used,");
                sb.AppendLine("?LeaveYear,");
                sb.AppendLine("?CarryForwardAmount,");
                sb.AppendLine("?CreatedDateTime,");
                sb.AppendLine("?CreatedUser,");
                sb.AppendLine("?CreatedMachine,");
                sb.AppendLine("?ModifiedDateTime,");
                sb.AppendLine("?ModifiedUser,");
                sb.AppendLine("?ModifiedMachine)");

                oCloudConnection.CommandText = sb.ToString();
                oCloudConnection.Parameters.Clear();
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = oEmpLeaveEntitlementDTO.LeaveCode });
                oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = oEmpLeaveEntitlementDTO.EmpNo });
                oCloudConnection.Parameters.Add(new Parameter { Name = "StartDate", Value = oEmpLeaveEntitlementDTO.StartDate });
                oCloudConnection.Parameters.Add(new Parameter { Name = "EndDate", Value = oEmpLeaveEntitlementDTO.EndDate });
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
                result = oCloudConnection.ExecuteQuery();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }

            return result;
        }

        #endregion Insert
    }
}
