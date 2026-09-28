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
        private readonly IEmailSender _emailSender;

        public EmailService(IEmailRepository emailRepository, IProfileRepository profileRepository, IEmailSender emailSender)
        {
            _emailRepository = emailRepository;
            _profileRepository = profileRepository;
            _emailSender = emailSender;
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

                    await SendAndPersistAsync(email);
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

            await SendAndPersistAsync(emailFallback);
        }

        private async Task SendAndPersistAsync(Email email)
        {
            try
            {
                await _emailSender.SendAsync(email);
                email.MarkAsSent();
            }
            catch (Exception ex)
            {
                email.MarkAsFailed(ex.Message);
            }

            await _emailRepository.CreateAsync(email);
        }
    }
}
