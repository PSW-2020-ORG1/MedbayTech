// File:    Appointment.cs
// Author:  Vlajkov
// Created: Saturday, April 11, 2020 11:23:56 PM
// Purpose: Definition of Class Appointment

using Model.Rooms;
using Model.Users;
using System;
using SimsProjekat.Repository;
using Model.Reports;

namespace Model.Schedule
{
    public class Appointment : IIdentifiable<int>
    {

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TypeOfAppointment TypeOfAppointment { get; set; }
        public string ShortDescription { get; set; }
        public bool Urgent { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord.MedicalRecord MedicalRecord { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int WeeklyAppointmentReportId { get; set; }
        public virtual WeeklyAppointmentReport WeeklyAppointmentReport { get; set; }

        public Appointment() { }

        public Appointment(DateTime startTime, DateTime endTime, Doctor doctor, TypeOfAppointment type)
        {
            Finished = false;
            StartTime = startTime;
            EndTime = endTime;
            TypeOfAppointment = type;
            Doctor = doctor;
            Room = type == TypeOfAppointment.examination ? doctor.ExaminationRoom : doctor.OperationRoom;
        }

        public Appointment(int id)
        {
            Id = id;
        }

        public Appointment(DateTime startTime, DateTime endTime, TypeOfAppointment type, string shortDescription,
            bool urgent, bool deleted, Room room, MedicalRecord.MedicalRecord medicalRecord, Doctor doctor)
        {
            Finished = false;
            StartTime = startTime;
            EndTime = endTime;
            TypeOfAppointment = type;
            ShortDescription = shortDescription;
            Urgent = urgent;
            Deleted = deleted;
            Room = room;
            MedicalRecord = medicalRecord;
            Doctor = doctor;
        }

     
        public override int GetHashCode()
        {
            return (StartTime.Year + 76) * ( StartTime.Day + 13) * ( StartTime.Hour + 17 )  * ( StartTime.Minute + 21) * ( StartTime.Second  + 15) * ( StartTime.Month + 47)
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