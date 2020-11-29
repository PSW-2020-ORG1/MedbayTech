﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using Backend.Users.Repository.MySqlRepository;
using Backend.Records.Repository.MySqlRepository;

namespace Repository
{
    public class UnitOfWork : IDisposable 
    {

        private MySqlContext context = new MySqlContext();

        private FeedbackSqlRepository feedbackRepository;
        private MedicalRecordSqlRepository medicalRecordRepository;

        public FeedbackSqlRepository FeedBackRepository
        {
            get
            {
                if (this.feedbackRepository == null)
                {
                    this.feedbackRepository = new FeedbackSqlRepository(context);

                }
                return this.feedbackRepository;
            }
        }

        public MedicalRecordSqlRepository MedicalRecordRepository 
        {
            get
            {
                if (this.medicalRecordRepository == null)
                {
                    this.medicalRecordRepository = new MedicalRecordSqlRepository(context);
                }
                return this.medicalRecordRepository;
            }
        }
        /// <summary>
        /// Saves all changes to database
        /// </summary>
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
