using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SBTCv3.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using SBTCv3.Models.Mail;
using SBTCv3.Data;
using Microsoft.EntityFrameworkCore;

namespace SBTCv3.Controllers
{
    public class SendMailController : Controller
    {
        public readonly MailSettings _mailSettings;
        private readonly SBTCv3Context _context;
        public SendMailController(IOptions<MailSettings> options, SBTCv3Context context)
        {
            _mailSettings = options.Value;
            _context = context;
        }
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail([FromForm] string email)
        {
            var mailUser = new Email();
            
            try
            {
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress("Uỷ ban vé tàu ABC", "kidsclothesfree@gmail.com");
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress("duy", email);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = "Thông báo đặt vé thành công!";

                string FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplate\\MailTemp.html";
                string EmailTemplateText = System.IO.File.ReadAllText(FilePath);

                var cart = new Cart();
                var ticket = new Ticket();
                cart = _context.Cart.FromSqlRaw(@"select * from Cart where Id = 1").FirstOrDefault();
                ticket = _context.Ticket.FromSqlRaw(@"select * from Ticket where id = 1", mailUser.idTicket).FirstOrDefault();
                EmailTemplateText = string.Format(EmailTemplateText, "Nguyễn Văn A", cart.Email, "09123123454", cart.IdentityCard, ticket.name, ticket.quantity, ticket.price);

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
