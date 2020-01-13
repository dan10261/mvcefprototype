using mvcEFprototype.Filters;
using mvcEFprototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcEFprototype.Controllers
{
    
    public class AccountsController : Controller
    {
        // GET: Accounts/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // POST: Accounts
        [HttpPost]
        public ActionResult Login(Account account)
        {
            if (!ModelState.IsValid)
            { 
                return View(); 
            }
            else
            {
                if (account.UserName == "Test" && account.Password == "Test")
                {
                    Session["UserId"] = Guid.NewGuid();//Setting User session
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt");
                    return View(account);
                }
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login");
        }
    }
}