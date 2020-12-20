// File:    ICityRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:26:25 AM
// Purpose: Definition of Interface ICityRepository

using Model.Users;
using System;
using System.Collections.Generic;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public interface ICityRepository : ICreate<City>, IGetAll<City>, IGet<City, int>
   {
        List<City> GetAllCitiesByState(State state);
        bool CheckIfExists(City city);
        City GetCityByName(City city);
    }
}