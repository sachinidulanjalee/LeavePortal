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

        private void LeaveAccuralPlan_Load(object sender, EventArgs e)
        {
            LoadGrid();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            LoadGrid();
            timer2.Start();
        }

        private void btnAddNewAccrualPaln_Click(object sender, EventArgs e)
        {
            AddNewAccrualPlan addNewAccrualPlan = new AddNewAccrualPlan();
            addNewAccrualPlan.Show();
        }
    }
}
