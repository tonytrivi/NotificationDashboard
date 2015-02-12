using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace NotificationDashboardPrototype.Data
{
    public class Server
    {
        private ICollection<StatusNotification> _notifications;

        public Server() 
        {
            _notifications = new List<StatusNotification>();
        }

        public int ServerId { get; set; }
        public string Name { get; set; }
        //public DbGeography LocationLatLong { get; set; }
        public ServerVersion ServerVersion { get; set; }
        public int CustomerId { get; set; }
       

        public virtual ICollection<StatusNotification> Notifications 
        {
            get { return _notifications; }
            set { _notifications = value; }
        }
    }

    public enum ServerVersion
    {
        WindowsServer2003 = 1,
        WindowsServer2008 = 2,
        WindowsServer2012 = 3

    }
}