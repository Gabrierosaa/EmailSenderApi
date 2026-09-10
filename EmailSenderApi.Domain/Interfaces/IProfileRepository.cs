using EmailSenderApi.Domain.Entities;

namespace EmailSenderApi.Domain.Interfaces
{
    public interface IProfileRepository
    {
        Task CreateAsync(Profile profile);
        Task<Profile> GetAsyncById(Guid id, Profile profile);
        Task<Profile> GetAsync(Profile profiles);
    }
}
