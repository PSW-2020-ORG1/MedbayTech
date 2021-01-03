using MedbayTech.Repository;
using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Domain;
using MedbayTech.Rooms.Infrastructure.Database;
using System.Linq;

namespace MedbayTech.Rooms.Infrastructure.Persistance
{
    public class DepartmentRepository : SqlRepository<Department, int>, IDepartmentRepository
    {
        public DepartmentRepository(RoomDbContext context) : base(context) { }
        public Department GetByName(string name)
        {
            return GetAll().ToList().FirstOrDefault(d => d.Name.Equals(name));
        }
    }
}
