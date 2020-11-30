using Backend.Users.Repository.MySqlRepository;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.WebApiService
{
    public class StateService
    {
        IStateRepository stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }

        public State Save(State stateToSave)
        {
            State state = CheckIfExists(stateToSave);
            if(state == null)
            {
                return stateRepository.Create(stateToSave);
            }
            return state;
        }

        public State CheckIfExists(State state)
        {
            List<State> states = stateRepository.GetAll().ToList();
            bool exists = states.Any(s => s.Id == state.Id);
            if(exists)
            {
                return states.FirstOrDefault(s => s.Id == state.Id);
            }
            return null;



        }
    }
}
