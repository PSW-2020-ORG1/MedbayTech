using MedbayTech.Repository;
using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Domain;
using MedbayTech.Rooms.Infrastructure.Database;
using System.Collections.Generic;
using System.Linq;

namespace MedbayTech.Rooms.Infrastructure.Persistance
{
    public class HospitalEquipmentRepository : SqlRepository<HospitalEquipment, int>, IHospitalEquipmentRepository
    {
        public HospitalEquipmentRepository(RoomDbContext context) : base(context) { }
  
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
