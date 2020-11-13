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
using ZdravoKorporacija.Model.Users;

namespace Model.Users
{
   public class Doctor : Employee
   {
        [Key]
        public string LicenseNumber { get; protected set; }
        public bool OnCall { get; protected set; }
        public double PatientReview { get; protected set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; protected set; }
        public virtual Department Department { get;  set; }
        [ForeignKey("ExaminationRoom")]
        public int ExaminationRoomId { get; protected set; }
        public virtual Room ExaminationRoom { get;  set; }
        [ForeignKey("OperationRoom")]
        public int OperationRoomId { get; protected set; }
        public virtual Room OperationRoom { get;  set; }
        public virtual List<Specialization> Specializations { get; set; }

        public Doctor() 
        {
            Specializations = new List<Specialization>();
        }

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
            Specializations = new List<Specialization>();
            Department = department;
            DepartmentId = department.Id;
            PatientReview = 0.0;
            OnCall = false;
            ExaminationRoom = examinationRoom;
            ExaminationRoomId = examinationRoom.Id;
            OperationRoom = operationRoom;
            OperationRoomId = operationRoom.Id;
        }

        internal bool IsMySpecialization(Specialization toCheck)
        {
            if (Specializations.Count > 0)
            {
                foreach (Specialization specialization in  Specializations) 
                {
                    if (specialization.SpecializationName.Equals(toCheck.SpecializationName))
                        return true;
                    
                }
            }

            return false;
        }
    }
}