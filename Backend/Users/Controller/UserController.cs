// File:    UserController.cs
// Author:  ThinkPad
// Created: Sunday, May 24, 2020 3:59:57 AM
// Purpose: Definition of Class UserController

using Model.Rooms;
using Model.Users;
using Service.UserService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.UserController
{
    public class UserController
    {
        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        public RegisteredUser RegisterUser(RegisteredUser user) => userService.RegisterUser(user);
        public RegisteredUser Login(string username, string password) => userService.Login(username, password);
        public RegisteredUser UpdateUserProfile(RegisteredUser updatedUser) => userService.UpdateUserProfile(updatedUser);
        public bool DeleteUser(RegisteredUser user) => userService.DeleteUser(user);
        public RegisteredUser GetUser(string username) => userService.GetUser(username);
        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(Specialization specialization) => userService.GetAllDoctorsBySpecialization(specialization);
        public IEnumerable<Employee> GetAllEmployees() => userService.GetAllEmployees();
        public IEnumerable<Secretary> GetAllSecrateries() => userService.GetAllSecrateries();
        public IEnumerable<Patient> GetAllPatients() => userService.GetAllPatients();
        public IEnumerable<Doctor> GetAllDoctors() => userService.GetAllDoctors();
        public RegisteredUser GetDoctor(string id) => (Doctor) userService.GetDoctor(id);
        public IEnumerable<Doctor> GetDoctorsFromDepartment(Department department) => userService.GetDoctorsFromDepartment(department);

        public UserService userService;

    }
}

