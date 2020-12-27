// File:    Treatment.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 10:32:27 PM
// Purpose: Definition of Class Treatment

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Examinations.Model.Enums;
using MedbayTech.Repository.Domain.Entities;

namespace Backend.Examinations.Model
{
   public class Treatment : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string AdditionalNotes { get; set; }
        public TreatmentType Type { get; set; }
        public int ExaminationSurgeryId { get; set; }
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

    }
}