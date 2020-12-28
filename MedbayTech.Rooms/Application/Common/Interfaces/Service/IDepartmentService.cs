using MedbayTech.Rooms.Domain;
using System.Collections.Generic;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Service
{
    public interface IDepartmentService
    {
        Department AddNewDepartment(Department department);

        Department ChangeFloorForDepartment(Department department, int floor);

        Department GetDepartment(int id);
        Department GetDepartmentByName(string name);
        bool DeleteDepartment(Department department);

        List<Department> GetAllDepartments();
    }
}
