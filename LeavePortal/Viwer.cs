using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeavePortal
{
    public partial class Viwer : Form
    {
        public string gReptName = "";
        static public DataSet ds1 = new DataSet();
        public Viwer()
        {
            InitializeComponent();
        }

        private void Viwer_Load(object sender, EventArgs e)
        {
            ds1 = (DataSet)Sessions.ReportData;

            DataSet oDataSet = new DataSet();
            oDataSet.Merge(ds1);
            string dataSource = string.Empty;

            switch (gReptName)
            {
                case "LeaveType":
                    dataSource = "LeaveType";
                    reportViewer1.LocalReport.ReportPath = (@"Report/LeaveType.rdlc");
                    if (oDataSet.Tables[0] != null)
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(dataSource, oDataSet.Tables[0]));
                        oDataSet.Dispose();
                    }
                    break;
            }
        }
    }
}
