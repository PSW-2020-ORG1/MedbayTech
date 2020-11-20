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
            Gender gender = medicalRecord.Patient.Gender;
            DateTime dateOfBirth = medicalRecord.Patient.DateOfBirth;
            BloodType bloodType = medicalRecord.BloodType;
            Address residenceAddress = medicalRecord.Patient.CurrResidence;
            string phone = medicalRecord.Patient.Phone;
            string email = medicalRecord.Patient.Email;
            string insurancePolicyCompany = medicalRecord.Patient.InsurancePolicy.Company;
            Period insurancePolicyPeriod = medicalRecord.Patient.InsurancePolicy.Period;
            PatientCondition patientCondition = medicalRecord.CurrHealthState;
            List<Allergens> allergies = medicalRecord.Allergies;
            List<Vaccines> vaccines = medicalRecord.Vaccines;
            List<Diagnosis> illnesHistory = medicalRecord.IllnessHistory;
            List<FamilyIllnessHistory> familyIllnessHistory = medicalRecord.FamilyIllnessHistory;
            List<Therapy> therapies = medicalRecord.Therapies;

            return new MedicalRecordDTO(patientId, name, surname, gender, dateOfBirth, bloodType, residenceAddress, phone, email,
                insurancePolicyCompany, insurancePolicyPeriod, patientCondition, allergies, vaccines, illnesHistory, familyIllnessHistory, therapies);
        }
    }
}
