using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CustomersApp.Models;


namespace CustomersApp.DAL
{
    public class CustomersAppDBContext : DbContext
    {


        public CustomersAppDBContext() : base ("CustomersAppDBContext")
        {

        }

        public DbSet<Main_Customer> MainCustomers { get; set; }
        public DbSet<Sub_Customer> SubCustomers { get; set; }


     

    }
}