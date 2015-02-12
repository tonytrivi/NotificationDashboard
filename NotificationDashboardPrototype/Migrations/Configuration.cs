namespace NotificationDashboardPrototype.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using NotificationDashboardPrototype.Data;


    internal sealed class Configuration : DbMigrationsConfiguration<NotificationDashboardPrototype.Data.NotificationModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "NotificationDashboardPrototype.Data.NotificationModelContext";

            // with this, you can remove columns
            this.AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// Seed is triggered by database initialization, even if model hasn't changed
        /// </summary>
        /// <param name="dbContext"></param>
        protected override void Seed(NotificationDashboardPrototype.Data.NotificationModelContext dbContext)
        {
            // create a couple customers with servers and notifications
            var notifications = new List<StatusNotification> { 
                new StatusNotification{ ServerId=8, DateCreated=DateTime.Now, Message="The scan didn't detect any threats.", Status= StatusResult.Success, StatusType=StatusType.AntiVirus },
                new StatusNotification{ ServerId=8, DateCreated=DateTime.Now, Message="The backup completed.", Status= StatusResult.Success, StatusType=StatusType.Backup },
                new StatusNotification{ ServerId=8, DateCreated=DateTime.Now, Message="Nothing happened.", Status= StatusResult.Unknown, StatusType=StatusType.Backup },
                new StatusNotification{ ServerId=8, DateCreated=DateTime.Now, Message="The backup didn't complete.", Status= StatusResult.Failure, StatusType=StatusType.Backup }
            };
            
            var servers = new List<Server> { 
                new Server{ Name="Luke Skywalker SBS 2003", 
                            ServerId=8, 
                            ServerVersion=ServerVersion.WindowsServer2003,
                            Notifications=notifications, 
                            CustomerId=4
                            }     
            };


            var notifications2 = new List<StatusNotification> { 
                new StatusNotification{ ServerId=10, DateCreated=DateTime.Now, Message="No threats detected.", Status= StatusResult.Success, StatusType=StatusType.AntiVirus },
                new StatusNotification{ ServerId=10, DateCreated=DateTime.Now, Message="The backup is over.", Status= StatusResult.Success, StatusType=StatusType.Backup },
                new StatusNotification{ ServerId=10, DateCreated=DateTime.Now, Message="Nothing happened.", Status= StatusResult.Unknown, StatusType=StatusType.Backup },
                new StatusNotification{ ServerId=10, DateCreated=DateTime.Now, Message="I think there was a power outage.", Status= StatusResult.Failure, StatusType=StatusType.Backup }
            };

            var servers2 = new List<Server> { 
                new Server{ Name="Jabba", 
                            ServerId=10, 
                            ServerVersion=ServerVersion.WindowsServer2003,
                            Notifications=notifications2, 
                            CustomerId=3
                            }
            };

            var customers = new List<Customer> { 
                new Customer{Name="Isaiah Films",  
                                CustomerId=3, 
                                Servers=servers

                
                },
                new Customer{Name="Olivia Sings",  
                                CustomerId=4, 
                                Servers=servers2

                
                }
            
            };

            dbContext.Customers.AddOrUpdate(
                //checking for existing customer rows, by name
                c => new { c.Name }, customers.ToArray());

           
        }
    }
}
