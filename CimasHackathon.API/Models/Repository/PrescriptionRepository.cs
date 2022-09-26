using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;
using CimasHackathon.API.Models.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CimasHackathon.API.Models.Repository
{
    public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<IEnumerable<Prescription>>> GetByPatientIdAsync(int patientId)
        {
            var prescriptions = await _dbSet
                .Where(x => x.PatientId == patientId)
                .Include(x => x.Patient)
                .Include(x => x.Medication)
                .ToListAsync();

            return new Result<IEnumerable<Prescription>>(prescriptions);
        }
    }
}