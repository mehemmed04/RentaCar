using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentaCar.Services
{
    public class EmailService
    {
        public static void SendEmail(string receiver, string body)
        {
            try
            {
                string fromEmail = "mehemmedbayramov2004@gmail.com";
                MailMessage mailMessage = new MailMessage(fromEmail, receiver, "Rented Succesfully", body);
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromEmail, "hbsdpwwjtugwjvrg");
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
