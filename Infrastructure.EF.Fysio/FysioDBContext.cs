using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;

namespace Infrastructure.EF.Fysio
{
    public class FysioDBContext : DbContext
    {
        public FysioDBContext(DbContextOptions<FysioDBContext> options)
            :base (options) { }

        public DbSet<Comment> comments { get; set; }
        public DbSet<Practitioner> practitioners { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<PatientFile> patientFiles { get; set; }
        public DbSet<TreatmentPlan> treatmentPlans { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<AppUser> users { get; set; }

        protected override void OnModelCreating(ModelBuilder model) {

            // Uniques
            model.Entity<Comment>().HasIndex(c => c.commentId).IsUnique();
            model.Entity<Practitioner>().HasIndex(p => p.practitionerId).IsUnique();
            model.Entity<Patient>().HasIndex(p => p.patientId).IsUnique();
            model.Entity<PatientFile>().HasIndex(p => p.fileId).IsUnique();
            model.Entity<TreatmentPlan>().HasIndex(t => t.treatmentPlanId).IsUnique();
            model.Entity<Diagnosis>().HasIndex(d => d.diagnosisId).IsUnique();
            model.Entity<Treatment>().HasIndex(t => t.treatmentId).IsUnique();
            model.Entity<Appointment>().HasIndex(a => a.appointmentId).IsUnique();
            //model.Entity<AppUser>().HasIndex(a => a.appUserId).IsUnique();

            // Keys
            model.Entity<Comment>().HasKey(c => c.commentId);
            model.Entity<Practitioner>().HasKey(p => p.practitionerId);
            model.Entity<Patient>().HasKey(p => p.patientId);
            model.Entity<PatientFile>().HasKey(f => f.fileId);
            model.Entity<TreatmentPlan>().HasKey(t => t.treatmentPlanId);
            model.Entity<Diagnosis>().HasKey(d => d.diagnosisId);
            model.Entity<Treatment>().HasKey(t => t.treatmentId);
            model.Entity<Appointment>().HasKey(a => a.appointmentId);
            //model.Entity<AppUser>().HasKey(a => a.appUserId);


            // Comments
            model.Entity<Comment>().HasOne<Practitioner>(c => c.practitioner);

            // Patients
            model.Entity<Patient>().HasOne(p => p.patientFile)
                .WithOne(f => f.patient)
                .HasForeignKey<Patient>(p=>p.patientFileId);

            //// Patient Files
            //model.Entity<PatientFile>()
            //    .HasOne<TreatmentPlan>(p => p.treatmentPlan)
            //    .WithOne(t => t.patientFile)
            //    .HasForeignKey<TreatmentPlan>(t => t.patientFileId);

            model.Entity<PatientFile>()
                .HasMany<Comment>(p => p.comments)
                .WithOne(c => c.patientFile);

            // Appointments
            model.Entity<Appointment>().HasOne<Practitioner>(a => a.practitioner);
            model.Entity<Appointment>()
                .HasOne<Patient>(a => a.patient)
                .WithMany(patient => patient.appointments);
        }
    }
}
