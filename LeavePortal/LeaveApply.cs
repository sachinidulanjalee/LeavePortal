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
    public partial class LeaveApply : Form
    {
        private CommonMethod oCommonMethod = new CommonMethod();
        private EmpLeaveEntitlementBL oEmpLeaveEntitlementBL = new EmpLeaveEntitlementBL();
        private BindingSource bindingSource1 = new BindingSource();
        public Point mouseLocation;
        public LeaveApply()
        {
            InitializeComponent();
            txtYear.Format = DateTimePickerFormat.Custom;
            txtYear.CustomFormat = "yyyy";
            txtYear.ShowUpDown = true;
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPortalForm userPortalForm = new UserPortalForm();
            userPortalForm.Show();
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

        protected void LoadLeaveDetails()
        {
            List<EmpLeaveEntitlementDTO> lstEmpLeaveEntitlementDTO = oEmpLeaveEntitlementBL.EmpLeaveEntitlementData(Convert.ToInt32(LogUser.empNo), Convert.ToInt32(txtYear.Text));
            LeaveGridLoad(lstEmpLeaveEntitlementDTO);
        }

        protected void LeaveGridLoad(List<EmpLeaveEntitlementDTO> lstEmpLeaveEntitlementDTO)
        {
            dgLeaveDetails.AutoGenerateColumns = false;
            dgLeaveDetails.DataSource = lstEmpLeaveEntitlementDTO;
        }

        

        private void LeaveApply_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
            LoadLeaveDetails();
        }

        private void dgLeaveDetails_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgLeaveDetails.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader)
            {
                ContextMenu menu = new ContextMenu();

                foreach (DataGridViewColumn column in dgLeaveDetails.Columns)
                {
                    MenuItem item = new MenuItem();
                    item.Text = column.HeaderText;
                    item.Checked = column.Visible;


                    item.Click += (obj, ea) =>
                    {

                        column.Visible = item.Checked;
                        item.Checked = column.Visible;
                        menu.Show(dgLeaveDetails, e.Location);
                    };


                    menu.MenuItems.Add(item);

                }

                menu.Show(dgLeaveDetails, e.Location);
            }
        }

        private void txtYear_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadLeaveDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgLeaveDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgLeaveDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            AddNewLeaveApply addNewLeaveApply = new AddNewLeaveApply();
            
            addNewLeaveApply.lblSelectedLeaveType.Text = this.dgLeaveDetails.CurrentRow.Cells[3].Value.ToString();
            Sessions.entitlment = this.dgLeaveDetails.CurrentRow.Cells[8].Value.ToString();
            Sessions.used = this.dgLeaveDetails.CurrentRow.Cells[9].Value.ToString();
            Sessions.balance = this.dgLeaveDetails.CurrentRow.Cells[10].Value.ToString();
            Sessions.leaveCode = Convert.ToInt32(this.dgLeaveDetails.CurrentRow.Cells[1].Value.ToString());
            Sessions.startDate = Convert.ToDateTime(this.dgLeaveDetails.CurrentRow.Cells[4].Value.ToString()).ToString("yyyy-MM-dd");
            Sessions.endDate = Convert.ToDateTime(this.dgLeaveDetails.CurrentRow.Cells[6].Value.ToString()).ToString("yyyy-MM-dd");
            Sessions.year = Convert.ToInt32(txtYear.Text).ToString();
            addNewLeaveApply.Show();
        }

        private void LeaveApply_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void LeaveApply_MouseMove(object sender, MouseEventArgs e)
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
