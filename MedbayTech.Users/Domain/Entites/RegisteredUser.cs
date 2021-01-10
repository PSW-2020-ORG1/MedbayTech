/***********************************************************************
 * Module:  RegisteredUser.cs
 * Author:  ThinkPad
 * Purpose: Definition of the Class HealthCorporation.Manager.RegisteredUser
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Entities;
using MedbayTech.Users.Domain.Entites.Enums;
using MedbayTech.Users.Domain.ValueObjects;

namespace MedbayTech.Users.Domain.Entites
{
   public class RegisteredUser : IIdentifiable<string>
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string Profession { get; set; }
        public string ProfileImage { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; }
        [NotMapped]

        public virtual City PlaceOfBirth { get; set; }
        [NotMapped]

        public virtual Address CurrResidence { get;  set; }
        [NotMapped]

        public virtual InsurancePolicy InsurancePolicy { get; set; }


        public RegisteredUser() { }

        public RegisteredUser(string name, string surname, DateTime dateOfBirth,
            string identificationNumber, string email, string username, string phone,
            string password, EducationLevel educationLevel, Gender gender,
            string profession, City city, Address currResidence, InsurancePolicy insurancePolicy,
            string profileImage)
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
            DateOfCreation = DateTime.Now;
            ProfileImage = profileImage;
        }

        public string GetId()
        {
            return Id;
        }

    }
}