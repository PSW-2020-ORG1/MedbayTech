using Model;
using Model.Rooms;
using Repository.RoomRepository;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Rooms.Repository.MySqlRepository
{
    public class EquipmentTypeSqlRepository : IEquipmentTypeRepository
    {
        private MySqlContext _context;
        
        public EquipmentTypeSqlRepository(MySqlContext context)
        {
            _context = context;
        }
        public EquipmentType Create(EquipmentType entity)
        {
            if(ExistsInSystem(entity.Id))
            {
                return null;
            }
            _context.EquipmentTypes.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(EquipmentType entity)
        {
            _context.EquipmentTypes.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool ExistsInSystem(int id)
        {
            return GetObject(id) != null;
        }

        public IEnumerable<EquipmentType> GetAll()
        {
            return _context.EquipmentTypes.ToList();
        }

        public EquipmentType GetObject(int id)
        {
            return _context.EquipmentTypes.ToList().Find(p => p.Id == id);
        }

        public EquipmentType Update(EquipmentType entity)
        {
            _context.EquipmentTypes.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
