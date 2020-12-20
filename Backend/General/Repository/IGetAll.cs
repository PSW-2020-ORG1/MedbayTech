// File:    IGetAll.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 2:29:18 AM
// Purpose: Definition of Interface IGetAll

using Backend.General.Model;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IGetAll<T>
   {
        List<T> GetAll();

    }
}