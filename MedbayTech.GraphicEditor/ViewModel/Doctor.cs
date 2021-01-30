using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.ViewModel
{
    public class Doctor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public int ExaminationRoomId { get; set; }
        public Room ExaminationRoom { get; set; }
        public Room OperationRoom { get; set; }

        public string FullName
        {
            get { return Name + " " + Surname; }
        }

        public Doctor()
        {
        }

        public Doctor(string id, string name, string surname, Specialization specialization, Room examinationRoom, Room operationRoom)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Specialization = specialization;
            ExaminationRoom = examinationRoom;
            OperationRoom = operationRoom;
        }
    }
}
