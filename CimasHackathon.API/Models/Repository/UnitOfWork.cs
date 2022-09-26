using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Repository.IRepository;

namespace CimasHackathon.API.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IPatientRepository Patient { get; private set; }
        public IMedicationRepository Medication { get; private set; }
        public IDiseaseRepository Disease { get; private set; }
        public IDoctorRepository Doctor { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            Patient = new PatientRepository(context);
            Medication = new MedicationRepository(context);
            Disease = new DiseaseRepository(context);
            Doctor = new DoctorRepository(context);
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}