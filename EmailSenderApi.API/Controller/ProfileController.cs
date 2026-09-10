using EmailSenderApi.Application.DataTransferObject.ProfileDTO;
using EmailSenderApi.Application.Interfaces;
using EmailSenderApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApi.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileservice;

        public ProfileController(IProfileService profileservice)
        {
            _profileservice = profileservice;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfileCreateDto dto)
        {
            await _profileservice.CreateAsync(dto);

            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
