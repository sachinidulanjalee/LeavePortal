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
   public class DesignationBL
    {
        private static StringBuilder DesignationSearch()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT ");
            sb.AppendLine("DesignationID,");
            sb.AppendLine("Description,");
            sb.AppendLine("Status,");
            sb.AppendLine("CreatedDateTime,");
            sb.AppendLine("CreatedUser,");
            sb.AppendLine("CreatedMachine,");
            sb.AppendLine("ModifiedDateTime,");
            sb.AppendLine("ModifiedUser,");
            sb.AppendLine("ModifiedMachine");
            sb.AppendLine(" FROM Designation ");
            sb.AppendLine(" WHERE 1=1 ");
            return sb;
        }
        public List<DropListDTO> DesignationSearchForDropDown(int Status)
        {
            List<DropListDTO> results = new List<DropListDTO>();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("    SELECT ");
                    sb.AppendLine("   DesignationID,");
                    sb.AppendLine("   Description");
                    sb.AppendLine("   FROM Designation ");
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
                            result.Value = Helper.GetDataValue<int>(dr, "DesignationID").ToString();
                            result.Text = Helper.GetDataValue<string>(dr, "Description");
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

        public DesignationDTO DesignationSearchById(int designationID)
        {
            DesignationDTO result = new DesignationDTO();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = DesignationSearch();
                    sb.AppendLine(" AND (DesignationID=?DesignationID)");

                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "DesignationID", Value = designationID });

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.DesignationID = Helper.GetDataValue<int>(dr, "DesignationID");
                            result.Description = Helper.GetDataValue<string>(dr, "Description");
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
    }
}
