using CimasHackathon.API.Models.Local;
using CimasHackathon.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CimasHackathon.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;

        public AccountController(IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
        }


        [HttpPost("login/patient")]
        public async Task<IActionResult> Login(PatientLoginRequest request)
        {
            var result = await _accountRepository.PatientLoginAsync(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("otp")]
        public async Task<IActionResult> Otp(string phoneNumber)
        {
            var result = await _accountRepository.PatientOtpAsync(phoneNumber);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}