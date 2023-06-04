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
    public partial class AddNewLeaveType : Form
    {
        public static AddNewLeaveType addNewLeaveType;

        public static AddNewLeaveType getAddNewLeaveType
        {
          get
            {
                if(addNewLeaveType ==  null)
                {
                    addNewLeaveType = new AddNewLeaveType();
                }
                return addNewLeaveType;
              }

        }

        public AddNewLeaveType()
        {
            InitializeComponent();
           
        }
        private LeaveTypeBL oLeaveTypeBL = new LeaveTypeBL();

        private void AddNewLeaveType_Load(object sender, EventArgs e)
        {
          
           
            CommonMethod.setEnumValues(cmbLeaveEntilmet, typeof(LeaveEntitlemant));
            CommonMethod.setEnumValues(cmbDedQuota, typeof(LeaveTypeIsDeductFromQuota));
            CommonMethod.setEnumValues(cmbDayMode, typeof(DayMode));
            CommonMethod.setEnumValues(cmbStatus, typeof(Status));

            btnSave.Enabled = false;

        
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLeaveCode.Clear();
            txtAbbrevaiation.Clear();
            txtEntitlment.Clear();
            txtName.Clear();
            cmbDayMode.Text = string.Empty;
            cmbDedQuota.Text = string.Empty;
            cmbLeaveEntilmet.Text = string.Empty;
            cmbStatus.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLeaveCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool LeaveTypeValidation()
        {
            bool status = true;
            try
            {
                if (string.IsNullOrEmpty(txtLeaveCode.Text.Trim()))
                {
                    errorProvider1.SetError(txtLeaveCode, "Leave Code is required");
                }
                if (string.IsNullOrEmpty(txtLeaveCode.Text.Trim()))
                {
                    errorProvider1.SetError(txtLeaveCode, "Leave Code is required");
                }
                if (string.IsNullOrEmpty(txtLeaveCode.Text.Trim()))
                {
                    errorProvider1.SetError(txtLeaveCode, "Leave Code is required");
                }
                if (string.IsNullOrEmpty(txtLeaveCode.Text.Trim()))
                {
                    errorProvider1.SetError(txtLeaveCode, "Leave Code is required");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
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


                    if (oLeaveTypeBL.LeaveTypeInsert(oLeaveTypeDTO) > 0)
                    {
                        MessageBox.Show("Successfully Instert....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                      
                    }
                    else
                    {
                        MessageBox.Show("Instert Fail....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return;
            }
        }
    }
}
