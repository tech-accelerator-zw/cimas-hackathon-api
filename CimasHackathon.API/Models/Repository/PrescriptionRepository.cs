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

        public async Task<Result<bool>> AddPrescriptionAsync(PrescriptionRequest request)
        {
            request.MedicationIds!.ForEach(async medicationId =>
            {
                await _dbSet.AddAsync(new Prescription
                {
                    PatientId = request.PatientId,
                    MedicationId = medicationId,
                    Description = request.Description,
                    Status = request.Status
                });
            });
            
            return new Result<bool>(true);
        }

        public async Task<Result<IEnumerable<Prescription>>> GetByCimasNumberAsync(string cimasNumber)
        {
            var result = await _dbSet
                .Include(p => p.Patient)
                .Include(p => p.Medication)
                .Where(p => p.Patient!.Account!.CimasNumber == cimasNumber)
                .ToListAsync();

            return new Result<IEnumerable<Prescription>>(result);
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