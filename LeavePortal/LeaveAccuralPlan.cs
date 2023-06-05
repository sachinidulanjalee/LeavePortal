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
    public partial class LeaveAccuralPlan : UserControl
    {
        private LeaveAccrualPlanBL oLeaveAccrualPlanBL = new LeaveAccrualPlanBL();
        public static DataGridViewRow selectedrow;


        public LeaveAccuralPlan()
        {
            InitializeComponent();
        }

        #region Event
        private void LeaveAccuralPlan_Load(object sender, EventArgs e)
        {
            LoadGrid();
            timer2.Start();
        }

        private void btnAddNewAccrualPaln_Click(object sender, EventArgs e)
        {
            AddNewAccrualPlan AccPlan = new AddNewAccrualPlan();
            AccPlan.Show();

        }
        #endregion Event

        #region method
        private void LoadGrid()
        {
            try
            {
                List<LeaveAccrualPlanDTO> lstDTO = oLeaveAccrualPlanBL.AccrualLeaveDatagridLoadData();
                DataGridViewAP.DataSource = lstDTO;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        #endregion Method

        private void timer2_Tick(object sender, EventArgs e)
        {
            LoadGrid();
            timer2.Start();
        }

        private void DataGridViewAP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridViewAP_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedrow = DataGridViewAP.Rows[e.RowIndex];
                EditNewAccrualPlan.getEditNewAccrualPlan.ShowDialog();


            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
