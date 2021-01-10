// File:    IDepartmentRepository.cs
// Author:  Vlajkov
// Created: Friday, May 22, 2020 4:46:50 AM
// Purpose: Definition of Interface IDepartmentRepository



using MedbayTech.Common.Repository;
using MedbayTech.Rooms.Domain;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Persistance
{
    public interface IDepartmentRepository : IRepository<Department, int>
    {
        Department GetByName(string name);
    }
}