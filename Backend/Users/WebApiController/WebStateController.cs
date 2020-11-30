using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Model;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.WebApiController
{
    public class WebStateController
    {
        private StateSqlRepository stateRepository = new StateSqlRepository(new MySqlContext());
        private StateService stateService;

        public WebStateController()
        {
            this.stateService = new StateService(stateRepository);
        }

        public State Save(State stateToSave)
        {
            return stateService.Save(stateToSave);
        }

    }
}
