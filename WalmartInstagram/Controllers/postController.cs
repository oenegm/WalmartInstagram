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
        public ActionResult add()
        {
            if (Session["username"] == null) return RedirectToAction("signIn", "user");

            SelectList st = new SelectList(db.categories.ToList(), "id", "name");
            ViewBag.cat = st;

            return View();
        }
        [HttpPost]
        public ActionResult add(post n, HttpPostedFileBase img)
        {
            img.SaveAs(Server.MapPath($"~/attach/postp/{img.FileName}"));

            n.picture = $"/attach/newsphoto/postp/{img.FileName}";
            n.writerUsername = (string)Session["username"];
            //n.date = DateTime.Now;

            db.posts.Add(n);
            db.SaveChanges();
            return RedirectToAction("mynews");
        }
    }
}