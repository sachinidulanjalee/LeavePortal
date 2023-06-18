using LeavePortal.BL;
using LeavePortal.Common;
using LeavePortal.Model;
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
    public partial class CancelLeave : Form
    {
        public Point mouseLocation;
        private LeaveRequestHeaderBL oLeaveRequestHeaderBL = new LeaveRequestHeaderBL();
        private EmpLeaveEntitlementBL oEmpLeaveEntitlementBL = new EmpLeaveEntitlementBL();
        private LeaveTypeBL oLeaveTypeBL = new LeaveTypeBL();
        public CancelLeave()
        {
            InitializeComponent();
            txtYear.Format = DateTimePickerFormat.Custom;
            txtYear.CustomFormat = "yyyy";
            txtYear.ShowUpDown = true;
            lblDateTime.Text = DateTime.UtcNow.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaxzimis_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frm_Login frm_Login = new frm_Login();
            frm_Login.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPortalForm userPortalForm = new UserPortalForm();
            userPortalForm.Show();
        }

        private void lblHome_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CancelLeave_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mouusePose = Control.MousePosition;
                mouusePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mouusePose;

            }
        }

        private void CancelLeave_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void CancelLeave_Load(object sender, EventArgs e)
        {
            LoadLeaveGrid();
        }

        private void LoadLeaveGrid()
        {
            try
            {
                string StartDate = txtYear.Text + "-01-01";
                string EndDate = txtYear.Text + "-12-31";

                List<ParamsDTO> oParamsDTOs = new List<ParamsDTO>
                {
                    new ParamsDTO { ColumnName = "A.EmpNo", Operator = "=", Value = Convert.ToInt32(LogUser.empNo) },
                    new ParamsDTO { ColumnName = "A.RequestDate", Operator = "BETWEEN", Value = StartDate + " ' AND ' " + EndDate },
                };

                int[] oLeaveStatus = { (int)LeaveAuthorizationFlag.Pending, (int)LeaveAuthorizationFlag.Validate, (int)LeaveAuthorizationFlag.Denied, (int)LeaveAuthorizationFlag.Approved };

                List<LeaveRequestHeaderDTO> lstLeaveRequestHeaderDTO = oLeaveRequestHeaderBL.LeaveRequestHeaderSearchByForLeaveCancel(oParamsDTOs, oLeaveStatus);

                dgCancelLeave.AutoGenerateColumns = false;
                dgCancelLeave.DataSource = lstLeaveRequestHeaderDTO.OrderByDescending(x => x.LeaveChitNumber).ToList();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void dgCancelLeave_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                Sessions.LeaveChitNumber = this.dgCancelLeave.CurrentRow.Cells[1].Value.ToString();
                LeaveRequestHeaderDTO oLeaveRequestHeaderDTO = oLeaveRequestHeaderBL.LeaveRequestHeaderSearchByChitNo(Sessions.LeaveChitNumber);

                    if (oLeaveRequestHeaderDTO != null)
                    {
                        List<EmpLeaveEntitlementDTO> lstEmpLeaveEntitlementDTOUpdate = new List<EmpLeaveEntitlementDTO>();

                        oLeaveRequestHeaderDTO.LeaveStatus = (int)LeaveStatuss.Cancel;
                        oLeaveRequestHeaderDTO.CancelledDate = DateTime.UtcNow.Date;
                        oLeaveRequestHeaderDTO.ModifiedDateTime = DateTime.UtcNow;
                        oLeaveRequestHeaderDTO.ModifiedUser = LogUser.userName.ToString();
                        oLeaveRequestHeaderDTO.ModifiedMachine = Environment.MachineName;

                        LeaveTypeDTO oLeaveTypeDTO = oLeaveTypeBL.LeaveTypeSearchById(oLeaveRequestHeaderDTO.LeaveCode);

                        if (oLeaveTypeDTO != null)
                        {
                            if (oLeaveTypeDTO.IsDeductFromQuota == (int)YesNo.Yes)
                            {
                                List<EmpLeaveEntitlementDTO> lstEmpLeaveEntitlementDTO = oEmpLeaveEntitlementBL.EmpLeaveEntitlementSearchByRange(oLeaveRequestHeaderDTO.EmpNo, oLeaveRequestHeaderDTO.LeaveCode, oLeaveRequestHeaderDTO.StartDate.Date, oLeaveRequestHeaderDTO.EndDate.Date);

                                if (lstEmpLeaveEntitlementDTO.Count > 0)
                                {
                                    decimal oUsed = oLeaveRequestHeaderDTO.NoOfHoursDays;
                                    int i = 0;

                                    while (oUsed > 0)
                                    {
                                        if (lstEmpLeaveEntitlementDTO[i].Used > oUsed)
                                        {
                                            lstEmpLeaveEntitlementDTO[i].Used -= oUsed;
                                            oUsed = 0;
                                        }
                                        else
                                        {
                                            oUsed -= lstEmpLeaveEntitlementDTO[i].Used;
                                            lstEmpLeaveEntitlementDTO[i].Used = 0;
                                        }


                                        lstEmpLeaveEntitlementDTOUpdate.Add(lstEmpLeaveEntitlementDTO[i]);
                                    }
                                }
                                else
                                {
                                         MessageBox.Show("No entitlement for this period !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Leave Period invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    
                    if (oLeaveRequestHeaderBL.DeleteLeaveKIOSK(oLeaveRequestHeaderDTO, lstEmpLeaveEntitlementDTOUpdate, oLeaveTypeDTO) > 0)
                    {
                        MessageBox.Show("Leave Successfully cancelled...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLeaveGrid();
                    }
                    else
                    {
                        MessageBox.Show("Leave Fail cancelled...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Leave Type!!...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
