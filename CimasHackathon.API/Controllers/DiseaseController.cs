using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;
using CimasHackathon.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CimasHackathon.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiseaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post(DiseaseRequest request)
        {
            var result = await _unitOfWork.Disease.AddAsync(new Disease
            {
                Name = request.Name
            });

            if (!result.Success) return BadRequest(result);

            _unitOfWork.SaveChanges();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Disease.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Disease.FindAsync(id);

            if (!result.Success) return NotFound(result);

            return Ok(result);
        }
    }
}