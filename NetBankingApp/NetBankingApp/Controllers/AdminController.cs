using NetBankingApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace NetBankingApp.Controllers
{
    public class AdminController : Controller
    {
        CustomerContext DbCustomer = new CustomerContext();

        public ViewResult Index() => View();
        
        public ActionResult CustomerDetails() => View(DbCustomer.CustomerData.ToList());
       
        public ActionResult AddCustomer() => View();
      
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            DbCustomer.CustomerData.Add(customer);
            DbCustomer.SaveChanges();

            return RedirectToAction("CustomerDetails");
        }

        public ActionResult ViewCustomer(int id)
        {
            var customer = DbCustomer.CustomerData.Find(id);
            return View(customer);
        }

        public ActionResult AddBalance(int id)
        {
            var customer = DbCustomer.CustomerData.Find(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult AddBalance(Customer updateCustomer)
        {
            var customer = DbCustomer.CustomerData.Find(updateCustomer.AccountNumber);

            customer.AccountBalance += updateCustomer.AccountBalance;
            DbCustomer.SaveChanges();

            return RedirectToAction("CustomerDetails", customer);
        }

        public ActionResult DisplayBalanceErr() => View();
       
        public ActionResult DeleteAccount(int id)
        {
            var customer = DbCustomer.CustomerData.Find(id);

            if (customer.AccountBalance != 0)
                return RedirectToAction("DisplayBalanceErr");

            return View(customer);
        }

        [HttpPost]
        [ActionName("DeleteAccount")]
        public ActionResult RemoveAccount(int id)
        {
            var customer = DbCustomer.CustomerData.Find(id);
            DbCustomer.CustomerData.Remove(customer);

            UpdateModel(customer);
            DbCustomer.SaveChanges();

            return RedirectToAction("CustomerDetails");
        }
    }
}