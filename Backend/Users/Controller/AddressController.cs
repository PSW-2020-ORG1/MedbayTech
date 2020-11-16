// File:    AddressController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 4:45:37 AM
// Purpose: Definition of Class AddressController

using Model.Users;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.GeneralController
{
   public class AddressController
   {
        public AddressController(AddressService addressService)
        {
            this.addressService = addressService;
        }

        public IEnumerable<Address> GetAdressesByCity(City city) => addressService.GetAdressesByCity(city);

        public Address CreateAddress(Address request) => addressService.CreateAddress(request);
        public IEnumerable<Address> GetAll() => addressService.GetAll();
        public bool CheckIfExists(Address address) => addressService.CheckIfExists(address);
        public Address GetExistentAddress(Address address) => addressService.GetExistentAddress(address);

        public AddressService addressService;
   
   }
}