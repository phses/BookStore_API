
using bookstore.Domain.Interfaces.Services;
using bookstore.Domain.Settings;
using System.Net;
using System.Net.Mail;

namespace bookstore.Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }
        public void EnviaEmailConfirmacao(string emailDestinatario, Guid tokenEmailConfirmacao)
        {
            var smtpClient = new SmtpClient(_emailSettings.Host)
            {
                Port = _emailSettings.Port,
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
                EnableSsl = _emailSettings.EnableSsl
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.Username),
                Subject = "Book Store",
                Body = $"<p>{tokenEmailConfirmacao}</p>",
                IsBodyHtml = true
            };

            mailMessage.To.Add(emailDestinatario);
            smtpClient.Send(mailMessage);
        }
    }
}
