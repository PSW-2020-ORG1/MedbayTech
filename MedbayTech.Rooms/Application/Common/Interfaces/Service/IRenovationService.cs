using MedbayTech.Rooms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Service
{
    interface IRenovationService
    {
        List<Renovation> GetAllRenovations();
        

        Renovation GetRenovation(int id);
        void MoveAllToStorage(Renovation renovation);

        Renovation CreateNewRenovation(Renovation renovation);

         bool CheckIfHasNewAppointments(Renovation renovation);

         Renovation EditRenovation(Renovation renovation);
       
        bool DeleteRenovation(Renovation renovation);

        List<Renovation> GetRenovationsFromOneRoom(int roomNumber);


        List<Renovation> GetActiveRenovations();

        bool IsStartDateValid(DateTime date);

    }
}
