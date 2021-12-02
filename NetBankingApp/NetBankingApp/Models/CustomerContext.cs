using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NetBankingApp.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() :base("AdminConnection")
        {

        }

        public DbSet<Customer> CustomerData{ get; set; }
    }
}