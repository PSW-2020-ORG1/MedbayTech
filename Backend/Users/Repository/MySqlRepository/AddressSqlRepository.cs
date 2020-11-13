using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class AddressSqlRepository : MySqlrepository<Address, int>,
        IAddressRepository
    {
        public bool CheckIfExists(Address address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAdressesByCity(City city)
        {
            throw new NotImplementedException();
        }

        public Address GetExistentAddress(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
