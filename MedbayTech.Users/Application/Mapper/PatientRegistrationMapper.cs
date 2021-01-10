using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Common.Domain.ValueObjects;
using MedbayTech.Users.Application.DTO;
using MedbayTech.Users.Domain.Entites;
using MedbayTech.Users.Domain.ValueObjects;

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
                EducationLevel = RegisteredUserEnumMapper.StringToEducationalLevel(patientRegistrationDTO.EducationLevel),
                PlaceOfBirth = new City { Name = patientRegistrationDTO.CityOfBirth, State = new State {Name = patientRegistrationDTO.StateOfBirth}},
                CurrResidence = new Address
                {
                    Apartment = patientRegistrationDTO.Apartment,
                    City = new City {Name = patientRegistrationDTO.City, State = new State {Name = patientRegistrationDTO.State}},
                    Floor = patientRegistrationDTO.Floor,
                    Number = patientRegistrationDTO.Number,
                    Street = patientRegistrationDTO.Street
                },
                InsurancePolicy = new InsurancePolicy(patientRegistrationDTO.PolicyNumber, patientRegistrationDTO.Company, new Period(patientRegistrationDTO.PolicyStart, patientRegistrationDTO.PolicyEnd))
            };
            return patient;
        }
    }
}

