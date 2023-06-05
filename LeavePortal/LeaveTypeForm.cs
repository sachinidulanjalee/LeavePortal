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
        private void btnAddNewLeaveType_Click(object sender, EventArgs e)
        {
            AddNewLeaveType lT = new AddNewLeaveType();


            lT.Show();

        }



        private void LeaveTypeForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
            timer1.Start();
        }

        private void dgLeaveTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgLeaveTypes_Click(object sender, EventArgs e)
        {


        }



        private void dgLeaveTypes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedrow = dgLeaveTypes.Rows[e.RowIndex];
                AddNewLeaveType.getAddNewLeaveType.ShowDialog();


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadGrid();
            timer1.Start();
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
    }
}
