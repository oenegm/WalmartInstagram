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
        public ActionResult Index()
        {
            return View();
        }
    }
}