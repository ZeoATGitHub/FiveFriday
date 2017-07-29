using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CustomersApp.Models
{
    public class Main_CustomerDTO
    {

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonNumber { get; set; }

        public List<Sub_Customer> SubCustomers { get; set; }
    }
}