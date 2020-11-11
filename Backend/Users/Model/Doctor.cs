/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Doctor.Doctor
 ***********************************************************************/

using Model.Rooms;
using System;
using System.Collections.Generic;
using ZdravoKorporacija.Model.Users;

namespace Model.Users
{
   public class Doctor : Employee
   {
        public string LicenseNumber { get; set; }
        public bool OnCall { get; set; }
        public double PatientReview { get; set; }
        // TODO(Jovan): Does Specialization need a Doctor reference?
        public virtual List<Specialization> Specializations { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int ExaminationRoomId { get; set; }
        public virtual Room ExaminationRoom { get; set; }
        public int OperationRoomId { get; set; }
        public virtual Room OperationRoom { get; set; }

        public Doctor() 
        {
            Specializations = new List<Specialization>();
        }

        public Doctor(string username) : base(username) { }

        public Doctor(string name, string surname, DateTime dateOfBirth,
            string identificationNumber, string email, string username, string phone,
            string password, EducationLevel educationLevel,Gender gender,
            string profession, City city, Address currResidence, InsurancePolicy insurancePolicy, string biography,
            Department department, List<Specialization> specializations, string licenseNumber, Room patientRoom, Room operationRoom)
            : base(name, surname, dateOfBirth, identificationNumber, email, username, phone, password,
                  educationLevel, gender, profession, city, currResidence, insurancePolicy, biography)
        {
            LicenseNumber = licenseNumber;
            Specializations = specializations;
            Department = department;
            PatientReview = 0.0;
            OnCall = false;
            ExaminationRoom = patientRoom;
            OperationRoom = operationRoom;
        }
    }
}