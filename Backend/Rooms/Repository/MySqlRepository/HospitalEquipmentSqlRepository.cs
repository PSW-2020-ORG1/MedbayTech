using Model.Rooms;
using Repository;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Rooms.Repository.MySqlRepository
{
    class HospitalEquipmentSqlRepository : MySqlrepository<HospitalEquipment, int>,
        IHospitalEquipmentRepository
    {
        public IEnumerable<HospitalEquipment> GetEquipmentByRoomNumber(int roomNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HospitalEquipment> GetEquipmentByType(EquipmentType type)
        {
            return GetAll().ToList().Where(he => he.EquipmentTypeId.Equals(type.Id));
        }
    }
}
