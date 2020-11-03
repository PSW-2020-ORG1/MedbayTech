using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Interfaces.General;

namespace Repository
{
    public class UnitOfWork : IDisposable
    {

        private MySqlContext context = new MySqlContext();

        private FeedbackRepository feedbackRepository;

        public FeedbackRepository FeedBackRepository
        {
            get
            {
                if (this.feedbackRepository == null)
                {
                    this.feedbackRepository = new FeedbackRepository(context);
                    ;

                }

                return this.feedbackRepository;
            }
        }






        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
