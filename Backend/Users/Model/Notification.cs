// File:    Notification.cs
// Author:  Vlajkov
// Created: Thursday, April 09, 2020 1:39:48 AM
// Purpose: Definition of Class Notification

using System;
using System.Collections.Generic;
using SimsProjekat.Repository;
namespace Model.Users
{
    public class Notification : IIdentifiable<int>
    {

        public int Id { get; set; }
        public string ContentOfNotification { get; set; }
        public int NotificationCategoryId { get; set; }
        public virtual NotificationCategory NotificationCategory { get; set; }
        public string NotificationFromRegisteredUserId { get; set; }
        public virtual RegisteredUser NotificationFrom { get; set; }
        public virtual List<RegisteredUser> NotificationTo { get; set; }


        public Notification() { }
        public Notification(int id) { }
        public Notification(string content, NotificationCategory category, RegisteredUser notificationFrom, List<RegisteredUser> notificationTo)
        {
            ContentOfNotification = content;
            NotificationCategory = category;
            NotificationTo = notificationTo;
            NotificationFrom = notificationFrom;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}