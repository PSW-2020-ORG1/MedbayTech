using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Backend.Examinations.Model;
using Backend.Records.Model;
using Backend.Medications;
using Model.Schedule;
using Model.Users;
using Backend.Utils;
using Model.Rooms;
using Backend.Medications.Model;
using Backend.Users.Model.Enums;
using Backend.Records.Model.Enums;
using Newtonsoft.Json;
using PharmacyIntegration.Model;
using Backend.Reports.Model;
using Backend.Examinations.Model.Enums;
using Backend.Users.Model;
namespace Model
{
    public class MedbayTechDbContext : DbContext
    {
        public DbSet<MedicationUsage> MedicationUsages { get; set; }
        public DbSet<MedicationUsageReport> MedicationUsageReports { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<PharmacyNotification> PharmacyNotifications { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<QuestionReply> QuestionReplies { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<PostContent> PostContents { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<DoctorReview> DoctorReviews { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Renovation> Renovations { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<HospitalEquipment> HospitalEquipments { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Vaccines> Vaccines { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
        public DbSet<Symptoms> Symptoms { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<FamilyIllnessHistory> FamilyIllnessHistories { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<ValidationMed> ValidationMeds { get; set; }
        public DbSet<SideEffect> SideEffects { get; set; }
        public DbSet<MedicationIngredient> MedicationIngredients { get; set; }
        public DbSet<MedicationCategory> MedicationCategories { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Allergens> Allergens { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<HospitalTreatment> HospitalTreatments { get; set; }
        public DbSet<ExaminationSurgery> ExaminationSurgeries { get; set; }
        public DbSet<EmergencyRequest> EmergencyRequests { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<DoctorWorkDay> DoctorWorkDays { get; set; }


        public MedbayTechDbContext(DbContextOptions<MedbayTechDbContext> options) : base(options)
        {
        }
        public MedbayTechDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseIdentityColumns();

            modelBuilder.Entity<Period>().HasNoKey();
            modelBuilder.Entity<Occupation>().HasNoKey();
            modelBuilder.Entity<Shift>().HasNoKey();


            modelBuilder.Entity<Survey>()
                .Property(b => b.SurveyQuestions)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<int>>(v)
            );
            modelBuilder.Entity<Survey>()
                .Property(b => b.SurveyAnswers)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<Grade>>(v));

        }
    }
}
