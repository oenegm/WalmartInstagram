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
            string imgName = DateTime.Now.Year.ToString() + DateTime.Now.DayOfYear.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string extention = img.ContentType.Contains("image/jpeg") ? ".jpg" : ".png";

            img.SaveAs(Server.MapPath("~/attach/postp/" + imgName + extention));
            n.picture = imgName + extention;
            n.writerUsername = (string)Session["username"];
            n.date = DateTime.Now;

            db.posts.Add(n);
            db.SaveChanges();

            return RedirectToAction("myposts");
        }

        public ActionResult myposts()
        {
            if (Session["username"] == null) return RedirectToAction("signIn", "user");

            string username = (string)Session["username"];
            List<post> ps = db.posts.Where(n => n.writerUsername == username).ToList();
            ps.Reverse();
            return View(ps);
        }

        public ActionResult allposts()
        {
            List<post> ps = db.posts.ToList();
            ps.Reverse();
            return View(ps);
        }

        public ActionResult details(int id)
        {
            post s = db.posts.Where(n => n.postID == id).FirstOrDefault();
            return View(s);
        }

        public ActionResult categories()
        {
            return View(db.categories.ToList());
        }
        public ActionResult specificCategory(string categoryName)
        {
            ViewBag.categoryName = categoryName;
            return View(db.posts.ToList());
        }
    }
}