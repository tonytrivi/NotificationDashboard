using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NotificationDashboardPrototype.Data;

namespace NotificationDashboardPrototype.DataLayer
{
    class NotificationModelContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<StatusNotification> StatusNotifications { get; set; }

        public DbSet<ITCompany> ITCompanies { get; set; }
        public DbSet<ITManager> ITManagers { get; set; }
        
        
    }
}
