using CimasHackathon.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CimasHackathon.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Doctor.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Doctor.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }
    }
}