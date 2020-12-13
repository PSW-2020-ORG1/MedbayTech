using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Users.Repository.MySqlRepository
{
    public class NotificationSqlRepository : MySqlrepository<Notification, int>,
        INotificationRepository
    {
    }
}
