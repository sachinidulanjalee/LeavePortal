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
    public class LeaveRequestDetailBL
    {
        private static StringBuilder LeaveRequestDetailSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  SELECT ");
            sb.AppendLine(" EmpNo,");
            sb.AppendLine(" LeaveDate,");
            sb.AppendLine(" DaySequence,");
            sb.AppendLine(" LeaveCode,");
            sb.AppendLine(" LeaveChitNumber,");
            sb.AppendLine(" DayMode,");
            sb.AppendLine(" WhichHalf,");
            sb.AppendLine(" LeaveStart,");
            sb.AppendLine(" LeaveEnd,");
            sb.AppendLine(" NoOfHoursDays,");
            sb.AppendLine(" AuthStatus,");
            sb.AppendLine(" CreatedDateTime,");
            sb.AppendLine(" CreatedUser,");
            sb.AppendLine(" CreatedMachine,");
            sb.AppendLine(" ModifiedDateTime,");
            sb.AppendLine(" ModifiedUser,");
            sb.AppendLine(" ModifiedMachine");
            sb.AppendLine(" FROM LeaveRequestDetail ");
            sb.AppendLine(" WHERE 1=1 ");
            return sb;
        }

        public List<LeaveRequestDetailDTO> LeaveRequestDetailSearchByEmployeePeriod( long employeeId, DateTime startDate, DateTime endDate)
        {
            List<LeaveRequestDetailDTO> results = new List<LeaveRequestDetailDTO>();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = LeaveRequestDetailSearch();
                    sb.AppendLine(" AND (EmpNo=?EmpNo)");
                    sb.AppendLine(" AND (LeaveDate BETWEEN ?StartDate AND ?EndDate)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = employeeId });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "StartDate", Value = startDate });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "EndDate", Value = endDate });

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LeaveRequestDetailDTO result = new LeaveRequestDetailDTO();
                            result.EmpNo = Helper.GetDataValue<long>(dr, "EmpNo");
                            result.LeaveDate = Helper.GetDataValue<DateTime>(dr, "LeaveDate");
                            result.DaySequence = Helper.GetDataValue<int>(dr, "DaySequence");
                            result.LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode");
                            result.LeaveChitNumber = Helper.GetDataValue<string>(dr, "LeaveChitNumber");
                            result.DayMode = Helper.GetDataValue<int>(dr, "DayMode");
                            result.WhichHalf = Helper.GetDataValue<int>(dr, "WhichHalf");
                            result.LeaveStart = Helper.GetDataValue<DateTime>(dr, "LeaveStart");
                            result.LeaveEnd = Helper.GetDataValue<DateTime>(dr, "LeaveEnd");
                            result.NoOfHoursDays = Helper.GetDataValue<decimal>(dr, "NoOfHoursDays");
                            result.AuthStatus = Helper.GetDataValue<int>(dr, "AuthStatus");
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

    }
}
