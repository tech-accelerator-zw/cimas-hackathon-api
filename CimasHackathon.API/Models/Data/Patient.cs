namespace CimasHackathon.API.Models.Data
{
    public class Patient
    {
        public int Id { get; set; }
        public string? AccountId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public DateTime DOB { get; set; }
        public string? Gender { get; set; }
        public Account? Account { get; set; }
    }
}