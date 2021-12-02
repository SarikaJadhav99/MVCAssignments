using System.Data.Entity;

namespace NetBankingApp.Models
{
    public class AdminContext : DbContext
    {
        public AdminContext() : base("AdminConnection")
        {

        }

        public DbSet<Admin> AdminDetails { get; set; }
    }
}