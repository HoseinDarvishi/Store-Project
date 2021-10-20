using MimeKit;
using MailKit.Net.Smtp;

namespace UtilityFreamwork.Application.Email
{
   public class EmailService : IEmailService
   {
      public void SendEmail(string title, string messageBody, string destination)
      {
         var message = new MimeMessage();

         var from = new MailboxAddress("Atriya", "test@atriya.com");
         message.From.Add(from);

         var to = new MailboxAddress("User", destination);
         message.To.Add(to);

         message.Subject = title;
         var bodyBuilder = new BodyBuilder
         {
            HtmlBody = $"<h1>{messageBody}</h1>",
         };

         message.Body = bodyBuilder.ToMessageBody();

         var client = new SmtpClient();
         client.Connect("185.88.152.251", 25, false);
         client.Authenticate("test@gmail.com", "123456");         // Sender Email & Password 
         client.Send(message);
         client.Disconnect(true);
         client.Dispose();
      }
   }
}