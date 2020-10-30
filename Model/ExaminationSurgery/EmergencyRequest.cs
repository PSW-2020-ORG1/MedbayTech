// File:    EmergencyRequest.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 11:33:22 PM
// Purpose: Definition of Class EmergencyRequest

using System;
using Model.Schedule;
using Model.Users;
using SimsProjekat.Repository;

namespace Model.ExaminationSurgery
{
   public class EmergencyRequest : IIdentifiable<int>
   {
        public TypeOfAppointment TypeOfAppointment { get; set; }
        public int RequestId { get; set; }
        public string SideNotes { get; set; }
        public Specialization Specialization { get; set; }
        public MedicalRecord.MedicalRecord MedicalRecord { get; set; }
        public bool Scheduled { get; set; }

        public EmergencyRequest() { }
        public EmergencyRequest(int id)
        {
            RequestId = id;
        }

        public EmergencyRequest(TypeOfAppointment typeOfAppointment, string sideNotes, Specialization specialization, MedicalRecord.MedicalRecord medicalRecord)
        {
            TypeOfAppointment = typeOfAppointment;
            SideNotes = sideNotes;
            Specialization = specialization;
            MedicalRecord = medicalRecord;
            Scheduled = false;
        }

        public int GetId()
        {
            return RequestId;
        }

        public void SetId(int id)
        {
            RequestId = id;
        }
    }
}