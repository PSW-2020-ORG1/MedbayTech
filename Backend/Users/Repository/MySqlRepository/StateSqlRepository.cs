using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class StateSqlRepository : MySqlrepository<State, long>,
        IStateRepository
    {
        public bool CheckIfExists(State state)
        {
            return GetObject(state.Id) == null ? false : true;
        }

        public State GetObject(string id)
        {
            return GetAll().ToList().FirstOrDefault(s => s.Id.Equals(id));
        }
    }
}
