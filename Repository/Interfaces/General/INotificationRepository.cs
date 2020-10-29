// File:    INotificationRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:23:36 AM
// Purpose: Definition of Interface INotificationRepository

using Model.Users;
using System;

namespace Repository.GeneralRepository
{
   public interface INotificationRepository : IRepository<Notification,int>
   {
   }
}