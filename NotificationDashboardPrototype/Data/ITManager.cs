using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NotificationDashboardPrototype.Data
{
    public class ITManager
    {
        public int ITManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ITCompanyId { get; set; }

    }
}