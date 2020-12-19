// File:    EmergencyRequestService.cs
// Author:  Vlajkov
// Created: Monday, May 18, 2020 1:37:20 AM
// Purpose: Definition of Class EmergencyRequestService

using Backend.Examinations.Model;
using Backend.Examinations.Repository;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Service
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
        public List<EmergencyRequest> GetAllUnscheduled() => emergencyRequestRepository.GetAllUnScheduled();

        public EmergencyRequest GetEmergencyRequest(int id) => emergencyRequestRepository.GetObject(id);

        public EmergencyRequest UpdateEmergencyRequest(EmergencyRequest request) => emergencyRequestRepository.Update(request);
        public bool DeleteEmergencyRequest(EmergencyRequest request) => emergencyRequestRepository.Delete(request);
        
        public IEmergencyRequestRepository emergencyRequestRepository;
        public NotificationService notificationService;
   }
}