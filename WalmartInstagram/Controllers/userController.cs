using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WalmartInstagram.Models;

namespace WalmartInstagram.Controllers
{
    public class userController : Controller
    {
        // GET: user
        instagramContext db = new instagramContext();

        public ActionResult signUp(user s)
        {
            user d = db.users.Where(n => n.username == s.username).FirstOrDefault();
            if (d != null)
            {
                ViewBag.status = "username aleardy exist !!";
                return View();

            }

            if (ModelState.IsValid)
            {
                db.users.Add(s);
                db.SaveChanges();

                return RedirectToAction("signIn");
            }

            return View();
        }

        public ActionResult signIn()
        {
            return View();
        }
    }
}