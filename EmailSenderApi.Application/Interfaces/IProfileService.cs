using EmailSenderApi.Application.DataTransferObject.ProfileDTO;
using EmailSenderApi.Domain.Entities;

namespace EmailSenderApi.Application.Interfaces
{
    public interface IProfileService
    {
        Task CreateAsync(ProfileCreateDto dto);
        Task<ProfileResponseDto> GetAsyncById(Guid id);
        Task<ProfileResponseDto> GetAsync(ProfileResponseDto dto);
    }
}
