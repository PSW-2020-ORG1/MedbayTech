// File:    QuestionController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:59:40 AM
// Purpose: Definition of Class QuestionController

using Model.Users;
using Service.GeneralService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.GeneralController
{
   public class QuestionController
   {
        public QuestionController(QuestionService questionService)
        {
            this.questionService = questionService;
        }

        public Question EditQuestion(Question question) => questionService.EditQuestion(question);
        public Question AskQuestion(Question question) => questionService.AskQuestion(question);
        public Question AnswerQuestion(Question question, QuestionReply questionReply) => questionService.AnswerQuestion(question, questionReply);
        public Question MoveToFAQ(Question question) => questionService.MoveToFAQ(question);
        public IEnumerable<Question> GetUnansweredQuestions() => questionService.GetUnansweredQuestions();
        public IEnumerable<Question> GetFAQ() => questionService.GetFAQ();
        public IEnumerable<Question> GetAll() => questionService.GetAll();
        public bool DeleteQuestion(Question question) => questionService.DeleteQuestion(question);
        
        public QuestionService questionService;
   
   }
}