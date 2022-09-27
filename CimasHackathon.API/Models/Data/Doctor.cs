using System.ComponentModel.DataAnnotations.Schema;

namespace CimasHackathon.API.Models.Data
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
        [NotMapped]
        public string? Token { get; set; }
    }
}