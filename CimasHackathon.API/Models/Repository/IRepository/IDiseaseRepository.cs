using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;

namespace CimasHackathon.API.Models.Repository.IRepository
{
    public interface IDiseaseRepository : IRepository<Disease>
    {
        Task<Result<IEnumerable<Disease>>> GetByMedicationIdAsync(int medicationId);
    }
}