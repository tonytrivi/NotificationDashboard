using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotificationDashboardPrototype.Data
{
    public class StatusNotification
    {
        public int StatusNotificationId { get; set; }
        // couldn't use enums until .NET 4.5
        public StatusType StatusType { get; set; }
        public StatusResult Status { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        //public int ITManagerId { get; set; }
        
        // Julie Lerman recommends foreign key and nav property for EF
        public int ServerId { get; set; }
        public virtual Server Server { get; set; }
        
        //public virtual ITManager ITManager { get; set; }

    }

    public enum StatusResult
    {
        Success = 1,
        Failure = 2,
        Unknown = 3

    }

    public enum StatusType
    {
        Backup = 1,
        AntiVirus = 2,
        Storage = 3

    }
 
}
