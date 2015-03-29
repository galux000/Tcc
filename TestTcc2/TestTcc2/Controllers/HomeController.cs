using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTcc2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
  
            ViewBag.UserType = TempData["UserType"];
            return View();
        }

        public ActionResult IndexMusico() 
        {
            ViewBag.Message = "Bem vindo a sua página como Músico";
            return View();
        }

        public ActionResult IndexOuvinte()
        {
            ViewBag.Message = "Bem vindo a sua página como Ouvinte";
            return View();
        }
    }
}
