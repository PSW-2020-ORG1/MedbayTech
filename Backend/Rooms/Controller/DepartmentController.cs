// File:    DepartmentController.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 11:48:13 PM
// Purpose: Definition of Class DepartmentController

using Model.Rooms;
using Service.RoomService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.RoomController
{
   public class DepartmentController
   {
        public DepartmentController(DepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        public Department AddNewDepartment(Department department) => departmentService.AddNewDepartment(department);
        public Department ChangeFloorForDepartment(Department department, int floor) => departmentService.ChangeFloorForDepartment(department, floor);
        public bool DeleteDepartment(Department department) => departmentService.DeleteDepartment(department);
        public Department GetDepartment(int id) => departmentService.GetDepartment(id);
        public Department GetDepartmentByName(string name) => departmentService.GetDepartmentByName(name);
        public IEnumerable<Department> GetAllDepartments() => departmentService.GetAllDepartments();

        public DepartmentService departmentService;

    }
}