using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.WebApiController
{
    public class WebAddressController
    {
        private AddressSqlRepository addressRepository = new AddressSqlRepository(new MySqlContext());
        private AddressService addressService;

        public WebAddressController()
        {
            this.addressService = new AddressService(addressRepository);
        }

        public Address Save(Address addressToSave)
        {
            return addressService.Save(addressToSave);
        } 

    }
}
