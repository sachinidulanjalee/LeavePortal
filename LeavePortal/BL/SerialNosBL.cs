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
    public class SerialNosBL
    {
        #region Search

        public SerialNosDTO SerialNosSearchById(string serialId, int year)
        {
            SerialNosDTO result = new SerialNosDTO();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT ");
                    sb.AppendLine("SerialId,");
                    sb.AppendLine("Year,");
                    sb.AppendLine("SerialNo");
                    sb.AppendLine(" FROM SerialNos ");
                    sb.AppendLine(" WHERE 1=1 ");
                    sb.AppendLine(" AND (SerialId=?SerialId)");
                    sb.AppendLine(" AND (Year=?Year)");


                    oCloudConnection.CommandText = sb.ToString();
                    oCloudConnection.Parameters.Clear();
                    oCloudConnection.Parameters.Add(new Parameter { Name = "SerialId", Value = serialId });
                    oCloudConnection.Parameters.Add(new Parameter { Name = "Year", Value = year });

                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.SerialId = Helper.GetDataValue<string>(dr, "SerialId");
                            result.Year = Helper.GetDataValue<int>(dr, "Year");
                            result.SerialNo = Helper.GetDataValue<int>(dr, "SerialNo");
                        }
                        dr.Close();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                //Logger.Write(ex);
                throw ex;
            }
        }

        #endregion Search
    }
}
