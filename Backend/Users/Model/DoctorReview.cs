// File:    DoctorReview.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 1:58:30 AM
// Purpose: Definition of Class DoctorReview

using System;

namespace Model.Users
{
   public class DoctorReview
   {
        public string PatientId { get; set;}
        public string DoctorId { get; set; }
        public int Id { get; set; }
        public DateTime DateOfReview { get; set; }
        public Grade Grade { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }

        public DoctorReview() { }

        public DoctorReview(int id)
        {
            Id = id;
        }

        public DoctorReview(DateTime dateOfReview, Grade grade, Patient patient, Doctor doctor)
        {
            DateOfReview = dateOfReview;
            Grade = grade;
            Patient = patient;
            Doctor = doctor;
        }

    }
}