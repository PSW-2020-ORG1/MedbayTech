/***********************************************************************
 * Module:  NotificationRepository.cs
 * Author:  Vlajkov
 * Purpose: Definition of the Class Repository.NotificationRepository
 ***********************************************************************/

using Model.Users;
using Repository.ReportRepository;
using Repository.UserRepository;
using SimsProjekat.Repository;
using SimsProjekat.SIMS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.GeneralRepository
{
   public class NotificationRepository : JSONRepository<Notification, int>,
        INotificationRepository, ObjectComplete<Notification>
    {
        public IUserRepository userRepository;
        public NotificationRepository(IUserRepository userRepository, Stream<Notification> stream) : base(stream, "Notification")
        {
            this.userRepository = userRepository;
        }

        public new Notification Create(Notification entity)
        {
            entity.Id = GetNextID();
            SetMissingValues(entity);
            return base.Create(entity);
        }

        public new IEnumerable<Notification> GetAll()
        {
            var allNotifications = base.GetAll().ToList();
            for (int i = 0; i < allNotifications.Count; i++)
            {
                CompleteObject(allNotifications[i]);
            }
            return allNotifications;
        }

        public new Notification GetObject(int id)
        {
            var notification = base.GetObject(id);
            CompleteObject(notification);
            return notification;
        }

        public new Notification Update(Notification entity)
        {
            SetMissingValues(entity);
            return base.Update(entity);
        }

        private int GetNextID() => stream.GetAll().ToList().Count + 1;

        public void CompleteObject(Notification entity)
        {
            if (entity.NotificationFrom != null)
                entity.NotificationFrom = userRepository.GetObject(entity.NotificationFrom.Username);
            for (int i = 0; i < entity.NotificationTo.Count; i++)
            {
                entity.NotificationTo[i] = userRepository.GetObject(entity.NotificationTo[i].Username);
            }
        }

        public void SetMissingValues(Notification entity)
        {
            if (entity.NotificationFrom != null)
                entity.NotificationFrom = new RegisteredUser(entity.NotificationFrom.Username);
            for(int i = 0; i < entity.NotificationTo.Count; i++)
            {
                entity.NotificationTo[i] = new RegisteredUser(entity.NotificationTo[i].Username);
            }
        }
    }
}