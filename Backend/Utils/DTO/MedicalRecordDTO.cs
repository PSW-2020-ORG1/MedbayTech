using Backend.Medications.Model;
using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Backend.Utils;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class MedicalRecordDTO
    {
        public String PatientId { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String BloodType { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Street { get; set; }
        public int Number { get; set; }
        public int Apartment { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String InsurancePolicyCompany { get; set; }
        public Period InsurancePolicyPeriod { get; set; }
        public DateTime InsurancePolicyStart { get; set; }
        public DateTime InsurancePolicyEnd { get; set; }
        public String PatientCondition { get; set; }
        public List<String> Allergies { get; set; }
        public List<String> Vaccines { get; set; }
        public List<String> IllnessHistoryName { get; set; }
        public List<String> IllnessHistorySymptoms { get; set; }
        public List<String> FamilyIllnessHistoriesRelative { get; set; }
        public List<String> FamilyIllnesHistoriesDiagnosis { get; set; }
        public List<int> TherapiesHourConsumption { get; set; } 
        public List<String> TherapiesMedication { get; set; }

        public string Img { get; set; }
        public MedicalRecordDTO() { }
        public MedicalRecordDTO(string patientId, string name, string surname, string gender, DateTime dateOfBirth, string bloodType, string city, string state, string street, int number, int apartment, string phone, string email, string insurancePolicyCompany, DateTime insurancePolicyStart, DateTime insurancePolicyEnd, 
            string patientCondition, List<string> allergies, List<string> vaccines, List<string> illnesHistoryName, List<string> illnesHistorySymptoms, List<string> familyIllnessHistoriesRelative, List<string> familyIllnesHistoriesDiagnosis, List<int> therapiesHourConsumption, List<string> therapiesMedication, string img)
        {
            PatientId = patientId;
            Name = name;
            Surname = surname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            BloodType = bloodType;
            City = city;
            State = state;
            Street = street;
            Number = number;
            Apartment = apartment;
            Phone = phone;
            Email = email;
            InsurancePolicyCompany = insurancePolicyCompany;
            InsurancePolicyStart = insurancePolicyStart;
            InsurancePolicyEnd = insurancePolicyEnd;
            PatientCondition = patientCondition;
            Allergies = allergies;
            Vaccines = vaccines;
            IllnessHistoryName = illnesHistoryName;
            IllnessHistorySymptoms = illnesHistorySymptoms;
            FamilyIllnessHistoriesRelative = familyIllnessHistoriesRelative;
            FamilyIllnesHistoriesDiagnosis = familyIllnesHistoriesDiagnosis;
            TherapiesHourConsumption = therapiesHourConsumption;
            TherapiesMedication = therapiesMedication;
            Img = img;
        }

    }
}
