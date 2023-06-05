using LeavePortal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion Processs
    }
}
