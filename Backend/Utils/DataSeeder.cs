using Backend.Examinations.Model;
using Backend.Examinations.Model.Enums;
using Backend.Medications.Model;
using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Backend.Reports.Model;
using Backend.Users.Model;
using Backend.Users.Model.Enums;
using Model;
using Model.Rooms;
using Model.Schedule;
using Model.Users;
using PharmacyIntegration.Model;
using System;
using System.Collections.Generic;

namespace Backend.Utils
{
    public class DataSeeder
    {
        public DataSeeder() { }

        public void SeedAllEntities(MedbayTechDbContext context)
        {
            SeedStates(context);
            SeedCities(context);
            SeedAddresses(context);
            SeedInsurancePolicy(context);

            SeedHospitals(context);
            SeedEquipmentType(context);
            SeedDepartments(context);
            SeedRooms(context);
            SeedHospitalEquipment(context);
            SeedSpecializations(context);

            SeedRegisteredUsers(context);
            SeedDoctors(context);
            SeedPatients(context);

            SeedFeedbacks(context);


            SeedPharmacies(context);
            SeedMedicationCategory(context);
            SeedMedicalRecords(context);

            SeedSurveyQuestion(context);
            SeedAppointemnts(context);

            SeedMedication(context);
            SeedExaminationSurgery(context);

            SeedMedicationIngredient(context);
            SeedDosageOfIngredient(context);
            SeedTherapies(context);
            SeedVaccines(context);
            SeedDiagnosis(context);
            SeedSymptoms(context);
            SeedSideEffect(context);
            SeedFamilyIllnessHistory(context);
            SeedMedicationUsage(context);
            SeedAllergens(context);
            SeedDoctorsWorkDay(context);
            SeedPrescriptions(context);
            SeedTreatments(context);
            SeedPrescriptions(context);

            context.SaveChanges();
        }

        private void SeedFeedbacks(MedbayTechDbContext context)
        {
            context.Add(new Feedback
            {
                AdditionalNotes = "Sve je super!",
                Approved = true,
                Date = new DateTime(),
                RegisteredUserId = "2406978890045",
                Anonymous = false,
                AllowedForPublishing = true
            }) ;
            context.Add(new Feedback
            {
                AdditionalNotes = "Bolnica je veoma losa, bas sam razocaran! Rupe u zidovima, voda curi na sve strane, treba vas zatvoriti!!!",
                Approved = false,
                Date = new DateTime(),
                RegisteredUserId = "2406978890045",
                Anonymous = false,
                AllowedForPublishing = true
            }) ;

            context.Add(new Feedback
            {
                AdditionalNotes = "Predivno, ali i ruzno! Sramite se! Cestitke... <3",
                Approved = false,
                Date = new DateTime(),
                RegisteredUserId = "2406978890045",
                Anonymous = false,
                AllowedForPublishing = false
            });
            context.Add(new Feedback
            {
                AdditionalNotes = "Odlicno!",
                Approved = false,
                Date = new DateTime(),
                RegisteredUserId = "2406978890045",
                Anonymous = false,
                AllowedForPublishing = false
            });
        }

        private void SeedStates(MedbayTechDbContext context)
        {
            context.Add(new State { Name = "Serbia" });
            context.SaveChanges();

        }

        private void SeedCities(MedbayTechDbContext context)
        {
            context.Add(new City { Id = 21000, Name = "Novi Sad", StateId = 1 });
            context.Add(new City { Id = 11000, Name = "Beograd", StateId = 1 });
            context.SaveChanges();
        }

        private void SeedAddresses(MedbayTechDbContext context)
        {
            context.Add(new Address { Street = "Radnicka", Number = 4, CityId = 21000 });
            context.Add(new Address { Street = "Gospodara Vucica", Number = 5, CityId = 11000 });
            context.Add(new Address { Street = "Stefana Nemanje", Number = 28, CityId = 11000 });
            context.Add(new Address { Street = "Stefana Nemanje", Number = 27, CityId = 11000 });
            context.SaveChanges();
        }

        private void SeedPharmacies(MedbayTechDbContext context)
        {
            context.Add(new Pharmacy { Id = "Jankovic", APIKey = "ID1APIKEYAAAA", APIEndpoint = "jankovic.rs", RecieveNotificationFrom = true });
            context.Add(new Pharmacy { Id = "Liman", APIKey = "ID2APIKEYAAAA", APIEndpoint = "liman.li", RecieveNotificationFrom = true });
            context.SaveChanges();
        }

        private void SeedPharmacyNotification(MedbayTechDbContext context)
        {
            context.Add(new PharmacyNotification { Content = "Lexapro on sale! Get 15% off!", Approved = true, PharmacyId = "Jankovic" });
            context.Add(new PharmacyNotification { Content = "Aspirin on sale! Get 11% off!", Approved = true, PharmacyId = "Liman" });
            context.SaveChanges();
        }

        private void SeedMedicationCategory(MedbayTechDbContext context)
        {
            context.Add(new MedicationCategory { CategoryName = "Drug", SpecializationId = 1 });
            context.Add(new MedicationCategory { CategoryName = "Kategorija1", SpecializationId = 1 });
            context.SaveChanges();
        }

        private void SeedInsurancePolicy(MedbayTechDbContext context)
        {
            context.Add(new InsurancePolicy
            {
                Company = "Dunav osiguranje d.o.o",
                Id = "policy1",
                StartTime = new DateTime(2020, 11, 1),
                EndTime = new DateTime(2020, 11, 1)
            });
            context.Add(new InsurancePolicy
            {
                Company = "Delta generali",
                Id = "policy2",
                StartTime = new DateTime(2020, 11, 1),
                EndTime = new DateTime(2021, 11, 1)
            });
            context.SaveChanges();
        }

