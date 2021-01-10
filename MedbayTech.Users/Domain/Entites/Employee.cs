// File:    Employee.cs
// Author:  ThinkPad
// Created: Monday, April 13, 2020 8:20:03 PM
// Purpose: Definition of Class Employee

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedbayTech.Users.Domain.Entites.Enums;
using MedbayTech.Users.Domain.ValueObjects;


namespace MedbayTech.Users.Domain.Entites
{
   public class Employee : RegisteredUser
   {    
        public bool VacationLeave { get; protected set; }
        public bool CurrentlyWorking { get; protected set; }
        public string Biography { get; protected set; }

        public Employee() { }

        public Employee(string name, string surname, DateTime dateOfBirth,
            string identificationNumber, string email, string username, string phone,
            string password, EducationLevel educationLevel, Gender gender,
            string profession, City city, Address currResidence, InsurancePolicy insurancePolicy, string biography,
            string profileImage)
            : base (name, surname, dateOfBirth, identificationNumber, email, username, phone, password, 
                  educationLevel, gender, profession, city, currResidence, insurancePolicy, profileImage)
        {
            VacationLeave = false;
            CurrentlyWorking = true;
            Biography = biography;
        }
    }
}