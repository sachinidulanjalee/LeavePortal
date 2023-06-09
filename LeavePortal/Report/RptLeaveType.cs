using LeavePortal.BL;
using LeavePortal.Common;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeavePortal.Report
{
    public partial class RptLeaveType : UserControl
    {
        private ReportBL _ReportBL = new ReportBL();
        private CommonMethod oCommonMethod = new CommonMethod();
        private string RptName = string.Empty;
        private System.Data.DataSet dsReport = new System.Data.DataSet();
        public RptLeaveType()
        {
            InitializeComponent();
        }

        //private void View()
        //{
        //    try
        //    {
        //        Thread thread = new Thread(getData);
        //        thread.Priority = ThreadPriority.Normal;
        //        thread.IsBackground = true;
        //        thread.SetApartmentState(ApartmentState.MTA);
        //        Sessions.ProgressThread = thread.ToString();
        //        thread.Start();

        //        trmWatcher.Enabled = true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        private void getData()
        {
            try
            {
                string dataSource = string.Empty;
               
                Sessions.RptName = "LeaveType";
                 dsReport.Merge(_ReportBL.GetLeaveType());
                Sessions.dsReport = dsReport;

                dsReport = (System.Data.DataSet)Sessions.dsReport;

                System.Data.DataSet oDataSet = new System.Data.DataSet();
                oDataSet.Merge(dsReport);

                dataSource = "LeaveType";

                DataTable dt = new DataTable();
                if (oDataSet.Tables[0] != null)
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(dataSource, oDataSet.Tables[0]));
                    reportViewer1.LocalReport.ReportPath = "D:\\Source\\C#Project\\LeavePortal\\LeavePortal\\LeavePortal\\Report\\LeaveType.rdlc";
                    oDataSet.Dispose();
                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnRptSearch_Click(object sender, EventArgs e)
        {
            reportViewer1 = new ReportViewer();
            getData();
            reportViewer1.Show();
        }

        //    private void trmWatcher_Tick(object sender, EventArgs e)
        //    {
        //        try
        //        {

        //            if (Sessions.dsReport != null)
        //            {
        //                RptName = Sessions.RptName.ToString();
        //                dsReport = (DataSet)Sessions.dsReport;
        //                if (dsReport.Tables.Count > 0)
        //                {
        //                    if (dsReport.Tables[0].Rows.Count > 0)
        //                    {
        //                        Sessions.ReportData = dsReport;
        //                        Viwer viwer = new Viwer();
        //                        viwer.Show();

        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("No data available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    }
        //                }
        //            }


        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
    }
}
