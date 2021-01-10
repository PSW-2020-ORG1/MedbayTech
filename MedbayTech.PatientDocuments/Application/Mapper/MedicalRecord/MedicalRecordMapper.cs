
using MedbayTech.PatientDocuments.Application.DTO;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;
using System;
using System.Collections.Generic;

namespace MedbayTech.PatientDocuments.Application.Mapper
{
    public class MedicalRecordMapper
    {

        public static MedicalRecordDTO MedicalRecordToMedicalRecordDTO(MedicalRecord medicalRecord)
        {
            string patientId = medicalRecord.PatientId;
            string name = medicalRecord.Patient.Name;
            string surname = medicalRecord.Patient.Surname;
            string gender = medicalRecord.Patient.Gender.ToString();
            DateTime dateOfBirth = medicalRecord.Patient.DateOfBirth;
            string bloodType = medicalRecord.BloodType.ToString();
            string city = medicalRecord.Patient.CurrResidence.City.Name;
            string state = medicalRecord.Patient.CurrResidence.City.State.Name;
            string street = medicalRecord.Patient.CurrResidence.Street;
            int number = medicalRecord.Patient.CurrResidence.Number;
            int apartment = medicalRecord.Patient.CurrResidence.Apartment;
            string phone = medicalRecord.Patient.Phone;
            string email = medicalRecord.Patient.Email;
            string insurancePolicyCompany = medicalRecord.Patient.InsurancePolicy.Company;
            DateTime insurancePolicyStart = medicalRecord.Patient.InsurancePolicy.Period.StartTime;
            DateTime insurancePolicyEnd = medicalRecord.Patient.InsurancePolicy.Period.EndTime;
            string patientCondition = medicalRecord.CurrHealthState.ToString();
            string image = medicalRecord.Patient.ProfileImage;

            List<string> allergies = new List<string>();
            foreach (Allergens allergen in medicalRecord.Allergens)
            {
                string allergenName = allergen.Allergen;
                allergies.Add(allergenName);
            }

            List<string> vaccines = new List<string>();
            foreach (Vaccines vaccine in medicalRecord.Vaccines)
            {
                string vaccineName = vaccine.Name;
                vaccines.Add(vaccineName);
            }

            List<string> illnessHistoryNames = new List<string>();
            foreach (Diagnosis illnessHistory in medicalRecord.IllnessHistory)
            {
                string illnessHistoryName = illnessHistory.Name;
                illnessHistoryNames.Add(illnessHistoryName);
            }

            List<string> illnessHistorySymptoms = new List<string>();
            foreach (Diagnosis illnessHistory in medicalRecord.IllnessHistory)
            {
                foreach (Symptoms symptom in illnessHistory.Symptoms)
                {
                    string symptomName = symptom.Name;
                    illnessHistorySymptoms.Add(symptomName);
                }
            }

            List<string> familyIllnessHistoriesRelatives = new List<string>();
            foreach (FamilyIllnessHistory familyIllnessHistory in medicalRecord.FamilyIllnessHistory)
            {
                string relative = familyIllnessHistory.RelativeMember.ToString();
                familyIllnessHistoriesRelatives.Add(relative);
            }

            List<string> familyIllnessHistoriesDiagnoses = new List<string>();
            foreach (FamilyIllnessHistory familyIllnessHistory1 in medicalRecord.FamilyIllnessHistory)
            {
                foreach (Diagnosis diagnosis in familyIllnessHistory1.Diagnosis)
                {
                    string diagnosisName = diagnosis.Name;
                    familyIllnessHistoriesDiagnoses.Add(diagnosisName);
                }
            }

            List<int> therapiesHourConsumption = new List<int>();
            foreach (Therapy therapy in medicalRecord.Therapies)
            {
                int hourConsumption = therapy.HourConsumption;
                therapiesHourConsumption.Add(hourConsumption);
            }

            List<string> therapiesMedication = new List<string>();
            foreach (Therapy therapy1 in medicalRecord.Therapies)
            {
                string medication = therapy1.MedicationName;
                therapiesMedication.Add(medication);
            }

            return new MedicalRecordDTO(patientId, name, surname, gender, dateOfBirth, bloodType, city, state, street, number, apartment,
                phone, email, insurancePolicyCompany, insurancePolicyStart, insurancePolicyEnd,
                patientCondition, allergies, vaccines,
                illnessHistoryNames, illnessHistorySymptoms, familyIllnessHistoriesRelatives, familyIllnessHistoriesDiagnoses, therapiesHourConsumption,
                therapiesMedication, image);

        }
    }
}
