﻿using System.Web.Mvc;

namespace ShopAssisst2.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}