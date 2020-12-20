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
    public class HospitalEquipmentSqlRepository : MySqlrepository<HospitalEquipment, int>, IHospitalEquipmentRepository
    {
        public HospitalEquipmentSqlRepository(MedbayTechDbContext context) : base(context) { }
        public List<HospitalEquipment> GetEquipmentByRoomNumber(int roomNumber)
        {
            return GetAll().ToList().Where(he => he.RoomId == roomNumber).ToList();
        }
        public List<HospitalEquipment> GetEquipmentByType(EquipmentType type)
        {
            return GetAll().ToList().Where(he => he.EquipmentTypeId.Equals(type.Id)).ToList();
        }
    }
}
