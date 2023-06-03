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
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
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
        }
    }
    
}
