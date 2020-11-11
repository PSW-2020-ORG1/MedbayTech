// File:    AddressService.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 4:38:49 AM
// Purpose: Definition of Class AddressService

using Model.Users;
using Backend.Users.Repository.MySqlRepository;
using System;
using System.Collections.Generic;

namespace Service.GeneralService
{
   public class AddressService
   {
        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public IEnumerable<Address> GetAdressesByCity(City city) => addressRepository.GetAdressesByCity(city);
        public Address CreateAddress(Address request) => addressRepository.Create(request);
        public IEnumerable<Address> GetAll() => addressRepository.GetAll();
        public bool CheckIfExists(Address address) => addressRepository.CheckIfExists(address);

        public IAddressRepository addressRepository;

        public Address GetExistentAddress(Address address) => addressRepository.GetExistentAddress(address);
    }
}