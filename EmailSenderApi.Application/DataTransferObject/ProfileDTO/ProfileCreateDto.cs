using EmailSenderApi.Domain.Entities;

namespace EmailSenderApi.Application.DataTransferObject.ProfileDTO
{
    public class ProfileCreateDto
    {
        public string? Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
    }
}
