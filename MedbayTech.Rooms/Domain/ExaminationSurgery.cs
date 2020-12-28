// File:    ExaminationSurgery.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 9:49:42 PM
// Purpose: Definition of Class ExaminationSurgery

using MedbayTech.Common.Domain.Entities;
using MedbayTech.Rooms.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Rooms.Domain
{
   public class ExaminationSurgery : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public DateTime StartTime { get; set; }
        public TypeOfAppointment Type { get; set; }
        public virtual List<Treatment> Treatments { get; set; }
        public virtual List<Diagnosis> Diagnoses { get; set; }
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }

        public ExaminationSurgery() 
        {
            Treatments = new List<Treatment>();
            Diagnoses = new List<Diagnosis>();
        }
        public ExaminationSurgery(int id)
        {
            Id = id; 
        }

        public ExaminationSurgery(DateTime startTime, TypeOfAppointment type, Doctor doctor, MedicalRecord record)
        {
            StartTime = startTime;
            Type = type;
            Doctor = doctor;
            MedicalRecord = record;
            Treatments = new List<Treatment>();
            Diagnoses = new List<Diagnosis>();
        }


        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
        
        public bool IsAlreadyStarted()
        {
            return StartTime.Date.CompareTo((DateTime.Today).Date) == 0;
        }

        public bool IsBeforeToday()
        {
            return StartTime.Date.CompareTo(DateTime.Today.Date) < 0;
        }

        public bool IsExaminationBefore(DateTime date)
        {
            return StartTime.Date.CompareTo(date.Date) > 0;
        }

        public bool IsPatient(string id)
        {
            return MedicalRecord.Id.Equals(id);
        }
    }
}