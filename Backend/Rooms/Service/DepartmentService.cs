// File:    DepartmentService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 11:03:49 PM
// Purpose: Definition of Class DepartmentService

using Model.Rooms;
using Repository.RoomRepository;
using System;
using System.Collections.Generic;

namespace Service.RoomService
{
   public class DepartmentService
   {
        public IDepartmentRepository departmentRepository;
        
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public Department AddNewDepartment(Department department) => departmentRepository.Create(department);
     
        public Department ChangeFloorForDepartment(Department department, int floor)
        {
            Department departmentToUpdate = departmentRepository.GetObject(department.Id);
            departmentToUpdate.Floor = floor;
            return departmentRepository.Update(departmentToUpdate);
        }

        public Department GetDepartment(int id) => departmentRepository.GetObject(id);
        public Department GetDepartmentByName(string name) => departmentRepository.GetByName(name);
        public bool DeleteDepartment(Department department) => departmentRepository.Delete(department);
     
        public IEnumerable<Department> GetAllDepartments() => departmentRepository.GetAll();


        

    }
}