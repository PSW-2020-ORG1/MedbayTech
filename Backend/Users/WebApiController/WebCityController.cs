using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.WebApiController
{
    public class WebCityController
    {
        private CitySqlRepository cityRepository = new CitySqlRepository(new MySqlContext());
        private CityService cityService;

        public WebCityController()
        {
            this.cityService = new CityService(cityRepository);
        }

        public City Save(City cityToSave)
        {
            return cityService.Save(cityToSave);
        }
    }
}
