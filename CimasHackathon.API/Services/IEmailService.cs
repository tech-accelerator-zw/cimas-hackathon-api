using CimasHackathon.API.Models.Data;
using CimasHackathon.API.Models.Local;

namespace CimasHackathon.API.Services
{
    public interface IEmailService
    {
        Task<Result<string>> SendEmailAsync(EmailRequest email);
    }
}