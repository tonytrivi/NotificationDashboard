using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationDashboardPrototype.Data
{
    public class NotificationDashboardRepository : INotificationDashboardRepository
    {
        NotificationModelContext _dbContext;

        public NotificationDashboardRepository(NotificationModelContext ctx)
        {
            _dbContext = ctx;
        }
        public IQueryable<Server> GetServers()
        {
            return _dbContext.Servers;
        }

        public IQueryable<StatusNotification> GetStatusNotificationsByServer(int serverId)
        {
            return _dbContext.StatusNotifications.Where(r => r.ServerId == serverId);
        }
    }
}