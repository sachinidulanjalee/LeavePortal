using DMSSWE;
using DMSSWE.DATA;
using LeavePortal.Common;
using LeavePortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.BL
{
    public class LeaveRequestHeaderBL
    {
        public void LeaveRequestHeaderInsert(CloudConnection oCloudConnection, LeaveRequestHeaderDTO oLeaveRequestHeaderDTO)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" INSERT INTO LeaveRequestHeader VALUES(");
                sb.AppendLine("?EmpNo,");
                sb.AppendLine("?LeaveCode,");
                sb.AppendLine("?LeaveChitNumber,");
                sb.AppendLine("?RequestDate,");
                sb.AppendLine("?StartDate,");
                sb.AppendLine("?EndDate,");
                sb.AppendLine("?NoOfHoursDays,");
                sb.AppendLine("?Remarks,");
                sb.AppendLine("?CoveringEmpCode,");
                sb.AppendLine("?ContactNoDuringLeave,");
                sb.AppendLine("?LeaveStatus,");
                sb.AppendLine("?AuthorizedUser,");
                sb.AppendLine("?AuthorizedDate,");
                sb.AppendLine("?DenialReason,");
                sb.AppendLine("?IsDocumentSubmitted,");
                sb.AppendLine("?LeaveDocument,");
                sb.AppendLine("?CancelledDate,");
                sb.AppendLine("?CreatedDateTime,");
                sb.AppendLine("?CreatedUser,");
                sb.AppendLine("?CreatedMachine,");
                sb.AppendLine("?ModifiedDateTime,");
                sb.AppendLine("?ModifiedUser,");
                sb.AppendLine("?ModifiedMachine)");

                oCloudConnection.CommandText = sb.ToString();
                oCloudConnection.Parameters.Clear();
                oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = (object)oLeaveRequestHeaderDTO.EmpNo ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = (object)oLeaveRequestHeaderDTO.LeaveCode ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveChitNumber", Value = (object)oLeaveRequestHeaderDTO.LeaveChitNumber ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "RequestDate", Value = (object)oLeaveRequestHeaderDTO.RequestDate ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "StartDate", Value = (object)oLeaveRequestHeaderDTO.StartDate ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "EndDate", Value = (object)oLeaveRequestHeaderDTO.EndDate ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "NoOfHoursDays", Value = (object)oLeaveRequestHeaderDTO.NoOfHoursDays ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "Remarks", Value = (object)oLeaveRequestHeaderDTO.Remarks ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CoveringEmpCode", Value = (object)oLeaveRequestHeaderDTO.CoveringEmpCode ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "ContactNoDuringLeave", Value = (object)oLeaveRequestHeaderDTO.ContactNoDuringLeave ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveStatus", Value = (object)oLeaveRequestHeaderDTO.LeaveStatus ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "AuthorizedUser", Value = (object)oLeaveRequestHeaderDTO.AuthorizedUser ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "AuthorizedDate", Value = (object)oLeaveRequestHeaderDTO.AuthorizedDate ?? DBNull.Value ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "DenialReason", Value = (object)oLeaveRequestHeaderDTO.DenialReason ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "IsDocumentSubmitted", Value = (object)oLeaveRequestHeaderDTO.IsDocumentSubmitted ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveDocument", Value = (object)oLeaveRequestHeaderDTO.LeaveDocument ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CancelledDate", Value = (object)oLeaveRequestHeaderDTO.CancelledDate ?? DBNull.Value ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = (object)oLeaveRequestHeaderDTO.CreatedDateTime ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedUser", Value = (object)oLeaveRequestHeaderDTO.CreatedUser ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedMachine", Value = (object)oLeaveRequestHeaderDTO.CreatedMachine ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = (object)oLeaveRequestHeaderDTO.ModifiedDateTime ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedUser", Value = (object)oLeaveRequestHeaderDTO.ModifiedUser ?? DBNull.Value });
                oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedMachine", Value = (object)oLeaveRequestHeaderDTO.ModifiedMachine ?? DBNull.Value });
                oCloudConnection.ExecuteQuery();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public void LeaveRequestDetailInsert(CloudConnection oCloudConnection, LeaveRequestDetailDTO oLeaveRequestDetailDTO)
        {
            try
            {
              
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" INSERT INTO LeaveRequestDetail VALUES(");
                sb.AppendLine("?EmpNo,");
                sb.AppendLine("?LeaveDate,");
                sb.AppendLine("?DaySequence,");
                sb.AppendLine("?LeaveCode,");
                sb.AppendLine("?LeaveChitNumber,");
                sb.AppendLine("?DayMode,");
                sb.AppendLine("?WhichHalf,");
                sb.AppendLine("?LeaveStart,");
                sb.AppendLine("?LeaveEnd,");
                sb.AppendLine("?NoOfHoursDays,");
                sb.AppendLine("?AuthStatus,");
                sb.AppendLine("?CreatedDateTime,");
                sb.AppendLine("?CreatedUser,");
                sb.AppendLine("?CreatedMachine,");
                sb.AppendLine("?ModifiedDateTime,");
                sb.AppendLine("?ModifiedUser,");
                sb.AppendLine("?ModifiedMachine)");

                oCloudConnection.CommandText = sb.ToString();
                oCloudConnection.Parameters.Clear();
                oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = oLeaveRequestDetailDTO.EmpNo });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveDate", Value = oLeaveRequestDetailDTO.LeaveDate });
                oCloudConnection.Parameters.Add(new Parameter { Name = "DaySequence", Value = oLeaveRequestDetailDTO.DaySequence });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = oLeaveRequestDetailDTO.LeaveCode });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveChitNumber", Value = oLeaveRequestDetailDTO.LeaveChitNumber });
                oCloudConnection.Parameters.Add(new Parameter { Name = "DayMode", Value = oLeaveRequestDetailDTO.DayMode });
                oCloudConnection.Parameters.Add(new Parameter { Name = "WhichHalf", Value = oLeaveRequestDetailDTO.WhichHalf });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveStart", Value = oLeaveRequestDetailDTO.LeaveStart });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveEnd", Value = oLeaveRequestDetailDTO.LeaveEnd });
                oCloudConnection.Parameters.Add(new Parameter { Name = "NoOfHoursDays", Value = oLeaveRequestDetailDTO.NoOfHoursDays });
                oCloudConnection.Parameters.Add(new Parameter { Name = "AuthStatus", Value = oLeaveRequestDetailDTO.AuthStatus });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = oLeaveRequestDetailDTO.CreatedDateTime });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedUser", Value = oLeaveRequestDetailDTO.CreatedUser });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedMachine", Value = oLeaveRequestDetailDTO.CreatedMachine });
                oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oLeaveRequestDetailDTO.ModifiedDateTime });
                oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedUser", Value = oLeaveRequestDetailDTO.ModifiedUser });
                oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedMachine", Value = oLeaveRequestDetailDTO.ModifiedMachine });
                oCloudConnection.ExecuteQuery();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }
        public void SerialNosInsert(CloudConnection oCloudConnection, SerialNosDTO oSerialNosDTO)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" INSERT INTO SerialNos VALUES(");
                sb.AppendLine("?SerialId,");
                sb.AppendLine("?Year,");
                sb.AppendLine("?SerialNo)");

                oCloudConnection.CommandText = sb.ToString();
                oCloudConnection.Parameters.Clear();
                oCloudConnection.Parameters.Add(new Parameter { Name = "SerialId", Value = oSerialNosDTO.SerialId });
                oCloudConnection.Parameters.Add(new Parameter { Name = "Year", Value = oSerialNosDTO.Year });
                oCloudConnection.Parameters.Add(new Parameter { Name = "SerialNo", Value = oSerialNosDTO.SerialNo });
                oCloudConnection.ExecuteQuery();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }
        public string ApplyLeaveKIOSK(int oYear, LeaveRequestHeaderDTO oLeaveRequestHeaderDTO, List<LeaveRequestDetailDTO> lstLeaveRequestDetailDTO, List<EmpLeaveEntitlementDTO> lstEmpLeaveEntitlementDTOAdd, List<EmpLeaveEntitlementDTO> lstEmpLeaveEntitlementDTOUpdate)
        {
            string LeaveChitNo = string.Empty;
            SerialNosBL oSerialNosBL = new SerialNosBL();
            LeaveEntitlementBL oLeaveEntitlementBL = new LeaveEntitlementBL();

            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    SerialNosDTO oSerialNosDTO = oSerialNosBL.SerialNosSearchById(SerialNosMode.LCNO.ToString(), oYear);

                    oSerialNosDTO.SerialNo++;

                    LeaveChitNo = oSerialNosDTO.Year.ToString() + "-" + oSerialNosDTO.SerialNo.ToString().PadLeft(5, '0');

                    oLeaveRequestHeaderDTO.LeaveChitNumber = LeaveChitNo;
                    lstLeaveRequestDetailDTO.ForEach(x => x.LeaveChitNumber = LeaveChitNo);


                    this.LeaveRequestHeaderInsert(oCloudConnection, oLeaveRequestHeaderDTO);

                    lstLeaveRequestDetailDTO.ForEach(x =>
                    {
                        this.LeaveRequestDetailInsert(oCloudConnection, x);
                    });


                    lstEmpLeaveEntitlementDTOAdd.ForEach(x => oLeaveEntitlementBL.EmpLeaveEntitlementInsert(oCloudConnection, x));
                    lstEmpLeaveEntitlementDTOUpdate.ForEach(x => this.UpdateEmpLeaveEntitlement(oCloudConnection, x));
                    this.SerialNosUpdate(oCloudConnection, oSerialNosDTO);

                }
                return LeaveChitNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEmpLeaveEntitlement(CloudConnection oCloudConnection, EmpLeaveEntitlementDTO oEmpLeaveEntitlementDTO)
        {
            int result = 0;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" UPDATE EmpLeaveEntitlement");
                sb.AppendLine(" SET ");
                sb.AppendLine(" Amount =?Amount, ");
                sb.AppendLine(" Used =?Used, ");
                sb.AppendLine(" LeaveYear =?LeaveYear ");
                sb.AppendLine(" WHERE 1=1");
                sb.AppendLine(" AND (LeaveCode=?LeaveCode)");
                sb.AppendLine(" AND (EmpNo=?EmpNo)");
                sb.AppendLine(" AND (convert(varchar(10), StartDate, 120)=?StartDate)");
                sb.AppendLine(" AND (convert(varchar(10), EndDate, 120)=?EndDate)");

                oCloudConnection.CommandText = sb.ToString();
                oCloudConnection.Parameters.Clear();
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = oEmpLeaveEntitlementDTO.LeaveCode });
                oCloudConnection.Parameters.Add(new Parameter { Name = "Amount", Value = oEmpLeaveEntitlementDTO.Amount });
                oCloudConnection.Parameters.Add(new Parameter { Name = "Used", Value = oEmpLeaveEntitlementDTO.Used });
                oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveYear", Value = oEmpLeaveEntitlementDTO.LeaveYear });
                oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = oEmpLeaveEntitlementDTO.EmpNo });
                oCloudConnection.Parameters.Add(new Parameter { Name = "StartDate", Value = oEmpLeaveEntitlementDTO.StartDate.ToString("yyyy-MM-dd") });
                oCloudConnection.Parameters.Add(new Parameter { Name = "EndDate", Value = oEmpLeaveEntitlementDTO.EndDate.ToString("yyyy-MM-dd") });
                oCloudConnection.Parameters.Add(new Parameter { Name = "CarryForwardAmount", Value = oEmpLeaveEntitlementDTO.CarryForwardAmount });
                result = oCloudConnection.ExecuteQuery();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public void SerialNosUpdate(CloudConnection oCloudConnection, SerialNosDTO oSerialNosDTO)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" UPDATE SerialNos");
                sb.AppendLine(" SET ");
                sb.AppendLine("SerialNo=?SerialNo");
                sb.AppendLine(" WHERE 1=1");
                sb.AppendLine(" AND (SerialId=?SerialId)");
                sb.AppendLine(" AND (Year=?Year)");

                oCloudConnection.CommandText = sb.ToString();
                oCloudConnection.Parameters.Clear();
                oCloudConnection.Parameters.Add(new Parameter { Name = "SerialId", Value = oSerialNosDTO.SerialId });
                oCloudConnection.Parameters.Add(new Parameter { Name = "Year", Value = oSerialNosDTO.Year });
                oCloudConnection.Parameters.Add(new Parameter { Name = "SerialNo", Value = oSerialNosDTO.SerialNo });
                oCloudConnection.ExecuteQuery();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }
    }
}
