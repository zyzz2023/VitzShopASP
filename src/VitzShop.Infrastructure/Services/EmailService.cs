//using MimeKit;
//using MailKit.Net.Smtp;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity.UI.Services;

//namespace VitzShop.Infrastructure.Services
//{
//    public class EmailService : IEmailSender
//    {
//        private readonly IConfiguration _config;

//        // Добавьте конструктор
//        public EmailService(IConfiguration config)
//        {
//            _config = config;
//        }
//        public async Task SendEmailAsync(string email, string subject, string message)
//        {
//            var authEmail = "korobenkov2005@mail.ru";
//            var authPassowrd = _config["EmailSender:Password"];
//            using var emailMessage = new MimeMessage();

//            emailMessage.From.Add(new MailboxAddress("VITZ SHOP", "korobenkov2005@mail.ru"));
//            emailMessage.To.Add(new MailboxAddress("", email));
//            emailMessage.Subject = subject;
//            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
//            {
//                Text = message
//            };

//            using (var client = new SmtpClient())
//            {
//                await client.ConnectAsync("smtp.mail.ru", 587, false);
//                await client.AuthenticateAsync(authEmail, authPassowrd);
//                try
//                {
//                    await client.SendAsync(emailMessage);
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex);
//                }

//                await client.DisconnectAsync(true);
//            }
//        }
//    }
//}
