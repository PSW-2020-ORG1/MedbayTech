using Model;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    public class CitySqlRepository : MySqlrepository<City, int>,
        ICityRepository
    {
        public CitySqlRepository(MedbayTechDbContext context) : base(context) { }
        public bool CheckIfExists(City city)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<City> GetAllCitiesByState(State state)
        {
            return GetAll().ToList().Where(c => c.StateId.Equals(state.Id));
        }

        public City GetCityByName(City city)
        {
            return GetAll().ToList().FirstOrDefault(c => c.Name.Equals(city.Name));
        }
    }
}
