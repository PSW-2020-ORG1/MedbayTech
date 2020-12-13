// File:    Treatment.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 10:32:27 PM
// Purpose: Definition of Class Treatment

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Examinations.Model.Enums;
using Backend.General.Model;

namespace Backend.Examinations.Model
{
   public class Treatment : IIdentifiable<int>
   {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string AdditionalNotes { get; set; }
        public TreatmentType Type { get; set; }
        [ForeignKey("ExaminationSurgery")]
        public int ExaminationSurgeryId { get; set; }
        public virtual ExaminationSurgery ExaminationSurgery { get; set; }
        public Treatment() { }

        public Treatment(int id)
        {
            Id = id;
        }

        public Treatment(TreatmentType type)
        {
            Type = type;
        }

        public Treatment(DateTime date, String additionalNotes, TreatmentType type)
        {
            Date = date.Date;
            AdditionalNotes = additionalNotes;
            Type = type;
        }

        
        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public bool IsPrescription()
        {
            return Type == TreatmentType.Prescription;
        }
        public bool IsHospitalTreatment()
        {
            return Type == TreatmentType.HospitalTreatment;
        }
        public bool IsLabTest()
        {
            return Type == TreatmentType.LabTest;
        }

        public bool IsPatient(string id)
        {
            return ExaminationSurgery.MedicalRecord.PatientId.Equals(id);
        }

    }
}