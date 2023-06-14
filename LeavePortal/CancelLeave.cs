using LeavePortal.BL;
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
    public partial class CancelLeave : Form
    {
        public Point mouseLocation;
        private LeaveRequestHeaderBL oLeaveRequestHeaderBL = new LeaveRequestHeaderBL();
        public CancelLeave()
        {
            InitializeComponent();
            txtYear.Format = DateTimePickerFormat.Custom;
            txtYear.CustomFormat = "yyyy";
            txtYear.ShowUpDown = true;
            lblDateTime.Text = DateTime.UtcNow.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaxzimis_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frm_Login frm_Login = new frm_Login();
            frm_Login.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPortalForm userPortalForm = new UserPortalForm();
            userPortalForm.Show();
        }

        private void lblHome_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CancelLeave_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mouusePose = Control.MousePosition;
                mouusePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mouusePose;

            }
        }

        private void CancelLeave_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void CancelLeave_Load(object sender, EventArgs e)
        {
            LoadLeaveGrid();
        }

        private void LoadLeaveGrid()
        {
            try
            {
                string StartDate = txtYear.Text + "-01-01";
                string EndDate = txtYear.Text + "-12-31";

                List<ParamsDTO> oParamsDTOs = new List<ParamsDTO>
                {
                    new ParamsDTO { ColumnName = "A.EmpNo", Operator = "=", Value = Convert.ToInt32(LogUser.empNo) },
                    new ParamsDTO { ColumnName = "A.RequestDate", Operator = "BETWEEN", Value = StartDate + " ' AND ' " + EndDate },
                };

                int[] oLeaveStatus = { (int)LeaveAuthorizationFlag.Pending, (int)LeaveAuthorizationFlag.Validate, (int)LeaveAuthorizationFlag.Denied, (int)LeaveAuthorizationFlag.Approved };

                List<LeaveRequestHeaderDTO> lstLeaveRequestHeaderDTO = oLeaveRequestHeaderBL.LeaveRequestHeaderSearchByForLeaveCancel(oParamsDTOs, oLeaveStatus);

                dgCancelLeave.AutoGenerateColumns = false;
                dgCancelLeave.DataSource = lstLeaveRequestHeaderDTO.OrderByDescending(x => x.LeaveChitNumber).ToList();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
