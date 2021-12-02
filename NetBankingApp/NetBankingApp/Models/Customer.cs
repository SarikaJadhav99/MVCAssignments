using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetBankingApp.Models
{
    [Table ("tblCustomer")]
    public class Customer
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        [Key]
        public int AccountNumber { get; set; }
        public Nullable <decimal> AccountBalance { get; set; }
    }
}