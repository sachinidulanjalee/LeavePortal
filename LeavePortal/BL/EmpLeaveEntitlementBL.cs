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
    public class EmpLeaveEntitlementBL
    {
        private static StringBuilder EmpLeaveEntitlementSearch()
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
            return sb;
        }
        public List<EmpLeaveEntitlementDTO> EmpLeaveEntitlementData(long EmpNo, int LeaveYear)
        {
            List<EmpLeaveEntitlementDTO> results = new List<EmpLeaveEntitlementDTO>();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append("SELECT \n");
                    varname1.Append("       A.LeaveCode, \n");
                    varname1.Append("       A.Abbreviation, \n");
                    varname1.Append("       A.Name, \n");
                    varname1.Append("       B.StartDate, \n");
                    varname1.Append("       B.EndDate, \n");
                    varname1.Append("       CONVERT(VARCHAR(50),B.StartDate,23) +' - '+CONVERT(VARCHAR(50),B.EndDate,23) StartEndDate, \n");
                    varname1.Append("       ISNULL(B.Amount, 0) Amount, \n");
                    varname1.Append("       ISNULL(B.Used, 0)   Used \n");
                    varname1.Append("FROM   (SELECT  \n");
                    varname1.Append("               [LeaveCode], \n");
                    varname1.Append("               [Abbreviation], \n");
                    varname1.Append("               [Name] \n");
                    varname1.Append("        FROM   [LeaveType] \n");
                    varname1.Append("        WHERE  [Status] = 1) A \n");
                    varname1.Append("       LEFT JOIN (SELECT \n");
                    varname1.Append("                         [LeaveCode], \n");
                    varname1.Append("                         [Amount], \n");
                    varname1.Append("                         [Used], \n");
                    varname1.Append("                         [StartDate], \n");
                    varname1.Append("                         [EndDate] \n");
                    varname1.Append("                  FROM   EmpLeaveEntitlement \n");
                    varname1.Append("                  WHERE \n");
                    varname1.Append("                          EmpNo = ?EmpNo \n");
                    varname1.Append("                         AND LeaveYear = ?LeaveYear) B \n");
                    varname1.Append("              ON A.LeaveCode = B.LeaveCode \n");

                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = EmpNo });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveYear", Value = LeaveYear });
                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EmpLeaveEntitlementDTO result = new EmpLeaveEntitlementDTO();

                            result.LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode");
                            result.Name = Helper.GetDataValue<string>(dr, "Name");
                            result.Amount = Helper.GetDataValue<decimal>(dr, "Amount");
                            result.Used = Helper.GetDataValue<decimal>(dr, "Used");
                            result.Balance = result.Amount - result.Used;
                            result.StartEndDate = Helper.GetDataValue<string>(dr, "StartEndDate");
                            result.StartDate = Helper.GetDataValue<DateTime>(dr, "StartDate");
                            result.EndDate = Helper.GetDataValue<DateTime>(dr, "EndDate");
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

        public List<EmpLeaveEntitlementDTO> EmpLeaveEntitlementSerch(long EmpNo, int Year)
        {
            List<EmpLeaveEntitlementDTO> results = new List<EmpLeaveEntitlementDTO>();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = EmpLeaveEntitlementSearch();
                    sb.AppendLine(" AND (EmpNo=?EmpNo)");
                    sb.AppendLine(" AND (LeaveYear=?Year)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = EmpNo });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Year", Value = Year });

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EmpLeaveEntitlementDTO result = new EmpLeaveEntitlementDTO
                            {
                                LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode"),
                                EmpNo = Helper.GetDataValue<long>(dr, "EmpNo"),
                                StartDate = Helper.GetDataValue<DateTime>(dr, "StartDate"),
                                EndDate = Helper.GetDataValue<DateTime>(dr, "EndDate"),
                                Amount = Helper.GetDataValue<decimal>(dr, "Amount"),
                                Used = Helper.GetDataValue<decimal>(dr, "Used"),
                                LeaveYear = Helper.GetDataValue<int>(dr, "LeaveYear"),
                                CarryForwardAmount = Helper.GetDataValue<decimal>(dr, "CarryForwardAmount"),
                                CreatedDateTime = Helper.GetDataValue<DateTime>(dr, "CreatedDateTime"),
                                CreatedUser = Helper.GetDataValue<string>(dr, "CreatedUser"),
                                CreatedMachine = Helper.GetDataValue<string>(dr, "CreatedMachine"),
                                ModifiedDateTime = Helper.GetDataValue<DateTime>(dr, "ModifiedDateTime"),
                                ModifiedUser = Helper.GetDataValue<string>(dr, "ModifiedUser"),
                                ModifiedMachine = Helper.GetDataValue<string>(dr, "ModifiedMachine")
                            };

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
        public List<EmpLeaveEntitlementDTO> EmpLeaveEntitlementSearchByRange(long empNo, int leaveCode, DateTime startDate, DateTime endDate)
        {
            List<EmpLeaveEntitlementDTO> results = new List<EmpLeaveEntitlementDTO>();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = EmpLeaveEntitlementSearch();

                    sb.AppendLine(" AND (LeaveCode=?LeaveCode)");
                    sb.AppendLine(" AND (EmpNo=?EmpNo)");
                    sb.AppendLine(" AND (StartDate  <= ?StartDate AND EndDate >= ?EndDate)");

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
                            EmpLeaveEntitlementDTO result = new EmpLeaveEntitlementDTO
                            {
                                LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode"),
                                EmpNo = Helper.GetDataValue<long>(dr, "EmpNo"),
                                StartDate = Helper.GetDataValue<DateTime>(dr, "StartDate"),
                                EndDate = Helper.GetDataValue<DateTime>(dr, "EndDate"),
                                Amount = Helper.GetDataValue<decimal>(dr, "Amount"),
                                Used = Helper.GetDataValue<decimal>(dr, "Used"),
                                LeaveYear = Helper.GetDataValue<int>(dr, "LeaveYear"),
                                CarryForwardAmount = Helper.GetDataValue<decimal>(dr, "CarryForwardAmount"),
                                CreatedDateTime = Helper.GetDataValue<DateTime>(dr, "CreatedDateTime"),
                                CreatedUser = Helper.GetDataValue<string>(dr, "CreatedUser"),
                                CreatedMachine = Helper.GetDataValue<string>(dr, "CreatedMachine"),
                                ModifiedDateTime = Helper.GetDataValue<DateTime>(dr, "ModifiedDateTime"),
                                ModifiedUser = Helper.GetDataValue<string>(dr, "ModifiedUser"),
                                ModifiedMachine = Helper.GetDataValue<string>(dr, "ModifiedMachine")
                            };
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
    }
}
