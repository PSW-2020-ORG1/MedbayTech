/***********************************************************************
 * Module:  FeedbackSqlRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.FeedbackSqlRepository
 ***********************************************************************/

using Model.Users;
using Repository.UserRepository;
using Backend.General.Model;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Backend.Users.Repository.MySqlRepository
{
    public class FeedbackRepository : IFeedbackRepository, ObjectComplete<Feedback>
    {
        public IUserRepository userRepository;
        public Stream<Feedback> stream;
        private const string NOT_FOUND = "Feedback with ID number {0} does not exist!";
        private const string ALREADY_EXISTS = "Feedback with ID number {0} already exists!";

        public FeedbackRepository(IUserRepository userRepository, Stream<Feedback> stream)
        {
            this.userRepository = userRepository;
            this.stream = stream;
        }

        public Feedback Create(Feedback entity)
        {
            if (!ExistsInSystem(entity.Id))
            {
                if (!UserReviewAlreadyExist(entity))
                {
                    var allFeedbacks = stream.GetAll().ToList();
                    entity.Id = GetNextID();
                    SetMissingValues(entity);
                    allFeedbacks.Add(entity);
                    stream.SaveAll(allFeedbacks);
                    return entity;
                }
                else
                    return null;
            }
            else
            {
                throw new EntityAlreadyExists(string.Format(ALREADY_EXISTS, entity.Id));
            }
        }

        public Feedback GetObject(int id)
        {
            if (ExistsInSystem(id))
            {
                var feedback = stream.GetAll().SingleOrDefault(entity => entity.Id.CompareTo(id) == 0);
                CompleteObject(feedback);
                return feedback;
            }
            else
            {
                throw new EntityNotFound(string.Format(NOT_FOUND, id));
            }
        }

        public IEnumerable<Feedback> GetAll()
        {
            var allFeedbacks = stream.GetAll().ToList();
            for (int i = 0; i < allFeedbacks.Count; i++)
            {
                CompleteObject(allFeedbacks[i]);
            }
            return allFeedbacks;
        }
        private int GetNextID() => stream.GetAll().ToList().Count + 1;
        private bool ExistsInSystem(int id)
        {
            var allAddresses = stream.GetAll().ToList();
            return allAddresses.Any(item => item.Id == id);
        }
        private bool UserReviewAlreadyExist(Feedback entity)
        {
            var allFeedbacks = stream.GetAll().ToList();
            foreach (Feedback f in allFeedbacks)
            {
                if (f.RegisteredUser.Username.Equals(entity.RegisteredUser.Username))
                {
                    return true;
                }
            }
            return false;
        }
        public void CompleteObject(Feedback feedback)
        {
            feedback.RegisteredUser = userRepository.GetByUsername(feedback.RegisteredUser.Username);
        }
        public void SetMissingValues(Feedback entity)
        {
            entity.RegisteredUser = new RegisteredUser();
        }

        IEnumerable<Feedback> IFeedbackRepository.GetAllApprovedFeedback()
        {
            throw new NotImplementedException();
        }

        bool IFeedbackRepository.UpdateStatus(int feedbackId, bool status)
        {
            throw new NotImplementedException();
        }

        int IFeedbackRepository.GetLastId()
        {
            throw new NotImplementedException();
        }

        public bool CheckIfExists(Feedback feedback)
        {
            throw new NotImplementedException();
        }

    }
}