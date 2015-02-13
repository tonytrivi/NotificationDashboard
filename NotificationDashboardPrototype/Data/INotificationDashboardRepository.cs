using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationDashboardPrototype.Data
{
    public interface INotificationDashboardRepository
    {
        // with IQueryable, you can get paging and filtering
        IQueryable<Server> GetServers();
        IQueryable<StatusNotification> GetStatusNotifications();
        StatusNotification GetStatusNotification(int notificationId);
        IQueryable<StatusNotification> GetStatusNotificationsByServer(int serverId);
    }
}
