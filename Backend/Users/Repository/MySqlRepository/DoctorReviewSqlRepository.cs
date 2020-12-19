using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class DoctorReviewSqlRepository : MySqlrepository<DoctorReview, int>,
        IDoctorReviewRepository
    {
        public DoctorReview Create(DoctorReview entity)
        {
            if(GetAll().ToList().FirstOrDefault(dr => dr.Id.Equals(entity.Id)) != null)
            {
                return null;
            }
            context.Add(entity);
            return entity;
        }

        public List<DoctorReview> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<DoctorReview> GetReviewsForDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
