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
        instagramContext db = new instagramContext();
        public ActionResult signUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signUp(user s, HttpPostedFileBase img)
        {
            user d = db.users.Where(n => n.username == s.username).FirstOrDefault();
            if (d != null)
            {
                ViewBag.status = "Username aleardy exists!!";
                return View();

            }

            img.SaveAs(Server.MapPath("~/attach/pfp/" + img.FileName));
            s.profilePic = img.FileName;

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

        [HttpPost]
        public ActionResult signIn(user s)
        {
            user d = db.users.Where(n => n.username == s.username && n.password == s.password).FirstOrDefault();
            if (d != null)
            {
                Session.Add("username", d.username);
                return RedirectToAction("profile");
            }
            else
            {
                ViewBag.status = "incorrect username or password";
                return View();
            }
        }

        public ActionResult profile()
        {
            if (Session["username"] == null) return RedirectToAction("signIn");

            string id = (string)Session["username"];

            user s = db.users.Where(n => n.username == id).FirstOrDefault();
            return View(s);
        }

        public ActionResult logout()
        {
            Session["userid"] = null;
            Session["userid"] = null;
            return RedirectToAction("signIn");
        }
    }
}
