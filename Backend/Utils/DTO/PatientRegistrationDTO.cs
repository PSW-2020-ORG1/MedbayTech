using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DTO
{
    public class PatientRegistrationDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string EducationLevel { get; set; }
        public string Profession { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int Apartment { get; set; }
        public int Floor { get; set; }
        public string PolicyNumber { get; set; }
        public string Company { get; set; }
        public DateTime PolicyStart { get; set; }
        public DateTime PolicyEnd { get; set; }
        public string PatientCondition { get; set; }
        public string BloodType { get; set; }
        public string Doctor { get; set; }
        public string CityOfBirth { get; set; }
        public int PostalCodeBirth { get; set; }
        public string StateOfBirth { get; set; }
        public int CurrentResidenceId { get; set; }
        public int PlaceOfBirthId { get; set; }
        public PatientRegistrationDTO() { }

        public PatientRegistrationDTO(string id, string name, string surname, DateTime dateOfBirth, string phone, string email, string username, string password, string confirmPassword, string educationLevel, string profession, string profileImage, string gender, int postalCode, string city, string state, string street, int number, int apartment, int floor, string policyNumber, string company, DateTime policyStart, DateTime policyEnd, string patientCondition, string bloodType, string doctor, string cityOfBirth, int postalCodeBirth, string stateOfBirth, int currentResidenceId, int placeOfBirthId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
            EducationLevel = educationLevel;
            Profession = profession;
            ProfileImage = profileImage;
            Gender = gender;
            PostalCode = postalCode;
            City = city;
            State = state;
            Street = street;
            Number = number;
            Apartment = apartment;
            Floor = floor;
            PolicyNumber = policyNumber;
            Company = company;
            PolicyStart = policyStart;
            PolicyEnd = policyEnd;
            PatientCondition = patientCondition;
            BloodType = bloodType;
            Doctor = doctor;
            CityOfBirth = cityOfBirth;
            PostalCodeBirth = postalCodeBirth;
            StateOfBirth = stateOfBirth;
            CurrentResidenceId = currentResidenceId;
            PlaceOfBirthId = placeOfBirthId;
        }
    }
}
