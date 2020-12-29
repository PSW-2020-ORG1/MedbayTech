using MedbayTech.PatientDocuments.Domain.ValueObjects;
using Model.Users;
using System;

namespace MedbayTech.PatientDocuments.Domain.Entities.Patient
{
    public class Patient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public InsurancePolicy InsurancePolicy { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BloodType { get; set; }
        public Address CurrResidence { get; set; }
        public string ProfileImage { get; set; }
        public string Phone { get; set; }
        public Patient() { }

        public Patient(string id, string name, string surname, InsurancePolicy insurancePolicy, 
            string gender, string email, DateTime dateOfBirth, string phoneNumber, 
            string bloodType, Address currResidence, string profileImage, string phone)
        {
            Id = id;
            Name = name;
            Surname = surname;
            InsurancePolicy = insurancePolicy;
            Gender = gender;
            Email = email;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BloodType = bloodType;
            CurrResidence = currResidence;
            ProfileImage = profileImage;
            Phone = phone;
        }
    }
}
