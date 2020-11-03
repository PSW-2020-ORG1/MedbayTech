using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository.GeneralRepository;

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
                    

                }

                return this.feedbackRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }




        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
