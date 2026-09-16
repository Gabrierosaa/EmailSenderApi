using EmailSenderApi.Application.DataTransferObject.EmailDTO;
using EmailSenderApi.Application.Interfaces;
using EmailSenderApi.Domain.Entities;
using EmailSenderApi.Domain.Interfaces;


namespace EmailSenderApi.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IProfileRepository _profileRepository;

        public EmailService(IEmailRepository emailRepository, IProfileRepository profileRepository)
        {
            _emailRepository = emailRepository;
            _profileRepository = profileRepository;
        }

        public async Task CreateAsync(EmailCreateDTO dto, Guid profileId)
        {
            var senderProfile = await _profileRepository.GetAsyncById(profileId);
            if (senderProfile is null)
                throw new ArgumentException("Profile remetente não encontrado.");

            if (dto.ProfileIds != null && dto.ProfileIds.Count > 0)
            {
                foreach (var recipientId in dto.ProfileIds)
                {
                    var recipientProfile = await _profileRepository.GetAsyncById(recipientId);
                    if (recipientProfile is null)
                        continue;

                    var email = new Email(
                        senderProfile.Email,
                        recipientProfile.Email,
                        dto.Subject,
                        dto.Body,
                        senderProfile.Id
                    );

                    await _emailRepository.CreateAsync(email);
                }

                return;
            }

            var emailFallback = new Email(
                senderProfile.Email,
                senderProfile.Email,
                dto.Subject,
                dto.Body,
                senderProfile.Id
            );

            await _emailRepository.CreateAsync(emailFallback);
        }
    }
}
