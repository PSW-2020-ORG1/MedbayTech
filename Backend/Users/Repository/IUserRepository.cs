// File:    IUserRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:50:13 AM
// Purpose: Definition of Interface IUserRepository

using Model.Rooms;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository.UserRepository
{
   public interface IUserRepository : IRepository<RegisteredUser,string>
   {
      
        IEnumerable<Doctor> GetAllDoctorsBySpecialization(Model.Users.Specialization specialization);
      
        IEnumerable<Employee> GetAllEmployees();
      
        IEnumerable<Secretary> GetAllSecretaries();
        IEnumerable<Doctor> GetAllDoctors();
        IEnumerable<Patient> GetAllPatients();

        IEnumerable<Manager> GetAllManagers();
        RegisteredUser GetByUsername(string username);
        IEnumerable<Doctor> GetDoctorsFromDepartment(Department department);
    }
}