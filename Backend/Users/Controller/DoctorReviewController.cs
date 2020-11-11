// File:    DoctorReviewController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 3:01:24 AM
// Purpose: Definition of Class DoctorReviewController

using Model.Users;
using Service.GeneralService;
using System;

namespace Backend.Examinations.Controller.GeneralController
{
   public class DoctorReviewController
   {
        public DoctorReviewController(DoctorReviewService doctorReviewService)
        {
            this.doctorReviewService = doctorReviewService;
        }

        public DoctorReview EvaluateDoctor(DoctorReview doctorReview) => doctorReviewService.EvaluateDoctor(doctorReview);

        public Grade GetGradeByDoctor(Doctor doctor) => doctorReviewService.GetAvgGradeByDoctor(doctor);
      
        public DoctorReviewService doctorReviewService;
   
   }
}