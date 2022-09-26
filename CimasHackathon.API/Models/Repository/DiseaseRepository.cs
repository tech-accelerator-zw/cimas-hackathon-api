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
    }
}