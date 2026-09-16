using EmailSenderApi.Application.DataTransferObject.EmailDTO;
using EmailSenderApi.Application.DataTransferObject.ProfileDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailSenderApi.Application.Interfaces
{
    public interface IEmailService
    {
        Task CreateAsync(EmailCreateDTO dto, Guid profileId);
    }
}
