using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;

namespace CimasHackathon.API.Models.Repository.IRepository
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        Task<Result<IEnumerable<Prescription>>> GetByPatientIdAsync(int patientId);
        Task<Result<IEnumerable<Prescription>>> GetByCimasNumberAsync(string cimasNumber);
        Task<Result<IEnumerable<Prescription>>> GetByDoctorIdAsync(int doctorId);
        Task<Result<bool>> AddPrescriptionAsync(PrescriptionRequest request);
    }
}