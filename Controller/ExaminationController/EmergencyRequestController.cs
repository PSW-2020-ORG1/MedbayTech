// File:    EmergencyRequestController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 3:29:31 AM
// Purpose: Definition of Class EmergencyRequestController

using Model.ExaminationSurgery;
using Service.ExaminationService;
using System;
using System.Collections.Generic;

namespace Controller.ExaminationController
{
   public class EmergencyRequestController
   {
        public EmergencyRequestController(EmergencyRequestService emergencyRequestService)
        {
            this.emergencyRequestService = emergencyRequestService;
        }

        public EmergencyRequest CreateEmergencyRequest(EmergencyRequest request) => emergencyRequestService.CreateEmergencyRequest(request);
        public IEnumerable<EmergencyRequest> GetAllUnscheduled() => emergencyRequestService.GetAllUnscheduled();
        public EmergencyRequest GetEmergencyRequest(int id) => emergencyRequestService.GetEmergencyRequest(id);
        public EmergencyRequest UpdateEmergencyRequest(EmergencyRequest request) => emergencyRequestService.UpdateEmergencyRequest(request);
        public bool DeleteEmergencyRequest(EmergencyRequest request) => emergencyRequestService.DeleteEmergencyRequest(request);

        public EmergencyRequestService emergencyRequestService;
     
   }
}