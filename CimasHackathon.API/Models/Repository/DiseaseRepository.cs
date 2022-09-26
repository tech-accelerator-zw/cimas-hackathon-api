using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;
using CimasHackathon.API.Models.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CimasHackathon.API.Models.Repository
{
    public class DiseaseRepository : Repository<Disease>, IDiseaseRepository
    {
        public DiseaseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<IEnumerable<Disease>>> GetByMedicationIdAsync(int medicationId)
        {
            var diseases = await _dbSet
                .Where(x => x.MedicationId == medicationId)
                .Include(x => x.Medication)
                .ToListAsync();

            return new Result<IEnumerable<Disease>>(diseases);
        }
    }
}