namespace CimasHackathon.API.Models.Data
{
    public class Medication
    {
        public int Id { get; set; }
        public int DiseaseId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Disease? Disease { get; set; }
    }
}