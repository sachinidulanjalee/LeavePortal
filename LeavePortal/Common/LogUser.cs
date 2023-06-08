using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Common
{
    class LogUser
    {
        static string UserName;
        static string EmpNo;

        public static string userName
        { 
        
            get
            {
                return UserName;
            }
            set
            {
                UserName = value;
            }

        }

        public static string empNo
        {

            get
            {
                return EmpNo;
            }
            set
            {
                EmpNo = value;
            }

        }
    }
}
