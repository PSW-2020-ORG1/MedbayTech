using GraphicEditor.ViewModel.Enums;
using MedbayTech.Common.Domain.ValueObjects;


namespace GraphicEditor.ViewModel
{
    public class Appointment
    {
        public int Id { get; set; }
        public virtual Period Period { get; set; }
        public TypeOfAppointment TypeOfAppointment { get; set; }
        public string ShortDescription { get; set; }
        public bool Urgent { get; set; }
        public Room Room { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

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
