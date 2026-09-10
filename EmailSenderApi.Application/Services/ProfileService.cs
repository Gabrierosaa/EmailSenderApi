using EmailSenderApi.Application.DataTransferObject.ProfileDTO;
using EmailSenderApi.Application.Interfaces;
using EmailSenderApi.Domain.Entities;
using EmailSenderApi.Domain.Interfaces;

namespace EmailSenderApi.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profilerepository;

        public ProfileService(IProfileRepository profilerepository)
        {
            _profilerepository = profilerepository;
        }

        public async Task CreateAsync(ProfileCreateDto dto)
        {
            var profile = new Profile(
                dto.Name,
                dto.Description,
                dto.Email);
            
            await _profilerepository.CreateAsync(profile);
        }
    }
}
