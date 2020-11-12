// File:    ExaminationSurgery.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 9:49:42 PM
// Purpose: Definition of Class ExaminationSurgery

using System;
using System.Collections.Generic;
using Backend.Records.Model;
using Model.Schedule;
using Model.Users;
using SimsProjekat.Repository;

namespace Backend.Examinations.Model
{
   public class ExaminationSurgery : IIdentifiable<int>
   {
        public DateTime StartTime { get; set; }
        public TypeOfAppointment Type { get; set; }
        public int Id { get; set; }
        public virtual List<Treatment> Treatments { get; set; }
        public virtual List<Diagnosis> Diagnoses { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
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
   }
}