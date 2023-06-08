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
    public partial class LeaveTypeForm : UserControl
    {

        public LeaveTypeForm()
        {
            InitializeComponent();
        }
        private LeaveTypeBL oLeaveTypeBL = new LeaveTypeBL();
        public static DataGridViewRow selectedrow;
        #region Event
       private void dgLeaveTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgLeaveTypes_Click(object sender, EventArgs e)
        {


        }

     

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                List<ParamsDTO> oParamsDTOs = new List<ParamsDTO>();

                oParamsDTOs.Add(new ParamsDTO { ColumnName = "LeaveCode", Operator = "= ", Value = txtSearch.Text.Trim() });


                List<LeaveTypeDTO> oLeaveTypeDTO = new List<LeaveTypeDTO>();
                oLeaveTypeDTO.AddRange(oLeaveTypeBL.LeaveTypeSearch(oParamsDTOs));
                dgLeaveTypes.DataSource = oLeaveTypeDTO;

            }

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
        #endregion Method

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

        private void dgLeaveTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            EditLeaveType editLeaveType = new EditLeaveType();
            editLeaveType.txtLeaveCode.Text = this.dgLeaveTypes.CurrentRow.Cells[0].Value.ToString();
            editLeaveType.txtName.Text = this.dgLeaveTypes.CurrentRow.Cells[1].Value.ToString();
            editLeaveType.txtAbbrevaiation.Text = this.dgLeaveTypes.CurrentRow.Cells[2].Value.ToString();
            editLeaveType.txtEntitlment.Text = this.dgLeaveTypes.CurrentRow.Cells[6].Value.ToString();
            editLeaveType.cmbDayMode.Text = this.dgLeaveTypes.CurrentRow.Cells[4].Value.ToString();
            editLeaveType.cmbDedQuota.Text = this.dgLeaveTypes.CurrentRow.Cells[5].Value.ToString();
            editLeaveType.cmbLeaveEntilmet.Text = this.dgLeaveTypes.CurrentRow.Cells[3].Value.ToString();
            editLeaveType.cmbStatus.Text = this.dgLeaveTypes.CurrentRow.Cells[7].Value.ToString();
            editLeaveType.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                LoadGrid();
                timer1.Start();
            
        }
    }
}
