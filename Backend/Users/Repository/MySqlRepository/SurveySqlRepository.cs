using Model;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    class SurveySqlRepository : MySqlrepository<Survey, int>,
        ISurveyRepository
    {
        public SurveySqlRepository(MySqlContext context) : base(context) { }
        public int GetLastId()
        {
            int id;
            if (GetAll() == null)
            {
                id = 1;
            }
            else
            {
                Survey survey = GetAll().Last();
                id = survey.Id;
            }
            return id;
        }
    }
}
