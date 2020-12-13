// File:    DoctorReview.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 1:58:30 AM
// Purpose: Definition of Class DoctorReview

using Backend.General.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Users
{
   public class DoctorReview : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfReview { get; protected set; }
        public Grade Grade { get; set; }
        [ForeignKey("Patient")]
        public string PatientId { get; protected set; }
        public virtual Patient Patient { get; set; }
        [ForeignKey("Doctor")]
        public string DoctorId { get; protected set; }
        public virtual Doctor Doctor { get; set; }

        public DoctorReview() { }

        public DoctorReview(int id, DateTime dateOfReview, Grade grade, Patient patient, Doctor doctor)
        {
            DateOfReview = dateOfReview;
            Grade = grade;
            Patient = patient;
            PatientId = patient.Id;
            Doctor = doctor;
            DoctorId = doctor.Id;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}