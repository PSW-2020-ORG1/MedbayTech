using Backend.Users.Model;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository
{
    public interface ISurveyAnswerRepository : ICreate<SurveyAnswer>, IGetAll<SurveyAnswer>
    {
    }
}
