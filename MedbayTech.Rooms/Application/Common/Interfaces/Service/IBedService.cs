using MedbayTech.Rooms.Domain;
using System;
using System.Collections.Generic;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Service
{
    public interface IBedService
    {


        Bed AddBed(Bed bed);

        bool DeleteBed(Bed bed);


        Bed GetBed(int bedId);

        List<Bed> GetAllBeds();

        List<Bed> GetAllFreeBedsInPeriod(DateTime startDate, DateTime endDate);


        List<Bed> GetBedsByRoomNumber(int roomNumber);

        bool OccupyBed(Bed bed, Occupation occupation);

        bool FreeBed(Bed bed, DateTime startDate, DateTime endDate);

        bool CheckIfOccupationDatesAreValid(Occupation occupation);

        bool CheckIfOccupationsOverlap(Bed bed, Occupation occupation);

        bool CheckIfDatesOverlap(DateTime startDate, DateTime endDate, Occupation occupation);
    }
}
