// File:    StateService.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 4:38:46 AM
// Purpose: Definition of Class StateService

using Model.Users;
using Backend.Users.Repository.MySqlRepository;
using System;
using System.Collections.Generic;

namespace Service.GeneralService
{
   public class StateService
   {
        public StateService(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }

        public IEnumerable<State> GetAllStates() => stateRepository.GetAll();
        public State CreateState(State request) => stateRepository.Create(request);
        public State GetState(string id) => stateRepository.GetObject(id);
        public bool CheckIfExists(State state) => stateRepository.CheckIfExists(state);

        public IStateRepository stateRepository;
   
   }
}