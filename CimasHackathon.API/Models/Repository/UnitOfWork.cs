using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Repository.IRepository;

namespace CimasHackathon.API.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IPatientRepository Patient { get; private set; }
        
        public UnitOfWork(AppDbContext context)
        {
            Patient = new PatientRepository(context);
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}