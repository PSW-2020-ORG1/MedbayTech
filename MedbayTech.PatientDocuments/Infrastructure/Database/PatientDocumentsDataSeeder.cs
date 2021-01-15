using Backend.Examinations.Model.Enums;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations.Enums;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords.Enums;
using MedbayTech.PatientDocuments.Domain.Entities.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.PatientDocuments.Infrastructure.Database
{
    public class PatientDocumentsDataSeeder
    {
        public PatientDocumentsDataSeeder() { }

        public void SeedAllEntities(PatientDocumentsDbContext context)
        {
            //SeedAllergens(context);
            /*SeedVaccines(context);
            SeedSymptoms(context);
            SeedDiagnosis(context);
            SeedFamilyIllnessHistory(context);*/
            //SeedTherapies(context);
            SeedSymptoms(context);
            SeedDiagnosis(context);
            SeedMedicalRecords(context);
            SeedReports(context);
            SeedTreatments(context);
            SeedPrescriptions(context);
            context.SaveChanges();
        }

        private void SeedMedicalRecords(PatientDocumentsDbContext context)
        {
            var allergens = new List<Allergens>();
            allergens.Add(new Allergens("Prasina"));
            var therapies = new List<Therapy>();
            therapies.Add(new Therapy(12, "Brufen"));
            therapies.Add(new Therapy(8, "Bromazepam"));

            context.Add(new MedicalRecord
            {
                CurrHealthState = PatientCondition.HospitalTreatment,
                BloodType = BloodType.ANeg,
                Allergens = allergens,
                Vaccines = new List<Vaccines>(),
                IllnessHistory = new List<Diagnosis>(),
                FamilyIllnessHistory = new List<FamilyIllnessHistory>(),
                PatientId = "2406978890046",
                Therapies = therapies
            });
            context.SaveChanges();
            /*
            context.Add(new MedicalRecord
            {
                CurrHealthState = PatientCondition.HospitalTreatment,
                BloodType = BloodType.ANeg,
                Allergies = new List<Allergens>(),
                Vaccines = new List<Vaccines>(),
                IllnessHistory = new List<Diagnosis>(),
                FamilyIllnessHistory = new List<FamilyIllnessHistory>(),
                PatientId = "2406978890048",
                Therapies = new List<Therapy>()
            });
            context.Add(new MedicalRecord
            {
                CurrHealthState = PatientCondition.HospitalTreatment,
                BloodType = BloodType.ANeg,
                Allergies = new List<Allergens>(),
                Vaccines = new List<Vaccines>(),
                IllnessHistory = new List<Diagnosis>(),
                FamilyIllnessHistory = new List<FamilyIllnessHistory>(),
                PatientId = "2406978890049",
                Therapies = new List<Therapy>()
            });
            context.Add(new MedicalRecord
            {
                CurrHealthState = PatientCondition.HospitalTreatment,
                BloodType = BloodType.ANeg,
                Allergies = new List<Allergens>(),
                Vaccines = new List<Vaccines>(),
                IllnessHistory = new List<Diagnosis>(),
                FamilyIllnessHistory = new List<FamilyIllnessHistory>(),
                PatientId = "2406978890050",
                Therapies = new List<Therapy>()
            });
            context.SaveChanges();*/
        }

        private void SeedTherapies(PatientDocumentsDbContext context)
        {
            context.Add(new Therapy { HourConsumption = 6, MedicationName = "Brufen" });
            context.Add(new Therapy { HourConsumption = 10, MedicationName = "Bromazepam" });
            context.SaveChanges();
        }

        private void SeedFamilyIllnessHistory(PatientDocumentsDbContext context)
        {
            context.Add(new FamilyIllnessHistory { RelativeMember = Relative.Father, Diagnosis = new List<Diagnosis>() });
            context.Add(new FamilyIllnessHistory { RelativeMember = Relative.Grandparents, Diagnosis = new List<Diagnosis>() });
            context.SaveChanges();
        }

        private void SeedSymptoms(PatientDocumentsDbContext context)
        {
            context.Add(new Symptoms { Name = "Kasalj" });
            context.Add(new Symptoms { Name = "Temperatura" });
            context.SaveChanges();
        }

        private void SeedVaccines(PatientDocumentsDbContext context)
        {
            context.Add(new Vaccines { Name = "Grip" });
            context.Add(new Vaccines { Name = "Male boginje" });
            context.SaveChanges();
        }

        private void SeedAllergens(PatientDocumentsDbContext context)
        {
            context.Add(new Allergens { Allergen = "Polen" });
            context.Add(new Allergens { Allergen = "Prasina" });
            context.SaveChanges();
        }
        private void SeedDiagnosis(PatientDocumentsDbContext context)
        {
            context.Add(new Diagnosis { Name = "Dijagnoza1", Symptoms = new List<Symptoms>() });
            context.Add(new Diagnosis { Name = "Dijagnoza2", Symptoms = new List<Symptoms>() });
            context.SaveChanges();
        }
    
        private void SeedPrescriptions(PatientDocumentsDbContext context)
        {
            context.Add(new Prescription
            {
                ReportId = 1,
                Date = new DateTime(2020, 12, 8),
                Reserved = true,
                StartDate = new DateTime(2020, 11, 27),
                EndDate = new DateTime(2020, 11, 30),
                HourlyIntake = 8,
                MedicationId = 25,
                Medication = "Brufen"
            });
            context.Add(new Prescription
            {
                ReportId = 1,
                Date = new DateTime(2020, 12, 5),
                Reserved = true,
                StartDate = new DateTime(2020, 11, 28),
                EndDate = new DateTime(2020, 12, 1),
                HourlyIntake = 6,
                MedicationId = 1,
                Medication = "Brufen"
            });
            context.Add(new Prescription
            {
                ReportId = 1,
                Date = new DateTime(2020, 12, 12),
                Reserved = true,
                StartDate = new DateTime(2020, 11, 27),
                EndDate = new DateTime(2020, 11, 30),
                HourlyIntake = 12,
                MedicationId = 10,
                Medication = "Bromazepam"
            });
            context.Add(new Prescription
            {
                ReportId = 1,
                Date = new DateTime(2020, 12, 10),
                Reserved = true,
                StartDate = new DateTime(2020, 11, 28),
                EndDate = new DateTime(2020, 12, 1),
                HourlyIntake = 6,
                MedicationId = 2,
                Medication = "Xanax"
            });
            context.Add(new Prescription
            {
                ReportId = 1,
                Date = new DateTime(2020, 12, 15),
                Reserved = true,
                StartDate = new DateTime(2020, 11, 27),
                EndDate = new DateTime(2020, 11, 30),
                HourlyIntake = 12,
                MedicationId = 20,
                Medication = "Bensedin"
            });
            context.Add(new Prescription
            {
                ReportId = 1,
                Date = new DateTime(2020, 12, 7),
                Reserved = true,
                StartDate = new DateTime(2020, 11, 28),
                EndDate = new DateTime(2020, 12, 1),
                HourlyIntake = 4,
                MedicationId = 1,
                Medication = "Brufen"
            });
            context.SaveChanges();
        }
        private void SeedReports(PatientDocumentsDbContext context)
            {
                context.Add(new Report
                {
                    StartTime = new DateTime(2020, 12, 5),
                    Type = TypeOfAppointment.Examination,
                    Treatments = new List<Treatment>(),
                    Diagnoses = new List<Diagnosis>(),
                    DoctorId = "2406978890047",
                    MedicalRecordId = 1
                });
                context.Add(new Report
                {
                    StartTime = new DateTime(2020, 12, 3),
                    Type = TypeOfAppointment.Surgery,
                    Treatments = new List<Treatment>(),
                    Diagnoses = new List<Diagnosis>(),
                    DoctorId = "2407978890045",
                    MedicalRecordId = 1
                });
                context.Add(new Report
                {
                    StartTime = new DateTime(2020, 12, 7),
                    Type = TypeOfAppointment.Examination,
                    Treatments = new List<Treatment>(),
                    Diagnoses = new List<Diagnosis>(),
                    DoctorId = "2407978890045",
                    MedicalRecordId = 1
                });
                context.Add(new Report
                {
                    StartTime = new DateTime(2020, 12, 9),
                    Type = TypeOfAppointment.Surgery,
                    Treatments = new List<Treatment>(),
                    Diagnoses = new List<Diagnosis>(),
                    DoctorId = "2406978890047",
                    MedicalRecordId = 1
                });
                context.Add(new Report
                {
                    StartTime = new DateTime(2020, 12, 13),
                    Type = TypeOfAppointment.Examination,
                    Treatments = new List<Treatment>(),
                    Diagnoses = new List<Diagnosis>(),
                    DoctorId = "2406978890047",
                    MedicalRecordId = 1
                });
                context.Add(new Report
                {
                    StartTime = new DateTime(2020, 12, 16),
                    Type = TypeOfAppointment.Surgery,
                    Treatments = new List<Treatment>(),
                    Diagnoses = new List<Diagnosis>(),
                    DoctorId = "2406978890047",
                    MedicalRecordId = 1
                });

                context.SaveChanges();
            }
            private void SeedTreatments(PatientDocumentsDbContext context)
            {
                context.Add(new Treatment
                {
                    Date = new DateTime(2020, 11, 27),
                    AdditionalNotes = ".",
                    Type = TreatmentType.Prescription,
                    ReportId = 1
                });
                context.Add(new Treatment
                {
                    Date = new DateTime(2020, 11, 29),
                    AdditionalNotes = ".",
                    Type = TreatmentType.Prescription,
                    ReportId = 1
                });

                context.SaveChanges();
            }

            public bool IsAlreadyFull(PatientDocumentsDbContext context)
            {
                return context.MedicalRecords.Count() > 0;
            }

    }
}
