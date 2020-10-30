/***********************************************************************
 * Module:  RegisteredUser.cs
 * Author:  ThinkPad
 * Purpose: Definition of the Class HealthCorporation.Manager.RegisteredUser
 ***********************************************************************/

using System;
using SimsProjekat.Repository;
using ZdravoKorporacija.Model.Users;

namespace Model.Users
{
   public class RegisteredUser : IIdentifiable<string>
   {
        private string name;
        private string surname;
        private DateTime dateOfBirth;
        private string identificationNumber;
        private string phone;
        private string email;
        private string username;
        private string password;
        private DateTime dateOfCreation;
        private EducationLevel educationLevel;
        private string profession;
        private string profileImage;
        private Gender gender;
      
        private City placeOfBirth;
        private Address currResidence;
        private InsurancePolicy insurancePolicy;

        public RegisteredUser() { }

        public RegisteredUser(string id)
        {
            Username = id;
        }

        public RegisteredUser(string name, string surname, string identificationNumber, string phone)
        {
            Name = name;
            Surname = surname;
            IdentificationNumber = identificationNumber;
            Phone = phone;
        }

        public RegisteredUser(string name, string surname, DateTime dateOfBirth, 
            string identificationNumber, string email, string username, string phone,
            string password, EducationLevel educationLevel, Gender gender,
            string profession, City city, Address currResidence, InsurancePolicy insurancePolicy)
        {
            Gender = gender;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            IdentificationNumber = identificationNumber;
            Email = email;
            Username = username;
            Password = password;
            EducationLevel = educationLevel;
            Profession = profession;
            PlaceOfBirth = city;
            CurrResidence = currResidence;
            InsurancePolicy = insurancePolicy;
            Phone = phone;

        }

        public string IdentificationNumber { get => identificationNumber; set => identificationNumber = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public DateTime DateOfCreation { get => dateOfCreation; set => dateOfCreation = value; }
        public EducationLevel EducationLevel { get => educationLevel; set => educationLevel = value; }
        public string Profession { get => profession; set => profession = value; }
        public string ProfileImage { get => profileImage; set => profileImage = value; }
        public City PlaceOfBirth { get => placeOfBirth; set => placeOfBirth = value; }
        public Address CurrResidence { get => currResidence; set => currResidence = value; }
        public InsurancePolicy InsurancePolicy { get => insurancePolicy; set => insurancePolicy = value; }
        public Gender Gender { get => gender; set => gender = value; }

        public string GetId()
        {
            return Username;
        }

        public void SetId(string id)
        {
            Username = id;
        }
    }
}