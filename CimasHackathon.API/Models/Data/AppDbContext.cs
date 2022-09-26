using Microsoft.EntityFrameworkCore;

namespace CimasHackathon.API.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<GeneratedCode>? GeneratedCodes { get; set; }
        public DbSet<Patient>? Patients { get; set; }
        public DbSet<Medication>? Medications { get; set; }
        public DbSet<Disease>? Diseases { get; set; }
        public DbSet<Doctor>? Doctors { get; set; }
        public DbSet<Prescription>? Prescriptions { get; set; }
    }
}