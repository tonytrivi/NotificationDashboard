﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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
            var servers = _dbContext.Servers
                .Include(s => s.Notifications);

            return servers;
        }

        public IQueryable<StatusNotification> GetStatusNotificationsByServer(int serverId)
        {
            return _dbContext.StatusNotifications.Where(r => r.ServerId == serverId);
        }
    }
}