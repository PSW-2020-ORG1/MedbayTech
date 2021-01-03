using MedbayTech.Rooms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Gateways
{
    public interface IUserGateway
    {
        Patient GetPatients();
        Doctor GetDoctors();

        


    }
}
