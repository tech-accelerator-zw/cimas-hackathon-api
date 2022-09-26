namespace CimasHackathon.API.Models.Data
{
    public class Disease
    {
        public int Id { get; set; }
        public int MedicationId { get; set; }
        public string? Name { get; set; }
        public Medication? Medication { get; set; }
    }
}