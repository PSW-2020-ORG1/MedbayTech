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
        private string licenseNumber;
        private bool onCall;
        private double patientReview;
        private List<Specialization> specializations;
        private Department department;
        private Room examinationRoom;
        private Room operationRoom;

        public int departmentId;
        public int examinationRoomId;
        public int operationRoomId;

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
        public string LicenseNumber { get => licenseNumber; set => licenseNumber = value; }
        public bool OnCall { get => onCall; set => onCall = value; }
        public double PatientReview { get => patientReview; set => patientReview = value; }
        public virtual List<Specialization> Specializations { get => specializations; set => specializations = value; }
        public virtual Department Department { get => department; set => department = value; }
        public virtual Room ExaminationRoom { get => examinationRoom; set => examinationRoom = value; }
        public virtual Room OperationRoom { get => operationRoom; set => operationRoom = value; }
    }
}