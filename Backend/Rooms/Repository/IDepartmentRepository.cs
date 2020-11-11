// File:    IDepartmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:46:50 AM
// Purpose: Definition of Interface IDepartmentRepository

using Model.Rooms;
using System;

namespace Repository.RoomRepository
{
    public interface IDepartmentRepository : IRepository<Department, int>
    {
        Department GetByName(string name);
    }
}