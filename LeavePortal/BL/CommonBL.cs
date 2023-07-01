using DMSSWE.DATA;
using LeavePortal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace LeavePortal.BL
{
    public class CommonBL
    {
        #region Process

        public string GenerateQueryFromListArray(List<ParamsDTO> oParamsDTO)
        {
            DataTable dtParams = new DataTable();
            dtParams.Merge(ListToDataTable<ParamsDTO>(oParamsDTO));

            StringBuilder selectquery = new StringBuilder();

            DataView oDataView = new DataView(dtParams);

            string[] strArr = { "ColumnName" };

            DataTable dtDistinct = new DataTable();
            dtDistinct.Merge(oDataView.ToTable(true, strArr));

            for (int i = 0; i < dtDistinct.Rows.Count; i++)
            {
                DataRow[] dr = dtParams.Select("ColumnName = '" + dtDistinct.Rows[i]["ColumnName"].ToString() + "'");
                if (dr.Length > 1)
                {
                    string subSelect = "";

                    for (int j = 0; j < dr.Length; j++)
                    {
                        if (j == 0)
                        {
                            subSelect += dr[j][0].ToString() + " " + dr[j][1].ToString() + " '" + dr[j][2].ToString() + "' ";
                        }
                        else
                        {
                            if (dr[j - 1]["Operator"].ToString().Contains(">=") || dr[j - 1]["Operator"].ToString().Contains("<="))
                            {
                                subSelect += "AND " + dr[j][0].ToString() + " " + dr[j][1].ToString() + " '" + dr[j][2].ToString() + "' ";
                            }
                            else
                            {
                                subSelect += "OR " + dr[j][0].ToString() + " " + dr[j][1].ToString() + " '" + dr[j][2].ToString() + "' ";
                            }
                        }
                    }
                    selectquery.AppendLine("AND ((" + subSelect + "))");
                }
                else
                {
                    selectquery.AppendLine("AND (" + dtDistinct.Rows[i]["ColumnName"].ToString() + " " + dr[0]["Operator"].ToString() + " '" + dr[0]["Value"].ToString() + "')");
                }
            }

            return selectquery.ToString();
        }

        public static DataTable ListToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];

            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        #endregion Process

        //mail detail query from mail configartiontable
        public MailConfigurationDTO MailDetails()
        {
            MailConfigurationDTO result = new MailConfigurationDTO();
            try
            {
                using (CloudConnection oCloudConnection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    StringBuilder varname1 = new StringBuilder();
                    varname1.Append("SELECT   Top(1)     Id, Smtp_Username, Smtp_Password, Configset, Host, Port, [From], From_Name \n");
                    varname1.Append("FROM            MailConfiguration \n");
                    //varname1.Append("WHERE CompanyID=?CompanyId");

                    oCloudConnection.CommandText = varname1.ToString();
                    oCloudConnection.Parameters.Clear();
                    //oCloudConnection.Parameters.Add(new Parameter { Name = "CompanyId", Value = CompanyId });
                    using (IDataReader dr = oCloudConnection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.Id = Helper.GetDataValue<int>(dr, "Id");
                            result.Smtp_Username = Helper.GetDataValue<string>(dr, "Smtp_Username");
                            result.Smtp_Password = Helper.GetDataValue<string>(dr, "Smtp_Password");
                            result.Configset = Helper.GetDataValue<string>(dr, "Configset");
                            result.Host = Helper.GetDataValue<string>(dr, "Host");
                            result.Port = Helper.GetDataValue<int>(dr, "Port");
                            result.From = Helper.GetDataValue<string>(dr, "From");
                            result.From_Name = Helper.GetDataValue<string>(dr, "From_Name");
                        }
                        dr.Close();
                    }
                }

                return result;
            }
            catch (Exception ex)
            {

                
                throw ex;
            }
        }
    }
}