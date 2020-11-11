// File:    EmergencyRequest.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 11:33:22 PM
// Purpose: Definition of Class EmergencyRequest

using System;
using Backend.Examinations.Model.Model.Enums;
using Model.MedicalRecord;
using Model.Schedule;
using Model.Users;
using SimsProjekat.Repository;

namespace Backend.Examinations.Model
{
   public class EmergencyRequest : IIdentifiable<int>
   {
        public TypeOfAppointment TypeOfAppointment { get; set; }
        public int Id { get; protected set; }
        public string SideNotes { get; set; }
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        public Status Status { get; set; }

        public EmergencyRequest() { }
        public EmergencyRequest(int id)
        {
            Id = id;
        }

        public EmergencyRequest(TypeOfAppointment typeOfAppointment, string sideNotes, Specialization specialization, MedicalRecord medicalRecord)
        {
            TypeOfAppointment = typeOfAppointment;
            SideNotes = sideNotes;
            Specialization = specialization;
            MedicalRecord = medicalRecord;
            Status = Status.Created;
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