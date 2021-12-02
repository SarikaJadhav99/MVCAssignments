using NetBankingApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace NetBankingApp.Controllers
{
    public class LoginController : Controller
    {

        CustomerContext dbCustomer = new CustomerContext();

        public ActionResult Login() => View();
        
        public ActionResult AdminLogin() => View();
       
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            using (var db = new AdminContext())
            {
                if (db.AdminDetails.Any(a => a.UserName == admin.UserName && a.Password == admin.Password))
                    return RedirectToAction("Index", "Admin");
                else
                    return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult CustomerLogin() => View();
      
        [HttpPost]
        public ActionResult CustomerLogin(Customer customer)
        {
            try
            {
                var customerAccount = dbCustomer.CustomerData.Single(c => c.UserName == customer.UserName && c.Password == customer.Password);
                return RedirectToAction("Index", "Customer", customerAccount);
            }
            catch
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}