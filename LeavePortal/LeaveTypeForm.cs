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
        // Create the desired object

        private LeaveTypeBL oLeaveTypeBL = new LeaveTypeBL();//-> Blfolder
        public static DataGridViewRow selectedrow;
        private EditLeaveType editLeaveType = new EditLeaveType();
        public LeaveTypeForm()
        {
            InitializeComponent();
        }

        #region Event

        private void dgLeaveTypes_Click(object sender, EventArgs e)
        {


        }

        //when click the Add new button open the Add New Leave Type Form
        private void btnAddNewLeaveType_Click_1(object sender, EventArgs e)
        {
            AddNewLeaveType lT = new AddNewLeaveType();
            lT.Show();
        }

        private void LeaveTypeForm_Load_1(object sender, EventArgs e)
        {
            LoadGrid();
           timer1.Start();
        }

        //when click grid cell  open to EditLaveType form
        private void dgLeaveTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //bind cell values to editform textbox

            editLeaveType.txtLeaveCode.Text = this.dgLeaveTypes.CurrentRow.Cells[0].Value.ToString();
            editLeaveType.txtName.Text = this.dgLeaveTypes.CurrentRow.Cells[1].Value.ToString();
            editLeaveType.txtAbbrevaiation.Text = this.dgLeaveTypes.CurrentRow.Cells[2].Value.ToString();
            editLeaveType.txtEntitlment.Text = this.dgLeaveTypes.CurrentRow.Cells[6].Value.ToString();
            string DM = this.dgLeaveTypes.CurrentRow.Cells[4].Value.ToString();
            if(Convert.ToInt32(DM) == 1)
            {
                editLeaveType.cmbDayMode.SelectedValue = (int)DayMode.FullDay;
            }
            else if (Convert.ToInt32(DM) == 2)
            {
                editLeaveType.cmbDayMode.SelectedValue = (int)DayMode.HalfDay;
            }
            else if (Convert.ToInt32(DM) == 3)
            {
                editLeaveType.cmbDayMode.SelectedValue = (int)DayMode.Both;
            }


            editLeaveType.cmbDedQuota.Text = this.dgLeaveTypes.CurrentRow.Cells[5].Value.ToString();
            editLeaveType.cmbLeaveEntilmet.Text = this.dgLeaveTypes.CurrentRow.Cells[3].Value.ToString();
            editLeaveType.cmbStatus.Text = this.dgLeaveTypes.CurrentRow.Cells[7].Value.ToString();
            editLeaveType.Show();


        }

        //when click the search button called to  SearchLeaveType method
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            SearchLeaveType();
        }

        #endregion Event

        #region method

        // load values to datagrid
        private void LoadGrid()
        {
            try
            {
                //get a list from below write query
                List<LeaveTypeDTO> lstDTO = oLeaveTypeBL.LeaveDatagridLoadData();
                dgLeaveTypes.DataSource = lstDTO;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        // filter by LeaveCode
        private void SearchLeaveType()
        {
            try
            {
                List<ParamsDTO> oParamsDTOs = new List<ParamsDTO>();
              
                if (!String.IsNullOrEmpty(txtSearch.Text.Trim()))
                    oParamsDTOs.Add(new ParamsDTO { ColumnName = "LeaveCode", Operator = "Like", Value = txtSearch.Text.Trim() + "%" });

                //if (employeeProfile.cmbSatus.SelectedIndex > 0)
                //    oParamsDTOs.Add(new ParamsDTO { ColumnName = "A.Status", Operator = "=", Value = Convert.ToInt32(employeeProfile.cmbSatus.SelectedValue) });

                //BL Folder-> LeaveTypeBL.cs
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
