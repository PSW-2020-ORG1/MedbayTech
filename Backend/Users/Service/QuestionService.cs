// File:    QuestionService.cs
// Author:  Vlajkov
// Created: Tuesday, May 19, 2020 10:17:49 PM
// Purpose: Definition of Class QuestionService

using Model.Users;
using Backend.Users.Repository.MySqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.GeneralService
{
   public class QuestionService
   {
        public QuestionService(IQuestionRepository questionRepository, NotificationService notificationService)
        {
            this.notificationService = notificationService;
            this.questionRepository = questionRepository;
        }

        public Question EditQuestion(Question question) => questionRepository.Update(question);
        public Question AskQuestion(Question question)
        {
            Question fullQuestion = question;
            questionRepository.Create(question);
            notificationService.QuestionNotification(fullQuestion);
            return question;
        }
        public Question AnswerQuestion(Question question, QuestionReply questionReply)
        {
            Question questionToUpdate = questionRepository.GetObject(question.Id);
            questionToUpdate.QuestionReply = questionReply;
            notificationService.QuestionReplyNotification(questionToUpdate);
            return questionRepository.Update(questionToUpdate);
        }
      
        public Question MoveToFAQ(Question question)
        {
            Question questionToUpdate = questionRepository.GetObject(question.Id);
            questionToUpdate.FrequentlyAsked = true;
            return questionRepository.Update(questionToUpdate);
        }
      
        public List<Question> GetUnansweredQuestions()
        {
            var allQuestions = questionRepository.GetAll().ToList();
            List<Question> unAnsweredQuestions = new List<Question>();
            foreach (Question question in allQuestions)
            {
                if (question.QuestionReply == null)
                {
                    unAnsweredQuestions.Add(question);
                }
            }
            return unAnsweredQuestions;
        }

        public List<Question> GetFAQ() => questionRepository.GetFAQ();

        public List<Question> GetAll() => questionRepository.GetAll();

        public bool DeleteQuestion(Question question) => questionRepository.Delete(question);
      
        public IQuestionRepository questionRepository;
        public NotificationService notificationService;
   
   }
}