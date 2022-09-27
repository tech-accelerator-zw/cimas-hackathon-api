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

        public async new Task<Result<IEnumerable<Medication>>> GetAllAsync()
        {
            var result = await _dbSet
                .Include(m => m.Disease)
                .ToListAsync();
            
            return new Result<IEnumerable<Medication>>(result);
        }

        public async Task<Result<IEnumerable<Medication>>> GetByDiseaseIdAsync(int diseaseId)
        {
            var medications = await _dbSet
                .Where(x => x.DiseaseId == diseaseId)
                .Include(x => x.Disease)
                .ToListAsync();

            return new Result<IEnumerable<Medication>>(medications);
        }

        public async Task<Result<IEnumerable<Medication>>> SearchByNameAsync(string name)
        {
            var medications = await _dbSet
                .Where(x => x.Name!.Contains(name))
                .Include(x => x.Disease)
                .ToListAsync();

            return new Result<IEnumerable<Medication>>(medications);
        }
    }
}