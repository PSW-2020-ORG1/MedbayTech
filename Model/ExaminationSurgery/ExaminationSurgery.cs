// File:    ExaminationSurgery.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 9:49:42 PM
// Purpose: Definition of Class ExaminationSurgery

using System;
using System.Collections.Generic;
using Model.MedicalRecord;
using Model.Schedule;
using Model.Users;
using SimsProjekat.Repository;

namespace Model.ExaminationSurgery
{
   public class ExaminationSurgery : IIdentifiable<int>
   {
        private DateTime startTime;
        private TypeOfAppointment type;
        private int idNumber;
        private List<Treatment> treatments;
        private List<Diagnosis> diagnoses;
        private Doctor doctor;
        private MedicalRecord.MedicalRecord medicalRecord;

        public ExaminationSurgery() 
        {
            Treatments = new List<Treatment>();
            Diagnoses = new List<Diagnosis>();
        }
        public ExaminationSurgery(int id)
        {
            IdNumber = id; 
        }

        public ExaminationSurgery(DateTime startTime, TypeOfAppointment type, Doctor doctor, MedicalRecord.MedicalRecord record)
        {
            StartTime = startTime;
            Type = type;
            Doctor = doctor;
            MedicalRecord = record;
            Treatments = new List<Treatment>();
            Diagnoses = new List<Diagnosis>();
        }

        public DateTime StartTime { get => startTime; set => startTime = value; }
        public TypeOfAppointment Type { get => type; set => type = value; }
        public int IdNumber { get => idNumber; set => idNumber = value; }
        public List<Treatment> Treatments { get => treatments; set => treatments = value; }
        public List<Diagnosis> Diagnoses { get => diagnoses; set => diagnoses = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }
        public MedicalRecord.MedicalRecord MedicalRecord { get => medicalRecord; set => medicalRecord = value; }

        public int GetId()
        {
            return IdNumber;
        }

        public void SetId(int id)
        {
            IdNumber = id;
        }
    }
}