using Model.Rooms;
using Repository;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Backend.Rooms.Repository.MySqlRepository
{
    public class HospitalEquipmentSqlRepository :MySqlrepository<HospitalEquipment, int>, IHospitalEquipmentRepository
    {
        public HospitalEquipmentSqlRepository(MySqlContext context) : base(context) { }
        public IEnumerable<HospitalEquipment> GetEquipmentByRoomNumber(int roomNumber)
        {
            return GetAll().ToList().Where(he => he.RoomId == roomNumber);
        }
        public IEnumerable<HospitalEquipment> GetEquipmentByType(EquipmentType type)
        {
            return GetAll().ToList().Where(he => he.EquipmentTypeId.Equals(type.Id));
        }
    }
}
