using EmailSenderApi.Domain.Entities;

namespace EmailSenderApi.Domain.Interfaces
{
    public interface IEmailRepository
    {
        Task CreateAsync(Email dto);
    }
}
