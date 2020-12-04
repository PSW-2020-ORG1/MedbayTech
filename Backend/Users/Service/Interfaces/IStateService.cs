using Model.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Service.Interfaces
{
    public interface IStateService
    {
        State Save(State stateToSave);
        State CheckIfExists(State state);
    }
}
