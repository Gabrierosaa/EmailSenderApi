using EmailSenderApi.Domain.Entities;

namespace EmailSenderApi.Application.Interfaces
{
    public interface IEmailSender
    {
        Task SendAsync(Email email, CancellationToken cancellationToken = default);
    }
}
