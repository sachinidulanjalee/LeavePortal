using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LeavePortal.Common
{
    public static class MailConfiguration
    {
        private static string Smtp_Username { get; set; }

        private static string Smtp_Password { get; set; }

        private static string Configset { get; set; }

        private static string Host { get; set; }

        private static int Port { get; set; }

        private static string From { get; set; }

        private static string From_Name { get; set; }

        #region Email Notification

        public static bool SendMail(string _toAddress, string _subject, string _msgBody, string Host, int Port, string Smtp_Username, string Smtp_Password, string From, string From_Name, string copymail)
        {
            bool status = false;

            try
            {
                Configset = "ConfigSet";
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(From, From_Name);
                message.To.Add(new MailAddress(_toAddress));
                message.Subject = _subject;
                message.Body = _msgBody;
                message.Headers.Add("X-SES-CONFIGURATION-SET", Configset);

                if (!string.IsNullOrEmpty(copymail))
                {
                    MailAddress copy = new MailAddress(copymail);
                    message.CC.Add(copy);
                }

                message.Priority = MailPriority.High;

                using (var client = new SmtpClient(Host, Port))
                {
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    // Enable SSL encryption
                    client.EnableSsl = true;

                    client.UseDefaultCredentials = false;

                    // Pass SMTP credentials
                    client.Credentials = new NetworkCredential(Smtp_Username, Smtp_Password);
                    client.Timeout = 600000;
                    try
                    {
                        Console.WriteLine("Attempting to send email...");
                        client.Send(message);
                        status = true;
                        //ShowMessage("Successful", "Email verification code was successfully sent, Check your mail.!");
                    }
                    catch (Exception ex)
                    {
                        status = false;
                        Console.WriteLine("The email was not sent.");
                        Console.WriteLine("Error message: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        #endregion Email Notification

        #region Leave

        public static string GetApplyLeaveMessage(string ReportPersonName, Int64 EmpID, string Name, DateTime FromDate, DateTime ToDate, string LeaveName, string DayMode, string WhichHalf)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<b>Dear " + ReportPersonName.Substring(0, 1).ToUpper() + ReportPersonName.Substring(1).ToUpper() + ",</b><br />");
            sb.AppendLine("<br />");

            sb.AppendLine("Leave application of Employee ID : " + EmpID + "   " + Name.Substring(0, 1).ToUpper() + Name.Substring(1).ToUpper() + " is pending for your approval.  </b><br />");
            sb.AppendLine("<br />");
            sb.AppendLine("Leave Type  : " + LeaveName.ToUpper() + "</b><br />");
            sb.AppendLine("Leave From  : " + FromDate.Date.ToShortDateString() + "</b><br />");
            sb.AppendLine("Leave To    : " + ToDate.Date.ToShortDateString() + "</b><br />");
            sb.AppendLine("Day Mode    : " + DayMode + ", Which Half : " + WhichHalf + "</b><br />");
            sb.AppendLine("<br />");
            sb.AppendLine("<br />");

            sb.AppendLine("Sincerely,<br />");
            sb.AppendLine("Online Leave Webmaster<br />");
            return sb.ToString();
        }

        public static string GetCoveringLeaveMessage(string ReportPersonName, Int64 EmpID, string Name, DateTime FromDate, DateTime ToDate, string LeaveName, string coverEmpName, Int64 CoverEmpID, string DayMode, string WhichHalf)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<b>Dear " + coverEmpName.Substring(0, 1).ToUpper() + coverEmpName.Substring(1).ToUpper() + ",</b><br />");
            sb.AppendLine("<br />");
            sb.AppendLine(Name.Substring(0, 1).ToUpper() + Name.Substring(1).ToUpper() + " applied a Leave on " + DateTime.UtcNow.Date.ToShortDateString() + "." + "</b><br />");
            sb.AppendLine("Employee ID :  " + EmpID.ToString() + "</b><br />");
            sb.AppendLine("Leave Type  : " + LeaveName.ToUpper() + "</b><br />");
            sb.AppendLine("Leave From  : " + FromDate.Date.ToShortDateString() + "</b><br />");
            sb.AppendLine("Leave To    : " + ToDate.Date.ToShortDateString() + "</b><br />");
            sb.AppendLine("Day Mode    : " + DayMode + " Which Half : " + WhichHalf + "</b><br />");
            sb.AppendLine("<br />");
            sb.AppendLine("I have assigned " + coverEmpName.Substring(0, 1).ToUpper() + coverEmpName.Substring(1).ToUpper() + " (" + CoverEmpID + ") as the covering employee.</b><br />");
            sb.AppendLine("<br />");
            sb.AppendLine("<a href='http://dmshrisportallive.azurewebsites.net/'>HRIS Live Portal</a>");
            sb.AppendLine("<br />");
            return sb.ToString();
        }
        #endregion Leave
    }

}
