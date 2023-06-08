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
    public partial class EditLeaveType : Form
    {
        public static EditLeaveType editLeaveType;

        public static EditLeaveType getEditLeaveTypee
        {
            get
            {
                if (editLeaveType == null)
                {
                    editLeaveType = new EditLeaveType();
                }
                return editLeaveType;
            }

        }

        public EditLeaveType()
        {
            InitializeComponent();
        }
    }
}
