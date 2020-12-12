using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class QuestionSqlRepository : MySqlrepository<Question, int>,
        IQuestionRepository
    {
        public IEnumerable<Question> GetFAQ()
        {
            return GetAll().ToList().Where(q => q.FrequentlyAsked == true);
        }
    }
}
