using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WalmartInstagram.Models;

namespace WalmartInstagram.Controllers
{
    public class adminController : Controller
    {
        instagramContext db = new instagramContext();
        public ActionResult dashboard()
        {
            if ((string)Session["username"] != "admin") return RedirectToAction("signIn", "user");

            ViewBag.userscount = db.users.Count() - 1;
            ViewBag.postscount = db.posts.Count();

            List<category> cs = db.categories.ToList();
            return View(cs);
        }
        // do this
        public ActionResult usersBrief()
        {
            return View();
        }
    }
}