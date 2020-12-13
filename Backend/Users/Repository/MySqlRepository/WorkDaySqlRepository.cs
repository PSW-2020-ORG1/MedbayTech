using Model.Users;
using Repository;
using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class WorkDaySqlRepository : MySqlrepository<WorkDay, int>,
        IWorkDayRepository
    {
        public IEnumerable<WorkDay> GetWorkTimeForEmployee(Employee employee)
        {
            return GetAll().ToList().Where(wd => wd.EmployeeId.Equals(employee));
        }
    }
}
