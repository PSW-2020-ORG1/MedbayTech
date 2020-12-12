using Model.Rooms;
using Repository;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Linq;

namespace Backend.Rooms.Repository.MySqlRepository
{
    public class RoomSqlRepository : IRoomRepository //MySqlrepository<Pharmacy, string>,
    {

        private MySqlContext _context;
        public RoomSqlRepository(MySqlContext context)
        {
            _context = context;
        }

        public Room Create(Room entity)
        {
            if (ExistsInSystem(entity.Id))
            {
                return null;
            }
            _context.Rooms.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(Room entity)
        {
            _context.Rooms.Remove(entity);
            _context.SaveChanges();
            return true;
        }


        public bool ExistsInSystem(int id)
        {
            return GetObject(id) != null;
        }

        public IEnumerable<Room> GetAll() => _context.Rooms.ToList();


        public Room GetObject(int id)
        {
            return _context.Rooms.ToList().Find(p => p.Id.Equals(id));

        }
        

        public Room Update(Room entity)
        {
            _context.Rooms.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
