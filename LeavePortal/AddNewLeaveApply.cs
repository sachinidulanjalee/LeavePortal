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
    public partial class AddNewLeaveApply : Form
    {
        private LeaveTypeBL oLeaveTypeBL = new LeaveTypeBL();
        private CommonMethod oCommonMethod = new CommonMethod();
        private EmployeeProfileBL oEmployeeProfileBL = new EmployeeProfileBL();
        private LeaveRequestDetailBL oLeaveRequestDetailBL = new LeaveRequestDetailBL();
        private EmpLeaveEntitlementBL oEmpLeaveEntitlementBL = new EmpLeaveEntitlementBL();
        private LeaveRequestHeaderBL oLeaveRequestHeaderBL = new LeaveRequestHeaderBL();
        private CommonBL oCommonBL = new CommonBL();
        private EmpAuthorizationAllocationBL oEmpAuthorizationAllocationBL = new EmpAuthorizationAllocationBL();


        public AddNewLeaveApply()
        {
            InitializeComponent();
        }

        private void AddNewLeaveApply_Load(object sender, EventArgs e)
        {
            FillDropDowns();
            GetLeaveTypes();
            SetLeaveApply();
            
            cmbWhichHalf.SelectedValue = ((int)WhichHalf.NotApplicable).ToString();
            txtNoHours.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cmbDayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbDayMode.SelectedValue) == (int)LeaveRequestDayMode1.Fullday)
                {
                    cmbWhichHalf.Enabled = false;
                    cmbWhichHalf.SelectedValue = (int)WhichHalf.NotApplicable;
                    dtEndDate.Enabled = true;
                    txtNoHours.Text = "1.0";
                }
                else if (Convert.ToInt32(cmbDayMode.SelectedValue) == (int)LeaveRequestDayMode1.Halfday)
                {
                    cmbWhichHalf.Enabled = true;
                    cmbWhichHalf.SelectedValue = ((int)WhichHalf.FirstHalf).ToString();
                    dtEndDate.Text = dtStartDate.Text;
                    dtEndDate.Enabled = false;
                    txtNoHours.Text = "0.5";
                }
                SetLeaveDaysCount();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dtStartDate.Text)) dtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                dtEndDate.Text = dtStartDate.Text;
                SetLeaveDaysCount();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dtEndDate.Text) || Convert.ToDateTime(dtStartDate.Text) > Convert.ToDateTime(dtEndDate.Text)) dtEndDate.Text = dtStartDate.Text;

                LeaveTypeDTO _oLeaveTypeDTO = ((List<LeaveTypeDTO>)Sessions.LstlstLeaveTypeDTO).Find(x => x.LeaveCode == Sessions.leaveCode);

                SetLeaveDaysCount();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = Convert.ToDateTime(dtStartDate.Text);
                DateTime toDate = Convert.ToDateTime(dtEndDate.Text);
                long empNo = Convert.ToInt64(LogUser.empNo.ToString());

                List<LeaveRequestDetailDTO> lstLeaveRequestDetailDTO = oLeaveRequestDetailBL.LeaveRequestDetailSearchByEmployeePeriod(empNo, fromDate.AddMonths(-1), toDate.AddMonths(1));

                if (string.IsNullOrEmpty(txtNoHours.Text) || Convert.ToDecimal(txtNoHours.Text) == decimal.Zero)
                {
                    MessageBox.Show("Number of Leaves cannot be Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToDateTime(dtStartDate.Text) < Convert.ToDateTime(Sessions.startDate) || Convert.ToDateTime(dtEndDate.Text) > Convert.ToDateTime(Sessions.endDate))
                {
                    MessageBox.Show("Leave Period invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LeaveTypeDTO _oLeaveTypeDTO = ((List<LeaveTypeDTO>)Sessions.LstlstLeaveTypeDTO).Find(x => x.LeaveCode == Sessions.leaveCode);

                if (_oLeaveTypeDTO != null)
                {
                    if (_oLeaveTypeDTO.IsDeductFromQuota == (int)YesNo.Yes && Convert.ToDecimal(txtNoHours.Text) > Convert.ToDecimal(Sessions.balance))
                    {
                        MessageBox.Show("Not enough leave balance !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //if (Convert.ToDecimal(txtNoHours.Text) > _oLeaveTypeDTO.MaximunNoOfLeaves || Convert.ToDecimal(txtNoHours.Text) < _oLeaveTypeDTO.MinimumNoOfLeaves)
                    //{
                    //    ShowInformationMessage(Resources.Resource.msgInvalidLeaves, WarningType.Danger);
                    //    return;
                    //}


                }
                else
                {
                    return;
                }

                if (SetLeaveDetailRecords() == false)
                {
                   MessageBox.Show(" Already Applied Leave for this Employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_oLeaveTypeDTO.IsDeductFromQuota == (int)YesNo.Yes)
                {
                    SetLeaveEntitlementRecords();
                }

              
                SetLeaveHeaderRecord();


                if (string.IsNullOrEmpty(oLeaveRequestHeaderBL.ApplyLeaveKIOSK(Convert.ToInt32(Sessions.year), (LeaveRequestHeaderDTO)Sessions.LeaveRequestHeaderDTOs, (List<LeaveRequestDetailDTO>)Sessions.LeaveRequestDetailDTOs, (List<EmpLeaveEntitlementDTO>)Sessions.empLeaveEntitlementDTOAdd, (List<EmpLeaveEntitlementDTO>)Sessions.EmpLeaveEntitlementDTOUpdate)))
                {
                    MessageBox.Show(" Leave apply failed. \nTry again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show(" Leave Successfully Applied....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                    #region Send Mail Notification

                    LeaveRequestHeaderDTO oLeaveRequestHeaderDTO = (LeaveRequestHeaderDTO)Sessions.LeaveRequestHeaderDTOs;

                    MailConfigurationDTO oMailConfigurationDTO = oCommonBL.MailDetails();
                    EmployeeProfileDTO oData = oEmployeeProfileBL.EmployeeProfileSearchByEmpNo( oLeaveRequestHeaderDTO.EmpNo);

                    List<ExpEmployeeProfileDTO> _oEmployeeProfileReportingDTOs = oEmpAuthorizationAllocationBL.GetAllocatedEmployees( oLeaveRequestHeaderDTO.EmpNo, (int)AutharizationLevel.AuthorizationLevel2);

                    //EmployeeProfileDTO  = oEmployeeProfileBL.EmployeeProfileSearchByEmpNo(Convert.ToInt32(Session["CompanyID"].ToString()), oData.ReportingTo);
                    if (_oEmployeeProfileReportingDTOs.Count > 0 && _oEmployeeProfileReportingDTOs != null)
                    {
                        if (oLeaveRequestHeaderDTO.CoveringEmpCode != 0)
                        {
                            EmployeeProfileDTO _oEmployeeProfileCoveringDTO = oEmployeeProfileBL.EmployeeProfileSearchByEmpNo(oLeaveRequestHeaderDTO.CoveringEmpCode);

                            foreach (var _oEmployeeProfileReportingDTO in _oEmployeeProfileReportingDTOs)
                            {
                                if (!string.IsNullOrEmpty(_oEmployeeProfileReportingDTO.Email) && oMailConfigurationDTO != null)
                                {
                                    string _message = MailConfiguration.GetCoveringLeaveMessage(_oEmployeeProfileReportingDTO.ShortName,
                                                                                                oLeaveRequestHeaderDTO.EmpNo,
                                                                                                LogUser.userName.ToString(),
                                                                                                oLeaveRequestHeaderDTO.StartDate,
                                                                                                oLeaveRequestHeaderDTO.EndDate,
                                                                                               Sessions.leaevType.ToString(),
                                                                                                _oEmployeeProfileCoveringDTO.ShortName,
                                                                                                oLeaveRequestHeaderDTO.CoveringEmpCode,
                                                                                                cmbDayMode.SelectedItem.ToString(),
                                                                                                cmbWhichHalf.SelectedItem.ToString());

                                    MailConfiguration.SendMail(_oEmployeeProfileReportingDTO.Email,
                                                               "Leave Apply", _message,
                                                               oMailConfigurationDTO.Host,
                                                               oMailConfigurationDTO.Port,
                                                               oMailConfigurationDTO.Smtp_Username,
                                                               oMailConfigurationDTO.Smtp_Password,
                                                               oMailConfigurationDTO.From,
                                                               oMailConfigurationDTO.From_Name,
                                                               _oEmployeeProfileCoveringDTO.Email);
                                }
                            }
                        }
                        foreach (var _oEmployeeProfileReportingDTO in _oEmployeeProfileReportingDTOs)
                        {
                            if (!string.IsNullOrEmpty(_oEmployeeProfileReportingDTO.Email) && oMailConfigurationDTO != null)
                            {
                                string _message = MailConfiguration.GetApplyLeaveMessage(_oEmployeeProfileReportingDTO.ShortName,
                                                                                         oLeaveRequestHeaderDTO.EmpNo,
                                                                                         LogUser.userName.ToString(),
                                                                                         oLeaveRequestHeaderDTO.StartDate,
                                                                                         oLeaveRequestHeaderDTO.EndDate,
                                                                                         Sessions.leaevType.ToString(),
                                                                                         cmbDayMode.SelectedItem.ToString(),
                                                                                         cmbWhichHalf.SelectedItem.ToString());

                                MailConfiguration.SendMail(_oEmployeeProfileReportingDTO.Email,
                                                           "Leave Apply",
                                                           _message,
                                                           oMailConfigurationDTO.Host,
                                                           oMailConfigurationDTO.Port,
                                                           oMailConfigurationDTO.Smtp_Username,
                                                           oMailConfigurationDTO.Smtp_Password,
                                                           oMailConfigurationDTO.From,
                                                           oMailConfigurationDTO.From_Name,
                                                           string.Empty);
                            }
                        }
                    }

                    #endregion Send Mail Notification


                   // dvDetails.Visible = false;
                    btnAdd.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Method
        private void FillDropDowns()
        {
            try
            {
                CommonMethod.setEnumValues(cmbDayMode, typeof(DayMode));
                CommonMethod.setEnumValues(cmbWhichHalf, typeof(WhichHalf));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetLeaveTypes()
        {

            try
            {
                List<ParamsDTO> oData = new List<ParamsDTO>
                {
                    new ParamsDTO { ColumnName = "Status", Operator = "=", Value = (int)Status.Active }
                };


                Sessions.LstlstLeaveTypeDTO = oLeaveTypeBL.LeaveTypeSearch(oData);
            }


            catch (Exception)
            {
                throw;
            }
        }


        private void SetLeaveApply()
        {

            try
            {
                LeaveTypeDTO _oLeaveTypeDTO = ((List<LeaveTypeDTO>)Sessions.LstlstLeaveTypeDTO).Find(x => x.LeaveCode == Sessions.leaveCode);

                if (_oLeaveTypeDTO != null)
                {

                    decimal _LeaveEntitlement = Convert.ToDecimal(Sessions.entitlment);
                    decimal _LeaveBalance = Convert.ToDecimal(Sessions.balance);
                    decimal _LeaveUsed = Convert.ToDecimal(Sessions.used);


                    lblBalanceLeave.Text = "Entitlement" + " : [ " + _LeaveEntitlement.ToString("##0.00") + " ] " + "Used" + ": [ " + _LeaveUsed.ToString("##0.00") + " ] " + "Balance" + ": [ " + _LeaveBalance.ToString("##0.00") + " ]";

                    dtStartDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    dtEndDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    dtStartDate.Enabled = true;

                    if (_oLeaveTypeDTO.DayMode == (int)DayMode.FullDay)
                    {
                        cmbDayMode.Enabled = true;
                        cmbWhichHalf.Enabled = false;
                        txtNoHours.Enabled = true;
                        dtStartDate.Enabled = true;
                        dtEndDate.Enabled = true;
                        cmbDayMode.SelectedValue = ((int)LeaveRequestDayMode3.Fullday).ToString();
                        cmbWhichHalf.SelectedValue = ((int)WhichHalf.NotApplicable).ToString();
                    }
                    else
                    {
                        cmbDayMode.Enabled = true;
                        cmbWhichHalf.Enabled = true;
                        dtStartDate.Enabled = true;
                        dtEndDate.Enabled = true;
                        cmbDayMode.SelectedValue = ((int)LeaveRequestDayMode1.Halfday).ToString();
                        // cmbWhichHalf.Items.Remove(new ListItem { Value = ((int)WhichHalf.NotApplicable).ToString(), Text = "Not Applicable" });
                        cmbWhichHalf.SelectedIndex = 0;


                    }
                    SetLeaveDaysCount();
                }

                else
                {
                    MessageBox.Show("Invalid Setting", "warninf]g", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void SetLeaveDaysCount()
        {
            try
            {
                DateTime fromDate = Convert.ToDateTime(dtStartDate.Text);
                DateTime toDate = Convert.ToDateTime(dtEndDate.Text);
                long empNo = Convert.ToInt64(LogUser.empNo.ToString());
                decimal NoOfDays = 0;

                LeaveTypeDTO _oLeaveTypeDTO = ((List<LeaveTypeDTO>)Sessions.LstlstLeaveTypeDTO).Find(x => x.LeaveCode == Sessions.leaveCode);

                EmployeeProfileDTO oEmployeeProfileDTO = oEmployeeProfileBL.EmployeeProfileSearchByEmpNo(empNo);

                if (_oLeaveTypeDTO != null)
                {
                    if (Convert.ToInt32(cmbDayMode.SelectedValue) == (int)DayMode.HalfDay)
                    {

                        if (oEmployeeProfileDTO.LabourAct == (int)LabourAct.WagesBoardsOrdinance)
                            NoOfDays = Convert.ToDecimal("0.5");

                    }

                    else if (_oLeaveTypeDTO.DayMode == (int)DayMode.FullDay)
                    {
                        if (oEmployeeProfileDTO.LabourAct == (int)LabourAct.WagesBoardsOrdinance)
                               NoOfDays++;


                    }

                }

                txtNoHours.Text = NoOfDays.ToString("##0.0");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool SetLeaveDetailRecords()
        {
            try
            {
                List<LeaveRequestDetailDTO> lstLeaveRequestDetailDTO = new List<LeaveRequestDetailDTO>();

                DateTime fromDate = Convert.ToDateTime(dtStartDate.Text);
                DateTime toDate = Convert.ToDateTime(dtEndDate.Text);
                long empNo = Convert.ToInt64(LogUser.empNo);

                LeaveTypeDTO _oLeaveTypeDTO = ((List<LeaveTypeDTO>)Sessions.LstlstLeaveTypeDTO).Find(x => x.LeaveCode == Sessions.leaveCode);
                EmployeeProfileDTO oEmployeeProfileDTO = oEmployeeProfileBL.EmployeeProfileSearchByEmpNo( empNo);

              
                List<LeaveRequestDetailDTO> _oLeaveRequestDetailDTOs = oLeaveRequestDetailBL.LeaveRequestDetailSearchByEmployeePeriod(empNo, fromDate, toDate);

                if (_oLeaveRequestDetailDTOs.Count > 0)
                {
                    foreach (var item in lstLeaveRequestDetailDTO)
                    {
                        List<LeaveRequestDetailDTO> leaveRequestDetailDTOs = _oLeaveRequestDetailDTOs.FindAll(x => x.LeaveDate == item.LeaveDate && x.DaySequence == 0);

                        if (leaveRequestDetailDTOs.Count > 0) return false;
                        else
                        {
                            leaveRequestDetailDTOs = _oLeaveRequestDetailDTOs.FindAll(x => x.LeaveDate == item.LeaveDate);

                            if (leaveRequestDetailDTOs.Count > 0)
                            {
                                if (item.DaySequence == 0) return false;
                                else
                                {
                                    leaveRequestDetailDTOs = _oLeaveRequestDetailDTOs.FindAll(x => x.LeaveDate == item.LeaveDate && x.DaySequence == item.DaySequence);
                                    if (leaveRequestDetailDTOs.Count > 0) return false;
                                }
                            }
                        }
                    }
                }

                Sessions.LeaveRequestDetailDTOs = lstLeaveRequestDetailDTO;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SetLeaveHeaderRecord()
        {
            try
            {
                LeaveRequestHeaderDTO oLeaveRequestHeaderDTO = new LeaveRequestHeaderDTO
                {
                    EmpNo = Convert.ToInt64(LogUser.empNo),
                    LeaveCode = Sessions.leaveCode,
                    LeaveChitNumber = string.Empty,
                    RequestDate = DateTime.Now.Date,
                    StartDate = Convert.ToDateTime(dtStartDate.Text),
                    EndDate = Convert.ToDateTime(dtEndDate.Text),
                    NoOfHoursDays = Convert.ToDecimal(txtNoHours.Text),
                    Remarks = string.Empty,
                    CoveringEmpCode = 0,
                    ContactNoDuringLeave = string.Empty,
                    LeaveStatus = (int)LeaveStatuss.Pending,
                    AuthorizedUser = string.Empty,
                    AuthorizedDate = null,
                    DenialReason = string.Empty,
                    CreatedDateTime = DateTime.UtcNow,
                    CreatedUser =LogUser.userName,
                    CreatedMachine = Environment.MachineName,
                    ModifiedDateTime = DateTime.UtcNow,
                    ModifiedUser = LogUser.userName,
                    ModifiedMachine = Environment.MachineName,
                    IsDocumentSubmitted = (int)DocumentSubmitted.No,
                    LeaveDocument = new byte[0]
                };

                Sessions.LeaveRequestHeaderDTOs = oLeaveRequestHeaderDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetLeaveEntitlementRecords()
        {
            try
            {
                DateTime fromDate = Convert.ToDateTime(dtStartDate.Text);
                DateTime toDate = Convert.ToDateTime(dtEndDate.Text);
                long empNo = Convert.ToInt64(LogUser.empNo);

                List<EmpLeaveEntitlementDTO> lstEmpLeaveEntitlementDTO = oEmpLeaveEntitlementBL.EmpLeaveEntitlementSerch(empNo, Convert.ToInt32(Sessions.year));
                EmpLeaveEntitlementDTO _oEmpLeaveEntitlementDTO = lstEmpLeaveEntitlementDTO.Find(x => x.LeaveCode == Sessions.leaveCode && x.StartDate.Date == Convert.ToDateTime(Sessions.startDate).Date && x.EndDate.Date == Convert.ToDateTime(Sessions.endDate).Date);

                List<EmpLeaveEntitlementDTO> lstEmpLeaveEntitlementDTOAdd = new List<EmpLeaveEntitlementDTO>();
                List<EmpLeaveEntitlementDTO> lstEmpLeaveEntitlementDTOUpdate = new List<EmpLeaveEntitlementDTO>();

                if (_oEmpLeaveEntitlementDTO != null)
                {
                     _oEmpLeaveEntitlementDTO.Amount += 4;
                    _oEmpLeaveEntitlementDTO.Used += Convert.ToDecimal(txtNoHours.Text);
                    _oEmpLeaveEntitlementDTO.ModifiedDateTime = DateTime.UtcNow;
                    _oEmpLeaveEntitlementDTO.ModifiedUser = LogUser.userName;
                    _oEmpLeaveEntitlementDTO.ModifiedMachine = Environment.MachineName;
                    lstEmpLeaveEntitlementDTOUpdate.Add(_oEmpLeaveEntitlementDTO);
                }
                else
                {
                    lstEmpLeaveEntitlementDTOAdd.Add(new EmpLeaveEntitlementDTO()
                    {
                        LeaveCode = Sessions.leaveCode,
                        EmpNo = Convert.ToInt64(LogUser.empNo),
                        StartDate = Convert.ToDateTime(new DateTime(Convert.ToInt32(Sessions.year), 01, 01)),
                        EndDate = Convert.ToDateTime(new DateTime(Convert.ToInt32(Sessions.year), 12, 31)),
                        Amount = Convert.ToDecimal(Sessions.entitlment),
                        Used = Convert.ToDecimal(txtNoHours.Text),
                        LeaveYear = Convert.ToInt32(Sessions.year),
                        CarryForwardAmount = 0,
                        CreatedDateTime = DateTime.UtcNow,
                        CreatedUser = LogUser.userName,
                        CreatedMachine = Environment.MachineName,
                        ModifiedDateTime = DateTime.UtcNow,
                        ModifiedUser = LogUser.userName,
                        ModifiedMachine = Environment.MachineName
                    });
                }

                Sessions.empLeaveEntitlementDTOAdd = lstEmpLeaveEntitlementDTOAdd;
                Sessions.EmpLeaveEntitlementDTOUpdate = lstEmpLeaveEntitlementDTOUpdate;
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message.ToString();
                throw ex;
            }
        }

        #endregion Method
    }
}
