using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;
using CimasHackathon.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CimasHackathon.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Medication.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Medication.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MedicationRequest request)
        {
            var result = await _unitOfWork.Medication.AddAsync(new Medication
            {
                Description = request.Description,
                Name = request.Name,
                DiseaseId = request.DiseaseId
            });

            if (!result.Success) return BadRequest(result);

            _unitOfWork.SaveChanges();
            
            return Ok(result);
        }

        [HttpGet("disease/{diseaseId}")]
        public async Task<IActionResult> GetByDisease(int diseaseId) => Ok(await _unitOfWork.Medication.GetByDiseaseIdAsync(diseaseId));

        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchByName(string name) => Ok(await _unitOfWork.Medication.SearchByNameAsync(name));
    }
}