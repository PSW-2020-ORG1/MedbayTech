// File:    Appointment.cs
// Author:  Vlajkov
// Created: Saturday, April 11, 2020 11:23:56 PM
// Purpose: Definition of Class Appointment

using Model.Rooms;
using Model.Users;
using System;
using SimsProjekat.Repository;

namespace Model.Schedule
{
   public class Appointment :  IIdentifiable<int>
   {
        private int id;
        private DateTime startTime;
        private DateTime endTime;
        private TypeOfAppointment typeOfAppointment;
        private string shortDescription;
        private bool urgent = false;
        private bool deleted = false;
        private bool finished = false;
        private Room room;
        private MedicalRecord.MedicalRecord medicalRecord;
        private Doctor doctor;
        private string doctorId;
        private int roomId;
        private int medicalRecordId;
        
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

        public int Id { get => id; set => id = value; }
        public TypeOfAppointment TypeOfAppointment { get => typeOfAppointment; set => typeOfAppointment = value; }
        public string ShortDescription { get => shortDescription; set => shortDescription = value; }
        public bool Urgent { get => urgent; set => urgent = value; }
        public bool Deleted { get => deleted; set => deleted = value; }
        public virtual Room Room { get => room; set => room = value; }
        public virtual MedicalRecord.MedicalRecord MedicalRecord { get => medicalRecord; set => medicalRecord = value; }
        public virtual Doctor Doctor { get => doctor; set => doctor = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public bool Finished { get => finished; set => finished = value; }
        public string DoctorId { get => doctorId; set => doctorId = value; }
        public int RoomId { get => roomId; set => roomId = value; }
        public int MedicalRecordId { get => medicalRecordId; set => medicalRecordId = value; }

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