
namespace MedbayTech.Rooms.Application
{
    public class RoomHasAppointmentsScheduled : System.Exception
    {
        public RoomHasAppointmentsScheduled()
        {

        }

        public RoomHasAppointmentsScheduled(string message) : base(message)
        {

        }

        public RoomHasAppointmentsScheduled(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
