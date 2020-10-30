// File:    UserBuilder.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 3:03:52 AM
// Purpose: Definition of Interface UserBuilder

using System;

namespace Model.Users
{
   public interface UserBuilder
   {
      void SetName(string name);
      
      void SetSurname(string surname);
      
      void SetDateOfBirth(DateTime date);
      
      void SetIDNumber(string id);
      
      void SetPhone(string phone);
      
      void SetEmail(string email);
      
      void SetUsername(string username);
      
      void SetPassword(string password);
      
      void SetDateOfCreation(DateTime date);
      
      void SetEducationLevel(EducationLevel eduLvl);
      
      void SetProfession(string profession);
      
      void SetProfilePicture(string image);
      
      void SetCurrentResidence(Address address);
      
      void SetPlaceOfBirth(City city);
      
      void SetInsurancePolicy(InsurancePolicy policy);
   
   }
}