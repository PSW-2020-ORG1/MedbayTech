// File:    Patient.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:25:23 PM
// Purpose: Definition of Class Patient

using System;
using ZdravoKorporacija.Model.Users;

namespace Model.Users
{
   public class Patient : RegisteredUser
   {
        public bool IsGuestAccount { get; set; }
        public string ChosenDoctorId { get; set; }
        public virtual Doctor ChosenDoctor { get; set; }

        public Patient(string name, string surname, DateTime dateOfBirth,
            string identificationNumber, string email, string username,
            string password, EducationLevel educationLevel, Gender gender,  string phone,
            string profession, City city, Address currResidence, InsurancePolicy insurancePolicy, bool guestAccount)
            : base(name, surname, dateOfBirth, identificationNumber, email, username, phone, password,
                educationLevel, gender, profession, city, currResidence, insurancePolicy)
        {
            IsGuestAccount = guestAccount;
            ChosenDoctor = null;
        }

        public Patient(string username) : base(username) { }

        public Patient() { }

        public Patient(string name, string surname, string idNumber, string phone) : base(name, surname, idNumber, phone) { } 
    }
}