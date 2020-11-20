/***********************************************************************
 * Module:  StateRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.StateRepository
 ***********************************************************************/

using Model.Users;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public class StateRepository : IStateRepository
   {
        public Stream<State> stream;
        private const string ALREADY_EXISTS = "State with name {0} already exists!";
        private const string NOT_FOUND = "State with name {0} does not exists!";

        public StateRepository(Stream<State> stream)
        {
            this.stream = stream;
        }

        public State Create(State entity)
        {
            if (!ExistsInSystem(entity.Name))
            {
                var allStates = stream.GetAll().ToList();
                allStates.Add(entity);
                stream.SaveAll(allStates);
                return entity;
            }
            else
            {
                throw new EntityAlreadyExists(string.Format(ALREADY_EXISTS, entity.Name));
            }
        }

        public IEnumerable<State> GetAll() => stream.GetAll();

        private bool ExistsInSystem(String name) 
        {
            var allStates = stream.GetAll().ToList();
            return allStates.Any(item => item.Name.Equals(name));
        }
        public bool CheckIfExists(State state)
        {
            var allStates = stream.GetAll().ToList();
            return allStates.Any(item => item.Name.Equals(state.Name));
        }

        public State GetObject(string name)
        {
            if (ExistsInSystem(name))
            {
                var state = stream.GetAll().SingleOrDefault(entity => entity.Name.CompareTo(name) == 0);
                return state;
            }
            else
            {
                throw new EntityNotFound(string.Format(NOT_FOUND, name));
            }
        }
    }
}