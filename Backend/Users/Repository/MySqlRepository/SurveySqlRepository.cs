using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class SurveySqlRepository : MySqlrepository<Survey, int>,
        ISurveyRepository
    {
    }
}
