using System;

namespace Application.DTO
{
    public class GetAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String TypeOfAppointment { get; set; }
        public bool Finished { get; set; }
        public bool CanceledByPatient { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public GetAppointmentDTO() { }

        public GetAppointmentDTO(int id, DateTime start, DateTime end, String typeOfAppointment, bool finished, bool canceledByPatient,
                                 string doctorId, string name, string surname, string roomNumber, string roomType) 
        {
            Id = id;
            Start = start;
            End = end;
            TypeOfAppointment = typeOfAppointment;
            Finished = finished;
            CanceledByPatient = canceledByPatient;
            DoctorId = doctorId;
            Name = name;
            Surname = surname;
            RoomNumber = roomNumber;
            RoomType = roomType;
        }
    }

}
