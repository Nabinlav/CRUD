using CRUDapplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDapplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        StudentDBEntities1 db = new StudentDBEntities1();
        public ActionResult Index()
        {
            return View(db.tblUsers.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblUser tb)
        {
            db.tblUsers.Add(tb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(db.tblUsers.Where(u=>u.UserId==id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(tblUser tb)
        {
            tblUser edt = db.tblUsers.Where(u => u.UserId == tb.UserId).FirstOrDefault();
            edt.UserName = tb.UserName;
            edt.Email = tb.Email;
            edt.Password = tb.Password;
            edt.Contact = tb.Contact;
            edt.Address = tb.Address;
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(db.tblUsers.Where(u => u.UserId == id).FirstOrDefault());
        }
        public ActionResult Delete(int id)
        {
            return View(db.tblUsers.Where(u => u.UserId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(tblUser tb,int id)
        {
             tb = db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            db.tblUsers.Remove(tb);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}