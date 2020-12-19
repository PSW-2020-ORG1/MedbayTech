/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class HealthCorporation.Doctor.Doctor
 ***********************************************************************/

using Backend.General.Model;
using Model.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Model.Users;

namespace Model.Users
{
   public class Doctor : Employee
   {
        public string LicenseNumber { get;  set; }
        public bool OnCall { get;  set; }
        public double PatientReview { get;  set; }
        [ForeignKey("Department")]
        public int DepartmentId { get;  set; }
        public virtual Department Department { get;  set; }
        [ForeignKey("ExaminationRoom")]
        public int ExaminationRoomId { get;  set; }
        public virtual Room ExaminationRoom { get;  set; }
        [ForeignKey("OperationRoom")]
        public int OperationRoomId { get;  set; }
        public virtual Room OperationRoom { get;  set; }
        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }

        public virtual Specialization Specialization { get; set; }


        public Doctor() {}

        public Doctor(string name, string surname, DateTime dateOfBirth,
            string identificationNumber, string email, string username, string phone,
            string password, EducationLevel educationLevel,Gender gender,
            string profession, City city, Address currResidence, InsurancePolicy insurancePolicy, string biography,
            Department department, string licenseNumber, Room examinationRoom, Room operationRoom,
            string profileImage)
            : base(name, surname, dateOfBirth, identificationNumber, email, username, phone, password,
                  educationLevel, gender, profession, city, currResidence, insurancePolicy, biography,
                  profileImage)
        {
            LicenseNumber = licenseNumber;
            Specialization = new Specialization();
            Department = department;
            DepartmentId = department.Id;
            PatientReview = 0.0;
            OnCall = false;
            ExaminationRoom = examinationRoom;
            ExaminationRoomId = examinationRoom.Id;
            OperationRoom = operationRoom;
            OperationRoomId = operationRoom.Id;
        }
        public void UpdateDoctor(Doctor doctor)
        {
            LicenseNumber = doctor.LicenseNumber;
            OnCall = doctor.OnCall;
            PatientReview = doctor.PatientReview;
            DepartmentId = doctor.DepartmentId;
            Department = null;
            ExaminationRoomId = doctor.ExaminationRoomId;
            ExaminationRoom = null;
            OperationRoomId = doctor.OperationRoomId;
            OperationRoom = null;
            SpecializationId = doctor.SpecializationId;
            Specialization = null;
        }
   }
}