using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;

namespace CimasHackathon.API.Models.Repository.IRepository
{
    public interface IMedicationRepository : IRepository<Medication>
    {
        Task<Result<IEnumerable<Medication>>> GetByDiseaseIdAsync(int diseaseId);
        Task<Result<IEnumerable<Medication>>> SearchByNameAsync(string name);
    }
}