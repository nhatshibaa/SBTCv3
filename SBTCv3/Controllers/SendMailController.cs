using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SBTCv3.Models;
using MailKit.Net.Smtp;


namespace SBTCv3.Controllers
{
    public class SendMailController : Controller
    {
        private readonly Models.Mail.MailSettings _mailSettings;
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(IMail mail, string userEmail)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();


                MailboxAddress emailFrom = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(mail.username, mail.email);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = "Thông báo đặt vé thành công!";

                string FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplate\\MailTemp.html";
                string EmailTemplateText = System.IO.File.ReadAllText(FilePath);


                EmailTemplateText = string.Format(EmailTemplateText, userEmail);

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = EmailTemplateText;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                SmtpClient emailClient = new SmtpClient();
                emailClient.Connect(_mailSettings.Host, _mailSettings.Port);
                emailClient.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();                
            }
            catch (Exception ex)
            {
                //Log Exception Details
                return Ok(ex);
            }

            return View();
        }
    }
}
