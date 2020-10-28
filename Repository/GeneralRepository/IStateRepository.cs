// File:    IStateRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:27:44 AM
// Purpose: Definition of Interface IStateRepository

using Model.Users;
using System;

namespace Repository.GeneralRepository
{
   public interface IStateRepository : ICreate<State>, IGetAll<State>, IGet<State, string>
   {
        bool CheckIfExists(State state);
   }
}