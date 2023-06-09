﻿using DMSSWE;
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
    public class LeaveRequestHeaderBL
    {
        private CommonBL oCommonBL = new CommonBL();
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

        public List<LeaveRequestHeaderDTO> LeaveRequestHeaderSearchByForLeaveCancel(List<ParamsDTO> oParamsDTOs, int[] oLeaveStatus)
        {
            List<LeaveRequestHeaderDTO> results = new List<LeaveRequestHeaderDTO>();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    string query = oCommonBL.GenerateQueryFromListArray(oParamsDTOs);

                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append("SELECT A.EmpNo, \n");
                    varname1.Append("       A.LeaveChitNumber, \n");
                    varname1.Append("       A.RequestDate, \n");
                    varname1.Append("       A.LeaveCode, \n");
                    varname1.Append("       B.Name, \n");
                    varname1.Append("       A.StartDate, \n");
                    varname1.Append("       A.EndDate, \n");
                    varname1.Append("       A.LeaveStatus, \n");
                    varname1.Append("       A.NoOfHoursDays \n");
                    varname1.Append("FROM   LeaveRequestHeader AS A \n");
                    varname1.Append("       INNER JOIN LeaveType AS B \n");
                    varname1.Append("              ON A.LeaveCode = B.LeaveCode \n");
                    varname1.Append("WHERE  ( 1 = 1 ) \n");

                    if (oLeaveStatus.Count() > 0)
                    {
                        query += "AND A.LeaveStatus IN (" + oLeaveStatus[0].ToString();

                        for (int i = 1; i < oLeaveStatus.Count(); i++)
                        {
                            query += ", " + oLeaveStatus[i].ToString();
                        }

                        query += ")";
                    }

                    varname1.Append(query);

                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LeaveRequestHeaderDTO result = new LeaveRequestHeaderDTO
                            {
                                EmpNo = Helper.GetDataValue<long>(dr, "EmpNo"),
                                LeaveChitNumber = Helper.GetDataValue<string>(dr, "LeaveChitNumber"),
                                LeaveCodeText = Helper.GetDataValue<string>(dr, "Name"),
                                RequestDate = Helper.GetDataValue<DateTime>(dr, "RequestDate"),
                                StartDate = Helper.GetDataValue<DateTime>(dr, "StartDate"),
                                EndDate = Helper.GetDataValue<DateTime>(dr, "EndDate"),
                                NoOfHoursDays = Helper.GetDataValue<decimal>(dr, "NoOfHoursDays"),
                                LeaveStatus = Helper.GetDataValue<int>(dr, "LeaveStatus"),
                                LeaveStatusText = Enum.GetName(typeof(LeaveStatuss), Helper.GetDataValue<int>(dr, "LeaveStatus"))
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

        private static StringBuilder LeaveRequestHeaderSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("EmpNo,");
            sb.AppendLine("LeaveCode,");
            sb.AppendLine("LeaveChitNumber,");
            sb.AppendLine("RequestDate,");
            sb.AppendLine("StartDate,");
            sb.AppendLine("EndDate,");
            sb.AppendLine("NoOfHoursDays,");
            sb.AppendLine("Remarks,");
            sb.AppendLine("CoveringEmpCode,");
            sb.AppendLine("ContactNoDuringLeave,");
            sb.AppendLine("LeaveStatus,");
            sb.AppendLine("AuthorizedUser,");
            sb.AppendLine("AuthorizedDate,");
            sb.AppendLine("DenialReason,");
            sb.AppendLine("IsDocumentSubmitted,");
            sb.AppendLine("LeaveDocument,");
            sb.AppendLine("CancelledDate,");
            sb.AppendLine("CreatedDateTime,");
            sb.AppendLine("CreatedUser,");
            sb.AppendLine("CreatedMachine,");
            sb.AppendLine("ModifiedDateTime,");
            sb.AppendLine("ModifiedUser,");
            sb.AppendLine("ModifiedMachine");
            sb.AppendLine(" FROM LeaveRequestHeader ");
            sb.AppendLine(" WHERE 1=1 ");
            return sb;
        }
        public LeaveRequestHeaderDTO LeaveRequestHeaderSearchByChitNo(string LeaveChitNo)
        {
            LeaveRequestHeaderDTO result = new LeaveRequestHeaderDTO();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = LeaveRequestHeaderSearch();
                    sb.AppendLine(" AND (LeaveStatus!=?LeaveStatus)");
                    sb.AppendLine(" AND (LeaveChitNumber=?LeaveChitNumber)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveChitNumber", Value = LeaveChitNo });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveStatus", Value = (int)LeaveStatuss.DoubleDeduction });

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.EmpNo = Helper.GetDataValue<long>(dr, "EmpNo");
                            result.LeaveCode = Helper.GetDataValue<int>(dr, "LeaveCode");
                            result.LeaveChitNumber = Helper.GetDataValue<string>(dr, "LeaveChitNumber");
                            result.RequestDate = Helper.GetDataValue<DateTime>(dr, "RequestDate");
                            result.StartDate = Helper.GetDataValue<DateTime>(dr, "StartDate");
                            result.EndDate = Helper.GetDataValue<DateTime>(dr, "EndDate");
                            result.NoOfHoursDays = Helper.GetDataValue<decimal>(dr, "NoOfHoursDays");
                            result.Remarks = Helper.GetDataValue<string>(dr, "Remarks");
                            result.CoveringEmpCode = Helper.GetDataValue<long>(dr, "CoveringEmpCode");
                            result.ContactNoDuringLeave = Helper.GetDataValue<string>(dr, "ContactNoDuringLeave");
                            result.LeaveStatus = Helper.GetDataValue<int>(dr, "LeaveStatus");
                            result.AuthorizedUser = Helper.GetDataValue<string>(dr, "AuthorizedUser");
                            result.AuthorizedDate = Helper.GetDataValue<DateTime>(dr, "AuthorizedDate");
                            result.DenialReason = Helper.GetDataValue<string>(dr, "DenialReason");
                            result.IsDocumentSubmitted = Helper.GetDataValue<int>(dr, "IsDocumentSubmitted");
                            result.LeaveDocument = Helper.GetDataValue<byte[]>(dr, "LeaveDocument");
                            result.CancelledDate = Helper.GetDataValue<DateTime>(dr, "CancelledDate");
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

        public int DeleteLeaveKIOSK(LeaveRequestHeaderDTO oLeaveRequestHeaderDTO, List<EmpLeaveEntitlementDTO> oEmpLeaveEntitlementDTOs, LeaveTypeDTO oLeaveTypeDTO)
        {
            int result = 0;
            try
            {
                LeaveRequestDetailBL _oLeaveRequestDetailBL = new LeaveRequestDetailBL();

                //List<LeaveRequestDetailDTO> lstLeaveRequestDetailDTO = _oLeaveRequestDetailBL.LeaveRequestDetailSearchByChitNo(oLeaveRequestHeaderDTO.LeaveChitNumber);

                //StringBuilder sb = new StringBuilder();
                //sb.AppendLine(" DELETE FROM LeaveRequestDetail");
                //sb.AppendLine(" WHERE 1=1");
                //sb.AppendLine(" AND (EmpNo=?EmpNo)");
                //sb.AppendLine(" AND (LeaveChitNumber=?LeaveChitNumber)");

                StringBuilder sbLeaveRequestHeader = new StringBuilder();
                sbLeaveRequestHeader.AppendLine(" UPDATE LeaveRequestHeader");
                sbLeaveRequestHeader.AppendLine(" SET ");
                sbLeaveRequestHeader.AppendLine("LeaveStatus=?LeaveStatus,");

                if (oLeaveRequestHeaderDTO.LeaveStatus == (int)LeaveAuthorizationFlag.Cancel) sbLeaveRequestHeader.AppendLine("CancelledDate=?CancelledDate,");
                else
                {
                    sbLeaveRequestHeader.AppendLine("AuthorizedUser=?AuthorizedUser,");
                    sbLeaveRequestHeader.AppendLine("AuthorizedDate=?AuthorizedDate,");
                    sbLeaveRequestHeader.AppendLine("DenialReason=?DenialReason,");
                }

                sbLeaveRequestHeader.AppendLine("ModifiedDateTime=?ModifiedDateTime,");
                sbLeaveRequestHeader.AppendLine("ModifiedUser=?ModifiedUser,");
                sbLeaveRequestHeader.AppendLine("ModifiedMachine=?ModifiedMachine");
                sbLeaveRequestHeader.AppendLine(" WHERE 1=1");
                sbLeaveRequestHeader.AppendLine(" AND (CompanyID=?CompanyID)");
                sbLeaveRequestHeader.AppendLine(" AND (EmpNo=?EmpNo)");
                sbLeaveRequestHeader.AppendLine(" AND (LeaveChitNumber=?LeaveChitNumber)");

                StringBuilder sbUpdate = new StringBuilder();
                sbUpdate.AppendLine(" UPDATE EmpLeaveEntitlement");
                sbUpdate.AppendLine(" SET ");
                sbUpdate.AppendLine(" Amount=?Amount, ");
                sbUpdate.AppendLine(" Used=?Used ");
                sbUpdate.AppendLine(" WHERE 1=1");
                sbUpdate.AppendLine(" AND (LeaveCode=?LeaveCode)");
                sbUpdate.AppendLine(" AND (EmpNo=?EmpNo)");
                sbUpdate.AppendLine(" AND (StartDate =?StartDate)");
                sbUpdate.AppendLine(" AND (EndDate =?EndDate)");

                List<LeaveRequestDetailDTO> results = new List<LeaveRequestDetailDTO>();

                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {

                    //oCloudConnection.CommandText = sb.ToString();
                    //oCloudConnection.Parameters.Clear();
                    //oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = oLeaveRequestHeaderDTO.EmpNo });
                    //oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveChitNumber", Value = oLeaveRequestHeaderDTO.LeaveChitNumber });
                    //result = oCloudConnection.ExecuteQuery();

                    oCloudConnection.CommandText = sbLeaveRequestHeader.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = oLeaveRequestHeaderDTO.EmpNo });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveChitNumber", Value = oLeaveRequestHeaderDTO.LeaveChitNumber });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveStatus", Value = oLeaveRequestHeaderDTO.LeaveStatus });

                    if (oLeaveRequestHeaderDTO.LeaveStatus == (int)LeaveAuthorizationFlag.Cancel) oCloudConnection.Parameters.Add(new Parameter { Name = "CancelledDate", Value = oLeaveRequestHeaderDTO.CancelledDate });
                    else
                    {
                        oCloudConnection.Parameters.Add(new Parameter { Name = "AuthorizedUser", Value = oLeaveRequestHeaderDTO.AuthorizedUser });
                        oCloudConnection.Parameters.Add(new Parameter { Name = "AuthorizedDate", Value = oLeaveRequestHeaderDTO.AuthorizedDate });
                        oCloudConnection.Parameters.Add(new Parameter { Name = "DenialReason", Value = oLeaveRequestHeaderDTO.DenialReason });
                    }

                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oLeaveRequestHeaderDTO.ModifiedDateTime });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedUser", Value = oLeaveRequestHeaderDTO.ModifiedUser });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedMachine", Value = oLeaveRequestHeaderDTO.ModifiedMachine });
                    result = oCloudConnection.ExecuteQuery();

                    foreach (var oEmpLeaveEntitlementDTO in oEmpLeaveEntitlementDTOs)
                    {
                        oCloudConnection.CommandText = sbUpdate.ToString();
                        oCloudConnection.Parameters.Clear();
                        oCloudConnection.Parameters.Add(new Parameter { Name = "LeaveCode", Value = oEmpLeaveEntitlementDTO.LeaveCode });
                        oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = oEmpLeaveEntitlementDTO.EmpNo });
                        oCloudConnection.Parameters.Add(new Parameter { Name = "StartDate", Value = oEmpLeaveEntitlementDTO.StartDate.Date });
                        oCloudConnection.Parameters.Add(new Parameter { Name = "EndDate", Value = oEmpLeaveEntitlementDTO.EndDate.Date });
                        oCloudConnection.Parameters.Add(new Parameter { Name = "Amount", Value = oEmpLeaveEntitlementDTO.Amount });
                        oCloudConnection.Parameters.Add(new Parameter { Name = "Used", Value = oEmpLeaveEntitlementDTO.Used });
                        result = oCloudConnection.ExecuteQuery();
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

    }
}
