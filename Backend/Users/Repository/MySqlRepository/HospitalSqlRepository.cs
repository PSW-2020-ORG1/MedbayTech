using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class HospitalSqlRepository : MySqlrepository<Hospital, int>,
        IHospitalRepository
    {
    }
}
