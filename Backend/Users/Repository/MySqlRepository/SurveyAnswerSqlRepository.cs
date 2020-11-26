using Backend.Users.Model;
using Model;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class SurveyAnswerSqlRepository : MySqlrepository<SurveyAnswer, int>,
        ISurveyAnswerRepository
    {
        public SurveyAnswerSqlRepository(MySqlContext context) : base(context) { }

       
    }
}
