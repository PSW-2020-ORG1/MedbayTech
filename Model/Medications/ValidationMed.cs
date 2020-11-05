// File:    ValidationMed.cs
// Author:  Vlajkov
// Created: Friday, April 17, 2020 12:17:08 AM
// Purpose: Definition of Class ValidationMed

using Model.Users;
using System;
using SimsProjekat.Repository;

namespace Model.Medications
{
   public class ValidationMed : IIdentifiable<int>
   {
        public int Id { get; set; }
        public  string SideNotes { get; set; }
        public  DateTime DateOfValidation { get; set; }
        public  bool Approved { get; set; }
        public  bool Reviewed { get; set; }

        public int MedicationId { get; set; }
        public  Medication Medication { get; set; }

        public string DoctorId { get; set; }

        public  Model.Users.Doctor Doctor { get; set; }
       
       
        public ValidationMed() { }

        public ValidationMed(string sideNotes, bool approved, Medication medication, Doctor doctor)
        {
            this.SideNotes = sideNotes;
            this.Approved = approved;
            this.Medication = medication;
            this.Doctor = doctor;
        }
        public ValidationMed(string sideNotes, bool approved, Medication medication)
        {
            this.SideNotes = sideNotes;
            this.Approved = approved;
            this.Medication = medication;
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