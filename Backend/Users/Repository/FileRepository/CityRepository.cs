/***********************************************************************
 * Module:  CityRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.CityRepository
 ***********************************************************************/

using Model.Users;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public class CityRepository : ICityRepository
   {
        public Stream<City> stream;
        private const string NOT_FOUND = "City with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "City with ID number {0} already exists!";

        public CityRepository(Stream<City> stream)
        {
            this.stream = stream;
        }

        public City Create(City entity)
        {
            if (!ExistsInSystem(entity.Id) && !CheckIfExists(entity))
            {
                var allCities = stream.GetAll().ToList();
                entity.Id = GetNextID();
                allCities.Add(entity);
                stream.SaveAll(allCities);
                return entity;
            }
            else
            {
                throw new EntityAlreadyExists(string.Format(ALREADY_EXISTS, entity.Id));
            }
        }

        private int GetNextID() => stream.GetAll().ToList().Count + 1;

        private bool ExistsInSystem(int id)
        {
            var allCities = stream.GetAll().ToList();
            return allCities.Any(item => item.Id == id);
        }
        public bool CheckIfExists(City city)
        {
            var allCities = stream.GetAll().ToList();
            foreach(City c in allCities)
            {
                if (c.Name.Equals(city.Name)) {
                    if (c.State.Name.Equals(city.State.Name))
                        return true;
                }
            }
            return false;
        }

        public City GetCityByName(City city)
        {
            var allCities = stream.GetAll().ToList();
            foreach (City c in allCities)
            {
                if (c.Name.Equals(city.Name))
                {
                    if (c.State.Name.Equals(city.State.Name))
                        return c;
                }
            }
            throw new EntityNotFound(NOT_FOUND);
        }

        public IEnumerable<City> GetAll() => stream.GetAll();

        public IEnumerable<City> GetAllCitiesByState(State state) => stream.GetAll().Where(item => item.State.Name.Equals(state.Name)).ToList();

        public City GetObject(int id)
        {
            if (ExistsInSystem(id))
            {
                return stream.GetAll().SingleOrDefault(entity => entity.Id.CompareTo(id) == 0);
            }
            else
            {
                throw new EntityNotFound(string.Format(NOT_FOUND, id));
            }
        }
    }
}