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
    public class EmployeeProfileBL : CommonBL
    {
        #region Search

        private static StringBuilder EmployeeProfileSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("EmpNo,");
            sb.AppendLine("Title,");
            sb.AppendLine("ShortName,");
            sb.AppendLine("FullName,");
            sb.AppendLine("SurName,");
            sb.AppendLine("Designation,");
            sb.AppendLine("NICNo,");
            sb.AppendLine("EPFNo,");
            sb.AppendLine("ETFNo,");
            sb.AppendLine("Gender,");
            sb.AppendLine("Religion,");
            sb.AppendLine("Nationality,");
            sb.AppendLine("CivilStatus,");
            sb.AppendLine("DateOfBirth,");
            sb.AppendLine("DateOfJoining,");
            sb.AppendLine("DateOfLeaving,");
            sb.AppendLine("ReportingTo,");
            sb.AppendLine("Email,");
            sb.AppendLine("HomeTelephone,");
            sb.AppendLine("Mobile,");
            sb.AppendLine("EmployeePhoto,");
            sb.AppendLine("LabourAct,");
            sb.AppendLine("Status,");
            sb.AppendLine("CreatedDateTime,");
            sb.AppendLine("CreatedUser,");
            sb.AppendLine("CreatedMachine,");
            sb.AppendLine("ModifiedDateTime,");
            sb.AppendLine("ModifiedUser,");
            sb.AppendLine("ModifiedMachine");
            sb.AppendLine(" FROM EmployeeProfile ");
            sb.AppendLine(" WHERE 1=1 ");
            return sb;
        }

        private static StringBuilder EmployeeProfileSearchCustom()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("A.CompanyID,");
            sb.AppendLine("A.EmpNo,");
            sb.AppendLine("A.Title,");
            sb.AppendLine("A.ShortName,");
            sb.AppendLine("A.FullName,");
            sb.AppendLine("A.SurName,");
            sb.AppendLine("A.Designation,");
            sb.Append("B.Description AS DesignationText ");
            sb.Append(" FROM    EmployeeProfile AS A LEFT JOIN ");
            sb.Append("             Designation AS B ON A.CompanyID = B.CompanyID AND A.Designation = B.DesignationID");
            sb.AppendLine(" WHERE 1=1 ");
            return sb;
        }

        //public List<EmployeeProfileDTO> AllEmpoyeeSearchForDropDown(int Status)
        //{
        //    List<EmployeeProfileDTO> results = new List<EmployeeProfileDTO>();
        //    try
        //    {
        //        using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
        //        {
        //            StringBuilder sb = EmployeeProfileSearch();
        //            oCloudConnection.CommandText = sb.ToString();
        //            oCloudConnection.Parameters.Clear();
        //            oCloudConnection.Parameters.Add(new Parameter { Name = "Status", Value = Status });

        //            using (IDataReader dr = oCloudConnection.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    EmployeeProfileDTO result = new EmployeeProfileDTO();
        //                    result.EmpNo = Helper.GetDataValue<int>(dr, "EmpNo");
        //                    result.ShortName = Helper.GetDataValue<string>(dr, "ShortName");
        //                    result.Status = Helper.GetDataValue<int>(dr, "Status");

        //                    results.Add(result);
        //                }
        //                dr.Close();
        //            }
        //        }
        //            return results;
        //        }
        //    catch (Exception ex)
        //    {
        //        Logger.Write(ex);
        //        throw ex;
        //    }
        //}

        public EmployeeProfileDTO EmployeeProfileSearchById(long empNo)
        {
            EmployeeProfileDTO result = new EmployeeProfileDTO();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT  A.EmpNo, \n");
                    sb.Append("       A.Title, \n");
                    sb.Append("       A.ShortName, \n");
                    sb.Append("       A.FullName, \n");
                    sb.Append("       A.SurName, \n");
                    sb.Append("       A.Designation, \n");
                    sb.Append("       A.NICNo, \n");
                    sb.Append("       A.EPFNo, \n");
                    sb.Append("       A.ETFNo, \n");
                    sb.Append("       A.Gender, \n");
                    sb.Append("       A.Religion, \n");
                    sb.Append("       A.Nationality, \n");
                    sb.Append("       A.CivilStatus, \n");
                    sb.Append("       A.DateOfBirth, \n");
                    sb.Append("       A.DateOfJoining, \n");
                    sb.Append("       A.DateOfLeaving, \n");
                    sb.Append("       A.ReportingTo, \n");
                    sb.Append("       A.Email, \n");
                    sb.Append("       A.HomeTelephone, \n");
                    sb.Append("       A.Mobile, \n");
                    sb.Append("       A.EmployeePhoto, \n");
                    sb.Append("       A.LabourAct, \n");
                    sb.Append("       A.Status, \n");
                    sb.Append("       A.CreatedDateTime, \n");
                    sb.Append("       A.CreatedUser, \n");
                    sb.Append("       A.CreatedMachine, \n");
                    sb.Append("       A.ModifiedDateTime, \n");
                    sb.Append("       A.ModifiedUser, \n");
                    sb.Append("       A.ModifiedMachine, \n");
                    sb.Append("       B.Description \n");
                    sb.Append("FROM   EmployeeProfile AS A \n");
                    sb.Append("       INNER JOIN Designation AS B \n");
                    sb.Append("               ON A.Designation = B.DesignationID \n");
                    sb.Append("WHERE  1 = 1 \n");
                    sb.AppendLine(" AND (A.EmpNo=?EmpNo)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = empNo });

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.EmpNo = Helper.GetDataValue<long>(dr, "EmpNo");
                            result.Title = Helper.GetDataValue<int>(dr, "Title");
                            result.ShortName = Helper.GetDataValue<string>(dr, "ShortName");
                            result.FullName = Helper.GetDataValue<string>(dr, "FullName");
                            result.SurName = Helper.GetDataValue<string>(dr, "SurName");
                            result.Designation = Helper.GetDataValue<int>(dr, "Designation");
                            result.NICNo = Helper.GetDataValue<string>(dr, "NICNo");
                            result.EPFNo = Helper.GetDataValue<int>(dr, "EPFNo");
                            result.ETFNo = Helper.GetDataValue<int>(dr, "ETFNo");
                            result.Gender = Helper.GetDataValue<int>(dr, "Gender");
                            result.Religion = Helper.GetDataValue<int>(dr, "Religion");
                            result.Nationality = Helper.GetDataValue<int>(dr, "Nationality");
                            result.CivilStatus = Helper.GetDataValue<int>(dr, "CivilStatus");
                            result.DateOfBirth = Helper.GetDataValue<DateTime>(dr, "DateOfBirth");
                            result.DateOfJoining = Helper.GetDataValue<DateTime>(dr, "DateOfJoining");
                            result.DateOfLeaving = Helper.GetDataValue<DateTime>(dr, "DateOfLeaving");
                            result.ReportingTo = Helper.GetDataValue<long>(dr, "ReportingTo");
                            result.Email = Helper.GetDataValue<string>(dr, "Email");
                            result.HomeTelephone = Helper.GetDataValue<string>(dr, "HomeTelephone");
                            result.Mobile = Helper.GetDataValue<string>(dr, "Mobile");
                            result.EmployeePhoto = Helper.GetDataValue<byte[]>(dr, "EmployeePhoto");
                            result.LabourAct = Helper.GetDataValue<int>(dr, "LabourAct");
                            result.EmployeesCount = Helper.GetDataValue<int>(dr, "Status");
                            result.CreatedDateTime = Helper.GetDataValue<DateTime>(dr, "CreatedDateTime");
                            result.CreatedUser = Helper.GetDataValue<string>(dr, "CreatedUser");
                            result.CreatedMachine = Helper.GetDataValue<string>(dr, "CreatedMachine");
                            result.ModifiedDateTime = Helper.GetDataValue<DateTime>(dr, "ModifiedDateTime");
                            result.ModifiedUser = Helper.GetDataValue<string>(dr, "ModifiedUser");
                            result.ModifiedMachine = Helper.GetDataValue<string>(dr, "ModifiedMachine");
                            result.Description = Helper.GetDataValue<string>(dr, "Description");
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
        public List<EmployeeProfileDTO> EmployeeProfileSearchByParamDTO(List<ParamsDTO> oParamsDTOs)
        {
            List<EmployeeProfileDTO> results = new List<EmployeeProfileDTO>();
            try
            {
                string Queary = base.GenerateQueryFromListArray(oParamsDTOs);

                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append("SELECT A.CompanyID, \n");
                    varname1.Append("       A.EmpNo, \n");
                    varname1.Append("       A.ShortName, \n");
                    varname1.Append("       A.FullName, \n");
                    varname1.Append("       A.SurName, \n");
                    varname1.Append("       A.Designation, \n");
                    varname1.Append("       B.Description, \n");
                    varname1.Append("       A.NICNo, \n");
                    varname1.Append("       A.Status \n");
                    varname1.Append("FROM   EmployeeProfile A \n");
                    varname1.Append("       LEFT JOIN Designation B \n");
                    varname1.Append("              ON A.CompanyID = B.CompanyID \n");
                    varname1.Append("                 AND A.Designation = B.DesignationID \n");
                    varname1.Append("WHERE  1 = 1");
                    varname1.Append(Queary);

                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EmployeeProfileDTO result = new EmployeeProfileDTO();
                            result.EmpNo = Helper.GetDataValue<long>(dr, "EmpNo");
                            result.ShortName = Helper.GetDataValue<string>(dr, "ShortName");
                            result.FullName = Helper.GetDataValue<string>(dr, "FullName");
                            result.SurName = Helper.GetDataValue<string>(dr, "SurName");
                            result.Designation = Helper.GetDataValue<int>(dr, "Designation");
                            result.DesignationText = Helper.GetDataValue<string>(dr, "Description");
                            result.NICNo = Helper.GetDataValue<string>(dr, "NICNo");
                            result.EmployeesCount = Helper.GetDataValue<int>(dr, "Status");
                            result.StatusText = Enum.GetName(typeof(Status), Helper.GetDataValue<int>(dr, "Status"));
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

        public List<EmployeeProfileDTO> EmployeeProfileSearch(List<ParamsDTO> oParamsDTOs)
        {
            List<EmployeeProfileDTO> results = new List<EmployeeProfileDTO>();
            try
            {
                string Queary = base.GenerateQueryFromListArray(oParamsDTOs);

                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append("SELECT   A.EmpNo, A.ShortName, A.FullName, A.SurName, A.Designation, B.Description, A.NICNo, ");
                    varname1.Append("                    A.Status ");
                    varname1.Append("FROM     EmployeeProfile A LEFT JOIN ");
                    varname1.Append("                    Designation B ON A.Designation = B.DesignationID ");
                    varname1.Append("WHERE    (1=1 ) ");
                    varname1.AppendLine(Queary);
                    varname1.Append(" Order  By  A.EmpNo ");

                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EmployeeProfileDTO result = new EmployeeProfileDTO();
                            result.EmpNo = Helper.GetDataValue<long>(dr, "EmpNo");
                            result.ShortName = Helper.GetDataValue<string>(dr, "ShortName");
                            result.FullName = Helper.GetDataValue<string>(dr, "FullName");
                            result.SurName = Helper.GetDataValue<string>(dr, "SurName");
                            result.Designation = Helper.GetDataValue<int>(dr, "Designation");
                            result.DesignationText = Helper.GetDataValue<string>(dr, "Description");
                            result.NICNo = Helper.GetDataValue<string>(dr, "NICNo");
                            result.EmployeesCount = Helper.GetDataValue<int>(dr, "Status");
                            result.StatusText = Enum.GetName(typeof(Status), Helper.GetDataValue<int>(dr, "Status"));
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

        public List<DropListDTO> ReportingSearchForDropDown(int Status)
        {
            List<DropListDTO> results = new List<DropListDTO>();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("    SELECT ");
                    sb.AppendLine("   EmpNo,");
                    sb.AppendLine("   ShortName");
                    sb.AppendLine("   FROM EmployeeProfile ");
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
                            result.Value = Helper.GetDataValue<long>(dr, "EmpNo").ToString();
                            result.Text = Helper.GetDataValue<string>(dr, "ShortName");
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
        public List<EmployeeProfileDTO> EmployeeProfileGetAll()
        {
            List<EmployeeProfileDTO> results = new List<EmployeeProfileDTO>();
            try
            {

                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append("SELECT   A.EmpNo, A.ShortName, A.FullName, A.SurName, A.Designation, B.Description, A.NICNo, ");
                    varname1.Append("                    A.Status ");
                    varname1.Append("FROM     EmployeeProfile A LEFT JOIN ");
                    varname1.Append("                    Designation B ON A.Designation = B.DesignationID ");
                    varname1.Append("WHERE    (1=1 ) ");
                    varname1.Append(" Order  By  A.EmpNo ");

                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EmployeeProfileDTO result = new EmployeeProfileDTO();
                            result.EmpNo = Helper.GetDataValue<long>(dr, "EmpNo");
                            result.ShortName = Helper.GetDataValue<string>(dr, "ShortName");
                            result.FullName = Helper.GetDataValue<string>(dr, "FullName");
                            result.SurName = Helper.GetDataValue<string>(dr, "SurName");
                            result.Designation = Helper.GetDataValue<int>(dr, "Designation");
                            result.DesignationText = Helper.GetDataValue<string>(dr, "Description");
                            result.NICNo = Helper.GetDataValue<string>(dr, "NICNo");
                            result.EmployeesCount = Helper.GetDataValue<int>(dr, "Status");
                            result.StatusText = Enum.GetName(typeof(Status), Helper.GetDataValue<int>(dr, "Status"));
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

        public EmployeeProfileDTO EmployeeProfileSearchByEmpNo(long empNo)
        {
            EmployeeProfileDTO result = new EmployeeProfileDTO();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append("SELECT  ");
                    varname1.Append("		A.EmpNo, ");
                    varname1.Append("		A.Title, ");
                    varname1.Append("		A.ShortName, ");
                    varname1.Append("		A.FullName, ");
                    varname1.Append("		A.SurName, ");
                    varname1.Append("		A.Designation, ");
                    varname1.Append("		B.Description AS DesignationText, ");
                    varname1.Append("		A.ReportingTo, ");
                    varname1.Append("	    D.Title AS ReportingToOneTitle, ");
                    varname1.Append("		D.FullName AS ReportingToOneName, ");
                    varname1.Append("		A.NICNo, ");
                    varname1.Append("		A.EPFNo, ");
                    varname1.Append("		A.ETFNo, ");
                    varname1.Append("		A.Gender, ");
                    varname1.Append("		A.Religion, ");
                    varname1.Append("		A.Nationality, ");
                    varname1.Append("		A.CivilStatus, ");
                    varname1.Append("        A.DateOfBirth, ");
                    varname1.Append("		A.DateOfJoining, ");
                    varname1.Append("		A.DateOfLeaving, ");
                    varname1.Append("		A.ReportingTo, ");
                    varname1.Append("		A.Email, ");
                    varname1.Append("		A.HomeTelephone, ");
                    varname1.Append("		A.Mobile, ");
                    varname1.Append("		A.EmployeePhoto, ");
                    varname1.Append("		A.LabourAct, ");
                    varname1.Append("       A.CreatedDateTime,");
                    varname1.Append("       A.CreatedUser,");
                    varname1.Append("       A.CreatedMachine,");
                    varname1.Append("       A.ModifiedDateTime,");
                    varname1.Append("       A.ModifiedUser,");
                    varname1.Append("       A.ModifiedMachine,");
                    varname1.Append("		A.Status ");
                    varname1.Append(" FROM    EmployeeProfile AS A LEFT JOIN ");
                    varname1.Append("             Designation AS B ON  A.Designation = B.DesignationID LEFT OUTER JOIN ");
                    varname1.Append("             EmployeeProfile AS D ON  A.ReportingTo = D.EmpNo ");
                    varname1.Append(" WHERE  (1=1) ");
                    varname1.Append("	   AND (A.EmpNo=?EmpNo)");

                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = empNo });

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.EmpNo = Helper.GetDataValue<long>(dr, "EmpNo");
                            result.Title = Helper.GetDataValue<int>(dr, "Title");
                            result.ShortName = Helper.GetDataValue<string>(dr, "ShortName");
                            result.FullName = Helper.GetDataValue<string>(dr, "FullName");
                            result.SurName = Helper.GetDataValue<string>(dr, "SurName");
                            result.Designation = Helper.GetDataValue<int>(dr, "Designation");
                            result.DesignationText = Helper.GetDataValue<string>(dr, "DesignationText");
                            result.NICNo = Helper.GetDataValue<string>(dr, "NICNo");
                            result.EPFNo = Helper.GetDataValue<int>(dr, "EPFNo");
                            result.ETFNo = Helper.GetDataValue<int>(dr, "ETFNo");
                            result.Gender = Helper.GetDataValue<int>(dr, "Gender");
                            result.Religion = Helper.GetDataValue<int>(dr, "Religion");
                            result.Nationality = Helper.GetDataValue<int>(dr, "Nationality");
                            result.CivilStatus = Helper.GetDataValue<int>(dr, "CivilStatus");
                            result.DateOfBirth = Helper.GetDataValue<DateTime>(dr, "DateOfBirth");
                            result.DateOfJoining = Helper.GetDataValue<DateTime>(dr, "DateOfJoining");
                            result.DateOfLeaving = Helper.GetDataValue<DateTime>(dr, "DateOfLeaving");
                            result.ReportingTo = Helper.GetDataValue<long>(dr, "ReportingTo");
                            result.Email = Helper.GetDataValue<string>(dr, "Email");
                            result.HomeTelephone = Helper.GetDataValue<string>(dr, "HomeTelephone");
                            result.Mobile = Helper.GetDataValue<string>(dr, "Mobile");
                            result.EmployeePhoto = Helper.GetDataValue<byte[]>(dr, "EmployeePhoto");
                            result.LabourAct = Helper.GetDataValue<int>(dr, "LabourAct");
                            result.EmployeesCount = Helper.GetDataValue<int>(dr, "Status");
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


        #region Insert
        public int EmployeeProfileInsert(EmployeeProfileDTO oEmployeeProfileDTO)
        {
            int result = 0;
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("INSERT INTO EmployeeProfile VALUES( ");
                    sb.AppendLine("?EmpNo,");
                    sb.AppendLine("?Title,");
                    sb.AppendLine("?ShortName,");
                    sb.AppendLine("?FullName,");
                    sb.AppendLine("?SurName,");
                    sb.AppendLine("?Designation,");
                    sb.AppendLine("?NICNo,");
                    sb.AppendLine("?EPFNo,");
                    sb.AppendLine("?ETFNo,");
                    sb.AppendLine("?Gender,");
                    sb.AppendLine("?Religion,");
                    sb.AppendLine("?Nationality,");
                    sb.AppendLine("?CivilStatus,");
                    sb.AppendLine("?DateOfBirth,");
                    sb.AppendLine("?DateOfJoining,");
                    sb.AppendLine("?DateOfLeaving,");
                    sb.AppendLine("?ReportingTo,");
                    sb.AppendLine("?Email,");
                    sb.AppendLine("?HomeTelephone,");
                    sb.AppendLine("?Mobile,");
                    sb.AppendLine("?EmployeePhoto,");
                    sb.AppendLine("?LabourAct,");
                    sb.AppendLine("?Status,");
                    sb.AppendLine("?CreatedDateTime,");
                    sb.AppendLine("?CreatedUser,");
                    sb.AppendLine("?CreatedMachine,");
                    sb.AppendLine("?ModifiedDateTime,");
                    sb.AppendLine("?ModifiedUser,");
                    sb.AppendLine("?ModifiedMachine)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "EmpNo", Value = oEmployeeProfileDTO.EmpNo });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Title", Value = oEmployeeProfileDTO.Title });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ShortName", Value = oEmployeeProfileDTO.ShortName });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "FullName", Value = oEmployeeProfileDTO.FullName });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "SurName", Value = oEmployeeProfileDTO.SurName });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Designation", Value = oEmployeeProfileDTO.Designation });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "NICNo", Value = oEmployeeProfileDTO.NICNo });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "EPFNo", Value = oEmployeeProfileDTO.EPFNo });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ETFNo", Value = oEmployeeProfileDTO.ETFNo });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Gender", Value = oEmployeeProfileDTO.Gender });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Religion", Value = oEmployeeProfileDTO.Religion });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Nationality", Value = oEmployeeProfileDTO.Nationality });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CivilStatus", Value = oEmployeeProfileDTO.CivilStatus });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "DateOfBirth", Value = (oEmployeeProfileDTO.DateOfBirth != DateTime.MinValue) ? oEmployeeProfileDTO.DateOfBirth : (object)DBNull.Value });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "DateOfJoining", Value = (oEmployeeProfileDTO.DateOfJoining != DateTime.MinValue) ? oEmployeeProfileDTO.DateOfJoining : (object)DBNull.Value });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "DateOfLeaving", Value = (oEmployeeProfileDTO.DateOfLeaving != DateTime.MinValue) ? oEmployeeProfileDTO.DateOfLeaving : (object)DBNull.Value });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ReportingTo", Value = oEmployeeProfileDTO.ReportingTo });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Email", Value = oEmployeeProfileDTO.Email });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "HomeTelephone", Value = oEmployeeProfileDTO.HomeTelephone });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Mobile", Value = oEmployeeProfileDTO.Mobile });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "EmployeePhoto", Value = oEmployeeProfileDTO.EmployeePhoto });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "LabourAct", Value = oEmployeeProfileDTO.LabourAct });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Status", Value = oEmployeeProfileDTO.Status });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = oEmployeeProfileDTO.CreatedDateTime });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedUser", Value = oEmployeeProfileDTO.CreatedUser });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "CreatedMachine", Value = oEmployeeProfileDTO.CreatedMachine });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oEmployeeProfileDTO.ModifiedDateTime });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedUser", Value = oEmployeeProfileDTO.ModifiedUser });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "ModifiedMachine", Value = oEmployeeProfileDTO.ModifiedMachine });
                    result = oCloudConnection.ExecuteQuery();

                }

                
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return result;
        }


        #endregion Insert
    }
}
