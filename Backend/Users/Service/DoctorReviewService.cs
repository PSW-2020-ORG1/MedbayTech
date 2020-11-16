// File:    DoctorReviewService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 10:26:09 PM
// Purpose: Definition of Class DoctorReviewService

using Model.Users;
using Backend.Users.Repository.MySqlRepository;
using System;
using System.Linq;

namespace Service.GeneralService
{
   public class DoctorReviewService
   {
        public DoctorReviewService(IDoctorReviewRepository doctorReviewRepository)
        {
            this.doctorReviewRepository = doctorReviewRepository;
        }

        public DoctorReview EvaluateDoctor(DoctorReview doctorReview) => doctorReviewRepository.Create(doctorReview);
      
        public Grade GetAvgGradeByDoctor(Doctor doctor)
        {
            var allReviews = doctorReviewRepository.GetReviewsForDoctor(doctor);
            int sum = 0;
            foreach (DoctorReview review in allReviews)
            {
                sum += (int)review.Grade;
            }
            double grade = Math.Floor((double)sum / (double) allReviews.ToList().Count);
            return gradeByDoubleValue(grade);
        }

        private Grade gradeByDoubleValue(double grade)
        {
            if (grade == 1) return Grade.excellent;
            else if (grade == 2) return Grade.veryGood;
            else if (grade == 3) return Grade.good;
            else if (grade == 4) return Grade.poor;
            else if (grade == 5) return Grade.veryPoor;
            else return Grade.poor;
        }

        public IDoctorReviewRepository doctorReviewRepository;
   
   }
}