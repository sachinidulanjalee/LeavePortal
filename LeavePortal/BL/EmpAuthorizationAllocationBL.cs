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
    public class EmpAuthorizationAllocationBL : CommonBL
    {
        public List<ExpEmployeeProfileDTO> GetAllocatedEmployees(long EmpNo, int AuthLevel)
        {
            List<ExpEmployeeProfileDTO> results = new List<ExpEmployeeProfileDTO>();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append("SELECT  A.Empno, \n");
                    varname1.Append("                A.Shortname, \n");
                    varname1.Append("                A.Fullname, \n");
                    varname1.Append("                A.Surname, \n");
                    varname1.Append("                A.Designation, \n");
                    varname1.Append("                B.Description, \n");
                    varname1.Append("                A.Nicno, \n");
                    varname1.Append("                A.Email, \n");
                    varname1.Append("                A.Status, C.Type, C.AuthorizedLevel \n");
                    varname1.Append("FROM   EMPLOYEEPROFILE AS A \n");
                    varname1.Append("       INNER JOIN EmpAuthorizationAllocation AS C \n");
                    varname1.Append("               ON \n");
                    varname1.Append("                   A.Empno = C.AuthorizedUser \n");
                    varname1.Append("       LEFT OUTER JOIN DESIGNATION AS B \n");
                    varname1.Append("                    ON  \n");
                    varname1.Append("                        A.Designation = B.Designationid \n");
                    varname1.Append("WHERE  ( 1 = 1 ) \n");
                    varname1.Append("AND C.EmpNo = " + EmpNo + "\n");
                    varname1.Append("AND C.AuthorizedLevel = " + AuthLevel);
                    varname1.Append(" Order  By  A.EmpNo ");

                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ExpEmployeeProfileDTO result = new ExpEmployeeProfileDTO();
                            result.EmpNo = Helper.GetDataValue<long>(dr, "EmpNo");
                            result.ShortName = Helper.GetDataValue<string>(dr, "ShortName");
                            result.FullName = Helper.GetDataValue<string>(dr, "FullName");
                            result.SurName = Helper.GetDataValue<string>(dr, "SurName");
                            result.Designation = Helper.GetDataValue<int>(dr, "Designation");
                            result.DesignationText = Helper.GetDataValue<string>(dr, "Description");
                            result.NICNo = Helper.GetDataValue<string>(dr, "NICNo");
                            result.Email = Helper.GetDataValue<string>(dr, "Email");
                            result.EmployeesCount = Helper.GetDataValue<int>(dr, "Status");
                            result.AuthorizedType = Helper.GetDataValue<int>(dr, "Type");
                            result.AuthorizedLevel = Helper.GetDataValue<int>(dr, "AuthorizedLevel");
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
                throw ex;
            }
        }

    }
}
