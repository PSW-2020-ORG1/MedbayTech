// File:    BedController.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 11:48:16 PM
// Purpose: Definition of Class BedController

using Backend.Records.Model.Enums;
using Model.Rooms;
using Service.RoomService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.RoomController
{
   public class BedController
   {
        public BedController(BedService bedService)
        {
            this.bedService = bedService;
        }

        public Bed AddBed(Bed bed) => bedService.AddBed(bed);
        public bool DeleteBed(Bed bed) => bedService.DeleteBed(bed);
        public IEnumerable<Bed> GetAllBeds() => bedService.GetAllBeds();

        public Bed GetBed(int bedId) => bedService.GetBed(bedId);
        public IEnumerable<Bed> GetAllFreeBedsInPeriod(DateTime startDate, DateTime endDate) => bedService.GetAllFreeBedsInPeriod(startDate, endDate);
        public IEnumerable<Bed> GetBedsByRoomNumber(int roomNumber) => bedService.GetBedsByRoomNumber(roomNumber);
        public bool OccupyBed(Bed bed, Occupation occupation) => bedService.OccupyBed(bed, occupation);
        public bool FreeBed(Bed bed, DateTime startDate, DateTime endDate) => bedService.FreeBed(bed, startDate, endDate);

        public BedService bedService;

    }
}