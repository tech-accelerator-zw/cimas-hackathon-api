using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Repository.IRepository;

namespace CimasHackathon.API.Models.Repository
{
    public class PharmacyRepository : Repository<Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(AppDbContext context) : base(context)
        {
        }
    }
}