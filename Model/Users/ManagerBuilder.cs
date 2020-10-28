// File:    ManagerBuilder.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 3:08:10 AM
// Purpose: Definition of Class ManagerBuilder

using System;

namespace Model.Users
{
   public class ManagerBuilder : UserBuilder
   {
        public Manager manager;

        public ManagerBuilder()
        {
            manager = new Manager();
        }

        public Manager BuildManager()
        {
            return manager;
        }

        public void SetCurrentResidence(Address address)
        {
            manager.CurrResidence = address;
        }

        public void SetDateOfBirth(DateTime date)
        {
            manager.DateOfBirth = date;
        }

        public void SetDateOfCreation(DateTime date)
        {
            manager.DateOfCreation = date;
        }

        public void SetEducationLevel(EducationLevel eduLvl)
        {
            manager.EducationLevel = eduLvl;
        }

        public void SetEmail(string email)
        {
            manager.Email = email;
        }

        public void SetIDNumber(string id)
        {
            manager.IdentificationNumber = id;
        }

        public void SetInsurancePolicy(InsurancePolicy policy)
        {
            manager.InsurancePolicy = policy;
        }

        public void SetName(string name)
        {
            manager.Name = name;
        }

        public void SetPassword(string password)
        {
            manager.Password = password;
        }

        public void SetPhone(string phone)
        {
            manager.Phone = phone;
        }

        public void SetPlaceOfBirth(City city)
        {
            manager.PlaceOfBirth = city;
        }

        public void SetProfession(string profession)
        {
            manager.Profession = profession;
        }

        public void SetProfilePicture(string image)
        {
            manager.ProfileImage = image;
        }

        public void SetSurname(string surname)
        {
            manager.Surname = surname;
        }

        public void SetUsername(string username)
        {
            manager.Username = username;
        }
    }
}