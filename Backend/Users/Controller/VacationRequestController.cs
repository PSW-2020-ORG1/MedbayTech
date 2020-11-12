// File:    VacationRequestController.cs
// Author:  ThinkPad
// Created: Wednesday, May 20, 2020 3:01:25 AM
// Purpose: Definition of Class VacationRequestController

using Model.Users;
using Service.UserService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.UserController
{
   public class VacationRequestController
   {
        public VacationRequestService vacationRequestService;
        public VacationRequestController(VacationRequestService vacationRequestService)
        {
            this.vacationRequestService = vacationRequestService;
        }

        public VacationRequest ApproveVacationRequest(VacationRequest request) => vacationRequestService.ApproveVacationRequest(request);
        public VacationRequest GetVacationRequest(int id) => vacationRequestService.GetVacationRequest(id);
        public VacationRequest UpdateVacationRequest(VacationRequest request) => vacationRequestService.UpdateVacationRequest(request);
        public VacationRequest SendVacationRequest(VacationRequest request) => vacationRequestService.SendVacationRequest(request);
        public VacationRequest RejectVacationRequest(VacationRequest request) => vacationRequestService.RejectVacationRequest(request);
        public IEnumerable<VacationRequest> GetAllUnapproved() => vacationRequestService.GetAllUnapproved();
      
        
   
   }
}