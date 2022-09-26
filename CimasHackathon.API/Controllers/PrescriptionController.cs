using CimasHackathon.API.Enums;
using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;
using CimasHackathon.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CimasHackathon.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PrescriptionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _unitOfWork.Prescription.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Prescription.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatient(int patientId) => Ok(await _unitOfWork.Prescription.GetByPatientIdAsync(patientId));

        [HttpGet("membership/{cimasNumber}")]
        public async Task<IActionResult> GetByPatient(string cimasNumber) => Ok(await _unitOfWork.Prescription.GetByCimasNumberAsync(cimasNumber));
        
        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetByDoctor(int doctorId) => Ok(await _unitOfWork.Prescription.GetByDoctorIdAsync(doctorId));

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(PrescriptionStatus status) => Ok(await _unitOfWork.Prescription.GetByStatusAsync(status));
        
        [HttpPost]
        public async Task<IActionResult> Post(PrescriptionRequest request)
        {
            var result = await _unitOfWork.Prescription.AddPrescriptionAsync(request);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}