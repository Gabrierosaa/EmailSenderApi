using EmailSenderApi.Domain.Entities;
using EmailSenderApi.Application.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Threading;
using System.Threading.Tasks;

namespace EmailSenderApi.Infrastructure.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly SmtpSettings _settings;

        public SmtpEmailSender(IOptions<SmtpSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendAsync(EmailSenderApi.Domain.Entities.Email email, CancellationToken cancellationToken = default)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_settings.FromName, email.From));
            message.To.Add(MailboxAddress.Parse(email.To));
            message.Subject = email.Subject;

            var bodyBuilder = new BodyBuilder();
            if (email.IsHtml)
                bodyBuilder.HtmlBody = email.Body;
            else
                bodyBuilder.TextBody = email.Body;

            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();

            var socketOptions = _settings.UseSsl
                ? SecureSocketOptions.SslOnConnect
                : SecureSocketOptions.StartTlsWhenAvailable;

            await client.ConnectAsync(_settings.Host, _settings.Port, socketOptions, cancellationToken);

            if (!string.IsNullOrWhiteSpace(_settings.Username))
                await client.AuthenticateAsync(_settings.Username, _settings.Password, cancellationToken);

            await client.SendAsync(message, cancellationToken);
            await client.DisconnectAsync(true, cancellationToken);
        }
    }
}
