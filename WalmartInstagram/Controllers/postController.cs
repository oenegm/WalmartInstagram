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
            if (Session["username"] == null) return RedirectToAction("signIn", "user");

            SelectList st = new SelectList(db.categories.ToList(), "categoryID", "categoryName");
            ViewBag.cat = st;

            return View();
        }
        [HttpPost]
        public ActionResult addPost(post n, HttpPostedFileBase img)
        {
            string imgName = (db.posts.LastOrDefault().postID + 1).ToString(); // change this shit
            string extention = img.ContentType.Contains("image/jpg") ? ".jpg" :".png";

            img.SaveAs(Server.MapPath("~/attach/postp/" + imgName + extention));
            n.picture = imgName + extention;
            n.writerUsername = (string)Session["username"];
            n.date = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.posts.Add(n);
                db.SaveChanges();
                // change this to myposts later
                return RedirectToAction("profile", "user");
            }

            return View();
        }
    }
}