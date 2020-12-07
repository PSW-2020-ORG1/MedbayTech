using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Utils.DTO
{
    public class GetAppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String TypeOfAppointment { get; set; }
        public bool Finished { get; set; }
        public bool CanceledByPatient { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public GetAppointmentDTO() { }

        public GetAppointmentDTO(int id, DateTime start, DateTime end, String typeOfAppointment, bool finished, bool canceledByPatient, int roomNumber, string roomType,
                                 string doctorId, string name, string surname) 
        {
            Id = id;
            Start = start;
            End = end;
            TypeOfAppointment = typeOfAppointment;
            Finished = finished;
            CanceledByPatient = canceledByPatient;
            RoomNumber = roomNumber;
            RoomType = roomType;
            DoctorId = doctorId;
            Name = name;
            Surname = surname;


        }
    }

}
