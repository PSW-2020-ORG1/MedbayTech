/***********************************************************************
 * Module:  Manager.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Manager.Manager
 ***********************************************************************/

using MedbayTech.Rooms.Domain.Enums;
using System;

namespace MedbayTech.Rooms.Domain
{
   public class Manager : RegisteredUser
   {
        public Manager() { }
        public Manager(string name, string surname, DateTime dateOfBirth,
            string identificationNumber, string email, string username, string phone,
            string password, EducationLevel educationLevel, Gender gender,
            string profession, City city, Address currResidence, InsurancePolicy insurancePolicy,
            string profileImage)
            : base(name, surname, dateOfBirth, identificationNumber, email, username, phone, password,
                 educationLevel, gender, profession, city, currResidence, insurancePolicy, profileImage)
        { }
   }
}