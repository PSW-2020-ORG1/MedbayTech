using Model.Rooms;
using Repository;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Rooms.Repository.MySqlRepository
{
    class EquipmentTypeSqlRepository : MySqlrepository<EquipmentType, int>,
        IEquipmentTypeRepository
    {
    }
}
