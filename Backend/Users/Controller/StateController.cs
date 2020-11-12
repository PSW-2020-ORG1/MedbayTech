// File:    StateController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 4:45:36 AM
// Purpose: Definition of Class StateController

using Model.Users;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.GeneralController
{
   public class StateController
   {
        public StateController(StateService stateService)
        {
            this.stateService = stateService;
        }

        public IEnumerable<State> GetAllStates() => stateService.GetAllStates();
        public State CreateState(State request) => stateService.CreateState(request);
        public State GetState(string id) => stateService.GetState(id);
        public bool CheckIfExists(State state) => stateService.CheckIfExists(state);

        public StateService stateService;
   
   }
}