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

        [HttpPost("login/doctor")]
        public async Task<IActionResult> Login(DoctorLoginRequest request)
        {
            var result = await _accountRepository.DoctorLoginAsync(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("login/pharmacy")]
        public async Task<IActionResult> Login(PharmacyLoginRequest request)
        {
            var result = await _accountRepository.PharmacyLoginAsync(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("login/admin")]
        public async Task<IActionResult> Login(AdminLoginRequest request)
        {
            var result = await _accountRepository.AdminLoginAsync(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("otp")]
        public async Task<IActionResult> Otp(string cimasNumber)
        {
            var result = await _accountRepository.PatientOtpAsync(cimasNumber);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get() => Ok(await _unitOfWork.)
    }
}