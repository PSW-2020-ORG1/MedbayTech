using Model;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    public class SurveySqlRepository : MySqlrepository<Survey, int>,
        ISurveyRepository
    {
        public SurveySqlRepository(MySqlContext context) : base(context) { }

        public bool CheckIfExistsById(int id)
        {
            foreach(Survey s in GetAll()) {
                if (s.AppointmentId == id) {
                    return false;
                }
            }
            return true;
        }

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