        private void SeedRegisteredUsers(MedbayTechDbContext context)
        {
            context.Add(new RegisteredUser
            {
                Id = "2406978890045",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "marko@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy1",
                Name = "Marko",
                Surname = "Markovic",
                Username = "markic",
                Password = "marko1978",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "vodoinstalater",
                ProfileImage = "."

            });
            context.SaveChanges();
        }
        private void SeedSurveyQuestion(MedbayTechDbContext context)
        {

            context.Add(new SurveyQuestion { Question = "How would you rate the kindness of your doctor?", QuestionType = QuestionType.DOCTOR, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent has your doctor clearly stated what your examination will look like and instructed you on how to behave?", QuestionType = QuestionType.DOCTOR, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the clarity and expertise of the doctor in making the diagnosis?", QuestionType = QuestionType.DOCTOR, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the competence of your doctor during the treatment?", QuestionType = QuestionType.DOCTOR, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent has your doctor paid attention to you and contributed to your more comfortable stay in the hospital?", QuestionType = QuestionType.DOCTOR, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the helpfulness and kindness of the information counter employees?", QuestionType = QuestionType.MEDICAL_STUFF, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the helpfulness and kindness of nurses and technicians?", QuestionType = QuestionType.MEDICAL_STUFF, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent were nurses and technicians professional in treatment?", QuestionType = QuestionType.MEDICAL_STUFF, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent have nurses and technicians paid attention to you and your comfortable hospital stay?", QuestionType = QuestionType.MEDICAL_STUFF, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent have nurses and technicians instructed you in the procedures they will perform during your treatment?", QuestionType = QuestionType.MEDICAL_STUFF, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the cleanliness of hospital hallways and waiting rooms?", QuestionType = QuestionType.HOSPITAL, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the cleanliness of the toilet in the hospital?", QuestionType = QuestionType.HOSPITAL, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the cleanliness and comfort of the patient's room?", QuestionType = QuestionType.HOSPITAL, Status = true });
            context.Add(new SurveyQuestion { Question = "To what extent are you satisfied with the equipment of the hospital for the needs of your treatment?", QuestionType = QuestionType.HOSPITAL, Status = true });
            context.Add(new SurveyQuestion { Question = "How would you rate the organization of the hospital when scheduling an examination?", QuestionType = QuestionType.HOSPITAL, Status = true });

            context.SaveChanges();
        }

