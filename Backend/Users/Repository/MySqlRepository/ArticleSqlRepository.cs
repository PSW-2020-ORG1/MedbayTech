using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class ArticleSqlRepository : MySqlrepository<Article, int>,
        IArticleRepository
    {
        public IEnumerable<Article> GetArticlesWroteByDoctor(Doctor doctor)
        {
            return GetAll().ToList().Where(a => a.DoctorId.Equals(doctor.Id));
        }
    }
}
