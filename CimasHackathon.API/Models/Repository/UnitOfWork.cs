using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Repository.IRepository;

namespace CimasHackathon.API.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        //public IRoleRepository Role { get; private set; }
        //public IServiceProviderRepository ServiceProvider { get; private set; }
        //public ICategoryRepository Category { get; private set; }

        //public ILocationRepository Location { get; private set; }
        //public IQuotationRepository Quotation { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            //Role = new RoleRepository(context);
            //ServiceProvider = new ServiceProviderRepository(context);
            //Category = new CategoryRepository(context);
            //Location = new LocationRepository(context);
            //Quotation = new QuotationRepository(context);
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}