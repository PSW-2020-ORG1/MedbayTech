using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.ViewModel
{
    public class Medication
    {
        public int Id { get; set; }
        public string Med { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public Medication()
        {
        }

        public Medication(int id, string med, string company, int quantity, string dosage, int roomId, Room room)
        {
            Id = id;
            Med = med;
            Company = company;
            Quantity = quantity;
            Dosage = dosage;
            RoomId = roomId;
            Room = room;
        }
    }
}
