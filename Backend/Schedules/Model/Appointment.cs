// File:    Appointment.cs
// Author:  Vlajkov
// Created: Saturday, April 11, 2020 11:23:56 PM
// Purpose: Definition of Class Appointment

using Backend.General.Model;
using Backend.Records.Model;
using Backend.Utils;
using Model.Rooms;
using Model.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Schedule
{
    public class Appointment : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        public Period Period { get; protected set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CancelationDate { get; set; }
        public TypeOfAppointment TypeOfAppointment { get; set; }
        public string ShortDescription { get; set; }
        public bool Urgent { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        public bool CanceledByPatient { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get;  set; }
        public virtual Room Room { get; set; }
        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get;  set; }
        public virtual MedicalRecord MedicalRecord { get; set; }
        [ForeignKey("Doctor")]
        public string DoctorId { get;  set; }
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int WeeklyAppointmentReportId { get;  set; }

        public Appointment() { }

        public Appointment(int id, Period period, TypeOfAppointment type, string shortDescription,
            bool urgent, bool deleted, Room room, MedicalRecord medicalRecord, Doctor doctor)
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
        public bool isOccupied(DateTime start, DateTime end)
        {
            return DateTime.Compare(Start, start) == 0 && DateTime.Compare(End, end) == 0;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public bool IsAlreadyScheduled(DateTime time)
        {
            if (Period.StartTime.CompareTo(time) == 0)
                return true;
            return false;
        }

        public bool IsTooEarlyToSchedule(int allowedHours)
        {
            if (Period.StartTime.Date.CompareTo(DateTime.Now.AddHours(allowedHours).Date) <= 0)
                return true;
            return false;
        }

        public bool IsPatient(Patient patient)
        {
            return MedicalRecord.Patient.Username.Equals(patient.Username);
        }

        public bool IsDoctor(Doctor doctor)
        {
            return Doctor.Username.Equals(doctor.Username);
        }

        public bool IsMedicalRecord(MedicalRecord medicalRecord)
        {
            return MedicalRecord.Id == medicalRecord.Id;
        }

        public bool IsInConflict(Appointment availableAppointment)
        {
            return Period.StartTime.CompareTo(availableAppointment.Period.StartTime) >= 0 &&
                   Period.StartTime.CompareTo(availableAppointment.Period.EndTime) < 0
                   && Room.Id == availableAppointment.Room.Id;
        }

        public bool IsBefore(WorkDay workDay)
        {
            return Period.EndTime.Hour > workDay.Shift.EndHour;
        }

        public bool IsAfterToday()
        {
            return Period.StartTime.Date.CompareTo(DateTime.Today.Date) > 0;
        }
    }
}