using LeavePortal.Common;
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
    public partial class HomeScreen : Form
    {
        bool functionExpand = false;
        bool sidebarExpand = true;
        public Point mouseLocation;
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            UserName.Text = LogUser.userName;
            lblDatetime.Text = DateTime.Now.ToString();
            adminDashboard1.BringToFront();
        }

       
        private void btnFunction_Click(object sender, EventArgs e)
        {
            functionTransition.Start();
        }
      

        private void functionTransition_Tick(object sender, EventArgs e)
        {
            if(functionExpand == false)
            {
                FunctionContainer.Height += 10;
                if(FunctionContainer.Height >= 518)
                {
                    functionTransition.Stop();
                    functionExpand = true;
                }
            }
            else
            {
                FunctionContainer.Height -= 10;
                if (FunctionContainer.Height <= 61)
                {
                    functionTransition.Stop();
                    functionExpand = false;
                }
            }
        }

   
        private void sideBarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 62)
                {
                    sidebarExpand = false;
                    sideBarTransition.Stop();

                    pnDashboard.Width = sidebar.Width;
                    pnlReport.Width = sidebar.Width;
                    FunctionContainer.Width = sidebar.Width;

                }
            }
            else
            {
                sidebar.Width += 5;
                if (sidebar.Width >= 262)
                {
                    sidebarExpand = true;
                    sideBarTransition.Stop();
                    pnDashboard.Width = sidebar.Width;
                    pnlReport.Width = sidebar.Width;
                    FunctionContainer.Width = sidebar.Width;
                }
            }
        }
            
        private void btnHam_Click(object sender, EventArgs e)
        {
            sideBarTransition.Start();
        }

        private void btnLeaveType_Click(object sender, EventArgs e)
        {
            leaveTypeForm2.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            adminDashboard1.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        //private void btnMaxzimis_Click(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Normal)
        //    {
        //        WindowState = FormWindowState.Maximized;
        //    }
        //    else
        //    {
        //        WindowState = FormWindowState.Normal;
        //    }
        //}
        private void btnLeaveAccPlan_Click(object sender, EventArgs e)
        {
            
        }

        private void leaveAccuralPlan1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
        
        
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            employeeProfile1.BringToFront();
        }

        private void leaveEntitlment2_Load(object sender, EventArgs e)
        {

        }

        private void HomeScreen_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void HomeScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mouusePose = Control.MousePosition;
                mouusePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mouusePose;

            }
        }
    }
}
