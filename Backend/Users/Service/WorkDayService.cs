/***********************************************************************
 * Module:  ShiftService.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Service.ShiftService
 ***********************************************************************/

using Model.Users;
using Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Service.UserService
{
   public class WorkDayService
    {
        public int allowedWorkingHoursPerWeek;

        public IWorkDayRepository workDayRepository;
        public WorkDayService(IWorkDayRepository workDayRepository, int allowedWorkingHours)
        {
            this.workDayRepository = workDayRepository;
            this.allowedWorkingHoursPerWeek = allowedWorkingHours;
        }

        public WorkDay GetWorkDay(int id) => workDayRepository.GetObject(id);
        public List<WorkDay> GetAllByDate(DateTime date)
        {

            var allWorkDays = workDayRepository.GetAll();
            List<WorkDay> WorkDaysForDate = new List<WorkDay>();
            foreach (WorkDay day in allWorkDays)
            {
                if (day.Date.CompareTo(date)==0)
                {
                    WorkDaysForDate.Add(day);
                }
            }
            return WorkDaysForDate;
        }
        public bool DeleteWorkDay(WorkDay workDay) => workDayRepository.Delete(workDay);

        public WorkDay ChangeWorkDay(WorkDay workDay) => workDayRepository.Update(workDay);

        public WorkDay AddWorkDay(WorkDay workDay) => workDayRepository.Create(workDay);
      
        public List<WorkDay> GetAllByWeek(DateTime date)
        {
            var allWorkDays = workDayRepository.GetAll();
            List<WorkDay> WorkDaysForWeek = new List<WorkDay>();
            foreach(WorkDay day in allWorkDays)
            {
               if(IsInRangeOfWeek(date))
               {
                    WorkDaysForWeek.Add(day);
               }
            }
            return WorkDaysForWeek;
        }
      
        public bool IsInRangeOfWeek(DateTime date)
        {
            return date.CompareTo(DateTime.Today) == 0 || date.CompareTo(DateTime.Today.AddDays(7)) < 0 || date.CompareTo(DateTime.Today.AddDays(-7)) > 0;
        }
        public List<WorkDay> GetWorkingDoctorsForDay(DateTime date)
        {
            var allWorkDays = workDayRepository.GetAll();
            List<WorkDay> WorkingDoctorsForDay = new List<WorkDay>();
            foreach (WorkDay day in allWorkDays)
            {
                if (day.Date.CompareTo(date) == 0 && (day.Employee is Doctor))
                {
                    WorkingDoctorsForDay.Add(day);
                }
            }
            return WorkingDoctorsForDay;
        }
      
        public List<WorkDay> GetWorkingHoursForDoctor(Doctor doctor)
        {
            var allWorkDays = workDayRepository.GetAll();
            List<WorkDay> WorkingDaysForDoctor = new List<WorkDay>();
            foreach (WorkDay day in allWorkDays)
            {
                if (day.Employee.Equals(doctor))
                {
                    WorkingDaysForDoctor.Add(day);
                }
            }
            return WorkingDaysForDoctor;
        }

        public WorkDay GetWorkingHoursForDoctorByDay(Doctor doctor, DateTime day)
        {
            var allWorkDays = workDayRepository.GetWorkTimeForEmployee((Employee)doctor);
            
            foreach (WorkDay workDay in allWorkDays)
            {
                if (workDay.Date.Date.CompareTo(day.Date) == 0)
                {
                    return workDay;
                }
            }
            return null;
        }



    }
}