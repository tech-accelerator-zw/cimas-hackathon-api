using CimasHackathon.API.Models.Data;

namespace CimasHackathon.API.Services
{
    public interface IJwtService
    {
        Task<string> GenerateToken(Account account);
    }
}