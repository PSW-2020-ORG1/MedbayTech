using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service.Interfaces
{
    public interface IAddressService
    {
        Address Save(Address addressToSave);
        Address CheckIfExists(Address address);
    }
}
