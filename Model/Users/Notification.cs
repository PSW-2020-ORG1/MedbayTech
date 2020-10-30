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
        private int id;
        private string contentOfNotification;
        private NotificationCategory notificationCategory;
        private RegisteredUser notificationFrom;
        private List<RegisteredUser> notificationTo;


        public Notification() { }
        public Notification(int id) { }
        public Notification(string content, NotificationCategory category, RegisteredUser notificationFrom, List<RegisteredUser> notificationTo)
        {
            ContentOfNotification = content;
            NotificationCategory = category;
            NotificationTo = notificationTo;
            NotificationFrom = notificationFrom;
        }

        public int Id { get => id; set => id = value; }
        public string ContentOfNotification { get => contentOfNotification; set => contentOfNotification = value; }
        public NotificationCategory NotificationCategory { get => notificationCategory; set => notificationCategory = value; }
        public RegisteredUser NotificationFrom { get => notificationFrom; set => notificationFrom = value; }
        public List<RegisteredUser> NotificationTo { get => notificationTo; set => notificationTo = value; }

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