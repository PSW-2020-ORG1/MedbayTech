using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service.Interfaces
{
    public interface ICityService
    {
        City Save(City cityToSave);
        City CheckIfExists(City city);
    }
}
