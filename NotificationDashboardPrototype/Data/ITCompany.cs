using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NotificationDashboardPrototype.Data
{
    public class ITCompany
    {
        private ICollection<ITManager> _itManagers { get; set; }

        public ITCompany() 
        {
            _itManagers = new List<ITManager>();
        }

        public int ITCompanyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ITManager> ITManagers 
        {
            get { return _itManagers; }
            set { _itManagers = value; }
        }
        

    }
}