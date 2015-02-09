using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NotificationDashboardPrototype.Data
{
    public class Customer
    {
        private ICollection<Server> _servers;

        public Customer() 
        {
            // .NET pattern to avoid null exception
            _servers = new List<Server>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Server> Servers
        {
            get { return _servers; }
            set { _servers = value; }
        }

    }
}