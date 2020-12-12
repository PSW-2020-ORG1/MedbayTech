using Model.Users;
using Repository;
using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class VacationRequestSqlRepository : MySqlrepository<VacationRequest, int>,
        IVacationRequestRepository
    {
        public IEnumerable<VacationRequest> GetAllUnapproved()
        {
            return GetAll().ToList().Where(vr => vr.Approved == false);
        }
    }
}
