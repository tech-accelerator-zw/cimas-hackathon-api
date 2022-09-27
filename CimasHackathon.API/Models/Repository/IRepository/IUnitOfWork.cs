namespace CimasHackathon.API.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPatientRepository Patient { get; }
        IMedicationRepository Medication { get; }
        IDiseaseRepository Disease { get; }
        IDoctorRepository Doctor { get; }
        IPrescriptionRepository Prescription { get; }
        IPharmacyRepository Pharmacy { get; }
        void SaveChanges();
    }
}