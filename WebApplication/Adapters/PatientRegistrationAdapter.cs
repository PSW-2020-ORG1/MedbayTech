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
                //ChosenDoctorId = patientRegistrationDTO.Doctor
                CurrResidenceId = 1,
                PlaceOfBirthId = patientRegistrationDTO.PostalCodeBirth
            };
            return patient;
        }
 
    }
}
