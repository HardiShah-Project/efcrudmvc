using EFCRUDMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EFCRUDMVC.Controllers
{
    public class AccountController : Controller
    {
        private hardiContext db = new hardiContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //POST : Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tblLogin login)
        {
            bool isValid = db.Login.Any(x => x.UserName == login.UserName && x.Password == login.Password);
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(login.UserName, false);
                return RedirectToAction("Index", "User");
            }

            ModelState.AddModelError("", "Invalid UserName and Password");
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Include = "LoginId,UserName,Password,ConfirmPassword")] tblLogin tLogin)
        {
            if (ModelState.IsValid)
            {
                Login login = new Login();
                login.UserName = tLogin.UserName;
                login.Password = tLogin.Password;

                db.Login.Add(login);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}