// File:    IStream.cs
// Author:  Vlajkov
// Created: Wednesday, May 27, 2020 10:23:15 PM
// Purpose: Definition of Interface IStream

using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IStream<T>
   {
      IEnumerable<T> GetAll();
      
      void SaveAll(IEnumerable<T> entities);
   
   }
}