using Model;
using Model.Rooms;
using Repository;
using Repository.RoomRepository;

namespace Backend.Rooms.Repository.MySqlRepository
{
    public class EquipmentTypeSqlRepository : MySqlrepository<EquipmentType, int>, IEquipmentTypeRepository
    {
       public EquipmentTypeSqlRepository(MedbayTechDbContext context) : base(context) { }
    }
}
