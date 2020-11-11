// File:    ManagerBuilder.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 3:08:10 AM
// Purpose: Definition of Class ManagerBuilder

using System;

namespace Model.Users
{
   public class ManagerBuilder : UserBuilder
   {
        public string ManagerId { get; set; }
        public virtual Manager Manager { get; set; }

        public ManagerBuilder()
        {
            Manager = new Manager();
        }

        public Manager BuildManager()
        {
            return Manager;
        }

        public void SetCurrentResidence(Address address)
        {
            Manager.CurrResidence = address;
        }

        public void SetDateOfBirth(DateTime date)
        {
            Manager.DateOfBirth = date;
        }

        public void SetDateOfCreation(DateTime date)
        {
            Manager.DateOfCreation = date;
        }

        public void SetEducationLevel(EducationLevel eduLvl)
        {
            Manager.EducationLevel = eduLvl;
        }

        public void SetEmail(string email)
        {
            Manager.Email = email;
        }

        public void SetIDNumber(string id)
        {
            Manager.Id = id;
        }

        public void SetInsurancePolicy(InsurancePolicy policy)
        {
            Manager.InsurancePolicy = policy;
        }

        public void SetName(string name)
        {
            Manager.Name = name;
        }

        public void SetPassword(string password)
        {
            Manager.Password = password;
        }

        public void SetPhone(string phone)
        {
            Manager.Phone = phone;
        }

        public void SetPlaceOfBirth(City city)
        {
            Manager.PlaceOfBirth = city;
        }

        public void SetProfession(string profession)
        {
            Manager.Profession = profession;
        }

        public void SetProfilePicture(string image)
        {
            Manager.ProfileImage = image;
        }

        public void SetSurname(string surname)
        {
            Manager.Surname = surname;
        }

        public void SetUsername(string username)
        {
            Manager.Username = username;
        }
    }
}