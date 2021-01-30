using MedbayTech.Repository;
using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Domain;
using MedbayTech.Rooms.Infrastructure.Database;

namespace MedbayTech.Rooms.Infrastructure.Persistance
{
    public class RoomRepository : SqlRepository<Room, int>, IRoomRepository
    {
        public RoomRepository(RoomDbContext context) : base(context) { }


        
    }
}
