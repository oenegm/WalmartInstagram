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

            ViewBag.animalscount = db.posts.Where(n => n.category.categoryID == 0).Count();
            ViewBag.artcount = db.posts.Where(n => n.category.categoryID == 1).Count();
            ViewBag.buildingsscount = db.posts.Where(n => n.category.categoryID == 2).Count();
            ViewBag.foodcount = db.posts.Where(n => n.category.categoryID == 4).Count();
            ViewBag.vehiclescount = db.posts.Where(n => n.category.categoryID == 5).Count();
            ViewBag.sportsscount = db.posts.Where(n => n.category.categoryID == 6).Count();
            ViewBag.landscount = db.posts.Where(n => n.category.categoryID == 7).Count();

            return View();
        }
    }
}