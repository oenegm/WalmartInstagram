using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WalmartInstagram.Models;

namespace WalmartInstagram.Controllers
{
    public class postController : Controller
    {
        instagramContext db = new instagramContext();
        public ActionResult addPost()
        {
            //if (Session["username"] == null) return RedirectToAction("signIn", "user");

            SelectList st = new SelectList(db.categories.ToList(), "categoryID", "categoryName");
            ViewBag.cat = st;

            return View();
        }
        [HttpPost]
        public ActionResult addPost(post n, HttpPostedFileBase img)
        {
            // error with repeated filename
            img.SaveAs(Server.MapPath("~/attach/postp/" + img.FileName));

            n.picture = "/attach/postp/" + img.FileName;
            n.writerUsername = (string)Session["username"];

            n.date = DateTime.Now;

            db.posts.Add(n);
            db.SaveChanges();
            // change this to myposts later
            return RedirectToAction("profile", "user");
        }
    }
}