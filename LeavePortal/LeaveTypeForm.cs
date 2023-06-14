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
    public partial class LeaveTypeForm : UserControl
    {

        public LeaveTypeForm()
        {
            InitializeComponent();
        }
        private LeaveTypeBL oLeaveTypeBL = new LeaveTypeBL();
        public static DataGridViewRow selectedrow;
        EditLeaveType editLeaveType = new EditLeaveType();
        #region Event

        private void dgLeaveTypes_Click(object sender, EventArgs e)
        {


        }

        private void btnAddNewLeaveType_Click_1(object sender, EventArgs e)
        {
            AddNewLeaveType lT = new AddNewLeaveType();
            lT.Show();
        }

        private void LeaveTypeForm_Load_1(object sender, EventArgs e)
        {
           LoadGrid();
           // timer1.Start();
        }

        private void dgLeaveTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

          
            editLeaveType.txtLeaveCode.Text = this.dgLeaveTypes.CurrentRow.Cells[0].Value.ToString();
            editLeaveType.txtName.Text = this.dgLeaveTypes.CurrentRow.Cells[1].Value.ToString();
            editLeaveType.txtAbbrevaiation.Text = this.dgLeaveTypes.CurrentRow.Cells[2].Value.ToString();
            editLeaveType.txtEntitlment.Text = this.dgLeaveTypes.CurrentRow.Cells[6].Value.ToString();
            editLeaveType.cmbDayMode.SelectedItem = this.dgLeaveTypes.CurrentRow.Cells[4].Value.ToString();
            editLeaveType.cmbDedQuota.Text = this.dgLeaveTypes.CurrentRow.Cells[5].Value.ToString();
            editLeaveType.cmbLeaveEntilmet.Text = this.dgLeaveTypes.CurrentRow.Cells[3].Value.ToString();
            editLeaveType.cmbStatus.Text = this.dgLeaveTypes.CurrentRow.Cells[7].Value.ToString();
            editLeaveType.Show();


        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            SearchLeaveType();
        }

        #endregion Event

        #region method
        private void LoadGrid()
        {
            try
            {
                List<LeaveTypeDTO> lstDTO = oLeaveTypeBL.LeaveDatagridLoadData();
                dgLeaveTypes.DataSource = lstDTO;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void SearchLeaveType()
        {
            try
            {
                List<ParamsDTO> oParamsDTOs = new List<ParamsDTO>();
              
                if (!String.IsNullOrEmpty(txtSearch.Text.Trim()))
                    oParamsDTOs.Add(new ParamsDTO { ColumnName = "LeaveCode", Operator = "Like", Value = txtSearch.Text.Trim() + "%" });

                //if (employeeProfile.cmbSatus.SelectedIndex > 0)
                //    oParamsDTOs.Add(new ParamsDTO { ColumnName = "A.Status", Operator = "=", Value = Convert.ToInt32(employeeProfile.cmbSatus.SelectedValue) });

                dgLeaveTypes.DataSource = oLeaveTypeBL.LeaveTypeSearch(oParamsDTOs);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion Method

        private void dgLeaveTypes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }

   
    }
}
