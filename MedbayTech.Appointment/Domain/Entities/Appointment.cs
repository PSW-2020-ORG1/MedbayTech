// File:    Appointment.cs
// Author:  Vlajkov
// Created: Saturday, April 11, 2020 11:23:56 PM
// Purpose: Definition of Class Appointment

using Domain.Entities;
using Domain.Enums;
using Domain.ValueObject;
using MedbayTech.Repository.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedbayTech.Appointment.Domain.Entities
{
    public class Appointment : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Period Period { get; set; }
        public DateTime CancelationDate { get; set; }
        public TypeOfAppointment TypeOfAppointment { get; set; }
        public string ShortDescription { get; set; }
        public bool Urgent { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        public bool CanceledByPatient { get; set; }
        public int RoomId { get;  set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get;  set; }
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public Appointment() { }

        public Appointment(int id, Period period, TypeOfAppointment type, string shortDescription,
            bool urgent, bool deleted, Doctor doctor, int roomId)
        {
            Id = id;
            Period = period;
            TypeOfAppointment = type;
            ShortDescription = shortDescription;
            Urgent = urgent;
            Deleted = deleted;
            Finished = false;
            RoomId = roomId;
            Doctor = doctor;
            DoctorId = doctor.Id;
        }
        public bool IsOccupied(DateTime start, DateTime end)
        {
            return DateTime.Compare(Period.StartTime, start) == 0 && DateTime.Compare(Period.EndTime, end) == 0;
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

        public bool IsDoctor(Doctor doctor)
        {
            return Doctor.Id.Equals(doctor.Id);
        }

        public bool IsInConflict(Appointment availableAppointment)
        {
            return Period.StartTime.CompareTo(availableAppointment.Period.StartTime) >= 0 &&
                   Period.StartTime.CompareTo(availableAppointment.Period.EndTime) < 0
                   && RoomId == availableAppointment.RoomId;
        }

        public bool IsAfterToday()
        {
            return Period.StartTime.Date.CompareTo(DateTime.Today.Date) > 0;
        }
    }
}