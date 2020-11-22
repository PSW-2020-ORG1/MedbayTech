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
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public Address ResidenceAddress { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String InsurancePolicyCompany { get; set; }
        public Period InsurancePolicyPeriod { get; set; }
        public PatientCondition PatientCondition { get; set; }
    /*    public List<Allergens> Allergies { get; set; }
        public List<Vaccines> Vaccines { get; set; }
        public List<Diagnosis> IllnesHistory { get; set; }
        public List<FamilyIllnessHistory> FamilyIllnessHistories { get; set; }
        public List<Therapy> Therapies { get; set; } */

        public MedicalRecordDTO(string patientId, string name, string surname, Gender gender, DateTime dateOfBirth,
            BloodType bloodType, Address residenceAddress, string phone, string email, string insurancePolicyCompany,
            Period insurancePolicyPeriod, PatientCondition patientCondition) /*, List<Allergens> allergies, List<Vaccines> vaccines,
            List<Diagnosis> illnesHistory, List<FamilyIllnessHistory> familyIllnessHistories, List<Therapy> therapies) */
        {
            PatientId = patientId;
            Name = name;
            Surname = surname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            BloodType = bloodType;
            ResidenceAddress = residenceAddress;
            Phone = phone;
            Email = email;
            InsurancePolicyCompany = insurancePolicyCompany;
            InsurancePolicyPeriod = insurancePolicyPeriod;
            PatientCondition = patientCondition;
         /*   Allergies = allergies;
            Vaccines = vaccines;
            IllnesHistory = illnesHistory;
            FamilyIllnessHistories = familyIllnessHistories;
            Therapies = therapies; */
        }
    }
}
