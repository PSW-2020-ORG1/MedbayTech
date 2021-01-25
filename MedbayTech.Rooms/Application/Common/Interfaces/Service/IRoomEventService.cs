using MedbayTech.Rooms.Domain;
using MedbayTech.Rooms.Domain.Events;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Service
{
    public interface IRoomEventService
    {
        Room GetMostEnteredRoom();
        RoomEvent SaveNewRoomEvent(RoomEvent roomEvent);
    }
}
