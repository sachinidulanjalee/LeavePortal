using System;
using DMSSWE.CLOUD.SECURITY;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeavePortal.Model;
using LeavePortal.BL;
using LeavePortal.Common;
using System.Configuration;

namespace LeavePortal
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }
        string _constring = string.Empty;
        UserModel userModel = new UserModel();
        UserCreateBL userCreateBL = new UserCreateBL();
        public Point mouseLocation;


        private void frm_Login_Load(object sender, EventArgs e)
        {
            string activeConnection = ConfigurationManager.AppSettings["ActiveConnection"];
            _constring = ConfigurationManager.ConnectionStrings[activeConnection].ConnectionString;
            DMSSWE.Common.ConnectionString = _constring;

            CommonMethod.setEnumValues(cmbUserType, typeof(userType));
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlRegister.Height = pnlLogin.Height;
            pnlLogin.Location = new Point(5,5);
            panel2.Location = new Point(380,5);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlRegister.Height = 0;
            pnlLogin.Location = new Point(345,5);
            panel2.Location = new Point(5,5);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            pnlRegister.Height = 0;
            pnlLogin.Location = new Point(345, 5);
            panel2.Location = new Point(5, 5);

            Add();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim().ToLower();
                string password = txtPassword.Text.Trim();
                UserModel ouserModel = userCreateBL.GetByUserType(userName);

              
                userCreateBL.Login(userName, password, ouserModel.UserType);
                userCreateBL.GetByUserType(userName);
              
                LogUser.userName = userName;
                LogUser.empNo = ouserModel.EmpNo.ToString() ;

                if (ouserModel.UserName == txtUserName.Text && ouserModel.Password == txtPassword.Text)
                {

                    MessageBox.Show("Login Successfully....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if(ouserModel.UserType ==1)
                    {
                        HomeScreen hs = new HomeScreen();
                        hs.Show();
                      
                    }
                    else
                    {
                        UserPortalForm Us = new UserPortalForm();
                        Us.Show();
                    }
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("UserName or Password Incorrect....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

               
            }
            catch (Exception ex)
            {

                throw ex ;
            }
           
        }

        private void pnlLogin_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void pnlLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point mouusePose = Control.MousePosition;
                mouusePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mouusePose;
                    
            }
        }

        private void Add()
        {
            DateTime d1 = DateTime.UtcNow;
            DateTime ExpiryDate = d1.AddMonths(5);

            try
            {
                if (LoginValidation())
                {
                    UserModel oData = new UserModel();
                    oData.UserName = txtRUserName.Text.Trim();
                    oData.EmpNo = Convert.ToInt64(txtEmpNo.Text.Trim());
                    // oData.Password = DMSSWE.CryptoUtil.Encrypt(txtUserName.Text.Trim(), txtRpassword.Text.Trim());
                    oData.Password = txtRpassword.Text.Trim();
                    oData.Email = txtEmail.Text.ToString();
                    oData.UserType = Convert.ToInt32(cmbUserType.SelectedValue);
                    oData.ExpiryDate = ExpiryDate;
                    oData.MaximumAttemps = 3;
                    oData.Status = (int)Status.Active;
                    oData.CreatedDateTime = System.DateTime.UtcNow;
                    oData.CreatedBy = "Admin";
                    oData.CreatedMachine = System.Windows.Forms.SystemInformation.ComputerName;
                    oData.ModifiedDateTime = System.DateTime.UtcNow;
                    oData.ModifiedBy = "Admin";
                    oData.ModifiedMachine = System.Windows.Forms.SystemInformation.ComputerName;


                    if (userCreateBL.Add(oData) > 0)
                    {
                        MessageBox.Show("Successfully Registered....", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else
                    {
                        MessageBox.Show(" Registered Fail....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool LoginValidation()
        {
            bool status = true;
            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || string.IsNullOrEmpty(txtRUserName.Text.Trim()))
                {
                    errorProvider1.SetError(txtUserName, "UserName is required");
                }
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()) || string.IsNullOrEmpty(txtRpassword.Text.Trim()))
                {
                    errorProvider2.SetError(txtPassword, "Password is required");
                }
                if (string.IsNullOrEmpty(txtEmpNo.Text.Trim()))
                {
                    errorProvider3.SetError(txtEmpNo, "Employee No is required");
                }
                if (string.IsNullOrEmpty(cmbUserType.SelectedIndex.ToString()))
                {
                    errorProvider4.SetError(cmbUserType, "UserType is required");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }
    }
    
}
