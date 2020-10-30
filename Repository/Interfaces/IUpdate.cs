// File:    IUpdate.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 2:29:14 AM
// Purpose: Definition of Interface IUpdate

using System;

namespace Repository
{
   public interface IUpdate<T>
   {
      T Update(T entity);
   
   }
}