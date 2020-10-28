// File:    EmployeeBuilder.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 3:07:54 AM
// Purpose: Definition of Class EmployeeBuilder

using System;

namespace Model.Users
{
   public class EmployeeBuilder : UserBuilder
   {
        public EmployeeBuilder()
        {
            employee = new Employee();
        }
        public Secretary BuildSecretary()
        {
            return (Secretary)employee;
        }

        public Employee BuildEmployee()
        {
            return employee;
        }

        public void SetWorkersID(int id)
        {
            employee.WorkersID = id;
        }
      
        public void SetVacationLeave(bool activeLeave)
        {
            employee.VacationLeave = activeLeave;
        }
      
        public void SetCurrentlyWorking(bool working)
        { 
            employee.CurrentlyWorking = working;
        }
      
        public void SetBiography(string biography)
        { 
            employee.Biography = biography;
        }

        public void SetName(string name)
        {
            employee.Name = name;
        }

        public void SetSurname(string surname)
        {
            employee.Surname = surname;
        }

        public void SetDateOfBirth(DateTime date)
        {
            employee.DateOfBirth = date;
        }

        public void SetIDNumber(string id)
        {
            employee.IdentificationNumber = id;
        }

        public void SetPhone(string phone)
        {
            employee.Phone = phone;
        }

        public void SetEmail(string email)
        {
            employee.Email = email;
        }

        public void SetUsername(string username)
        {
            employee.Username = username;
        }

        public void SetPassword(string password)
        {
            employee.Password = password;
        }

        public void SetDateOfCreation(DateTime date)
        {
            employee.DateOfCreation = date;
        }

        public void SetEducationLevel(EducationLevel eduLvl)
        {
            employee.EducationLevel = eduLvl;
        }

        public void SetProfession(string profession)
        {
            employee.Profession = profession;
        }

        public void SetProfilePicture(string image)
        {
            employee.ProfileImage = image;
        }

        public void SetCurrentResidence(Address address)
        {
            employee.CurrResidence = address;
        }

        public void SetPlaceOfBirth(City city)
        {
            employee.PlaceOfBirth = city;
        }

        public void SetInsurancePolicy(InsurancePolicy policy)
        {
            employee.InsurancePolicy = policy;
        }

        public Employee employee;

   
   }
}