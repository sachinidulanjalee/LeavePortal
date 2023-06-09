using LeavePortal.BL;
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
    public partial class EmployeeProfile : UserControl
    {
       
        public EmployeeProfile()
        {
            InitializeComponent();
            LoadEmployee();
        }

        private EmployeeProfileBL oEmployeeProfileBL = new EmployeeProfileBL();
        public static DataGridViewRow selectedrow;
        private void EmployeeProfile_Load(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            LoadEmployee();
            timer3.Start();

        }

        private void LoadEmployee()
        {
            try
            {
                List<EmployeeProfileDTO> lstEmployeeProfileDTO = oEmployeeProfileBL.EmployeeProfileGetAll();
                gvEmpProfile.DataSource = lstEmployeeProfileDTO;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            // gvEmpProfile.DataSource = oEmployeeProfileBL.EmployeeProfileGetAll();
        }

        private void SearchEmployee()
        {
            try
            {
                List<ParamsDTO> oParamsDTOs = new List<ParamsDTO>();
                AddNewEmployeeProfile employeeProfile = new AddNewEmployeeProfile();

                if (!String.IsNullOrEmpty(txtEmpNo.Text.Trim()))
                    oParamsDTOs.Add(new ParamsDTO { ColumnName = "A.EmpNo", Operator = "Like", Value = txtEmpNo.Text.Trim() + "%" });

                //if (employeeProfile.cmbSatus.SelectedIndex > 0)
                //    oParamsDTOs.Add(new ParamsDTO { ColumnName = "A.Status", Operator = "=", Value = Convert.ToInt32(employeeProfile.cmbSatus.SelectedValue) });

                gvEmpProfile.DataSource = oEmployeeProfileBL.EmployeeProfileSearch(oParamsDTOs);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          
                SearchEmployee();
            
        }

        private void btnAddNewEmpProfile_Click(object sender, EventArgs e)
        {

            AddNewEmployeeProfile addNewEmployeeProfile = new AddNewEmployeeProfile();
            addNewEmployeeProfile.Show();
        }

        private void gvEmpProfile_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditEmployeeProfile editEmployeeProfile = new EditEmployeeProfile();
            editEmployeeProfile.txtEmpNo.Text = this.gvEmpProfile.CurrentRow.Cells[0].Value.ToString();
            editEmployeeProfile.txtEPFNo.Text = this.gvEmpProfile.CurrentRow.Cells[9].Value.ToString();
            editEmployeeProfile.cmbTitle.Text = this.gvEmpProfile.CurrentRow.Cells[1].Value.ToString();
            editEmployeeProfile.txtETFNo.Text = this.gvEmpProfile.CurrentRow.Cells[10].Value.ToString();
            editEmployeeProfile.txtShortName.Text = this.gvEmpProfile.CurrentRow.Cells[3].Value.ToString();
            //editLeaveType.cmbDayMode.SelectedItem = this.dgLeaveTypes.CurrentRow.Cells[4].Value.ToString();
            editEmployeeProfile.txtfullName.Text = this.gvEmpProfile.CurrentRow.Cells[4].Value.ToString();
            editEmployeeProfile.txtSurname.Text = this.gvEmpProfile.CurrentRow.Cells[5].Value.ToString();
            editEmployeeProfile.dtDateOfJoin.Text = this.gvEmpProfile.CurrentRow.Cells[20].Value.ToString();
            editEmployeeProfile.cmblabourAct.SelectedItem = this.gvEmpProfile.CurrentRow.Cells[11].Value.ToString();
            editEmployeeProfile.cmbDesignation.SelectedItem = this.gvEmpProfile.CurrentRow.Cells[6].Value.ToString();
            editEmployeeProfile.cmbReporting.SelectedItem = this.gvEmpProfile.CurrentRow.Cells[22].Value.ToString();
            editEmployeeProfile.cmbReligion.SelectedItem = this.gvEmpProfile.CurrentRow.Cells[13].Value.ToString();
            editEmployeeProfile.cmbCivilStatus.SelectedItem = this.gvEmpProfile.CurrentRow.Cells[17].Value.ToString();
            editEmployeeProfile.dtDateOfLeaving.Text = this.gvEmpProfile.CurrentRow.Cells[21].Value.ToString();
            editEmployeeProfile.dtDateOfBirth.Text = this.gvEmpProfile.CurrentRow.Cells[19].Value.ToString();
            editEmployeeProfile.txtNICNo.Text = this.gvEmpProfile.CurrentRow.Cells[8].Value.ToString();
            editEmployeeProfile.cmbGender.SelectedItem = this.gvEmpProfile.CurrentRow.Cells[12].Value.ToString();
            editEmployeeProfile.txtMobile.Text = this.gvEmpProfile.CurrentRow.Cells[25].Value.ToString();
            editEmployeeProfile.txtHomeTele.Text = this.gvEmpProfile.CurrentRow.Cells[24].Value.ToString();
            editEmployeeProfile.cmbNational.Text = this.gvEmpProfile.CurrentRow.Cells[15].Value.ToString();
            editEmployeeProfile.txtEmail.Text = this.gvEmpProfile.CurrentRow.Cells[23].Value.ToString();
            editEmployeeProfile.cmbSatus.SelectedItem = this.gvEmpProfile.CurrentRow.Cells[31].Value.ToString();
            editEmployeeProfile.Show();
        }
    }
}
