using CimasHackathon.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CimasHackathon.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Patient.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Patient.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }
    }
}