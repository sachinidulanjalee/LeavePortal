using LeavePortal.BL;
using LeavePortal.Common;
using LeavePortal.Model;
using System;
using System.Collections;
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
    public partial class LeaveEntitlment : UserControl
    {
        public LeaveEntitlment()
        {
            InitializeComponent();
            txtYear.Format = DateTimePickerFormat.Custom;
            txtYear.CustomFormat = "yyyy";
            txtYear.ShowUpDown = true;
            gvLeaveEntitlemen.Visible = false;
        }



        private EmployeeProfileBL oEmployeeProfileBL = new EmployeeProfileBL();
        CheckBox HeaderCheckBox = null;
        private bool ISheaderCheckBoxClicked = false;
        private LeaveEntitlementBL oLeaveEntitlementBL = new LeaveEntitlementBL();


        #region Event
        private void LeaveEntitlmentAdd_Load(object sender, EventArgs e)
        {
            CommonMethod.setEnumValues(cmbEmp, typeof(Selction));
            AddHeaderCheckBox();
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);

        }
        
        // Now header checkbox clickevent
        private void HeaderCheckBoxClick(CheckBox HcheckBox)
        {
            ISheaderCheckBoxClicked = true;
            foreach (DataGridViewRow Row in gvLeaveEntitlemen.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chk"]).Value = HcheckBox.Checked;
            gvLeaveEntitlemen.RefreshEdit();

            ISheaderCheckBoxClicked = false;
        }

        private void HeaderCheckBox_MouseClick(object sender, EventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbEmp.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gvLeaveEntitlemen.Visible = true;
            LoadEmployee();
        }

        private void cmbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion Event
        #region Method
        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();
            HeaderCheckBox.Size = new Size(15, 15);

            //Add the checkBox into the DatGrid
            this.gvLeaveEntitlemen.Controls.Add(HeaderCheckBox);
        }

        private void LoadEmployee()
        {

            try
            {
                List<EmployeeProfileDTO> oResults = new List<EmployeeProfileDTO>();
                List<ParamsDTO> oData = new List<ParamsDTO>();
                oData.Add(new ParamsDTO { ColumnName = "A.Status", Operator = "=", Value = (int)Status.Active });

                if (cmbEmp.SelectedIndex > 0)
                {
                    if (Convert.ToInt32(cmbEmp.SelectedValue) == 1)
                    {
                        oResults = oEmployeeProfileBL.EmployeeProfileSearch(oData);
                    }
              
                }

                gvLeaveEntitlemen.DataSource = oResults;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void GenarateLeaveEntitlement()
        {
            try
            {
                ArrayList EmployeeNoList = new ArrayList();
                //foreach (DataGridViewRow oRow in gvLeaveEntitlemen.Rows)
                //{
                //    if (oRow.RowType == DataControlRowType.DataRow)
                //    {
                //        CheckBox oCheckBox = (CheckBox)oRow.FindControl("chk");
                //        if (oCheckBox.Checked)
                //        {
                //            Label lblEmployeeNo = (Label)oRow.FindControl("lblgvEmployeeId");
                //            string EmployeeNo = lblEmployeeNo.Text.Trim();
                //            EmployeeNoList.Add(EmployeeNo);
                //        }
                //    }
                //}
                if (EmployeeNoList.Count > 0)
                {
                    int Year = Convert.ToInt32(txtYear.Text);
                    ResultDTO oResultDTO = oLeaveEntitlementBL.GenarateLeaveEntitlement(EmployeeNoList, Year, LogUser.userName);
                    if (oResultDTO.MessageId != 0)
                    {
                        //ShowMessage(oResultDTO.Message);
                    }
                }
                else
                {
                    //ShowErrorMessage("Please Select Employee Number.", "chkSelectall");
                    //ShowMessage(ResponseMessages.SelectEmployeeId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Method

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                GenarateLeaveEntitlement();
            }
            catch (Exception)
            {

                throw;
            }     
            
        }
    }


}
