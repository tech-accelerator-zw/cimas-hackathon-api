namespace CimasHackathon.API.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}