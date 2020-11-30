using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DTO;
using Backend.Utils.EnumMapper;

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
                Gender = RegisteredUserEnumMapper.StringToGender(patientRegistrationDTO.Gender),
                EducationLevel = RegisteredUserEnumMapper.StringToEducationalLevel(patientRegistrationDTO.EducationLevel)
            };
            return patient;
        }
    }
}
