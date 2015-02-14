using System;
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

        public Server GetServer(string serverName)
        {
            var server = _dbContext.Servers.FirstOrDefault(r => r.Name == serverName);

            return server;
        }

        public StatusNotification GetStatusNotification(int notificationId)
        {
            return _dbContext.StatusNotifications.FirstOrDefault(r => r.StatusNotificationId == notificationId);
        }

        public IQueryable<StatusNotification> GetStatusNotifications()
        {
            return _dbContext.StatusNotifications;
        }

        public IQueryable<StatusNotification> GetStatusNotificationsByServer(int serverId)
        {
            return _dbContext.StatusNotifications.Where(r => r.ServerId == serverId);
        }


        public bool Save()
        {
            try 
            {
               return  _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex) 
            {
                //TODO: log this error
                return false;
            }
        }

        public bool AddStatusNotification(StatusNotification newStatusNotification)
        {
            try
            {
                _dbContext.StatusNotifications.Add(newStatusNotification);
                return true;
            }
            catch (Exception ex)
            {
                //TODO: log this error
                return false;
            }
        }
    }
}