using Model.Rooms;
using Repository;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Rooms.Repository.MySqlRepository
{
    class RoomSqlRepository : MySqlrepository<Room, int>,
        IRoomRepository
    {
    }
}
