// File:    Secretary.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:24:49 PM
// Purpose: Definition of Class Secretary

using System;
using ZdravoKorporacija.Model.Users;

namespace Model.Users
{
   public class Secretary : Employee
   {
        public Secretary() { }
        public Secretary(string name, string surname, DateTime dateOfBirth,
            string identificationNumber, string email, string username, string phone,
            string password, EducationLevel educationLevel, Gender gender,
            string profession, City city, Address currResidence, InsurancePolicy insurancePolicy, string biography,
            string profileImage)
           
            : base(name, surname, dateOfBirth, identificationNumber, email, username, phone, password,
                educationLevel, gender, profession, city, currResidence, insurancePolicy, biography,
                profileImage) { }
   }
}