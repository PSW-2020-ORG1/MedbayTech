// File:    EmergencyRequest.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 11:33:22 PM
// Purpose: Definition of Class EmergencyRequest

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Examinations.Model.Enums;
using Backend.Records.Model;
using Model.Schedule;
using Model.Users;
using Backend.General.Model;

namespace Backend.Examinations.Model
{
   public class EmergencyRequest : IIdentifiable<int>
    {
        [Key]
        public int Id { get; protected set; }
        public TypeOfAppointment TypeOfAppointment { get; set; }
        public string SideNotes { get; set; }
        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }
        [ForeignKey("MedicalRecord")]
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