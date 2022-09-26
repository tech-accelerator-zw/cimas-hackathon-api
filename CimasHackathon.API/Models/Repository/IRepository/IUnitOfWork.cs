namespace CimasHackathon.API.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAccountRepository Account { get; }
        void SaveChanges();
    }
}