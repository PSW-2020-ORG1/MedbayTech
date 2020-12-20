using Model.Users;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Users.Repository.MySqlRepository
{
    class ArticleSqlRepository : MySqlrepository<Article, int>,
        IArticleRepository
    {
        public List<Article> GetArticlesWroteByDoctor(Doctor doctor)
        {
            return GetAll().ToList().Where(a => a.DoctorId.Equals(doctor.Id)).ToList();
        }
    }
}
