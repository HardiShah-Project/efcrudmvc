using EFCRUDMVC;
using EFCRUDMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Linq.Expressions;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Security;

namespace EFCRUDMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private hardiContext db = new hardiContext();    

        public ActionResult Index()
        {
            var users = (from x in db.Users
                         join y in db.Login on x.LoginId equals y.LoginId
                         where x.Name == y.UserName
                         select new tblUsers
                         {
                             UserId = x.UserId,
                             LoginId = x.LoginId,
                             Name = x.Name,
                             Gender = x.Gender,
                             City = x.City,
                             BirthDate = x.BirthDate,
                             Email = x.Email,
                             PhoneNo = x.PhoneNo,
                             Privacy = x.Privacy,

                         }).ToList();
            //List<Users> users = new List<Users>();
            //users = db.Users.ToList();
             return View(users);
            //return View(db.Users.ToList());
        }
        public JsonResult GetListInfo()
        {
            List<Users> users = new List<Users>();
            users = db.Users.ToList();

            //return Info as json  
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        // GET : Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsers users = (from c in db.Users
                              where c.UserId == Id
                              select new tblUsers
                              {
                                  UserId = c.UserId,
                                  Name = c.Name,
                                  Gender = c.Gender,
                                  City = c.City,
                                  BirthDate = c.BirthDate,
                                  Email = c.Email,
                                  PhoneNo = c.PhoneNo,
                                  Privacy = c.Privacy,

                              }).FirstOrDefault();
            // db.Users.Find(Id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        //POST : Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Gender,BirthDate,City,Email,PhoneNo,Privacy")] tblUsers tUsers)
        {
            if (ModelState.IsValid)
            {
                Login Login = db.Login.Where(x=> x.UserName == User.Identity.Name).SingleOrDefault();
                Users Users = new Users();
                Users.LoginId = Login != null ? Login.LoginId : 0;
                Users.Name = tUsers.Name;
                Users.Gender = tUsers.Gender;
                Users.Name = tUsers.Name;
                Users.BirthDate = tUsers.BirthDate;
                Users.City = tUsers.City;
                Users.Gender = tUsers.Gender;
                Users.Email = tUsers.Email;
                Users.PhoneNo = tUsers.PhoneNo;
                Users.Privacy = tUsers.Privacy;

                db.Users.Add(Users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //return View(tUsers);
            return Json(tUsers, JsonRequestBehavior.AllowGet);
        }

        //GET: Users/Edit/5
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //db.Users.Find(Id);
            tblUsers users = (from c in db.Users
                           where c.UserId == Id
                           select new tblUsers
                           {
                               UserId = c.UserId,
                               Name = c.Name,
                               Gender = c.Gender,
                               City = c.City,
                               BirthDate = c.BirthDate,
                               Email = c.Email,
                               PhoneNo = c.PhoneNo,
                               Privacy = c.Privacy,

                           }).FirstOrDefault();
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        //POST : Users/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "UserId,Name,Gender,City,BirthDate,Email,PhoneNo,Privacy")] tblUsers tUsers)
        {
           // return Json(db.Users.Update(tUsers), JsonRequestBehavior.AllowGet);
            if (ModelState.IsValid)
            {
                Users users = new Users()
                {
                    UserId = tUsers.UserId,
                    Name = tUsers.Name,
                    Gender = tUsers.Gender,
                    City = tUsers.City,
                    BirthDate = tUsers.BirthDate,
                    Email = tUsers.Email,
                    PhoneNo = tUsers.PhoneNo,
                    Privacy = tUsers.Privacy,

                };

                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //return View(tUsers);
            return Json(tUsers, JsonRequestBehavior.AllowGet);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Users users = db.Users.Find(id);
            tblUsers users = (from c in db.Users
                           where c.UserId == id
                           select new tblUsers
                           {
                               UserId = c.UserId,
                               Name = c.Name,
                               Gender = c.Gender,
                               City = c.City,
                               BirthDate = c.BirthDate,
                               Email = c.Email,
                               PhoneNo = c.PhoneNo,
                               Privacy = c.Privacy,

                           }).FirstOrDefault();
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            // tblUsers users = db.Users.Find(Id);
            Users user = db.Users.SingleOrDefault(x => x.UserId == Id);

            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}