using Model.Rooms;
using Repository;
using Repository.RoomRepository;
using Model;

namespace Backend.Rooms.Repository.MySqlRepository
{
    public class RoomSqlRepository : MySqlrepository<Room, int>, IRoomRepository
    {
        public RoomSqlRepository(MySqlContext context) : base(context) { }

    }
}
