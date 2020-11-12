// File:    IRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:03:04 AM
// Purpose: Definition of Interface IRepository

using Backend.General.Model;
using System;

namespace Repository
{
   public interface IRepository<T,ID> : ICreate<T>, IUpdate<T>, IDelete<T>, IGet<T, ID>, IGetAll<T>
        where T : IIdentifiable<ID>
        where ID : IComparable


    {

        bool ExistsInSystem(ID id);
       
    }
}