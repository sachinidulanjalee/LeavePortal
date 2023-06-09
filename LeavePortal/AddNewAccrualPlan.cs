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
    public partial class AddNewAccrualPlan : Form
    {
        public AddNewAccrualPlan()
        {
            InitializeComponent();
        }
        private LeaveTypeBL oLeaveTypeBL = new LeaveTypeBL();
        private LeaveAccrualPlanBL oLeaveAccrualPlanBL = new LeaveAccrualPlanBL();

        private void AddNewAccrualPlan_Load(object sender, EventArgs e)
        {
            FillDropDowns();
            LoadLeaveCode();
            pnlPoratType.Visible = false;

        }

          private void FillDropDowns()
        {
            try
            {
                CommonMethod.setEnumValues(cmbLACCPaln, typeof(LeaveAccrualType));
                CommonMethod.setEnumValues(cmbIsPotrate, typeof(YesNo));
                CommonMethod.setEnumValues(cmbIsEntitle, typeof(YesNo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadLeaveCode()
        {

            try
            {
                cmbLeaveCode.DataSource = oLeaveTypeBL.LeaveTypeSearchForDropDown((int)Status.Active);
                cmbLeaveCode.ValueMember = "Value";
                cmbLeaveCode.DisplayMember = "Text";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Add()
        {
            try
            {
                if (LeaveTypeValidation())
                {
                    LeaveAccrualPlanDTO oLeaveAccrualPlanDTO = new LeaveAccrualPlanDTO();
                    oLeaveAccrualPlanDTO.LeaveAccrualType = cmbLACCPaln.SelectedIndex != 0 ? Convert.ToInt32(cmbLACCPaln.SelectedValue) : 0;
                    oLeaveAccrualPlanDTO.LeaveCode = cmbLACCPaln.SelectedIndex != 0 ? Convert.ToInt32(cmbLACCPaln.SelectedValue) : 0;
                    oLeaveAccrualPlanDTO.IsEntitle = cmbIsEntitle.SelectedIndex != 0 ? Convert.ToInt32(cmbIsEntitle.SelectedValue) : 0;
                    oLeaveAccrualPlanDTO.IsProrate = cmbIsPotrate.SelectedIndex != 0 ? Convert.ToInt32(cmbIsPotrate.SelectedValue) : 0;
                    oLeaveAccrualPlanDTO.FirstQuarterEntitlement = txtFirst.Text != string.Empty ? Convert.ToInt32(txtFirst.Text) : 0;
                    oLeaveAccrualPlanDTO.SecondQuarterEntitlement = txtSecond.Text != string.Empty ? Convert.ToInt32(txtSecond.Text) : 0;
                    oLeaveAccrualPlanDTO.ThiredQuarterEntitlement = txtThired.Text != string.Empty ? Convert.ToInt32(txtThired.Text) : 0;
                    oLeaveAccrualPlanDTO.FourthQuarterEntitlement = txtFourth.Text != string.Empty ? Convert.ToInt32(txtFourth.Text) : 0;
                    oLeaveAccrualPlanDTO.CreatedDateTime = DateTime.UtcNow;
                    oLeaveAccrualPlanDTO.CreatedUser = LogUser.userName; ;
                    oLeaveAccrualPlanDTO.CreatedMachine = System.Windows.Forms.SystemInformation.ComputerName;
                    oLeaveAccrualPlanDTO.ModifiedDateTime = DateTime.UtcNow;
                    oLeaveAccrualPlanDTO.ModifiedUser = LogUser.userName;
                    oLeaveAccrualPlanDTO.ModifiedMachine = System.Windows.Forms.SystemInformation.ComputerName;

                    if (oLeaveAccrualPlanBL.LeaveAccrualPlanInsert(oLeaveAccrualPlanDTO) > 0)
                    {
                        MessageBox.Show("InsertSuccess", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Insert Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private bool LeaveTypeValidation()
        {
            bool status = true;
            try
            {

                if (cmbLACCPaln.SelectedIndex == 0)
                {
                    MessageBox.Show("LeaveAccrual Type is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbLACCPaln.Focus();
                    return status = false;
                }
                if (cmbIsEntitle.SelectedIndex == 0)
                {
                    MessageBox.Show("Leave Entitlment is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbIsEntitle.Focus();
                    return status = false;
                }
                if (cmbLeaveCode.SelectedIndex == 0)
                {
                    MessageBox.Show("LeaveCode is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbLeaveCode.Focus();
                    return status = false;
                }
                if (cmbIsPotrate.SelectedIndex == 0)
                {
                    MessageBox.Show("Potrate  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbIsPotrate.Focus();
                    return status = false;
                }
                if (cmbIsPotrate.SelectedIndex == (int)YesNo.Yes)
                {
                    if (string.IsNullOrEmpty(txtFirst.Text.Trim()))
                    {
                        MessageBox.Show("First Quarter Entitlement", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFirst.Focus();
                        return status = false;
                    }
                    if (string.IsNullOrEmpty(txtSecond.Text.Trim()))
                    {
                        MessageBox.Show("Second Quarter Entitlement", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSecond.Focus();
                        return status = false;
                    }
                    if (string.IsNullOrEmpty(txtThired.Text.Trim()))
                    {
                        MessageBox.Show("Third Quarter Entitlement", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtThired.Focus();
                        return status = false;
                    }
                    if (string.IsNullOrEmpty(txtFourth.Text.Trim()))
                    {
                        MessageBox.Show("Fourth Quarter Entitlement", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFourth.Focus();
                        return status = false;
                    }

               
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }


        private void btnLAPCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLAPClear_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLAPAdd_Click(object sender, EventArgs e)
        {
                Add();
                this.Close();
            
        }

        private void cmbIsPotrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbIsPotrate.SelectedIndex == (int)YesNo.Yes)
                {
                    pnlPoratType.Visible = true;
                    txtFirst.Text = string.Empty;
                    txtSecond.Text = string.Empty;
                    txtThired.Text = string.Empty;
                    txtFourth.Text = string.Empty;
                
                }
                else if (cmbIsPotrate.SelectedIndex == (int)YesNo.No)
                {
                    pnlPoratType.Visible = false;
                    txtFirst.Text = string.Empty;
                    txtSecond.Text = string.Empty;
                    txtThired.Text = string.Empty;
                    txtFourth.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
