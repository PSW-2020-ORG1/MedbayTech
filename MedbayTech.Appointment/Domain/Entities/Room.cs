using MedbayTech.Rooms.Domain;

namespace MedbayTech.Appointment.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomLabel { get; set; }
        public Enums.RoomType RoomType { get; set; }
        public Department Department { get; set; }

        public Room()
        {
        }

        public Room(int id, string roomLabel, Enums.RoomType roomType)
        {
            Id = id;
            RoomLabel = roomLabel;
            RoomType = roomType;
        }
    }
}
