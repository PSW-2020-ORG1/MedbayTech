// File:    IAddressRepository.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 4:15:45 AM
// Purpose: Definition of Interface IAddressRepository

using Model.Users;
using System.Collections.Generic;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public interface IAddressRepository : ICreate<Address>, IGetAll<Address>, IGet<Address, int>
   {
        List<Address> GetAdressesByCity(City city);
        bool CheckIfExists(Address address);
        Address GetExistentAddress(Address address);
    }
}