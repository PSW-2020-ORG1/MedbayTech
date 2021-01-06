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
        public Specialization Specialization { get; set; }
        public Room ExaminationRoom { get; set; }
        public Room OperationRoom { get; set; }

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
