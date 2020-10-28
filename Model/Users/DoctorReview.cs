// File:    DoctorReview.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 1:58:30 AM
// Purpose: Definition of Class DoctorReview

using System;

namespace Model.Users
{
   public class DoctorReview
   {
        private int id;
        private DateTime dateOfReview;
        private Grade grade;

        private Patient patient;
        private Doctor doctor;

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

        public int Id { get => id; set => id = value; }
        public DateTime DateOfReview { get => dateOfReview; set => dateOfReview = value; }
        public Grade Grade { get => grade; set => grade = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }

    }
}