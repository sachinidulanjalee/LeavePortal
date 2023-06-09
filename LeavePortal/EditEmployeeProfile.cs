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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeavePortal
{
    public partial class EditEmployeeProfile : Form
    {
        private CommonMethod oCommonMethod = new CommonMethod();
        private DesignationBL odesignationBL = new DesignationBL();
        private EmployeeProfileBL oemployeeProfileBL = new EmployeeProfileBL();
        private EmployeeValidationBL oEmployeeValidationBL = new EmployeeValidationBL();
        public Point mouseLocation;
        public EditEmployeeProfile()
        {
            InitializeComponent();
        }

        private void FillDropDowns()
        {
            try
            {
                CommonMethod.setEnumValues(cmbTitle, typeof(Title));
                CommonMethod.setEnumValues(cmblabourAct, typeof(LabourAct));
                CommonMethod.setEnumValues(cmbReligion, typeof(Religion));
                CommonMethod.setEnumValues(cmbNational, typeof(Nationality));
                CommonMethod.setEnumValues(cmbGender, typeof(Gender));
                CommonMethod.setEnumValues(cmbSatus, typeof(Status));
                CommonMethod.setEnumValues(cmbCivilStatus, typeof(CivilStatus));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadDesignation()
        {

            try
            {
                cmbDesignation.DataSource = odesignationBL.DesignationSearchForDropDown((int)Status.Active);
                cmbDesignation.ValueMember = "Value";
                cmbDesignation.DisplayMember = "Text";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadingReportingUser()
        {

            try
            {
                cmbReporting.DataSource = oemployeeProfileBL.ReportingSearchForDropDown((int)Status.Active);
                cmbReporting.ValueMember = "Value";
                cmbReporting.DisplayMember = "Text";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ClearAllFields()
        {
            try
            {
                txtEmpNo.Text = string.Empty;
                txtSurname.Text = string.Empty;
                txtEPFNo.Text = string.Empty;
                txtETFNo.Text = string.Empty;
                txtNICNo.Text = string.Empty;
                cmbNational.SelectedIndex = 0;
                cmbReligion.SelectedIndex = 0;
                cmbReporting.SelectedIndex = 0;
                cmbTitle.SelectedIndex = 0;
                txtShortName.Text = string.Empty;
                txtfullName.Text = string.Empty;
                cmbDesignation.Text = string.Empty;
                cmbGender.SelectedIndex = 0;
                dtDateOfBirth.Text = string.Empty;
                dtDateOfJoin.Text = string.Empty;
                dtDateOfLeaving.Text = string.Empty;
                cmblabourAct.SelectedIndex = 0;
                txtEmail.Text = string.Empty;
                txtHomeTele.Text = string.Empty;
                txtMobile.Text = string.Empty;
                txtEmpNo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ValidationEmployee()
        {
            bool status = true;
            try
            {
                if (txtEmpNo.Text.Trim() == string.Empty)
                {

                    txtEmpNo.Focus();
                    MessageBox.Show("Employee Number can not be empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return status = false;
                }

                if (txtShortName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Short Name can not be empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtShortName.Focus();
                    return status = false;
                }
                if (txtfullName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("FullName can not be empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtfullName.Focus();
                    return status = false;
                }
                if (dtDateOfJoin.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please selected dateofjoin...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtDateOfJoin.Focus();
                    return status = false;
                }

                if (cmbGender.SelectedIndex == 0)
                {
                    //   ShowInformationMessage("Select Gender . ");
                    cmbGender.Focus();
                    return status = false;
                }

                if (cmbNational.SelectedIndex == 0)
                {
                    //   ShowInformationMessage("Select Gender . ");
                    cmbNational.Focus();
                    return status = false;
                }
                if (cmbReligion.SelectedIndex == 0)
                {
                    //   ShowInformationMessage("Select Gender . ");
                    cmbReligion.Focus();
                    return status = false;
                }
                if (cmbCivilStatus.SelectedIndex == 0)
                {
                    cmbCivilStatus.Focus();
                    return status = false;
                }

                if (txtNICNo.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("NIC No is cannot be empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtDateOfJoin.Focus();
                    return status = false;

                }

                if (cmbSatus.SelectedIndex <= 0)
                {
                    cmbSatus.Focus();
                    return status = false;
                }

                DateTime DateofJoin = Convert.ToDateTime(dtDateOfJoin.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return status;
        }
        private void Save()
        {
            if (ValidationEmployee())
            {
                EmployeeProfileDTO oEmployeeProfileDTO = new EmployeeProfileDTO();
                oEmployeeProfileDTO.EmpNo = Convert.ToInt64(txtEmpNo.Text);
                oEmployeeProfileDTO.Title = Convert.ToInt32(cmbTitle.SelectedValue);
                oEmployeeProfileDTO.ShortName = txtShortName.Text.ToUpper();
                oEmployeeProfileDTO.FullName = txtfullName.Text.ToUpper();
                oEmployeeProfileDTO.SurName = txtSurname.Text.ToUpper();
                oEmployeeProfileDTO.EPFNo = !string.IsNullOrEmpty(txtEPFNo.Text.Trim()) ? Convert.ToInt32(txtEPFNo.Text.Trim()) : 0;
                oEmployeeProfileDTO.ETFNo = !string.IsNullOrEmpty(txtETFNo.Text.Trim()) ? Convert.ToInt32(txtETFNo.Text.Trim()) : 0;
                oEmployeeProfileDTO.Religion = cmbReligion.SelectedIndex != 0 ? Convert.ToInt32(cmbReligion.SelectedValue) : 0;
                oEmployeeProfileDTO.Nationality = cmbNational.SelectedIndex != 0 ? Convert.ToInt32(cmbNational.SelectedValue) : 0;
                oEmployeeProfileDTO.Designation = cmbDesignation.SelectedIndex != 0 ? Convert.ToInt32(cmbDesignation.SelectedValue) : 0;
                oEmployeeProfileDTO.NICNo = txtNICNo.Text.ToUpper();
                oEmployeeProfileDTO.Gender = cmbGender.SelectedIndex != 0 ? Convert.ToInt32(cmbGender.SelectedValue) : 0;
                oEmployeeProfileDTO.DateOfBirth = Convert.ToDateTime(dtDateOfBirth.Text);
                oEmployeeProfileDTO.DateOfJoining = Convert.ToDateTime(dtDateOfJoin.Text);
                if (dtDateOfLeaving.Text != string.Empty)
                {
                    oEmployeeProfileDTO.DateOfLeaving = Convert.ToDateTime(dtDateOfLeaving.Text);
                }
                oEmployeeProfileDTO.ReportingTo = cmbReporting.SelectedIndex != 0 ? Convert.ToInt32(cmbReporting.SelectedValue) : 0;
                oEmployeeProfileDTO.LabourAct = cmblabourAct.SelectedIndex != 0 ? Convert.ToInt32(cmblabourAct.SelectedValue) : 0;
                oEmployeeProfileDTO.Email = txtEmail.Text.Trim();
                oEmployeeProfileDTO.HomeTelephone = txtHomeTele.Text.Trim();
                oEmployeeProfileDTO.Mobile = txtMobile.Text.Trim();
                oEmployeeProfileDTO.EmployeePhoto = new byte[0];
                oEmployeeProfileDTO.CivilStatus = cmbCivilStatus.SelectedIndex != 0 ? Convert.ToInt32(cmbCivilStatus.SelectedValue) : 0;
                oEmployeeProfileDTO.CreatedDateTime = DateTime.UtcNow;
                oEmployeeProfileDTO.CreatedUser = LogUser.userName;
                oEmployeeProfileDTO.CreatedMachine = System.Windows.Forms.SystemInformation.ComputerName;
                oEmployeeProfileDTO.ModifiedDateTime = DateTime.UtcNow;
                oEmployeeProfileDTO.ModifiedUser = LogUser.userName;
                oEmployeeProfileDTO.ModifiedMachine = System.Windows.Forms.SystemInformation.ComputerName;

                if (oemployeeProfileBL.EmployeeProfileUpdate(oEmployeeProfileDTO) > 0)
                {

                    MessageBox.Show("Successfully Upadate....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllFields();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Upadate Fail....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void DeleteLeaveTypes()
        {
            try
            {


                EmployeeProfileDTO employeeProfileDTO = new EmployeeProfileDTO();
                employeeProfileDTO.EmpNo = Convert.ToInt32(txtEmpNo.Text);
                // oDayTypeDTO.RosterCode = lblgvRosterCode.Text;

                 if (oemployeeProfileBL.EmployeeDelete(employeeProfileDTO) >= 0)
                {
                    MessageBox.Show("Are you sure you want to delete this Employee?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    MessageBox.Show("Delete Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllFields();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool ValidateNIC(string nicNumber, int maxLength)
        {
            // Define the regular expression pattern for NIC validation
            string pattern = @"^\d{9}[VvXx]$";

            // Create a Regex object with the pattern
            Regex regex = new Regex(pattern);

            // Match the NIC number against the regular expression pattern
            Match match = regex.Match(nicNumber, maxLength);

            // Return true if the NIC number matches the pattern, false otherwise
            return match.Success;
        }
        private void EditEmployeeProfile_Load(object sender, EventArgs e)
        {
            FillDropDowns();
            LoadDesignation();
            LoadingReportingUser();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
           
        }

   

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteLeaveTypes();
        }
    }
}
