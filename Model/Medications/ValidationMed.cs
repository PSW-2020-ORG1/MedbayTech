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
        private int id;
        private string sideNotes;
        private DateTime dateOfValidation;
        private bool approved;
        private bool reviewed;
        private Medication medication;
        private Model.Users.Doctor doctor;
        private int medicationId;
        private string doctorId;
        public ValidationMed() { }

        public ValidationMed(string sideNotes, bool approved, Medication medication, Doctor doctor)
        {
            this.sideNotes = sideNotes;
            this.approved = approved;
            this.medication = medication;
            this.doctor = doctor;
        }
        public ValidationMed(string sideNotes, bool approved, Medication medication)
        {
            this.sideNotes = sideNotes;
            this.approved = approved;
            this.medication = medication;
        }
        public int Id { get => id; set => id = value; }
        public string SideNotes { get => sideNotes; set => sideNotes = value; }
        public DateTime DateOfValidation { get => dateOfValidation; set => dateOfValidation = value; }
        public bool Approved { get => approved; set => approved = value; }
        public bool Reviewed { get => reviewed; set => reviewed = value; }
        public virtual Medication Medication { get => medication; set => medication = value; }
        public int MedicationId { get => medicationId; set => medicationId = value; }
        public virtual Doctor Doctor { get => doctor; set => doctor = value; }
        public string DoctorId { get => doctorId; set => doctorId = value; }

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