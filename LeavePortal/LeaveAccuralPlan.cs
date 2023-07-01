using LeavePortal.BL;
using LeavePortal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        // create needed obejct
        private LeaveAccrualPlanBL oLeaveAccrualPlanBL = new LeaveAccrualPlanBL();
        public static DataGridViewRow selectedrow;

        public LeaveAccuralPlan()
        {
            InitializeComponent();
        }



        #region method

        //loaded value to datagrid 
        private void LoadGrid()
        {
            try
            {
                //BL Folder ->  LeaveAccrualPlanBL.cs
                List<LeaveAccrualPlanDTO> lstDTO = oLeaveAccrualPlanBL.AccrualLeaveDatagridLoadData();
                DataGridViewAP.DataSource = lstDTO;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        //filter by LeaveCode
        private void SearchLeaveAccrualType()
        {
            try
            {
                List<ParamsDTO> oParamsDTOs = new List<ParamsDTO>();

                if (!String.IsNullOrEmpty(txtSearch.Text.Trim()))
                    oParamsDTOs.Add(new ParamsDTO { ColumnName = "LeaveAccrualPlan.LeaveCode", Operator = "Like", Value = txtSearch.Text.Trim() + "%" });

                //if (employeeProfile.cmbSatus.SelectedIndex > 0)
                //    oParamsDTOs.Add(new ParamsDTO { ColumnName = "A.Status", Operator = "=", Value = Convert.ToInt32(employeeProfile.cmbSatus.SelectedValue) });

                //BL Folder-> LeaveAccrualPlanBL.cs
                DataGridViewAP.DataSource = oLeaveAccrualPlanBL.ApplicableLeaveTypeSearch(oParamsDTOs);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Method

        //formLoad.. called to LoadGrid Method..
        private void LeaveAccuralPlan_Load(object sender, EventArgs e)
        {
            LoadGrid(); // above loadGrid call through the form load
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            LoadGrid();
            timer2.Start();
        }

        //when click add new  button  open to AddNewAccrualPlan form
        private void btnAddNewAccrualPaln_Click(object sender, EventArgs e)
        {
            AddNewAccrualPlan addNewAccrualPlan = new AddNewAccrualPlan();
            addNewAccrualPlan.Show();
        }

        //called to  SearchLeaveAccrualType method
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchLeaveAccrualType();
        }


        //when click grid cell  open to EditAccrualPlan form
        private void DataGridViewAP_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //bind cell values to editform textbox
            EditNewAccrualPlan editNewAccrualPlan = new EditNewAccrualPlan();
            editNewAccrualPlan.cmbLACCPaln.SelectedItem = this.DataGridViewAP.CurrentRow.Cells[0].Value.ToString();
            editNewAccrualPlan.cmbLeaveCode.SelectedItem = this.DataGridViewAP.CurrentRow.Cells[1].Value.ToString();
            editNewAccrualPlan.cmbIsPotrate.SelectedItem = this.DataGridViewAP.CurrentRow.Cells[2].Value.ToString();
            editNewAccrualPlan.cmbIsEntitle.SelectedItem = this.DataGridViewAP.CurrentRow.Cells[3].Value.ToString();
            editNewAccrualPlan.txtFirst.Text = this.DataGridViewAP.CurrentRow.Cells[4].Value.ToString();
            editNewAccrualPlan.txtSecond.Text = this.DataGridViewAP.CurrentRow.Cells[5].Value.ToString();
            editNewAccrualPlan.txtThired.Text = this.DataGridViewAP.CurrentRow.Cells[6].Value.ToString();
            editNewAccrualPlan.txtFourth.Text = this.DataGridViewAP.CurrentRow.Cells[7].Value.ToString();
            editNewAccrualPlan.Show();
        }
    }
}
