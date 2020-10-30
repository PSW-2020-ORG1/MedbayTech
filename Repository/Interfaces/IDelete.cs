// File:    IDelete.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 2:29:16 AM
// Purpose: Definition of Interface IDelete

using System;

namespace Repository
{
   public interface IDelete<T>
   {
      Boolean Delete(T entity);
   
   }
}