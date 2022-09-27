using System.ComponentModel.DataAnnotations.Schema;

namespace CimasHackathon.API.Models.Data
{
    public class Admin
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        [NotMapped]
        public string? Token { get; set; }
    }
}