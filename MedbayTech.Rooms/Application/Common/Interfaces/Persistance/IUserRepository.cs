// File:    IUserRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:50:13 AM
// Purpose: Definition of Interface IUserRepository


using MedbayTech.Common.Repository;
using MedbayTech.Rooms.Domain;
using System.Collections.Generic;

namespace MedbayTech.Rooms.Application.Common.Interfaces
{
   public interface IUserRepository : IRepository<RegisteredUser,string>
   {

        List<Doctor> GetAllDoctorsBySpecialization(Specialization specialization);

        List<Employee> GetAllEmployees();

        List<Secretary> GetAllSecretaries();
        List<Doctor> GetAllDoctors();
        List<Patient> GetAllPatients();

        List<Manager> GetAllManagers();
        RegisteredUser GetByUsername(string username);
        List<Doctor> GetDoctorsFromDepartment(Department department);
    }
}