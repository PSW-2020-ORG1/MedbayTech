// File:    ExaminationSurgery.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 9:49:42 PM
// Purpose: Definition of Class ExaminationSurgery

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Examinations.Model;
using MedbayTech.Common.Domain.Entities;
using MedbayTech.PatientDocuments.Domain.Entities.Examinations.Enums;
using MedbayTech.PatientDocuments.Domain.Entities.MedicalRecords;

namespace MedbayTech.PatientDocuments.Domain.Entities.Examinations
{
    public class ExaminationSurgery : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public TypeOfAppointment Type { get; set; }
        public virtual List<Treatment.Treatment> Treatments { get; set; }
        public virtual List<Diagnosis> Diagnoses { get; set; }
        public string DoctorId { get; set; }
        public int MedicalRecordId { get; set; }
        public int DiagnosisId { get; set; }

        public ExaminationSurgery()
        {
            Treatments = new List<Treatment.Treatment>();
            Diagnoses = new List<Diagnosis>();
        }
        public ExaminationSurgery(int id)
        {
            Id = id;
        }

        public ExaminationSurgery(DateTime startTime, TypeOfAppointment type, string doctorId, int recordId)
        {
            StartTime = startTime;
            Type = type;
            DoctorId = doctorId;
            MedicalRecordId = recordId;
            Treatments = new List<Treatment.Treatment>();
            Diagnoses = new List<Diagnosis>();
        }


        public int GetId()
        {
            return Id;
        }

        public bool IsAlreadyStarted()
        {
            return StartTime.Date.CompareTo(DateTime.Today.Date) == 0;
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