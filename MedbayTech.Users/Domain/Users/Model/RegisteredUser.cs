/***********************************************************************
 * Module:  RegisteredUser.cs
 * Author:  ThinkPad
 * Purpose: Definition of the Class HealthCorporation.Manager.RegisteredUser
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Repository.Domain.Entities;
using Model.Users;

namespace Model.Users
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
        [ForeignKey("PlaceOfBirth")]
        public int PlaceOfBirthId { get; set; }
        public virtual City PlaceOfBirth { get; set; }
        [ForeignKey("CurrResidence")]
        public int CurrResidenceId { get; set; }
        public virtual Address CurrResidence { get;  set; }
        [ForeignKey("InsurancePolicy")]
        public string InsurancePolicyId { get; set; }
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
            PlaceOfBirthId = city.Id;
            CurrResidence = currResidence;
            CurrResidenceId = currResidence.Id;
            InsurancePolicy = insurancePolicy;
            InsurancePolicyId = insurancePolicy.Id;
            Phone = phone;
            DateOfCreation = DateTime.Now;
            ProfileImage = profileImage;
        }

        public string GetId()
        {
            return Id;
        }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}