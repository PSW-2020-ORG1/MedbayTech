
using MedbayTech.Common.Domain.Events;

namespace MedbayTech.GraphicEditor.ViewModel
{
    class RoomEvent : DomainEvent
    {
        public int RoomId { get; set; }

        public RoomEvent() : base()
        {
        }

        public RoomEvent(int roomId) : base()
        {
            RoomId = roomId;
        }
    }
}
