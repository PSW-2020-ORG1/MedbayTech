// File:    EmergencyRequestService.cs
// Author:  Vlajkov
// Created: Monday, May 18, 2020 1:37:20 AM
// Purpose: Definition of Class EmergencyRequestService

using Model.ExaminationSurgery;
using Repository.ExaminationRepository;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Service.ExaminationService
{
   public class EmergencyRequestService
   {
        public EmergencyRequestService(IEmergencyRequestRepository emergencyRequestRepository, NotificationService notificationService)
        {
            this.notificationService = notificationService;
            this.emergencyRequestRepository = emergencyRequestRepository;
        }
        public EmergencyRequest CreateEmergencyRequest(EmergencyRequest request)
        {
            notificationService.NewEmergencyRequest(request);
            return emergencyRequestRepository.Create(request);
        }
        public IEnumerable<EmergencyRequest> GetAllUnscheduled() => emergencyRequestRepository.GetAllUnScheduled();

        public EmergencyRequest GetEmergencyRequest(int id) => emergencyRequestRepository.GetObject(id);

        public EmergencyRequest UpdateEmergencyRequest(EmergencyRequest request) => emergencyRequestRepository.Update(request);
        public bool DeleteEmergencyRequest(EmergencyRequest request) => emergencyRequestRepository.Delete(request);
        
        public IEmergencyRequestRepository emergencyRequestRepository;
        public NotificationService notificationService;
   }
}