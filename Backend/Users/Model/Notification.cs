// File:    Notification.cs
// Author:  Vlajkov
// Created: Thursday, April 09, 2020 1:39:48 AM
// Purpose: Definition of Class Notification

using System;
using System.Collections.Generic;
using Backend.General.Model;
namespace Model.Users
{
    public class Notification : IIdentifiable<int>
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public virtual NotificationCategory NotificationCategory { get; set; }
        public string RegisteredUserId { get; set; }
        public virtual RegisteredUser RegisteredUser { get; set; }
        public virtual List<RegisteredUser> NotificationTo { get; set; }


        public Notification() { }

        public Notification(string content, NotificationCategory category, RegisteredUser registeredUser)
        {
            Content = content;
            NotificationCategory = category;
            RegisteredUser = registeredUser;
            RegisteredUserId = registeredUser.Id;
        }
        public Notification(int id, string content, NotificationCategory category, RegisteredUser registeredUser)
        {
            Id = id;
            Content = content;
            NotificationCategory = category;
            RegisteredUser = registeredUser;
            RegisteredUserId = registeredUser.Id;
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