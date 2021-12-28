using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Context
{
    public class MedicalManageMentContext : DbContext
    {
        public MedicalManageMentContext(DbContextOptions<MedicalManageMentContext> options)
          : base(options)
        {
        }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Reception> Receptions { get; set; }
        public virtual DbSet<ReceptionExamination> ReceptionExaminations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NationalCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
                entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);
                entity.Property(e => e.MedicalSystemCode)
                .IsRequired()
                .HasMaxLength(4);
            });
            modelBuilder.Entity<Examination>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
                entity.Property(e => e.Price)
                .IsRequired()
                .HasMaxLength(100);
                entity.Property(e => e.ExamineCode)
                .IsRequired()
                .HasMaxLength(2);
            });
        }
    }
}
