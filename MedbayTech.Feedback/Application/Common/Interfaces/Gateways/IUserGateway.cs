using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedbayTech.Feedback.Domain.Entities;

namespace MedbayTech.Feedback.Application.Common.Interfaces.Gateways
{
    public interface IUserGateway
    {
        List<User> GetUsers();
        string GetUsersDomain();
    }
}
