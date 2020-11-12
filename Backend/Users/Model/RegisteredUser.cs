/***********************************************************************
 * Module:  RegisteredUser.cs
 * Author:  ThinkPad
 * Purpose: Definition of the Class HealthCorporation.Manager.RegisteredUser
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimsProjekat.Repository;
using ZdravoKorporacija.Model.Users;

namespace Model.Users
{
   public class RegisteredUser : IIdentifiable<string>
    {
        [Key]
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public string Phone { get; protected set; }
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public DateTime DateOfCreation { get; protected set; }
        public EducationLevel EducationLevel { get; protected set; }
        public string Profession { get; protected set; }
        public string ProfileImage { get; protected set; }
        public Gender Gender { get; protected set; }
        [ForeignKey("PlaceOfBirth")]
        public int PlaceOfBirthId { get; protected set; }
        public virtual City PlaceOfBirth { get; set; }
        [ForeignKey("CurrResidence")]
        public int CurrResidenceId { get; protected set; }
        public virtual Address CurrResidence { get;  set; }
        [ForeignKey("InsurancePolicy")]
        public string InsurancePolicyId { get; protected set; }
        public virtual InsurancePolicy InsurancePolicy { get; protected set; }

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
            return Username;
        }

        public void SetId(string id)
        {
            Username = id;
        }
    }
}