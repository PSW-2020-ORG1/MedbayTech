// File:    Patient.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:25:23 PM
// Purpose: Definition of Class Patient

using System;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Common.Domain.Entities;
using MedbayTech.Users.Domain.Entites;
using MedbayTech.Users.Domain.Entites.Enums;
using MedbayTech.Users.Domain.ValueObjects;

namespace MedbayTech.Users.Domain.Entites
{
   public class Patient : RegisteredUser
   {
        public bool IsGuestAccount { get;  set; }
        [ForeignKey("ChosenDoctor")]
        public string ChosenDoctorId { get;  set; }
        public virtual Doctor ChosenDoctor { get; set; }
        public bool Confirmed { get; set; }
        public bool Blocked { get; set; }
        public bool ShouldBeBlocked { get; set; }
        public string Token { get; set; }


        public Patient(string name, string surname, DateTime dateOfBirth,
            string identificationNumber, string email, string username,
            string password, EducationLevel educationLevel, Gender gender, string phone,
            string profession, City city, Address currResidence, InsurancePolicy insurancePolicy, bool guestAccount,
            string profileImage)
            : base(name, surname, dateOfBirth, identificationNumber, email, username, phone, password,
                educationLevel, gender, profession, city, currResidence, insurancePolicy, profileImage)
        {
            IsGuestAccount = guestAccount;
            ChosenDoctor = null;
        }

        public Patient() { }
    }
}