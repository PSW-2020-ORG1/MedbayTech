// File:    CityController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 4:45:35 AM
// Purpose: Definition of Class CityController

using Model.Users;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.GeneralController
{
   public class CityController
   {
        public CityController(CityService cityService)
        {
            this.cityService = cityService;
        }

        public IEnumerable<City> GetAllCitiesByState(State state) => cityService.GetAllCitiesByState(state);
        public City CreateCity(City request) => cityService.CreateCity(request);
        public City GetCityByName(City city) => cityService.GetCityByName(city);
        public IEnumerable<City> GetAll() => cityService.GetAll();
        public bool CheckIfExists(City city) => cityService.CheckIfExists(city);

        public CityService cityService;
   
   }
}