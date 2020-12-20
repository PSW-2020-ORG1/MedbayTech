using Model;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    public class AddressSqlRepository : MySqlrepository<Address, int>,
        IAddressRepository
    {
        public AddressSqlRepository(MedbayTechDbContext context) : base(context) { }

        public bool CheckIfExists(Address address)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAdressesByCity(City city)
        {
            throw new NotImplementedException();
        }

        public Address GetExistentAddress(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
