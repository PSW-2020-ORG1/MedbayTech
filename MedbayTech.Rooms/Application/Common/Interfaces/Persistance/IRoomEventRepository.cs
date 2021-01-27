using MedbayTech.Common.Repository;
using MedbayTech.Rooms.Domain.Events;
namespace MedbayTech.Rooms.Application.Common.Interfaces.Persistance
{
    public interface IRoomEventRepository : IRepository<RoomEvent, int>
    {
        //RoomEvent GetMostEnteredRoom(int roomId);
    }
}
