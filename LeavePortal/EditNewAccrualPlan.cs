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
    public partial class EditNewAccrualPlan : Form
    {
        public EditNewAccrualPlan()
        {
            InitializeComponent();
        }

        public static EditNewAccrualPlan ediNewAccrualPlan;
        private LeaveTypeBL oLeaveTypeBL = new LeaveTypeBL();
        private LeaveAccrualPlanBL oLeaveAccrualPlanBL = new LeaveAccrualPlanBL();


        public static EditNewAccrualPlan getEditNewAccrualPlan
        {
            get
            {
                if (ediNewAccrualPlan == null)
                {
                    ediNewAccrualPlan = new EditNewAccrualPlan();
                }
                return ediNewAccrualPlan;
            }

        }

        private void btnLAPEditCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditNewAccrualPlan_Load(object sender, EventArgs e)
        {
            cmbLACCPaln.Enabled = false;
            cmbLeaveCode.Enabled = false;
            FillDropDowns();
            LoadLeaveCode();

            cmbLACCPaln.SelectedValue = LeaveAccuralPlan.selectedrow.Cells[0].Value.ToString();
            cmbLeaveCode.SelectedItem = LeaveAccuralPlan.selectedrow.Cells[1].Value.ToString();
            cmbIsPotrate.SelectedItem = LeaveAccuralPlan.selectedrow.Cells[2].Value.ToString();
            cmbIsEntitle.SelectedItem = LeaveAccuralPlan.selectedrow.Cells[3].Value.ToString();
            txtFirst.Text = LeaveAccuralPlan.selectedrow.Cells[4].Value.ToString();
            txtSecond.Text = LeaveAccuralPlan.selectedrow.Cells[5].Value.ToString();
            txtThired.Text = LeaveAccuralPlan.selectedrow.Cells[6].Value.ToString();
            txtFourth.Text = LeaveAccuralPlan.selectedrow.Cells[7].Value.ToString();
          
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

        private void btnLAPSave_Click(object sender, EventArgs e)
        {
            LeaveAccrualPlanDTO oLeaveAccrualPlanDTO = new LeaveAccrualPlanDTO();
            oLeaveAccrualPlanDTO.LeaveAccrualType = cmbLACCPaln.SelectedIndex != 0 ? Convert.ToInt32(cmbLACCPaln.SelectedValue) : 0;
            oLeaveAccrualPlanDTO.LeaveCode = cmbLeaveCode.Text != string.Empty ? Convert.ToInt32(cmbLeaveCode.Text) : 0;
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

            if (oLeaveAccrualPlanBL.LeaveAccrualPlanUpdate(oLeaveAccrualPlanDTO) > 0)
            {
                MessageBox.Show("Update Successful", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Update Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLAPDelete_Click(object sender, EventArgs e)
        {
            DeleteLeaveAccrualPlan();
        }

        private void DeleteLeaveAccrualPlan()
        {
            try
            {
                

                LeaveAccrualPlanDTO oLeaveAccrualPlanDTO = new LeaveAccrualPlanDTO();
                oLeaveAccrualPlanDTO.LeaveAccrualType = Convert.ToInt32(cmbLACCPaln.SelectedItem);
                oLeaveAccrualPlanDTO.LeaveCode = Convert.ToInt32(cmbLeaveCode.SelectedItem);

                if (oLeaveAccrualPlanBL.LeaveAccrualPlanDelete(oLeaveAccrualPlanDTO) >= 0)
                {
                    MessageBox.Show("Delete Successful", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Delete Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show (ex.Message);
                return;
            }
        }
    }
}
