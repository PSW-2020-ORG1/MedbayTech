using MedbayTech.Repository;
using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Domain;
using MedbayTech.Rooms.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Rooms.Infrastructure.Persistance
{
    public class EquipmentTypeRepository : SqlRepository<EquipmentType, int>, IEquipmentTypeRepository
    {
        public EquipmentTypeRepository(RoomDbContext context) : base(context) { }
    }
}
