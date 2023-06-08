using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Model
{
    public class MailConfigurationDTO
    {
        public int Id { get; set; }

        public string Smtp_Username { get; set; }

        public string Smtp_Password { get; set; }

        public string Configset { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string From { get; set; }

        public string From_Name { get; set; }
    }
}
