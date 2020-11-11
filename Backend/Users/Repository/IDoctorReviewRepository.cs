// File:    IDoctorReviewRepository.cs
// Author:  Vlajkov
// Created: Friday, May 29, 2020 4:15:45 AM
// Purpose: Definition of Interface IDoctorReviewRepository

using Model.Users;
using System;
using System.Collections.Generic;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
    public interface IDoctorReviewRepository : ICreate<DoctorReview>, IGetAll<DoctorReview>
    {
        IEnumerable<DoctorReview> GetReviewsForDoctor(Doctor doctor);
   }
}