using EmailSenderApi.Application.DataTransferObject.EmailDTO;
using Microsoft.AspNetCore.Mvc;
using EmailSenderApi.Application.Interfaces;

namespace EmailSenderApi.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmail([FromBody] EmailCreateDTO dto, Guid profileId)
        {
            await _emailService.CreateAsync(dto, profileId);
            return Ok();
        }
    }
}
