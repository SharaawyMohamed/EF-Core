using System.Net.Mail;
using Core.Models;
using Microsoft.Extensions.Options;
using OrderSystem.API.Settings;
using MimeKit;
using MailKit.Net.Smtp;

namespace Core.Services
{
    public class EmailService : IEmailService
    {

        private readonly MailSettings _options;
        public EmailService(IOptions<MailSettings> options)
        {
            _options = options.Value;
        }

        public async Task SendEmailAsync(Email email)
        {

            var mailMessage = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_options.Email),
                Subject = email.Subject

            };

            mailMessage.To.Add(MailboxAddress.Parse(email.To));
            mailMessage.From.Add(new MailboxAddress(_options.DisplayName, _options.Email));

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>Welcome Order System Website!</h1><p>Dear {email.To},</p><p>Thank you for registering on our website. We are excited to have you on board!</p><p>Best regards,<br/>The Team</p>",
                TextBody = $"Welcome to Our Website!\n\nDear {email.To},\n\nThank you for registering on our website. We are excited to have you on board!\n\nBest regards,\nThe Team"
            };
            mailMessage.Body = bodyBuilder.ToMessageBody();

            using var smtpClient = new MailKit.Net.Smtp.SmtpClient();

            smtpClient.Connect(_options.Host, _options.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtpClient.Authenticate(_options.Email, _options.Password);

            await smtpClient.SendAsync(mailMessage);
            smtpClient.Disconnect(true);

        }


    }

}
