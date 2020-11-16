// File:    IGet.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 2:29:17 AM
// Purpose: Definition of Interface IGet

using System;

namespace Repository
{
   public interface IGet<T,ID>
   {
      T GetObject(ID id);
   
   }
}