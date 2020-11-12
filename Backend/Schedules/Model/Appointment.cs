// File:    Appointment.cs
// Author:  Vlajkov
// Created: Saturday, April 11, 2020 11:23:56 PM
// Purpose: Definition of Class Appointment

using Model.Rooms;
using Model.Users;
using System;
using SimsProjekat.Repository;
using Backend.Utils;

namespace Model.Schedule
{
    public class Appointment : IIdentifiable<int>
    {

        public int Id { get; set; }
        public Period Period { get; protected set; }
        public TypeOfAppointment TypeOfAppointment { get; set; }
        public string ShortDescription { get; set; }
        public bool Urgent { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        public int RoomId { get; protected set; }
        public virtual Room Room { get; set; }
        public int MedicalRecordId { get; protected set; }
        public virtual MedicalRecord.MedicalRecord MedicalRecord { get; set; }
        public string DoctorId { get; protected set; }
        public virtual Doctor Doctor { get; set; }

        public int WeeklyAppointmentReportId { get; protected set; }

        public Appointment() { }

        public Appointment(int id, Period period, TypeOfAppointment type, string shortDescription,
            bool urgent, bool deleted, Room room, MedicalRecord.MedicalRecord medicalRecord, Doctor doctor)
        {
            Id = id;
            Period = period;
            TypeOfAppointment = type;
            ShortDescription = shortDescription;
            Urgent = urgent;
            Deleted = deleted;
            Finished = false;
            Room = room;
            RoomId = room.Id;
            MedicalRecord = medicalRecord;
            MedicalRecordId = medicalRecord.Id;
            Doctor = doctor;
            DoctorId = doctor.Id;
        }

     
        public override int GetHashCode()
        {
            return (Period.StartTime.Year + 76) * (Period.StartTime.Day + 13) * (Period.StartTime.Hour + 17)  * (Period.StartTime.Minute + 21) * (Period.StartTime.Second  + 15) * (Period.StartTime.Month + 47)
                + Doctor.WorkersID*25;
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