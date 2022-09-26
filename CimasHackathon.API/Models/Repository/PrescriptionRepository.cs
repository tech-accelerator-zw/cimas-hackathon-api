using CimasHackathon.API.Enums;
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
                     DoctorId = request.DoctorId,
                     Description = request.Description,
                     Status = request.Status
                 });
             });

            return await Task.FromResult(new Result<bool>(true));
        }

        public async Task<Result<IEnumerable<Prescription>>> GetByCimasNumberAsync(string cimasNumber)
        {
            var result = await _dbSet
                .Include(p => p.Patient)
                .Include(p => p.Medication)
                .Include(p => p.IssuedBy)
                .Where(p => p.Patient!.Account!.CimasNumber == cimasNumber)
                .ToListAsync();

            return new Result<IEnumerable<Prescription>>(result);
        }

        public async Task<Result<IEnumerable<Prescription>>> GetByDoctorIdAsync(int doctorId)
        {
            var result = await _dbSet
                .Include(p => p.Patient)
                .Include(p => p.Medication)
                .Include(p => p.IssuedBy)
                .Where(p => p.DoctorId == doctorId)
                .ToListAsync();

            return new Result<IEnumerable<Prescription>>(result);
        }

        public async Task<Result<IEnumerable<Prescription>>> GetByPatientIdAsync(int patientId)
        {
            var prescriptions = await _dbSet
                .Where(x => x.PatientId == patientId)
                .Include(x => x.Patient)
                .Include(x => x.Medication)
                .Include(x => x.IssuedBy)
                .ToListAsync();

            return new Result<IEnumerable<Prescription>>(prescriptions);
        }

        public async Task<Result<IEnumerable<Prescription>>> GetByStatusAsync(PrescriptionStatus status)
        {
            var result = await _dbSet
                .Include(p => p.Patient)
                .Include(p => p.Medication)
                .Include(p => p.IssuedBy)
                .Where(p => p.Status == status)
                .ToListAsync();

            return new Result<IEnumerable<Prescription>>(result);
        }
    }
}