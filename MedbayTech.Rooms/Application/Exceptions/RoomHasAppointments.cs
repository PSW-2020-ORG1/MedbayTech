
namespace MedbayTech.Rooms.Application
{
    public class RoomHasAppointments : System.Exception
    {
        public RoomHasAppointments()
        {

        }

        public RoomHasAppointments(string message) : base(message)
        {

        }

        public RoomHasAppointments(string message, System.Exception inner) : base(message, inner)
        {

        }
    }

}