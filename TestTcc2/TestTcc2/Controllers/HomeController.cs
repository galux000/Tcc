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

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Usuario()
        {
            ViewBag.Message = "Usuario";
            return View();
        }

        public ActionResult Musico()
        {
            ViewBag.Message = "Musico";
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
