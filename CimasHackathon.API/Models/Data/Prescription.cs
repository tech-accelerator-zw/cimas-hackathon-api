using CimasHackathon.API.Enums;

namespace CimasHackathon.API.Models.Data
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedicationId { get; set; }
        public string? Description { get; set; }
        public PrescriptionStatus Status { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public Medication? Medication { get; set; }
        public Patient? Patient { get; set; }
    }
}