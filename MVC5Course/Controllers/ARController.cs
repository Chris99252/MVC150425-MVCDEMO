using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View("View1");
        }

        public ActionResult View1()
        {
            return View();
        }

        public ActionResult View2()
        {
            return PartialView();
        }

        public ActionResult Content1()
        {
            return Content("<script>alert('OK'); location.href='/';</script>","text/html");
        }

        public ActionResult Content2()
        {
            return View("Content2");
        }
    }
}