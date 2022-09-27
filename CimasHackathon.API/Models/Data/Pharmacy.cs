using System.ComponentModel.DataAnnotations.Schema;

namespace CimasHackathon.API.Models.Data
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        [NotMapped]
        public string? Token { get; set; }
    }
}