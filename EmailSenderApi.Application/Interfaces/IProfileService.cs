using EmailSenderApi.Application.DataTransferObject.ProfileDTO;
using EmailSenderApi.Domain.Entities;

namespace EmailSenderApi.Application.Interfaces
{
    public interface IProfileService
    {
        Task CreateAsync(ProfileCreateDto dto);
    }
}
