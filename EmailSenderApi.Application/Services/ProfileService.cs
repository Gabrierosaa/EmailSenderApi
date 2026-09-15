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

        public async Task<ProfileResponseDto> GetAsync(ProfileResponseDto dto)
        {
            // Converte DTO para entidade para consulta no repositório
            var profileToSearch = new Profile(dto.Name, dto.Description, dto.Email);

            var profileFound = await _profilerepository.GetAsync(profileToSearch);

            if (profileFound is null)
                return null;

            return new ProfileResponseDto
            {
                Id = profileFound.Id ?? Guid.Empty,
                Name = profileFound.Name ?? string.Empty,
                Description = profileFound.Description,
                Email = profileFound.Email
            };
        }

        public async Task<ProfileResponseDto> GetAsyncById(Guid id)
        {
            var profileGet = await _profilerepository.GetAsyncById(id);

            if (profileGet is null)
                return null;

            return new ProfileResponseDto
            {
                Id = profileGet.Id ?? Guid.Empty,
                Name = profileGet.Name ?? string.Empty,
                Description = profileGet.Description,
                Email = profileGet.Email
            };
        }
    }
}
