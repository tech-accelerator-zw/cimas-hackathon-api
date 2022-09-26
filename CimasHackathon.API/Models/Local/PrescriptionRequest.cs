using CimasHackathon.API.Enums;

namespace CimasHackathon.API.Models.Local
{
    public class PrescriptionRequest
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public List<int>? MedicationIds { get; set; }
        public string? Description { get; set; }
        public PrescriptionStatus Status { get; set; }
    }
}