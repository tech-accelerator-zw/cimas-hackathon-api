namespace CimasHackathon.API.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPatientRepository Patient { get; }
        IMedicationRepository Medication { get; }
        void SaveChanges();
    }
}