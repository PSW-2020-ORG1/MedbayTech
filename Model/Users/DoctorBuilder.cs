// File:    DoctorBuilder.cs
// Author:  Vlajkov
// Created: Tuesday, June 02, 2020 3:07:56 AM
// Purpose: Definition of Class DoctorBuilder

using Model.Rooms;
using System;

namespace Model.Users
{
   public class DoctorBuilder : UserBuilder
   {
        public DoctorBuilder()
        {
            doctor = new Doctor();
        }


        public Doctor BuildDoctor()
        {
            return doctor;
        }


        public void SetExaminationRoom(Room room)
        {
            doctor.ExaminationRoom = room;
        }

        public void SetOpeartionRoom(Room room)
        {
            doctor.OperationRoom = room;
        }

        public void SetWorkersID(int id)
        {
            doctor.WorkersID = id;
        }
      
        public void SetVacationLeave(bool activeLeave)
        {
            doctor.VacationLeave = activeLeave;
        }
      
        public void SetCurrentlyWorking(bool working)
        {
            doctor.CurrentlyWorking = working;
        }
      
        public void SetBiography(string biography)
        {
            doctor.Biography = biography;
        } 
      
        public void SetLicenseNumber(string licenseNumber)
        {
            doctor.LicenseNumber = licenseNumber;
        }
      
        public void SetOnCall(bool onCall)
        {
            doctor.OnCall = onCall;
        }
      
        public void SetPatientReview(double review)
        {
            doctor.PatientReview = review;
        }

        public void SetName(string name)
        {
            doctor.Name = name;
        }

        public void SetSurname(string surname)
        {
            doctor.Surname = surname;
        }

        public void SetDateOfBirth(DateTime date)
        {
            doctor.DateOfBirth = date;
        }

        public void SetIDNumber(string id)
        {
            doctor.Id = id;
        }

        public void SetPhone(string phone)
        {
            doctor.Phone = phone;
        }

        public void SetEmail(string email)
        {
            doctor.Email = email;
        }

        public void SetUsername(string username)
        {
            doctor.Username = username;
        }

        public void SetPassword(string password)
        {
            doctor.Password = password;
        }

        public void SetDateOfCreation(DateTime date)
        {
            doctor.DateOfCreation = date;
        }

        public void SetEducationLevel(EducationLevel eduLvl)
        {
            doctor.EducationLevel = eduLvl;
        }

        public void SetProfession(string profession)
        {
            doctor.Profession = profession;
        }

        public void SetProfilePicture(string image)
        {
            doctor.ProfileImage = image;
        }

        public void SetCurrentResidence(Address address)
        {
            doctor.CurrResidence = address;
        }

        public void SetPlaceOfBirth(City city)
        {
            doctor.PlaceOfBirth = city;
        }

        public void SetInsurancePolicy(InsurancePolicy policy)
        {
            doctor.InsurancePolicy = policy;
        }

        public Doctor doctor;
   
   }
}