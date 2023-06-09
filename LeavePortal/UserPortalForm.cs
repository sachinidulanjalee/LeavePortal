using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeavePortal
{
    public partial class UserPortalForm : Form
    {
        public UserPortalForm()
        {
            InitializeComponent();
        }

        private void pnlMenubar_Paint(object sender, PaintEventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaxzimis_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frm_Login frm_Login = new frm_Login();
            frm_Login.Show();
            this.Hide();
        }

        private void btnCancelLeave_Click(object sender, EventArgs e)
        {
           
        }

        private void btnApplyLeave_Click(object sender, EventArgs e)
        {
            LeaveApply leaveApply = new LeaveApply();
            leaveApply.Show();
            this.Hide();
        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserPortalForm_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.UtcNow.ToString();
        }
    }
}
