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
    public class HospitalEquipmentSqlRepository : IHospitalEquipmentRepository
    {
        private MedbayTechDbContext _context;
        public HospitalEquipmentSqlRepository(MedbayTechDbContext context)
        {
            _context = context;
        }

        public HospitalEquipment Create(HospitalEquipment entity)
        {
            if (ExistsInSystem(entity.Id))
            {
                return null;
            }

            _context.HospitalEquipments.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(HospitalEquipment entity)
        {
            _context.HospitalEquipments.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public bool ExistsInSystem(int id)
        {
            return GetObject(id) != null;

        }

        public List<HospitalEquipment> GetAll()
        {
           return _context.HospitalEquipments.ToList();
        }

        public List<HospitalEquipment> GetEquipmentByRoomNumber(int roomNumber)
        {
            return null;
        }

        public List<HospitalEquipment> GetEquipmentByType(EquipmentType type)
        {
            return GetAll().ToList().Where(he => he.EquipmentTypeId.Equals(type.Id)).ToList();
        }

        public HospitalEquipment GetObject(int id)
        {
            return _context.HospitalEquipments.ToList().Find(p => p.Id.Equals(id));
        }

        public HospitalEquipment Update(HospitalEquipment entity)
        {
            _context.HospitalEquipments.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
