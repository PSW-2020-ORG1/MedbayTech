// File:    FeedbackController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 3:00:05 AM
// Purpose: Definition of Class FeedbackController

using Model.Users;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.GeneralController
{
   public class FeedbackController
   {
        public FeedbackController(FeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        } 

        public Feedback CreateFeedback(Feedback feedback) => feedbackService.CreateFeedback(feedback);
        public IEnumerable<Feedback> GetAllFeedbacks() => feedbackService.GetAllFeedbacks();
        
        public FeedbackService feedbackService;
   
   }
}