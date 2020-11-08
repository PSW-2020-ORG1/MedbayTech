using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Users;
using Repository.GeneralRepository;

namespace Repository.Interfaces.General
{
    public class FeedbackRepository : MySqlrepository<Feedback, int>
    {
        public FeedbackRepository(MySqlContext context) : base(context) {}
    }
}
