using MedbayTech.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace MedbayTech.PatientDocuments.Application.DTO
{
    public class MedicalRecordDTO
    {
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodType { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int Apartment { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string InsurancePolicyCompany { get; set; }
        public Period InsurancePolicyPeriod { get; set; }
        public DateTime InsurancePolicyStart { get; set; }
        public DateTime InsurancePolicyEnd { get; set; }
        public string PatientCondition { get; set; }
        public List<string> Allergies { get; set; }
        public List<string> Vaccines { get; set; }
        public List<string> IllnessHistoryName { get; set; }
        public List<string> IllnessHistorySymptoms { get; set; }
        public List<string> FamilyIllnessHistoriesRelative { get; set; }
        public List<string> FamilyIllnesHistoriesDiagnosis { get; set; }
        public List<int> TherapiesHourConsumption { get; set; }
        public List<string> TherapiesMedication { get; set; }

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
