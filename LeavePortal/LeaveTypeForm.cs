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


        private void btnAddNewLeaveType_Click(object sender, EventArgs e)
        {
            AddNewLeaveType lT = new AddNewLeaveType();


            lT.Show();
           
        }

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
                return;
            }
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

        public static DataGridViewRow selectedrow;

        private void dgLeaveTypes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >=0)
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
    }
}
    