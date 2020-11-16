/***********************************************************************
 * Module:  QuestionRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.QuestionRepository
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
   public class QuestionRepository : JSONRepository<Question, int>,
        IQuestionRepository, ObjectComplete<Question>
    {
        public IUserRepository userRepository;
        
        public QuestionRepository(IUserRepository userRepository, Stream<Question> stream) : base(stream, "Question")
        {
            this.userRepository = userRepository;
        }

        public new Question Create(Question entity)
        {
            SetMissingValues(entity);
            entity.Id = GetNextID();
            return base.Create(entity);
        }

        public new IEnumerable<Question> GetAll()
        {
            var allQuestions = base.GetAll().ToList();
            for (int i = 0; i < allQuestions.Count; i++)
            {
                CompleteObject(allQuestions[i]);
            }
            return allQuestions;
        }

        public new Question GetObject(int id)
        {
            var question = base.GetObject(id);
            CompleteObject(question);
            return question;
        }

        public new Question Update(Question entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        public IEnumerable<Question> GetFAQ()
        {
            var allQuestion = GetAll();
            List<Question> faq = new List<Question>();
            foreach (Question question in allQuestion)
            {
                if (question.FrequentlyAsked)
                {
                    faq.Add(question);
                }
            }
            return faq;
        }

        private int GetNextID() => stream.GetAll().ToList().Count + 1;

        public void CompleteObject(Question question)
        {
            question.Author = (Patient)userRepository.GetObject(question.Author.Username);
            if (question.QuestionReply.Author != null)
                question.QuestionReply.Author = (Doctor)userRepository.GetObject(question.QuestionReply.Author.Username);
        }

        public void SetMissingValues(Question entity)
        {
            entity.Author = new Patient(); 
            if (entity.QuestionReply.Author != null)
                entity.QuestionReply.Author = new Doctor();

        }
    }
}