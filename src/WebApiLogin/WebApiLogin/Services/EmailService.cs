using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApiLogin.Models;

namespace WebApiLogin.Services
{
    public class EmailService
    {
        private readonly WebsiteEmailSettings _emailSettings;
        public EmailService(WebsiteEmailSettings settings)
        {
            _emailSettings = settings;
        }

        public bool SendEmail(string email, string assunto, string mensagem)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email) ? _emailSettings.ToEmail : email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, _emailSettings.SenderName )
                };

                mail.To.Add(new MailAddress(toEmail));
                
                if( ! string.IsNullOrEmpty(_emailSettings.CcEmail) )
                    mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                //outras opções
                //mail.Attachments.Add(new Attachment(arquivo));
                //

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    smtp.SendMailAsync(mail);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    
}
