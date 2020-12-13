// File:    ValidationMed.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 12:17:08 AM
// Purpose: Definition of Class ValidationMed

using Model.Users;
using System;
using Backend.General.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Medications.Model
{
   public class ValidationMed : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public  string SideNotes { get; set; }
        public DateTime DateOfValidation { get; set; }
        public  bool Approved { get; set; }
        public  bool Reviewed { get; set; }
        [ForeignKey("Medication")]
        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public ValidationMed() { }

        public ValidationMed(string sideNotes, bool approved, Medication medication, Doctor doctor)
        {
            SideNotes = sideNotes;
            Approved = approved;
            Medication = medication;
            Doctor = doctor;
        }
        public ValidationMed(string sideNotes, bool approved, Medication medication)
        {
            SideNotes = sideNotes;
            Approved = approved;
            Medication = medication;
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