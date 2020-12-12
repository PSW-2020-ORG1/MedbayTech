using Model.Rooms;
using Repository;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Rooms.Repository.MySqlRepository
{
    class DepartmentSqlRepository : MySqlrepository<Department, int>,
        IDepartmentRepository
    {
        public Department GetByName(string name)
        {
            return GetAll().ToList().FirstOrDefault(d => d.Name.Equals(name));
        }
    }
}
