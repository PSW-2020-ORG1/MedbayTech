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
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string Profession { get; set; }
        public string ProfileImage { get; set; }
        public Gender Gender { get; set; }

        public int PlaceOfBirthId { get; set; }
        public virtual City PlaceOfBirth { get; set; }

        public int CurrResidenceId { get; set; }
        public virtual Address CurrResidence { get; set; }

        public string InsurancePolicyId { get; set; }
        public virtual InsurancePolicy InsurancePolicy { get; set; }

        public RegisteredUser() { }

        public RegisteredUser(string id)
        {
            Username = id;
        }

        public RegisteredUser(string name, string surname, string identificationNumber, string phone)
        {
            Name = name;
            Surname = surname;
            Id = identificationNumber;
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
            Id = identificationNumber;
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