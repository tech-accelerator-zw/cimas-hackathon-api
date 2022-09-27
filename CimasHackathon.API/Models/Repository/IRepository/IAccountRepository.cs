using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;

namespace CimasHackathon.API.Models.Repository.IRepository
{
    public interface IAccountRepository
    {
        Task<Result<Account>> AddAsync(Account account);
        Task<Result<Account>> GetByIdAsync(int id);
        Task<Result<IEnumerable<Account>>> GetAllAsync();
        Task<Result<Account>> UpdateAsync(Account account);
        Task<Result<bool>> DeleteAsync(Account account);
        Task<Result<Patient>> PatientLoginAsync(PatientLoginRequest login);
        Task<Result<Doctor>> DoctorLoginAsync(DoctorLoginRequest login);
        Task<Result<Pharmacy>> PharmacyLoginAsync(PharmacyLoginRequest login);
        Task<Result<Admin>> AdminLoginAsync(AdminLoginRequest login);
        Task<Result<string>> PatientOtpAsync(string phoneNumber);
        //Task<Result<Account>> ChangePasswordAsync(ChangePasswordRequest changePassword);
        //Task<Result<string>> GetResetPasswordCodeAsync(string email);
        //Task<Result<Account>> ResetPasswordAsync(ResetPasswordRequest resetPassword);
        //Task<Result<Account>> ConfirmAccountAsync(ConfirmAccountRequest confirmAccount);
        //Task<Result<string>> ResendOtpAsync(string email);
    }
}