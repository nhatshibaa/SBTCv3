using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SBTCv3.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using SBTCv3.Models.Mail;

namespace SBTCv3.Controllers
{
    public class SendMailController : Controller
    {
        public readonly MailSettings _mailSettings;
        public SendMailController(IOptions<MailSettings> options)
        {
            _mailSettings = options.Value;
        }
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail([FromForm] string userEmail)
        {
            var email = new Email();
            try
            {
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress("Uỷ ban vé tàu ABC", "kidsclothesfree@gmail.com");
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress("duyoccho", userEmail);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = "Thông báo đặt vé thành công!";

                string FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplate\\MailTemp.html";
                string EmailTemplateText = System.IO.File.ReadAllText(FilePath);


                EmailTemplateText = string.Format(EmailTemplateText, "1", "2", "3", "4", "5", "6","7","8");

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = EmailTemplateText;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                SmtpClient emailClient = new SmtpClient();
                emailClient.Connect("smtp.gmail.com", 587);
                emailClient.Authenticate("kidsclothesfree@gmail.com", "eetgdqcqjypcwnmu");
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();
            }
            catch (Exception ex)
            {
                //Log Exception Details
                throw ex;

            }

            return View();
        }
    }
}
