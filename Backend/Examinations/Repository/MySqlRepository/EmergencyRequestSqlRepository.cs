using System;
using System.Collections.Generic;
using System.Text;
using Backend.Examinations.Model;
using Repository;

namespace Backend.Examinations.Repository.MySqlRepository
{
    class EmergencyRequestSqlRepository : MySqlrepository<EmergencyRequest, int>,
        IEmergencyRequestRepository
    {
        public IEnumerable<EmergencyRequest> GetAllUnScheduled()
        {
            throw new NotImplementedException();
        }
    }
}
