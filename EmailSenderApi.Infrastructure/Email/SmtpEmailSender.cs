using EmailSenderApi.Domain.Entities;
using EmailSenderApi.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace EmailSenderApi.Infrastructure.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public Task SendAsync(EmailSenderApi.Domain.Entities.Email email, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

    }
}
