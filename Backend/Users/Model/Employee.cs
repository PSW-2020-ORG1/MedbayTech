// File:    Employee.cs
// Author:  ThinkPad
// Created: Monday, April 13, 2020 8:20:03 PM
// Purpose: Definition of Class Employee

using System;
using ZdravoKorporacija.Model.Users;

namespace Model.Users
{
   public class Employee : RegisteredUser
   {

        public int WorkersID { get; set; }
        public bool VacationLeave { get; set; }
        public bool CurrentlyWorking { get; set; }
        public string Biography { get; set; }

        public Employee() { }

        public Employee(string username) : base(username) { }

        public Employee(string name, string surname, DateTime dateOfBirth,
            string identificationNumber, string email, string username, string phone,
            string password, EducationLevel educationLevel, Gender gender,
            string profession, City city, Address currResidence, InsurancePolicy insurancePolicy, string biography)
            : base (name, surname, dateOfBirth, identificationNumber, email, username, phone, password, 
                  educationLevel, gender, profession, city, currResidence, insurancePolicy)
        {
            VacationLeave = false;
            CurrentlyWorking = true;
            Biography = biography;
        }

        //  public Hospital hospital;

    }
}