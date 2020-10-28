// File:    ICreate.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 2:29:13 AM
// Purpose: Definition of Interface ICreate

using System;

namespace Repository
{
   public interface ICreate<T>
   {
      T Create(T entity);
   
   }
}