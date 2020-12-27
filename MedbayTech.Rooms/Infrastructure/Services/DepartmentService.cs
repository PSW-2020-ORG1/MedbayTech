// File:    DepartmentService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 11:03:49 PM
// Purpose: Definition of Class DepartmentService


using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Domain;
using System.Collections.Generic;

namespace MedbayTech.Rooms.Infrastructure.Services
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
            Department departmentToUpdate = departmentRepository.GetBy(department.Id);
            departmentToUpdate.Floor = floor;
            return departmentRepository.Update(departmentToUpdate);
        }

        public Department GetDepartment(int id) => departmentRepository.GetBy(id);
        public Department GetDepartmentByName(string name) => departmentRepository.GetByName(name);
        public bool DeleteDepartment(Department department) => departmentRepository.Delete(department);
     
        public List<Department> GetAllDepartments() => departmentRepository.GetAll();


        

    }
}