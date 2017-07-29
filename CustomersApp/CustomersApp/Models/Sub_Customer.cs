using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomersApp.Models
{
    public class Sub_Customer
    {
        public int Id { get; set; }
        public string SubCustomerName { get; set; }
        public string SubCustomerEmail { get; set; }
        public string SubCustomerContactNumber { get; set; }

        public int Main_CustomerID { get; set; }

        public Main_Customer Main_Customer { get; set; }


    }
}