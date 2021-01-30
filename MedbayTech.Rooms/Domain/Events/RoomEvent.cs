using MedbayTech.Common.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Rooms.Domain.Events
{
    public class RoomEvent : DomainEvent
    {
        //public RoomType Type { get; set; }
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
