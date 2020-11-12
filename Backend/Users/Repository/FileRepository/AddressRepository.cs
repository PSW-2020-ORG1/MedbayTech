// File:    AddressRepository.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 4:15:45 AM
// Purpose: Definition of Class AddressRepository

using Model.Users;
using Backend.General.Model;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public class AddressRepository : IAddressRepository, ObjectComplete<Address>
    {
        public Stream<Address> stream;
        public ICityRepository cityRepository;
        private const string NOT_FOUND = "Address with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Address with ID number {0} already exists!";


        public AddressRepository(Stream<Address> stream, ICityRepository cityRepository)
        {
            this.stream = stream;
            this.cityRepository = cityRepository;
        }

        public Address Create(Address entity)
        {
            if (!ExistsInSystem(entity.Id))
            {
                var allCities = stream.GetAll().ToList();
                entity.Id = GetNextID();
                SetMissingValues(entity);
                allCities.Add(entity);
                stream.SaveAll(allCities);
                return entity;
            }
            else
            {
                throw new EntityAlreadyExists(string.Format(ALREADY_EXISTS, entity.Id));
            }
        }

        public void SetMissingValues(Address entity)
        {
            entity.City = new City();
        }

        public IEnumerable<Address> GetAdressesByCity(City city) => GetAll().ToList().Where(entity => entity.City.Id == city.Id);

        public IEnumerable<Address> GetAll()
        {
            var allAddress = stream.GetAll().ToList();
            for (int i = 0; i < allAddress.Count; i++)
            {
                CompleteObject(allAddress[i]);
            }
            return allAddress;
        }

        public Address GetObject(int id)
        {
            if (ExistsInSystem(id))
            {
                var address = stream.GetAll().SingleOrDefault(entity => entity.Id.CompareTo(id) == 0);
                CompleteObject(address);
                return address;
            }
            else
            {
                throw new EntityNotFound(string.Format(NOT_FOUND, id));
            }
        }
        public bool CheckIfExists(Address address)
        {
            var allAddresses = GetAll().ToList();
            foreach (Address a in allAddresses) {
                if (a.City.State.Name.Equals(address.City.State.Name) && a.City.Name.Equals(address.City.Name) 
                    && a.Street.Equals(address.Street) && a.Number == address.Number && a.Floor == address.Floor)
                    return true;
            }
            return false;
        }

        private int GetNextID() => stream.GetAll().ToList().Count + 1;
        private bool ExistsInSystem(int id)
        {
            var allAddresses = stream.GetAll().ToList();
            return allAddresses.Any(item => item.Id == id);
        }

        public void CompleteObject(Address address)
        {
            address.City = cityRepository.GetObject(address.City.Id);
        }

        public Address GetExistentAddress(Address address)
        {
            var allAddresses = GetAll().ToList();
            foreach (Address a in allAddresses)
            {
                if (a.City.State.Name.Equals(address.City.State.Name) && a.City.Name.Equals(address.City.Name)
                    && a.Street.Equals(address.Street) && a.Number == address.Number && a.Floor == address.Floor)
                    return a;
            }
            return null;
        }
    }
}