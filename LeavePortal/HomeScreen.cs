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
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            adminDashboard1.BringToFront();
        }

       
        private void btnFunction_Click(object sender, EventArgs e)
        {
            functionTransition.Start();
        }
        bool functionExpand = false;

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

        bool sidebarExpand = true;
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
            leaveTypeForm1.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            adminDashboard1.BringToFront();
        }
    }
}