        private void SeedAppointemnts(MedbayTechDbContext context)
        {
            context.Add(new Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                PatientId = "2406978890046"
            });
            context.Add(new Appointment
            {
                Start = new DateTime(2020, 12, 4, 14, 00, 0),
                End = new DateTime(2020, 12, 4, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                PatientId = "2406978890046"
            });
            context.Add(new Appointment
            {
                Start = new DateTime(2020, 12, 3, 14, 00, 0),
                End = new DateTime(2020, 12, 3, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                PatientId = "2406978890046"
            });
            context.Add(new Appointment
            {
                Start = new DateTime(2020, 12, 1, 14, 00, 0),
                End = new DateTime(2020, 12, 1, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                PatientId = "2406978890046"
            });
            context.Add(new Appointment
            {
                Start = new DateTime(2020, 12, 15, 14, 00, 0),
                End = new DateTime(2020, 12, 15, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = false,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                PatientId = "2406978890046"
            });
            context.Add(new Appointment
            {
                Start = new DateTime(2020, 12, 8, 14, 00, 0),
                End = new DateTime(2020, 12, 8, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = false,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                PatientId = "2406978890046"
            });
            context.Add(new Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 6, 5),
                PatientId = "2406978890046"
            });
            context.Add(new Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 6, 6),
                PatientId = "2406978890046"
            });
            context.Add(new Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 6, 6),
                PatientId = "2406978890046"
            });
            context.Add(new Appointment
            {
                Start = new DateTime(2020, 12, 5, 14, 00, 0),
                End = new DateTime(2020, 12, 5, 14, 30, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 7, 1),
                PatientId = "2406978890046"
            });
            context.Add(new Appointment
            {
                Start = new DateTime(2020, 12, 14, 13, 30, 0),
                End = new DateTime(2020, 12, 14, 14, 0, 0),
                TypeOfAppointment = TypeOfAppointment.Examination,
                ShortDescription = "standard appointment",
                Urgent = true,
                Deleted = false,
                Finished = true,
                RoomId = 1,
                MedicalRecordId = 1,
                DoctorId = "2406978890047",
                WeeklyAppointmentReportId = 1,
                CanceledByPatient = true,
                CancelationDate = new DateTime(2020, 7, 1),
                PatientId = "2406978890046"
            });
            context.SaveChanges();

        }
        private void SeedDoctors(MedbayTechDbContext context)
        {
            context.Add(new Doctor
            {
                Id = "2406978890047",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "mika@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy1",
                Name = "Milan",
                Surname = "Milanovic",
                Username = "mika",
                Password = "mika1978",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "vodoinstalater",
                ProfileImage = ".",
                LicenseNumber = "001",
                OnCall = true,
                PatientReview = 4.5,
                DepartmentId = 1,
                ExaminationRoomId = 49,
                OperationRoomId = 116,
                SpecializationId = 1
            });

            context.Add(new Doctor
            {
                Id = "2407978890045",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "ivan@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy2",
                Name = "Ivan",
                Surname = "Ivanovic",
                Username = "ivan",
                Password = "ivan123",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "doctor",
                ProfileImage = ".",
                LicenseNumber = "001",
                OnCall = true,
                PatientReview = 4.5,
                DepartmentId = 1,
                ExaminationRoomId = 8,
                OperationRoomId = 64,
                SpecializationId = 1
            });
            context.Add(new Doctor
            {
                Id = "2407978890043",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "ivan@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy2",
                Name = "Mirjana",
                Surname = "Lakic",
                Username = "mima",
                Password = "mima123",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "doctor",
                ProfileImage = ".",
                LicenseNumber = "001",
                OnCall = true,
                PatientReview = 4.5,
                DepartmentId = 1,
                ExaminationRoomId = 122,
                OperationRoomId = 15,
                SpecializationId = 2
            });
            context.Add(new Doctor
            {
                Id = "2407978890041",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "ivan@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy2",
                Name = "Petar",
                Surname = "Petrovic",
                Username = "mima",
                Password = "mima123",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "doctor",
                ProfileImage = ".",
                LicenseNumber = "001",
                OnCall = true,
                PatientReview = 4.5,
                DepartmentId = 1,
                ExaminationRoomId = 4,
                OperationRoomId = 18,
                SpecializationId = 1
            });
            context.SaveChanges();

        }
        private void SeedMedicalRecords(MedbayTechDbContext context)
        {
            context.Add(new MedicalRecord
            {
                CurrHealthState = PatientCondition.HospitalTreatment,
                BloodType = BloodType.ANeg,
                Allergies = new List<Allergens>(),
                Vaccines = new List<Vaccines>(),
                IllnessHistory = new List<Diagnosis>(),
                FamilyIllnessHistory = new List<FamilyIllnessHistory>(),
                PatientId = "2406978890046",
                Therapies = new List<Therapy>()
            });
            context.SaveChanges();
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
            context.SaveChanges();
        }

        private void SeedMedicationIngredient(MedbayTechDbContext context)
        {
            context.Add(new MedicationIngredient { Name = "Ibuprofen" });
            context.Add(new MedicationIngredient { Name = "Paracetamol" });
            context.SaveChanges();
        }

        private void SeedDosageOfIngredient(MedbayTechDbContext context)
        {
            context.Add(new DosageOfIngredient { Amount = 100.0, MedicationIngredientId = 1 });
            context.Add(new DosageOfIngredient { Amount = 120.0, MedicationIngredientId = 2 });
            context.SaveChanges();
        }

        private void SeedTherapies(MedbayTechDbContext context)
        {
            context.Add(new Therapy { HourConsumption = 6, MedicationId = 1, MedicalRecordId = 1 });
            context.Add(new Therapy { HourConsumption = 10, MedicationId = 2, MedicalRecordId = 1 });
            context.SaveChanges();
        }

        private void SeedVaccines(MedbayTechDbContext context)
        {
            context.Add(new Vaccines { Name = "Grip", MedicalRecordId = 1 });
            context.Add(new Vaccines { Name = "Male boginje", MedicalRecordId = 1 });
            context.SaveChanges();
        }
        private void SeedSymptoms(MedbayTechDbContext context)
        {
            context.Add(new Symptoms { Name = "Kasalj", DiagnosisId = 1 });
            context.Add(new Symptoms { Name = "Temperatura", DiagnosisId = 1 });
            context.SaveChanges();
        }

        private void SeedDiagnosis(MedbayTechDbContext context)
        {
            context.Add(new Diagnosis { Name = "Dijagnoza1", Symptoms = new List<Symptoms>(), MedicalRecordId = 1, ExaminationSurgeryId = 1 });
            context.Add(new Diagnosis { Name = "Dijagnoza2", Symptoms = new List<Symptoms>(), MedicalRecordId = 1, ExaminationSurgeryId = 1 });
            context.SaveChanges();
        }

        private void SeedFamilyIllnessHistory(MedbayTechDbContext context)
        {
            context.Add(new FamilyIllnessHistory { RelativeMember = Relative.Father, Diagnosis = new List<Diagnosis>(), MedicalRecordId = 1 });
            context.Add(new FamilyIllnessHistory { RelativeMember = Relative.Grandparents, Diagnosis = new List<Diagnosis>(), MedicalRecordId = 1 });
            context.SaveChanges();
        }

        private void SeedSpecializations(MedbayTechDbContext context)
        {
            context.Add(new Specialization { SpecializationName = "Interna medicina" });
            context.Add(new Specialization { SpecializationName = "Hirurgija" });
            context.SaveChanges();
        }

        private void SeedSideEffect(MedbayTechDbContext context)
        {
            context.Add(new SideEffect { Frequency = SideEffectFrequency.Rare, SideEffectsId = 1 });
            context.Add(new SideEffect { Frequency = SideEffectFrequency.Common, SideEffectsId = 1 });
            context.SaveChanges();

        }

        private void SeedMedication(MedbayTechDbContext context)
        {
            context.Add(new Medication { Med = "Brufen", Dosage = "400mg", RoomId = 87, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Xanax", Dosage = "20mg", RoomId = 87, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Panadon", Dosage = "500mg", RoomId = 87, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Diazepam", Dosage = "30mg", RoomId = 87, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Andol", Dosage = "200mg", RoomId = 87, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Reglan", Dosage = "100mg", RoomId = 87, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Caffetin", Dosage = "400mg", RoomId = 87, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Plavix", Dosage = "50mg", RoomId = 87, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Ambien", Dosage = "25mg", RoomId = 87, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Ranisan", Dosage = "200mg", RoomId = 87, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 88, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Adderall", Dosage = "40mg", RoomId = 88, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 88, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 88, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Demerol", Dosage = "30mg", RoomId = 88, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "OxyCotin", Dosage = "40mg", RoomId = 88, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Percocet", Dosage = "60mg", RoomId = 88, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Ritalin", Dosage = "80mg", RoomId = 88, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Eritromicin", Dosage = "100mg", RoomId = 88, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Penicillin", Dosage = "200mg", RoomId = 88, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });

            context.Add(new Medication { Med = "Amoksicilin", Dosage = "150mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Cefaleksin", Dosage = "200mg", RoomId = 101, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Zoloft", Dosage = "500mg", RoomId = 101, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Lexilium", Dosage = "40mg", RoomId = 101, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Bensedin", Dosage = "50mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Benedril", Dosage = "50mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Letrox", Dosage = "100mg", RoomId = 101, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Claritin", Dosage = "25mg", RoomId = 101, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Flobian", Dosage = "500mg", RoomId = 101, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Lasix", Dosage = "75mg", RoomId = 101, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Brufen", Dosage = "200mg", RoomId = 100, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Xanax", Dosage = "40mg", RoomId = 100, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Panadon", Dosage = "200mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Diazepam", Dosage = "60mg", RoomId = 100, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Andol", Dosage = "400mg", RoomId = 100, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Adderall", Dosage = "80mg", RoomId = 100, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 100, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Demerol", Dosage = "30mg", RoomId = 100, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });

            context.Add(new Medication { Med = "Brufen", Dosage = "400mg", RoomId = 10, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Xanax", Dosage = "20mg", RoomId = 10, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Panadon", Dosage = "500mg", RoomId = 10, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Diazepam", Dosage = "30mg", RoomId = 10, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Andol", Dosage = "200mg", RoomId = 10, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Reglan", Dosage = "100mg", RoomId = 10, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Caffetin", Dosage = "400mg", RoomId = 10, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Plavix", Dosage = "50mg", RoomId = 10, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Ambien", Dosage = "25mg", RoomId = 10, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Ranisan", Dosage = "200mg", RoomId = 10, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 9, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Adderall", Dosage = "40mg", RoomId = 9, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 9, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 9, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Demerol", Dosage = "30mg", RoomId = 9, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "OxyCotin", Dosage = "40mg", RoomId = 9, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Percocet", Dosage = "60mg", RoomId = 9, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Ritalin", Dosage = "80mg", RoomId = 9, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Eritromicin", Dosage = "100mg", RoomId = 9, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Penicillin", Dosage = "200mg", RoomId = 9, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Amoksicilin", Dosage = "150mg", RoomId = 6, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Cefaleksin", Dosage = "200mg", RoomId = 6, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Zoloft", Dosage = "500mg", RoomId = 6, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Lexilium", Dosage = "40mg", RoomId = 6, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Bensedin", Dosage = "50mg", RoomId = 6, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Letrox", Dosage = "100mg", RoomId = 6, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Claritin", Dosage = "25mg", RoomId = 6, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Flobian", Dosage = "500mg", RoomId = 6, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Lasix", Dosage = "75mg", RoomId = 6, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Brufen", Dosage = "200mg", RoomId = 6, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Xanax", Dosage = "40mg", RoomId = 5, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Panadon", Dosage = "200mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Diazepam", Dosage = "60mg", RoomId = 5, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Andol", Dosage = "400mg", RoomId = 5, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Vicodin", Dosage = "50mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Adderall", Dosage = "80mg", RoomId = 5, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Hemomicin", Dosage = "100mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Klonopin", Dosage = "20mg", RoomId = 5, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Demerol", Dosage = "30mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Amoksicilin", Dosage = "250mg", RoomId = 5, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });

            context.Add(new Medication { Med = "Cefaleksin", Dosage = "100mg", RoomId = 51, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Zoloft", Dosage = "200mg", RoomId = 51, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Lexilium", Dosage = "80mg", RoomId = 51, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Bensedin", Dosage = "10mg", RoomId = 51, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Brufen", Dosage = "100mg", RoomId = 51, Status = MedStatus.Approved, Company = "Famar", Quantity = 10, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Xanax", Dosage = "60mg", RoomId = 51, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Panadon", Dosage = "250mg", RoomId = 51, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Diazepam", Dosage = "800mg", RoomId = 51, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Andol", Dosage = "150mg", RoomId = 51, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Reglan", Dosage = "125mg", RoomId = 51, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Caffetin", Dosage = "200mg", RoomId = 61, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Plavix", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Ambien", Dosage = "50mg", RoomId = 61, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Ranisan", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Galenika", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Demerol", Dosage = "60mg", RoomId = 61, Status = MedStatus.Validation, Company = "Hemofarm", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "OxyCotin", Dosage = "25mg", RoomId = 61, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Percocet", Dosage = "30mg", RoomId = 61, Status = MedStatus.Validation, Company = "Goodwill", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Ritalin", Dosage = "40mg", RoomId = 61, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Eritromicin", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Famar", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });
            context.Add(new Medication { Med = "Penicillin", Dosage = "100mg", RoomId = 61, Status = MedStatus.Validation, Company = "Bosnalijek", Quantity = 15, MedicationContent = new List<DosageOfIngredient>(), MedicationCategoryId = 1, Allergens = new List<Allergens>(), AlternativeMedication = new List<Medication>(), SideEffects = new List<SideEffect>() });

            context.SaveChanges();
        }
        private void SeedMedicationUsage(MedbayTechDbContext context)
        {
            context.Add(new MedicationUsage { Usage = 4, MedicationId = 1, Date = new DateTime(2020, 8, 1) });
            context.Add(new MedicationUsage { Usage = 10, MedicationId = 2, Date = new DateTime(2020, 9, 1) });
            context.Add(new MedicationUsage { Usage = 50, MedicationId = 1, Date = new DateTime(2020, 1, 1) });
            context.Add(new MedicationUsage { Usage = 1, MedicationId = 2, Date = new DateTime(2020, 5, 1) });
            context.SaveChanges();
        }

        private void SeedAllergens(MedbayTechDbContext context)
        {
            context.Add(new Allergens { Allergen = "Polen", MedicalRecordId = 1 });
            context.Add(new Allergens { Allergen = "Prasina", MedicalRecordId = 1 });
            context.SaveChanges();
        }

        private void SeedPatients(MedbayTechDbContext context)
        {
            context.Add(new Patient
            {
                Id = "2406978890046",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "pera@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy1",
                Name = "Petar",
                Surname = "Petrovic",
                Username = "pera",
                Password = "pera1978",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "vodoinstalater",
                ProfileImage = "http://localhost:8080/Resources/Images/1234567891989/among-us-5659730_1280.png",
                IsGuestAccount = false,
                ChosenDoctorId = "2406978890047"
            });
            context.Add(new Patient
            {
                Id = "2406978890048",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "pera@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy1",
                Name = "Jovan",
                Surname = "Jovanovic",
                Username = "jova",
                Password = "jova98",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "vodoinstalater",
                ProfileImage = "http://localhost:8080/Resources/Images/1234567891989/among-us-5659730_1280.png",
                IsGuestAccount = false,
                ChosenDoctorId = "2406978890047",
                Blocked = false,
                ShouldBeBlocked = true
            });
            context.Add(new Patient
            {
                Id = "2406978890049",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "pera@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy1",
                Name = "Stefan",
                Surname = "Stefanovic",
                Username = "stef",
                Password = "stef23",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "vodoinstalater",
                ProfileImage = "http://localhost:8080/Resources/Images/1234567891989/among-us-5659730_1280.png",
                IsGuestAccount = false,
                ChosenDoctorId = "2406978890047",
                Blocked = false,
                ShouldBeBlocked = true
            });
            context.Add(new Patient
            {
                Id = "2406978890050",
                CurrResidenceId = 1,
                DateOfBirth = new DateTime(1978, 6, 24),
                DateOfCreation = new DateTime(),
                EducationLevel = EducationLevel.bachelor,
                Email = "pera@gmail.com",
                Gender = Gender.MALE,
                InsurancePolicyId = "policy1",
                Name = "Aleksa",
                Surname = "Aleksic",
                Username = "aleksa",
                Password = "aleksa1998",
                Phone = "065/123-4554",
                PlaceOfBirthId = 11000,
                Profession = "vodoinstalater",
                ProfileImage = "http://localhost:8080/Resources/Images/1234567891989/among-us-5659730_1280.png",
                IsGuestAccount = false,
                ChosenDoctorId = "2406978890047",
                Blocked = false,
                ShouldBeBlocked = true
            });
            context.SaveChanges();
        }

        private void SeedHospitals(MedbayTechDbContext context)
        {
            context.Add(new Hospital { Description = "blablal", Name = "Medbay", AddressId = 1 });
            context.Add(new Hospital { Description = "Hospital 1", Name = "Hospital 1", AddressId = 3 });
            context.Add(new Hospital { Description = "Hospital 2", Name = "Hospital 2", AddressId = 4 });
            context.SaveChanges();
        }

        private void SeedDepartments(MedbayTechDbContext context)
        {
            context.Add(new Department { Name = "General", Floor = 0, HospitalId = 1 });
            context.Add(new Department { Name = "Cardiology", Floor = 0, HospitalId = 1 });
            context.Add(new Department { Name = "Oncology", Floor = 1, HospitalId = 1 });
            context.Add(new Department { Name = "Radiology", Floor = 1, HospitalId = 1 });
            context.Add(new Department { Name = "Neurology", Floor = 2, HospitalId = 1 });
            context.Add(new Department { Name = "Intensive Care", Floor = 2, HospitalId = 1 });
            context.Add(new Department { Name = "Emergency", Floor = 0, HospitalId = 2 });
            context.Add(new Department { Name = "Dialysis", Floor = 0, HospitalId = 2 });
            context.Add(new Department { Name = "Gastroenterology", Floor = 1, HospitalId = 2 });
            context.Add(new Department { Name = "Hematology", Floor = 1, HospitalId = 2 });
            context.Add(new Department { Name = "Rheumatology", Floor = 2, HospitalId = 2 });
            context.Add(new Department { Name = "Infectous Diseases", Floor = 2, HospitalId = 2 });
            context.Add(new Department { Name = "Infektivno", Floor = 1, HospitalId = 3 });
            context.SaveChanges();
        }

        private void SeedRooms(MedbayTechDbContext context)
        {
            context.Add(new Room { RoomNumber = 1, RoomLabel = "", RoomUse = "", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 2, RoomLabel = "", RoomUse = "", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 1, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 1, RoomLabel = "0F-GN1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 2, RoomLabel = "0F-GN2", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 3, RoomLabel = "0F-GN3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 4, RoomLabel = "0F-GN4", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 5, RoomLabel = "0F-GN5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 6, RoomLabel = "0F-GN6", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 7, RoomLabel = "0F-GN7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 8, RoomLabel = "0F-GN8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 9, RoomLabel = "0F-GN9", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 10, RoomLabel = "0F-GN10", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 11, RoomLabel = "0F-GN11", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 13, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 12, RoomLabel = "0F-CA1", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 13, RoomLabel = "0F-CA2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 14, RoomLabel = "0F-CA3", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 15, RoomLabel = "0F-CA4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 16, RoomLabel = "0F-CA5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 17, RoomLabel = "0F-CA6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 18, RoomLabel = "0F-CA7", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 19, RoomLabel = "0F-CA8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 20, RoomLabel = "0F-CA9", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 21, RoomLabel = "0F-CA10", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 12, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 1, RoomLabel = "1F-ON1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 2, RoomLabel = "1F-ON2", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 3, RoomLabel = "1F-ON3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 4, RoomLabel = "1F-ON4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 5, RoomLabel = "1F-ON5", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 6, RoomLabel = "1F-ON6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 7, RoomLabel = "1F-ON7", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 8, RoomLabel = "1F-ON8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 9, RoomLabel = "1F-ON9", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 10, RoomLabel = "1F-ON10", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 11, RoomLabel = "1F-ON11", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 12, RoomLabel = "1F-ON12", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 13, RoomLabel = "1F-ON13", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 11, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 14, RoomLabel = "1F-RD1", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 15, RoomLabel = "1F-RD2", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 16, RoomLabel = "1F-RD3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 17, RoomLabel = "1F-RD4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 18, RoomLabel = "1F-RD5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 19, RoomLabel = "1F-RD6", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 20, RoomLabel = "1F-RD7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 21, RoomLabel = "1F-RD8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 10, HospitalEquipment = new List<HospitalEquipment>() });

            context.Add(new Room { RoomNumber = 1, RoomLabel = "2F-NE1", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 2, RoomLabel = "2F-NE2", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 3, RoomLabel = "2F-NE3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 4, RoomLabel = "2F-NE4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 5, RoomLabel = "2F-NE5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 6, RoomLabel = "2F-NE6", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 7, RoomLabel = "2F-NE7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 8, RoomLabel = "2F-NE8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 9, RoomLabel = "2F-NE9", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });

            context.Add(new Room { RoomNumber = 10, RoomLabel = "2F-NE10", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 11, RoomLabel = "2F-NE11", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 12, RoomLabel = "2F-NE12", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 13, RoomLabel = "2F-NE13", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 14, RoomLabel = "2F-NE14", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 9, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 15, RoomLabel = "2F-IC1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 16, RoomLabel = "2F-IC2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 17, RoomLabel = "2F-IC3", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 18, RoomLabel = "2F-IC4", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 19, RoomLabel = "2F-IC5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 20, RoomLabel = "2F-IC6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 21, RoomLabel = "2F-IC7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 22, RoomLabel = "2F-IC8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 8, HospitalEquipment = new List<HospitalEquipment>() });

            context.Add(new Room { RoomNumber = 1, RoomLabel = "0F-EM1", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 2, RoomLabel = "0F-EM2", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 3, RoomLabel = "0F-EM3", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 4, RoomLabel = "0F-EM4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 5, RoomLabel = "0F-EM5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 6, RoomLabel = "0F-EM6", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 7, RoomLabel = "0F-EM7", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 8, RoomLabel = "0F-EM8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 7, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 9, RoomLabel = "0F-DY1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 10, RoomLabel = "0F-DY2", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 11, RoomLabel = "0F-DY3", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 12, RoomLabel = "0F-DY4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 13, RoomLabel = "0F-DY5", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 14, RoomLabel = "0F-DY6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 15, RoomLabel = "0F-DY7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 16, RoomLabel = "0F-DY8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 6, HospitalEquipment = new List<HospitalEquipment>() });

            context.Add(new Room { RoomNumber = 1, RoomLabel = "1F-GE1", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 2, RoomLabel = "1F-GE2", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 3, RoomLabel = "1F-GE3", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 4, RoomLabel = "1F-GE4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 5, RoomLabel = "1F-GE5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 6, RoomLabel = "1F-GE6", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 7, RoomLabel = "1F-GE7", RoomUse = "Storage room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.StorageRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 8, RoomLabel = "1F-GE8", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 9, RoomLabel = "1F-GE9", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 10, RoomLabel = "1F-GE10", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 11, RoomLabel = "1F-GE11", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 12, RoomLabel = "1F-GE12", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 13, RoomLabel = "1F-GE13", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 14, RoomLabel = "1F-GE14", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 5, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 15, RoomLabel = "1F-HM1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });

            context.Add(new Room { RoomNumber = 16, RoomLabel = "1F-HM2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 17, RoomLabel = "1F-HM3", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 18, RoomLabel = "1F-HM4", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 19, RoomLabel = "1F-HM5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 20, RoomLabel = "1F-HM6", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 21, RoomLabel = "1F-HM7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 22, RoomLabel = "1F-HM8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 4, HospitalEquipment = new List<HospitalEquipment>() });

            context.Add(new Room { RoomNumber = 1, RoomLabel = "2F-RM1", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 2, RoomLabel = "2F-RM2", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 3, RoomLabel = "2F-RM3", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 4, RoomLabel = "2F-RM4", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 5, RoomLabel = "2F-RM5", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 6, RoomLabel = "2F-RM6", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 7, RoomLabel = "2F-RM7", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 8, RoomLabel = "2F-RM8", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 9, RoomLabel = "2F-RM9", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 10, RoomLabel = "2F-RM10", RoomUse = "Examination room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.ExaminationRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 11, RoomLabel = "2F-RM11", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 12, RoomLabel = "2F-RM12", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 13, RoomLabel = "2F-RM13", RoomUse = "Auxiliary room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 14, RoomLabel = "2F-RM14", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 3, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 15, RoomLabel = "2F-ID1", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 16, RoomLabel = "2F-ID2", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 17, RoomLabel = "2F-ID3", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 18, RoomLabel = "2F-ID4", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 19, RoomLabel = "2F-ID5", RoomUse = "Patient room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.PatientRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 20, RoomLabel = "2F-ID6", RoomUse = "Operation room", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.OperationRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 21, RoomLabel = "2F-ID7", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });
            context.Add(new Room { RoomNumber = 22, RoomLabel = "2F-ID8", RoomUse = "Elevator", BedsCapacity = 10, BedsFree = 3, RoomType = RoomType.AuxiliaryRoom, DepartmentId = 2, HospitalEquipment = new List<HospitalEquipment>() });

            context.SaveChanges();
        }

        private void SeedHospitalEquipment(MedbayTechDbContext context)
        {
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 122, EquipmentTypeId = 29 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 122, EquipmentTypeId = 30 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 122, EquipmentTypeId = 37 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 122, EquipmentTypeId = 38 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 122, EquipmentTypeId = 21 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 9, RoomId = 122, EquipmentTypeId = 9 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 11, RoomId = 122, EquipmentTypeId = 2 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 122, EquipmentTypeId = 3 });
            context.Add(new HospitalEquipment { QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 122, EquipmentTypeId = 4 });
            context.Add(new HospitalEquipment { QuantityInRoom = 70, QuantityInStorage = 250, RoomId = 122, EquipmentTypeId = 5 });
            context.Add(new HospitalEquipment { QuantityInRoom = 90, QuantityInStorage = 300, RoomId = 122, EquipmentTypeId = 6 });
            context.Add(new HospitalEquipment { QuantityInRoom = 100, QuantityInStorage = 500, RoomId = 122, EquipmentTypeId = 7 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 6, RoomId = 122, EquipmentTypeId = 8 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 12, RoomId = 122, EquipmentTypeId = 10 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 13, RoomId = 122, EquipmentTypeId = 18 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 14, RoomId = 122, EquipmentTypeId = 11 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 10, RoomId = 122, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 122, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 122, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 122, EquipmentTypeId = 16 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 67, EquipmentTypeId = 26 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 16, RoomId = 67, EquipmentTypeId = 27 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 69, EquipmentTypeId = 28 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 69, EquipmentTypeId = 29 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 69, EquipmentTypeId = 30 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 69, EquipmentTypeId = 31 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 69, EquipmentTypeId = 32 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 15, RoomId = 69, EquipmentTypeId = 12 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 10, RoomId = 69, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 20, RoomId = 69, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 4, RoomId = 74, EquipmentTypeId = 25 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 74, EquipmentTypeId = 26 });

            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 86, EquipmentTypeId = 22 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 1, RoomId = 89, EquipmentTypeId = 24 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 90, EquipmentTypeId = 23 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 1, RoomId = 91, EquipmentTypeId = 24 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 92, EquipmentTypeId = 22 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 0, RoomId = 116, EquipmentTypeId = 1 });

            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 10, RoomId = 104, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 104, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 5, RoomId = 104, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 97, EquipmentTypeId = 28 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 97, EquipmentTypeId = 31 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 97, EquipmentTypeId = 32 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 97, EquipmentTypeId = 33 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 97, EquipmentTypeId = 38 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 97, EquipmentTypeId = 21 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 30, RoomId = 97, EquipmentTypeId = 20 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 30, RoomId = 97, EquipmentTypeId = 19 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 9, RoomId = 97, EquipmentTypeId = 9 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 11, RoomId = 97, EquipmentTypeId = 2 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 97, EquipmentTypeId = 3 });
            context.Add(new HospitalEquipment { QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 97, EquipmentTypeId = 4 });
            context.Add(new HospitalEquipment { QuantityInRoom = 70, QuantityInStorage = 250, RoomId = 97, EquipmentTypeId = 5 });
            context.Add(new HospitalEquipment { QuantityInRoom = 90, QuantityInStorage = 300, RoomId = 97, EquipmentTypeId = 6 });
            context.Add(new HospitalEquipment { QuantityInRoom = 100, QuantityInStorage = 500, RoomId = 97, EquipmentTypeId = 7 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 6, RoomId = 97, EquipmentTypeId = 8 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 12, RoomId = 97, EquipmentTypeId = 10 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 13, RoomId = 97, EquipmentTypeId = 18 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 14, RoomId = 97, EquipmentTypeId = 11 });

            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 23, EquipmentTypeId = 29 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 23, EquipmentTypeId = 30 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 23, EquipmentTypeId = 37 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 23, EquipmentTypeId = 38 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 23, EquipmentTypeId = 21 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 9, RoomId = 23, EquipmentTypeId = 9 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 11, RoomId = 23, EquipmentTypeId = 2 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 23, EquipmentTypeId = 3 });
            context.Add(new HospitalEquipment { QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 23, EquipmentTypeId = 4 });
            context.Add(new HospitalEquipment { QuantityInRoom = 70, QuantityInStorage = 250, RoomId = 23, EquipmentTypeId = 5 });
            context.Add(new HospitalEquipment { QuantityInRoom = 90, QuantityInStorage = 300, RoomId = 23, EquipmentTypeId = 6 });
            context.Add(new HospitalEquipment { QuantityInRoom = 100, QuantityInStorage = 500, RoomId = 23, EquipmentTypeId = 7 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 6, RoomId = 23, EquipmentTypeId = 8 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 12, RoomId = 23, EquipmentTypeId = 10 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 13, RoomId = 23, EquipmentTypeId = 18 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 14, RoomId = 23, EquipmentTypeId = 11 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 10, RoomId = 23, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 23, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 23, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 23, EquipmentTypeId = 16 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 19, EquipmentTypeId = 28 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 19, EquipmentTypeId = 29 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 19, EquipmentTypeId = 30 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 19, EquipmentTypeId = 31 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 19, EquipmentTypeId = 32 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 15, RoomId = 19, EquipmentTypeId = 12 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 10, RoomId = 19, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 20, RoomId = 19, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 40, RoomId = 19, EquipmentTypeId = 39 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 18, EquipmentTypeId = 40 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 15, EquipmentTypeId = 40 });

            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 7, EquipmentTypeId = 34 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 6, RoomId = 4, EquipmentTypeId = 35 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 7, RoomId = 58, EquipmentTypeId = 36 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 7, RoomId = 57, EquipmentTypeId = 36 });

            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 10, RoomId = 45, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 45, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 5, RoomId = 45, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 10, RoomId = 44, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 44, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 5, RoomId = 44, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 43, EquipmentTypeId = 37 });
            context.Add(new HospitalEquipment { QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 43, EquipmentTypeId = 3 });
            context.Add(new HospitalEquipment { QuantityInRoom = 50, QuantityInStorage = 200, RoomId = 43, EquipmentTypeId = 4 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 10, RoomId = 43, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 3, QuantityInStorage = 20, RoomId = 43, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 43, EquipmentTypeId = 15 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 43, EquipmentTypeId = 16 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 36, EquipmentTypeId = 28 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 36, EquipmentTypeId = 29 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 8, RoomId = 36, EquipmentTypeId = 30 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 36, EquipmentTypeId = 31 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 36, EquipmentTypeId = 32 });
            context.Add(new HospitalEquipment { QuantityInRoom = 1, QuantityInStorage = 2, RoomId = 36, EquipmentTypeId = 33 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 15, RoomId = 36, EquipmentTypeId = 12 });
            context.Add(new HospitalEquipment { QuantityInRoom = 2, QuantityInStorage = 10, RoomId = 36, EquipmentTypeId = 13 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 20, RoomId = 36, EquipmentTypeId = 14 });
            context.Add(new HospitalEquipment { QuantityInRoom = 4, QuantityInStorage = 40, RoomId = 36, EquipmentTypeId = 39 });
            context.SaveChanges();
        }

        private void SeedEquipmentType(MedbayTechDbContext context)
        {
            context.Add(new EquipmentType { Name = "Mamogram" });
            context.Add(new EquipmentType { Name = "X-ray" });
            context.Add(new EquipmentType { Name = "CT" });
            context.Add(new EquipmentType { Name = "MRI" });
            context.Add(new EquipmentType { Name = "Ultra sound" });
            context.Add(new EquipmentType { Name = "EKG" });
            context.Add(new EquipmentType { Name = "Holter" });
            context.Add(new EquipmentType { Name = "Heart rate monitor" });
            context.Add(new EquipmentType { Name = "Blood preasure monitor" });
            context.Add(new EquipmentType { Name = "Blood sugar monitor" });
            context.Add(new EquipmentType { Name = "Defibrilator" });
            context.Add(new EquipmentType { Name = "Oxygen" });
            context.Add(new EquipmentType { Name = "Respirator" });
            context.Add(new EquipmentType { Name = "Gastroscope" });
            context.Add(new EquipmentType { Name = "Colonoscope" });
            context.Add(new EquipmentType { Name = "Blood test machine" });
            context.Add(new EquipmentType { Name = "Stethoscope" });
            context.Add(new EquipmentType { Name = "Suringe" });
            context.Add(new EquipmentType { Name = "Needle" });
            context.Add(new EquipmentType { Name = "Scalpel" });
            context.Add(new EquipmentType { Name = "Pean" });
            context.Add(new EquipmentType { Name = "Scissors" });
            context.Add(new EquipmentType { Name = "Tweezers" });
            context.Add(new EquipmentType { Name = "Surgical mask" });
            context.Add(new EquipmentType { Name = "Surgical gloves" });
            context.Add(new EquipmentType { Name = "Bandage" });
            context.Add(new EquipmentType { Name = "Gauze" });
            context.Add(new EquipmentType { Name = "Cotton pad" });
            context.Add(new EquipmentType { Name = "Adhesive tape" });
            context.Add(new EquipmentType { Name = "Alcohol" });
            context.Add(new EquipmentType { Name = "Iodine" });
            context.Add(new EquipmentType { Name = "Hydrogen peroxide" });
            context.Add(new EquipmentType { Name = "Bed" });
            context.Add(new EquipmentType { Name = "Table" });
            context.Add(new EquipmentType { Name = "Chair" });
            context.Add(new EquipmentType { Name = "Computer" });
            context.Add(new EquipmentType { Name = "Examining table" });
            context.Add(new EquipmentType { Name = "Weelchair" });
            context.Add(new EquipmentType { Name = "Thermometer" });
            context.Add(new EquipmentType { Name = "Dialysis machine" });

            context.SaveChanges();
        }

        private void SeedExaminationSurgery(MedbayTechDbContext context)
        {
            context.Add(new ExaminationSurgery
            {
                StartTime = new DateTime(2020, 11, 27),
                Type = TypeOfAppointment.Examination,
                Treatments = new List<Treatment>(),
                Diagnoses = new List<Diagnosis>(),
                DoctorId = "2406978890047",
                MedicalRecordId = 1
            });
            context.Add(new ExaminationSurgery
            {
                StartTime = new DateTime(2020, 11, 28),
                Type = TypeOfAppointment.Surgery,
                Treatments = new List<Treatment>(),
                Diagnoses = new List<Diagnosis>(),
                DoctorId = "2406978890047",
                MedicalRecordId = 1
            });

            context.SaveChanges();
        }
        private void SeedTreatments(MedbayTechDbContext context)
        {
            context.Add(new Treatment
            {
                Date = new DateTime(2020, 11, 27),
                AdditionalNotes = ".",
                Type = TreatmentType.Prescription,
                ExaminationSurgeryId = 1
            });
            context.Add(new Treatment
            {
                Date = new DateTime(2020, 11, 29),
                AdditionalNotes = ".",
                Type = TreatmentType.Prescription,
                ExaminationSurgeryId = 1
            });

            context.SaveChanges();
        }
        private void SeedPrescriptions(MedbayTechDbContext context)
        {
            context.Add(new Prescription
            {
                ExaminationSurgeryId = 1,
                Date = new DateTime(2020, 11, 27),
                Reserved = true,
                StartDate = new DateTime(2020, 11, 27),
                EndDate = new DateTime(2020, 11, 30),
                HourlyIntake = 6,
                MedicationId = 1,
            });
            context.Add(new Prescription
            {
                ExaminationSurgeryId = 1,
                Date = new DateTime(2020, 11, 28),
                Reserved = true,
                StartDate = new DateTime(2020, 11, 28),
                EndDate = new DateTime(2020, 12, 1),
                HourlyIntake = 6,
                MedicationId = 1,
            });
            context.SaveChanges();
        }

        private void SeedDoctorsWorkDay(MedbayTechDbContext context)
        {
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 10), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 11), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 12), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 13), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 14), StartTime = 8, EndTime = 15, DoctorId = "2406978890047" });

            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 20), StartTime = 8, EndTime = 15, DoctorId = "2407978890045" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 21), StartTime = 8, EndTime = 15, DoctorId = "2407978890045" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 22), StartTime = 8, EndTime = 15, DoctorId = "2407978890045" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 23), StartTime = 8, EndTime = 15, DoctorId = "2407978890045" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 24), StartTime = 8, EndTime = 15, DoctorId = "2407978890045" });

            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 6), StartTime = 8, EndTime = 15, DoctorId = "2407978890043" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 7), StartTime = 8, EndTime = 15, DoctorId = "2407978890043" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 8), StartTime = 8, EndTime = 15, DoctorId = "2407978890043" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 9), StartTime = 8, EndTime = 15, DoctorId = "2407978890043" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 10), StartTime = 8, EndTime = 15, DoctorId = "2407978890043" });

            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 6), StartTime = 8, EndTime = 15, DoctorId = "2407978890041" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 7), StartTime = 8, EndTime = 15, DoctorId = "2407978890041" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 8), StartTime = 8, EndTime = 15, DoctorId = "2407978890041" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 9), StartTime = 8, EndTime = 15, DoctorId = "2407978890041" });
            context.Add(new DoctorWorkDay { Date = new DateTime(2020, 12, 10), StartTime = 8, EndTime = 15, DoctorId = "2407978890041" });

            context.SaveChanges();
        }

    }
}
