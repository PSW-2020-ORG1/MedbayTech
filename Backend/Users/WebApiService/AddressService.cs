using Backend.Users.Repository.MySqlRepository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.WebApiService
{
    public class AddressService
    {
        IAddressRepository addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public Address Save(Address addressToSave)
        {
            Address address = CheckIfExists(addressToSave);
            if (address == null)
            {
                return addressRepository.Create(addressToSave);
            }
            return address;
        }

        public Address CheckIfExists(Address address)
        {
            List<Address> addresses = addressRepository.GetAll().ToList();
            bool exists = addresses.Any(s => s.Id == address.Id);
            if(exists)
            {
                return addresses.FirstOrDefault(s => s.Id == address.Id);
            }
            return null;



        }
    }
}
