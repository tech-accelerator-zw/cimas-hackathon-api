using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;
using CimasHackathon.API.Models.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CimasHackathon.API.Models.Repository
{
    public class MedicationRepository : Repository<Medication>, IMedicationRepository
    {
        public MedicationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<IEnumerable<Medication>>> GetByDiseaseIdAsync(int diseaseId)
        {
            var medications = await _dbSet.Where(x => x.DiseaseId == diseaseId).ToListAsync();

            return new Result<IEnumerable<Medication>>(medications);
        }
    }
}