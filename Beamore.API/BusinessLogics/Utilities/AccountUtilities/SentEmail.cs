using Beamore.API.BusinessLogics.CO;
using System;
using System.Net.Mail;
using System.Net.Mime;

namespace Beamore.API.BusinessLogics.Utilities.AccountUtilities
{
    public class SentEmail
    {

        public bool SendMail(ForgotPasswordModelCO model)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress(model.Email, "To :"));

                // From
                mailMsg.From = new MailAddress("info@beamore.tech", "Beamore Event Management System");

                // Subject and multipart/alternative Body
                mailMsg.Subject = "Reset Password";
                string text = "Hi, </br>Please click the link to reset your password";
                string html = @"<p>Please click the link to reset your password :</p></hr><a href='" + model.Link + "'><button>Reset Password</button></a></hr>Thanks for using Beamore </hr> Regards, </hr> <a href='http://beamoreweb.azurewebsites.net'>Beamore</a>";


                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_e53c1ca6103580db1df0ca9971078e98@azure.com", "beamore17");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
      

    }
}