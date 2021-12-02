using NetBankingApp.Models;
using System.Web.Mvc;

namespace NetBankingApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerContext DbCustomer = new CustomerContext();

        public ActionResult Index(Customer customer) => View(customer);

        public ActionResult DisplayBalanceErr() => View();

        public ActionResult DisplayNotFoundErr() => View();

        public ActionResult WithdrawAmount(int id)
        {
            var customer = DbCustomer.CustomerData.Find(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult WithdrawAmount(Customer updateCustomer)
        {
            var customer = DbCustomer.CustomerData.Find(updateCustomer.AccountNumber);

            if (customer.AccountBalance >= updateCustomer.AccountBalance && updateCustomer.AccountBalance >= 0)
            {
                customer.AccountBalance -= updateCustomer.AccountBalance;
                DbCustomer.SaveChanges();
                return RedirectToAction("Index", customer);
            }
            else
                return RedirectToAction("DisplayBalanceErr");
        }

        public ActionResult TransferAmount(int id)
        {
            var customer = DbCustomer.CustomerData.Find(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult TransferAmount(Customer sender, int receiverId)
        {
            var customer = DbCustomer.CustomerData.Find(sender.AccountNumber);
            var receiver = DbCustomer.CustomerData.Find(receiverId);

            if(sender.AccountBalance <= customer.AccountBalance && sender.AccountBalance >= 0)
            {
                if(receiver != null)
                {
                    customer.AccountBalance -= sender.AccountBalance;
                    receiver.AccountBalance += sender.AccountBalance;
                    DbCustomer.SaveChanges();
                }
                else
                {
                    return RedirectToAction("DisplayNotFoundErr", customer);
                }
                return RedirectToAction("Index", customer);
            }
            else
                return RedirectToAction("DisplayBalanceErr");
        }
    }
}