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
    }
}
