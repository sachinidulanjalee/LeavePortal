﻿using LeavePortal.BL;
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
    public partial class AddNewLeaveType : Form
    {
 
        public AddNewLeaveType()
        {
            InitializeComponent();
           
        }
        private LeaveTypeBL oLeaveTypeBL = new LeaveTypeBL();

            //FormLoad
        private void AddNewLeaveType_Load(object sender, EventArgs e)
        {
                   
            CommonMethod.setEnumValues(cmbLeaveEntilmet, typeof(LeaveEntitlemant));
            CommonMethod.setEnumValues(cmbDedQuota, typeof(LeaveTypeIsDeductFromQuota));
            CommonMethod.setEnumValues(cmbDayMode, typeof(DayMode));
            CommonMethod.setEnumValues(cmbStatus, typeof(Status));
        }
       
        //-----ClearButton Click Event(clear all textbox values)----
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLeaveCode.Clear();
            txtAbbrevaiation.Clear();
            txtEntitlment.Clear();
            txtName.Clear();
            cmbDayMode.Text = string.Empty;
            cmbDedQuota.Text = string.Empty;
            cmbLeaveEntilmet.Text = string.Empty;
            cmbStatus.Text = string.Empty;
        }

        //----Cancel Button Click Event (Nvigate to grid page)------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //------LeaveCode Validation---  Cannot type Charaters-- 
        private void txtLeaveCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //------Other Validation----
        private bool LeaveTypeValidation()
        {
            bool status = true;
            try
            {
                if (string.IsNullOrEmpty(txtLeaveCode.Text.Trim()))
                {
                   MessageBox.Show("Leave Code is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLeaveCode.Focus();
                    return status = false;
                }
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    MessageBox.Show("Leave Name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return status = false;
                }
                if (cmbDayMode.SelectedIndex==0)
                {
                    MessageBox.Show("Day Mode is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDayMode.Focus();
                    return status = false;
                }
                if (cmbLeaveEntilmet.SelectedIndex==0)
                {
                    MessageBox.Show("Leave Entitlment is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbLeaveEntilmet.Focus();
                    return status = false;
                }
                if (cmbDedQuota.SelectedIndex == 0)
                {
                    MessageBox.Show("Deduction Quota is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDedQuota.Focus();
                    return status = false;
                }
                if (cmbStatus.SelectedIndex == 0)
                {
                    MessageBox.Show("Status  is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbStatus.Focus();
                    return status = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return status;
        }

        // ---- add new leave type--- 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //--first validation check through the if conditon-----
                if (LeaveTypeValidation())
                {
                    LeaveTypeDTO oLeaveTypeDTO = new LeaveTypeDTO();// create leave type model object 
                    oLeaveTypeDTO.LeaveCode = Convert.ToInt32(txtLeaveCode.Text);
                    oLeaveTypeDTO.Name = txtName.Text.ToUpper();
                    oLeaveTypeDTO.Abbreviation = txtAbbrevaiation.Text.ToUpper();
                    oLeaveTypeDTO.LeaveEntitlementMode = cmbLeaveEntilmet.SelectedIndex != 0 ? Convert.ToInt32(cmbLeaveEntilmet.SelectedValue) : 0;
                    oLeaveTypeDTO.IsDeductFromQuota = cmbDedQuota.SelectedIndex != 0 ? Convert.ToInt32(cmbDedQuota.SelectedValue) : 0;
                    oLeaveTypeDTO.DayMode = cmbDayMode.SelectedIndex != 0 ? Convert.ToInt32(cmbDayMode.SelectedValue) : 0;
                    oLeaveTypeDTO.Entitlement = txtEntitlment.Text != string.Empty ? Convert.ToDecimal(txtEntitlment.Text) : 0;
                    oLeaveTypeDTO.Status = cmbStatus.SelectedIndex != 0 ? Convert.ToInt32(cmbStatus.SelectedValue) : 0;
                    oLeaveTypeDTO.CreatedDateTime = DateTime.UtcNow;
                    oLeaveTypeDTO.CreatedUser = LogUser.userName;// common folder-> lOg user.cs 
                    oLeaveTypeDTO.CreatedMachine = System.Windows.Forms.SystemInformation.ComputerName;
                    oLeaveTypeDTO.ModifiedDateTime = DateTime.UtcNow;
                    oLeaveTypeDTO.ModifiedUser = LogUser.userName;
                    oLeaveTypeDTO.ModifiedMachine = System.Windows.Forms.SystemInformation.ComputerName;


                    //----  navigate to the Bl folder-> LeaveTypeBL (ctr+ click)---- 
                    if (oLeaveTypeBL.LeaveTypeInsert(oLeaveTypeDTO) > 0)
                    {
                        MessageBox.Show("Successfully Instert....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                      
                    }
                    else
                    {
                        MessageBox.Show("Instert Fail....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }
    }
}
