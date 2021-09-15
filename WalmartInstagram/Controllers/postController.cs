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
            string imgName = DateTime.Now.Year.ToString() + DateTime.Now.DayOfYear.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();  // change this shit
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
                return RedirectToAction("myposts");
            }

            return View();
        }

        public ActionResult myposts()
        {
            if (Session["username"] == null) return RedirectToAction("signIn", "user");

            string username = (string)Session["username"];
            List<post> ps = db.posts.Where(n => n.writerUsername == username).ToList();

            return View(ps);
        }

        public ActionResult allposts()
        {
            return View(db.posts.ToList());
        }

        public ActionResult details(int id)
        {
            post s = db.posts.Where(n => n.postID == id).FirstOrDefault();
            return View(s);
        }
    }
}