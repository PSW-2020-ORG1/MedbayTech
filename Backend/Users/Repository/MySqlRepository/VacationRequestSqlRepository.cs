using Model.Users;
using Repository;
using Repository.UserRepository;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Users.Repository.MySqlRepository
{
    class VacationRequestSqlRepository : MySqlrepository<VacationRequest, int>,
        IVacationRequestRepository
    {
        public List<VacationRequest> GetAllUnapproved()
        {
            return GetAll().ToList().Where(vr => vr.Approved == false).ToList();
        }
    }
}
