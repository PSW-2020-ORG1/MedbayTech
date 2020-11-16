// File:    RenovationController.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 11:48:13 PM
// Purpose: Definition of Class RenovationController

using Model.Rooms;
using Service.RoomService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.RoomController
{
   public class RenovationController
   {

        public RenovationController(RenovationService renovationService)
        {
            this.renovationService = renovationService;
        }

        public Renovation GetRenovation(int id) => renovationService.GetRenovation(id);
        public void MoveAllToStorage(Renovation renovation) => renovationService.MoveAllToStorage(renovation);
        public Renovation CreateNewRenovation(Renovation renovation) => renovationService.CreateNewRenovation(renovation);
        public Renovation EditRenovation(Renovation renovation) => renovationService.EditRenovation(renovation);
        public bool DeleteRenovation(Renovation renovation) => renovationService.DeleteRenovation(renovation);
        public IEnumerable<Renovation> GetRenovationsFromOneRoom(int roomNumber) => renovationService.GetRenovationsFromOneRoom(roomNumber);
        public IEnumerable<Renovation> GetActiveRenovations() => renovationService.GetActiveRenovations();

        public IEnumerable<Renovation> GetAllRenovations() => renovationService.GetAllRenovations();

        public RenovationService renovationService;
    }
}