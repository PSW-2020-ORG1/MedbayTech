// File:    FeedbackService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 10:29:25 PM
// Purpose: Definition of Class FeedbackService

using Model.Users;
using Backend.Users.Repository.MySqlRepository;
using System;
using System.Collections.Generic;

namespace Service.GeneralService
{
   public class FeedbackService
   {
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        public Feedback CreateFeedback(Feedback feedback) => feedbackRepository.Create(feedback);
        public IEnumerable<Feedback> GetAllFeedbacks() => feedbackRepository.GetAll();
        
        public IFeedbackRepository feedbackRepository;
   
   }
}