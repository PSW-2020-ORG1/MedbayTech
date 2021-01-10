using GraphicEditor.ViewModel.Enums;
using MedbayTech.Common.Domain.ValueObjects;
using System;

namespace GraphicEditor.ViewModel
{
    public class Appointment
    {
        public int Id { get; set; }
        public virtual Period Period { get; set; }
        public DateTime CancelationDate { get; set; }
        public TypeOfAppointment TypeOfAppointment { get; set; }
        public string ShortDescription { get; set; }
        public bool Urgent { get; set; }
        public bool Deleted { get; set; }
        public bool Finished { get; set; }
        public Room Room { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int RoomId { get; set; }

        public string FullName
        {
            get { return this.Doctor.Name + " " + this.Doctor.Surname; }
        }

        public string PatientId { get; set; }
        public Appointment()
        {
        }

        public Appointment(int id, Period period, TypeOfAppointment typeOfAppointment, string shortDescription, bool urgent, Room room, Doctor doctor)
        {
            Id = id;
            Period = period;
            TypeOfAppointment = typeOfAppointment;
            ShortDescription = shortDescription;
            Urgent = urgent;
            Room = room;
            Doctor = doctor;
        }
    }
}
