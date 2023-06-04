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


        private void frm_Login_Load(object sender, EventArgs e)
        {
            string activeConnection = ConfigurationManager.AppSettings["ActiveConnection"];
            _constring = ConfigurationManager.ConnectionStrings[activeConnection].ConnectionString;
            DMSSWE.Common.ConnectionString = _constring;
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

            //try
            //{
            //    UserModel oData = new UserModel();
            //    oData.UserName = txtUserName.Text.Trim();
            //    oData.Password = DMSSWE.CryptoUtil.Encrypt(txtUserName.Text.Trim(), txtPassword.Text.Trim())
            //    oData.UserType = Convert.ToInt32(ddStatus.SelectedValue);
            //    oData.Status = Convert.ToInt32(ddStatus.SelectedValue);
            //    oData.CreatedDateTime = System.DateTime.UtcNow;
            //    oData.CreatedBy = Session["UserID"].ToString();
            //    oData.CreatedMachine = Session["UserMachine"].ToString();
            //    oData.ModifiedDateTime = System.DateTime.UtcNow;
            //    oData.ModifiedBy = Session["UserID"].ToString();
            //    oData.ModifiedMachine = Session["UserMachine"].ToString();

            //    if (oDesignationBL.DesignationInsert(oData) > 0)
            //    {
            //        // ShowMessage("Successfully inserted !..");
            //        ShowMessage(ResponseMessages.InsertSuccess);
            //        mvParent.ActiveViewIndex = 0;
            //        ResetControllers();
            //        HandleControllers(CommandMood.Add);
            //        LoadDesignations();
            ////    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //    return;
            //}
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim().ToLower();
                string password = txtPassword.Text.Trim();
                UserModel ouserModel = userCreateBL.GetByUserType(userName);

                userCreateBL.Login(userName, password, ouserModel.UserType);
                LogUser.userName = userName;
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

    }
    
}
