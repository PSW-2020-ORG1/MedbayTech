using MedbayTech.Repository;
using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Domain.Events;
using MedbayTech.Rooms.Infrastructure.Database;

namespace MedbayTech.Rooms.Infrastructure.Persistance
{
    public class RoomEventRepository : SqlRepository<RoomEvent, int>, IRoomEventRepository
    {
        public RoomEventRepository(RoomDbContext context) : base(context) { }
    }
}
