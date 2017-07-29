namespace CustomersApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CustomersApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomersApp.DAL.CustomersAppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CustomersApp.DAL.CustomersAppDBContext context)
        {
            context.MainCustomers.AddOrUpdate(x => x.Id,

              new Main_Customer() { CustomerName = "Makro", Description = "We sell overpriced stuff", Address = "1234 Bond Street, Sandton", Lat = "12.02.01.45", Long = "14.12.15.25", ContactPersonName = "Bruce Wanye", ContactPersonNumber = "0825557777" },
              new Main_Customer() { CustomerName = "Toys r Us", Description = "Toys toys and more toys", Address = "666 Bangla Road, Phukhet", Lat = "66.02.04.12", Long = "49.55.75.12", ContactPersonName = "Clark Kent", ContactPersonNumber = "0114558787" },
              new Main_Customer() { CustomerName = "Incredible Corruption", Description = "Nice gadgets, high prices", Address = "12 Sanza Street, The North", Lat = "66.02.04.12", Long = "49.55.75.12", ContactPersonName = "Jon Snow", ContactPersonNumber = "0125454544" }
         );


            context.SubCustomers.AddOrUpdate(x => x.Id,
                new Sub_Customer() { Main_CustomerID = 1, SubCustomerName = "Ramsey", SubCustomerEmail = "ramseyBolton@makro.co.za", SubCustomerContactNumber = "0415558787" },
                new Sub_Customer() { Main_CustomerID = 1, SubCustomerName = "Chester", SubCustomerEmail = "chesterB@@makro.co.za", SubCustomerContactNumber = "0115458788" },
                new Sub_Customer() { Main_CustomerID = 1, SubCustomerName = "Mike", SubCustomerEmail = "MikeS@makro.co.za", SubCustomerContactNumber = "0125659898" },
                new Sub_Customer() { Main_CustomerID = 2, SubCustomerName = "Drake", SubCustomerEmail = "drake@toysrus.co.za", SubCustomerContactNumber = "0111145858" },
                new Sub_Customer() { Main_CustomerID = 2, SubCustomerName = "Grim", SubCustomerEmail = "grim@toysrus.co.za", SubCustomerContactNumber = "0825548787" },
                new Sub_Customer() { Main_CustomerID = 2, SubCustomerName = "Denearis", SubCustomerEmail = "modragons@toysrus.co.za", SubCustomerContactNumber = "0835698987" },
                new Sub_Customer() { Main_CustomerID = 3, SubCustomerName = "Cercei", SubCustomerEmail = "CC@IC.co.za", SubCustomerContactNumber = "0829899999" },
                new Sub_Customer() { Main_CustomerID = 3, SubCustomerName = "Tyrin", SubCustomerEmail = "TL@IC.co.za", SubCustomerContactNumber = "0119898788" },
                new Sub_Customer() { Main_CustomerID = 3, SubCustomerName = "White Walker", SubCustomerEmail = "ww@IC.co.za", SubCustomerContactNumber = "0136565487" }

            );
        }
    }
}
