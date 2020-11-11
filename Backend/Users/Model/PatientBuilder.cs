// File:    PatientBuilder.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 3:08:16 AM
// Purpose: Definition of Class PatientBuilder

using System;

namespace Model.Users
{
   public class PatientBuilder : UserBuilder
   {
        public PatientBuilder()
        {
            patient = new Patient();
        }
        public void SetGuestAccount(bool isGuest)
        {
            patient.IsGuestAccount = isGuest;
        }

        public void SetName(string name)
        {
            patient.Name = name;
        }

        public void SetSurname(string surname)
        {
            patient.Surname = surname;
        }

        public void SetDateOfBirth(DateTime date)
        {
            patient.DateOfBirth = date;
        }

        public void SetIDNumber(string id)
        {
            patient.Id = id;
        }

        public void SetPhone(string phone)
        {
            patient.Phone = phone;
        }

        public void SetEmail(string email)
        {
            patient.Email = email;
        }

        public void SetUsername(string username)
        {
            patient.Username = username;
        }

        public void SetPassword(string password)
        {
            patient.Password = password;
        }

        public void SetDateOfCreation(DateTime date)
        {
            patient.DateOfCreation = date;
        }

        public void SetEducationLevel(EducationLevel eduLvl)
        {
            patient.EducationLevel = eduLvl;
        }

        public void SetProfession(string profession)
        {
            patient.Profession = profession;
        }

        public void SetProfilePicture(string image)
        {
            patient.ProfileImage = image;
        }

        public void SetCurrentResidence(Address address)
        {
            patient.CurrResidence = address;
        }

        public void SetPlaceOfBirth(City city)
        {
            patient.PlaceOfBirth = city;
        }

        public void SetInsurancePolicy(InsurancePolicy policy)
        {
            patient.InsurancePolicy = policy;
        }

        public Patient BuildPatient()
        {
            return patient;
        }

        public Patient patient;
   
   }
}