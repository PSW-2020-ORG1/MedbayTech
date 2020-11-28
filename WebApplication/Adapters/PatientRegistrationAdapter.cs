using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;

namespace WebApplication.Adapters
{
    public class PatientRegistrationAdapter
    {
        public static Patient PatientRegistrationDTOtoPatient(PatientRegistrationDTO patientRegistrationDTO)
        {

            Patient patient = new Patient
            {
                Id = patientRegistrationDTO.Id,
                Name = patientRegistrationDTO.Name,
                Surname = patientRegistrationDTO.Surname,
                DateOfBirth = patientRegistrationDTO.DateOfBirth,
                Phone = patientRegistrationDTO.Phone,
                Email = patientRegistrationDTO.Email,
                Username = patientRegistrationDTO.Username,
                Password = patientRegistrationDTO.Password,
                Profession = patientRegistrationDTO.Profession,
                ChosenDoctorId = patientRegistrationDTO.Doctor,
                CurrResidenceId = patientRegistrationDTO.CurrentResidenceId,
                PlaceOfBirthId = patientRegistrationDTO.PlaceOfBirthId,
                InsurancePolicyId = patientRegistrationDTO.PolicyNumber,
                Gender = StringToGender(patientRegistrationDTO.Gender),
                EducationLevel = StringToEducationalLevel(patientRegistrationDTO.EducationLevel)
            };
            return patient;
        }

        private static Gender StringToGender(string gender)
        {
            if (gender.ToLower().Equals("M"))
                return Gender.MALE;
            else
                return Gender.FEMALE;
        }

        private static EducationLevel StringToEducationalLevel(string educationalLevel)
        {
            if (educationalLevel.ToLower().Equals("primary"))
                return EducationLevel.primary;
            else if (educationalLevel.ToLower().Equals("secondary"))
                return EducationLevel.secondar;
            else if (educationalLevel.ToLower().Equals("bachelor"))
                return EducationLevel.bachelor;
            else if (educationalLevel.ToLower().Equals("master"))
                return EducationLevel.master;
            else if (educationalLevel.ToLower().Equals("specialist"))
                return EducationLevel.specialist;
            else 
                return EducationLevel.phD;
        }

        public static PatientCondition StringToCondition(string patientCondition)
        {
            if (patientCondition.ToLower().Equals("Stable"))
                return PatientCondition.Stable;
            else if (patientCondition.ToLower().Equals("Urgent"))
                return PatientCondition.Urgent;
            else if (patientCondition.ToLower().Equals("HospitalTreatment"))
                return PatientCondition.HospitalTreatment;
            else
                return PatientCondition.HomeTreatment;
        }

        public static BloodType StringToBloodType(string bloodType)
        {
            if (bloodType.ToLower().Equals("ONeg"))
                return BloodType.ONeg;
            else if (bloodType.ToLower().Equals("OPlus"))
                return BloodType.OPlus;
            else if (bloodType.ToLower().Equals("ANeg"))
                return BloodType.AbNeg;
            else if (bloodType.ToLower().Equals("APlus"))
                return BloodType.APlus;
            else if (bloodType.ToLower().Equals("BNeg"))
                return BloodType.BNeg;
            else if (bloodType.ToLower().Equals("BPlus"))
                return BloodType.BPlus;
            else if (bloodType.ToLower().Equals("AbNeg"))
                return BloodType.AbNeg;
            else
                return BloodType.AbPlus;
        }
    }
}
