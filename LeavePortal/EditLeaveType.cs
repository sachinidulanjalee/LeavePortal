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
    public partial class EditLeaveType : Form
    {
        public static EditLeaveType editLeaveType;
        private LeaveTypeBL oLeaveTypeBL = new LeaveTypeBL();
        public static EditLeaveType getEditLeaveTypee
        {
            get
            {
                if (editLeaveType == null)
                {
                    editLeaveType = new EditLeaveType();
                }
                return editLeaveType;
            }

        }

        public EditLeaveType()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditLeaveType_Load(object sender, EventArgs e)
        {
            CommonMethod.setEnumValues(cmbLeaveEntilmet, typeof(LeaveEntitlemant));
            CommonMethod.setEnumValues(cmbDedQuota, typeof(LeaveTypeIsDeductFromQuota));
            CommonMethod.setEnumValues(cmbDayMode, typeof(DayMode));
            CommonMethod.setEnumValues(cmbStatus, typeof(Status));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LeaveTypeForm leaveTypeForm = new LeaveTypeForm();
            leaveTypeForm.Show();
        }

        private void Save()
        {
        

            if (LeaveTypeValidation())
            {
                LeaveTypeDTO oLeaveTypeDTO = new LeaveTypeDTO();
                oLeaveTypeDTO.LeaveCode = Convert.ToInt32(txtLeaveCode.Text);
                oLeaveTypeDTO.Name = txtName.Text.ToUpper();
                oLeaveTypeDTO.Abbreviation = txtAbbrevaiation.Text.ToUpper();
                oLeaveTypeDTO.LeaveEntitlementMode = cmbLeaveEntilmet.SelectedIndex != 0 ? Convert.ToInt32(cmbLeaveEntilmet.SelectedValue) : 0;
                oLeaveTypeDTO.IsDeductFromQuota = cmbDedQuota.SelectedIndex != 0 ? Convert.ToInt32(cmbDedQuota.SelectedValue) : 0;
                oLeaveTypeDTO.DayMode = cmbDayMode.SelectedIndex != 0 ? Convert.ToInt32(cmbDayMode.SelectedValue) : 0;
                oLeaveTypeDTO.Entitlement = txtEntitlment.Text != string.Empty ? Convert.ToDecimal(txtEntitlment.Text) : 0;
                oLeaveTypeDTO.Status = cmbStatus.SelectedIndex != 0 ? Convert.ToInt32(cmbStatus.SelectedValue) : 0;
                oLeaveTypeDTO.CreatedDateTime = DateTime.UtcNow;
                oLeaveTypeDTO.CreatedUser = LogUser.userName;
                oLeaveTypeDTO.CreatedMachine = System.Windows.Forms.SystemInformation.ComputerName;
                oLeaveTypeDTO.ModifiedDateTime = DateTime.UtcNow;
                oLeaveTypeDTO.ModifiedUser = LogUser.userName;
                oLeaveTypeDTO.ModifiedMachine = System.Windows.Forms.SystemInformation.ComputerName;

                if (oLeaveTypeBL.LeaveTypeUpdate(oLeaveTypeDTO) > 0)
                {

                    MessageBox.Show("Successfully Upadate....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Upadate Fail....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private bool LeaveTypeValidation()
        {
            bool status = true;
            try
            {

                if (string.IsNullOrEmpty(txtLeaveCode.Text.Trim()))
                {
                    MessageBox.Show(txtLeaveCode, "Leave Code is required");
                }
                if (string.IsNullOrEmpty(txtLeaveCode.Text.Trim()))
                {
                    MessageBox.Show(txtLeaveCode, "Leave Code is required");
                }
                if (string.IsNullOrEmpty(txtLeaveCode.Text.Trim()))
                {
                    MessageBox.Show(txtLeaveCode, "Leave Code is required");
                }
                if (string.IsNullOrEmpty(txtLeaveCode.Text.Trim()))
                {
                    MessageBox.Show(txtLeaveCode, "Leave Code is required");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }
    }
}
