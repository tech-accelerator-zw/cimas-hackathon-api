namespace CimasHackathon.API.Models.Local
{
    public class MedicationRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int DiseaseId { get; set; }
    }
}