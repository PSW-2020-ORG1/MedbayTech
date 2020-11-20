// File:    VacationRequestService.cs
// Author:  Vlajkov
// Created: Thursday, May 14, 2020 2:53:06 AM
// Purpose: Definition of Class VacationRequestService

using Model.Users;
using Repository.UserRepository;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Service.UserService
{
   public class VacationRequestService
   {
        public int numberOfAllowedRequests;
        public IVacationRequestRepository vacationRequestRepository;
        public NotificationService notificationService;
        public VacationRequestService(IVacationRequestRepository vacationRequestRepository, NotificationService notificationService, int numberOfAllowedRequests)
        {
            this.vacationRequestRepository = vacationRequestRepository;
            this.notificationService = notificationService;
            this.numberOfAllowedRequests = numberOfAllowedRequests;
        }

        public VacationRequest GetVacationRequest(int id) => vacationRequestRepository.GetObject(id);
        private int GetNumberOfCurrentlyActiveVacations()
        {
            var allVacationRequests = vacationRequestRepository.GetAll();
            int CurrentlyActiveVacation = 0;
            foreach(VacationRequest vacationRequest in allVacationRequests)
            {
                if(vacationRequest.Approved==true && vacationRequest.Period.StartTime.CompareTo(DateTime.Today)<0)
                {
                    ++CurrentlyActiveVacation;
                }
            }
            return CurrentlyActiveVacation;
        }
      
        private int GetNumberOfActiveVacationsInPeriodOfTime(DateTime startDate, DateTime endDate)
        {
            var allVacationRequests = vacationRequestRepository.GetAll();
            int ActiveVacationsInPeriodOfTime = 0;
            foreach (VacationRequest vacationRequest in allVacationRequests)
            {
                if (vacationRequest.Approved == true && vacationRequest.Period.StartTime.CompareTo(startDate) <= 0 && vacationRequest.Period.EndTime.CompareTo(endDate) >= 0)
                {
                    ++ActiveVacationsInPeriodOfTime;
                }
            }
            return ActiveVacationsInPeriodOfTime;
        }
      
        public VacationRequest ApproveVacationRequest(VacationRequest request)
        {
            VacationRequest vacationRequest = request;
            vacationRequest.Approved = true;
            vacationRequestRepository.Update(request);
            return vacationRequest;
        }

        public VacationRequest UpdateVacationRequest(VacationRequest request) => vacationRequestRepository.Update(request);

        public VacationRequest SendVacationRequest(VacationRequest request)
        {
            VacationRequest fullRequest = request;
            vacationRequestRepository.Create(request);
            notificationService.NewVacationRequest(fullRequest.Employee);
            return request;
        }
      
        public VacationRequest RejectVacationRequest(VacationRequest request)
        {
            VacationRequest vacationRequest = request;
            vacationRequest.Approved = false;
            vacationRequestRepository.Update(request);
            return vacationRequest;
        }

        public IEnumerable<VacationRequest> GetAllUnapproved() => vacationRequestRepository.GetAllUnapproved();
      
        
   
   }
}