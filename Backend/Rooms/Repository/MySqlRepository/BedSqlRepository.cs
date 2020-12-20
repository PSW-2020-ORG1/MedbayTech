using Backend.Rooms;
using Model.Rooms;
using Repository;
using System.Linq;
using Repository.RoomRepository;
using System.Collections.Generic;

namespace Backend.Rooms.Repository.MySqlRepository
{
    class BedSqlRepository : MySqlrepository<Bed, int>,
        IBedRepository
    {
        public List<Bed> GetBedsByRoomNumber(int roomNumber)
        {
            return GetAll().ToList().Where(b => b.Room.RoomNumber.Equals(roomNumber)).ToList();
        }
    }
}
