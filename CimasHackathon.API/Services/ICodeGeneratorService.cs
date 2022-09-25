namespace CimasHackathon.API.Services
{
    public interface ICodeGeneratorService
    {
        Task<string> GenerateVerificationCode();
    }
}