using Model.Rooms;
using Repository;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Rooms.Repository.MySqlRepository
{
    class RenovationSqlRepository : MySqlrepository<Renovation, int>,
        IRenovationRepository
    {
        public IEnumerable<Renovation> GetAllFromDate(DateTime date)
        {
            return GetAll().ToList().Where(r => r.Period.StartTime.CompareTo(date) <= 0);
        }
    }
}
