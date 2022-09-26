namespace CimasHackathon.API.Models.Local
{
    public class PatientLoginRequest
    {
        public string? Otp { get; set; }
        public string? Email { get; set; }
    }
}