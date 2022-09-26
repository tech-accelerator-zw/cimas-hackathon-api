using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Repository.IRepository;

namespace CimasHackathon.API.Models.Repository
{
    public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(AppDbContext context) : base(context)
        {
        }
    }
}