// File:    IStateRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:27:44 AM
// Purpose: Definition of Interface IStateRepository

using Model.Users;
using System;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
   public interface IStateRepository : ICreate<State>, IGetAll<State>, IGet<State, string>
   {
        bool CheckIfExists(State state);
   }
}