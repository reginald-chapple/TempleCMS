using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempleCMS.Web.Domain;

namespace TempleCMS.Web.Data.Repository
{
    public interface INotificationRepository
    {
        List<UserNotification> GetUserNotifications(string userId);
            void Create(Notification notification, string receiverId);
            void ReadNotification(int notificationId, string userId);
    }
}