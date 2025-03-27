using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage(); //e-postanın temel yapısını temsil eden bir sınıftır. new MimeMessage() ifadesi, yeni bir e-posta mesajı oluşturur 
            MailboxAddress mailboxAddressFrom = new MailboxAddress(mailRequest.Name,"traversalcore2@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); //Bu, e-postayı gönderen kişinin kim olduğunu belirtir. 

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo); //Bu, e-postanın kime gönderileceğini belirtir.

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587,false);
            client.Authenticate("seyitacilingir@gmail.com", "jzxm htct lcss qhhf");
            client.Send(mimeMessage);
            client.Disconnect(true);
  
            return View();
        }
    }
}
