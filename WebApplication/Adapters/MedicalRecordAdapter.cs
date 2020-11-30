using Backend.Medications.Model;
using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Backend.Utils;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Adapters
{
    public class MedicalRecordAdapter
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
            DateTime insurancePolicyStart = medicalRecord.Patient.InsurancePolicy.StartTime;
            DateTime insurancePolicyEnd = medicalRecord.Patient.InsurancePolicy.EndTime;
            string patientCondition = medicalRecord.CurrHealthState.ToString();
            string image = medicalRecord.Patient.ProfileImage;
            
            List<String> allergies = new List<String>();
            foreach (Allergens allergen in medicalRecord.Allergies)
            {
                string allergenName = allergen.Allergen;
                allergies.Add(allergenName);
            }

            List<String> vaccines = new List<string>();
            foreach (Vaccines vaccine in medicalRecord.Vaccines)
            {
                string vaccineName = vaccine.Name;
                vaccines.Add(vaccineName);
            }

            List<String> illnessHistoryNames = new List<String>();
            foreach (Diagnosis illnessHistory in medicalRecord.IllnessHistory)
            {
                string illnessHistoryName = illnessHistory.Name;
                illnessHistoryNames.Add(illnessHistoryName);
            }

            List<String> illnessHistorySymptoms = new List<String>();
            foreach (Diagnosis illnessHistory in medicalRecord.IllnessHistory)
            {
                foreach (Symptoms symptom in illnessHistory.Symptoms)
                {
                    string symptomName = symptom.Name;
                    illnessHistorySymptoms.Add(symptomName);
                }
            }

            List<String> familyIllnessHistoriesRelatives = new List<String>();
            foreach (FamilyIllnessHistory familyIllnessHistory in medicalRecord.FamilyIllnessHistory)
            {
                string relative = familyIllnessHistory.RelativeMember.ToString();
                familyIllnessHistoriesRelatives.Add(relative);
            }

            List<String> familyIllnessHistoriesDiagnoses = new List<String>();
            foreach (FamilyIllnessHistory familyIllnessHistory1 in medicalRecord.FamilyIllnessHistory)
            {
                foreach(Diagnosis diagnosis in familyIllnessHistory1.Diagnosis)
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

            List<String> therapiesMedication = new List<String>();
            foreach (Therapy therapy1 in medicalRecord.Therapies)
            {
                string medication = therapy1.Medication.Med;
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
