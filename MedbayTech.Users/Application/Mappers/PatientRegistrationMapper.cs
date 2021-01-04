using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Domain.Entites;

namespace MedbayTech.Users.Application.Mappers
{
    public class PatientRegistrationMapper
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
                Gender = RegisteredUserEnumMapper.StringToGender(patientRegistrationDTO.Gender),
                EducationLevel = RegisteredUserEnumMapper.StringToEducationalLevel(patientRegistrationDTO.EducationLevel)
            };
            return patient;
        }
    }
}

