// File:    INotificationRepository.cs
// Author:  Vlajkov
// Created: Sunday, May 24, 2020 12:23:36 AM
// Purpose: Definition of Interface INotificationRepository



using MedbayTech.Common.Repository;
using MedbayTech.Rooms.Domain;

namespace MedbayTech.Rooms.Application.Common.Interfaces.Persistance
{
   public interface INotificationRepository : IRepository<Notification,int>
   {
   }
}