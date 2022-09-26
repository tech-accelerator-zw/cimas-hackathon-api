using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Repository.IRepository;

namespace CimasHackathon.API.Models.Repository
{
    public class MedicationRepository : Repository<Medication>, IMedicationRepository
    {
        public MedicationRepository(AppDbContext context) : base(context)
        {
        }
    }
}