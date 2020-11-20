// File:    WorkDayController.cs
// Author:  ThinkPad
// Created: Wednesday, May 20, 2020 3:00:30 AM
// Purpose: Definition of Class WorkDayController

using Model.Users;
using Service.UserService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.UserController
{
   public class WorkDayController
   {
        public WorkDayController(WorkDayService workDayService)
        {
            this.workDayService = workDayService;
        }

        public bool DeleteWorkDay(WorkDay workDay) => workDayService.DeleteWorkDay(workDay);
        public WorkDay ChangeWorkDay(WorkDay workDay) => workDayService.ChangeWorkDay(workDay);
        public WorkDay AddWorkDay(WorkDay workDay) => workDayService.AddWorkDay(workDay);

        public WorkDay GetWorkDay(int id) => workDayService.GetWorkDay(id);
        public IEnumerable<WorkDay> GetAllByWeek(DateTime date) => workDayService.GetAllByWeek(date);
        public IEnumerable<WorkDay> GetAllByDate(DateTime date) => workDayService.GetAllByDate(date);

        public IEnumerable<WorkDay> GetWorkingDoctorsForDay(DateTime date) => workDayService.GetWorkingDoctorsForDay(date);
        public IEnumerable<WorkDay> GetWorkingHoursForDoctor(Doctor doctor) => workDayService.GetWorkingHoursForDoctor(doctor);

        public WorkDayService workDayService;
   
   }
}