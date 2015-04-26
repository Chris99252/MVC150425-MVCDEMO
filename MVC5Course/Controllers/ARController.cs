using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
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

        public ActionResult File1()
        {
            byte[] content = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/Pic1.png"));

            return File(content,"image/png");
        }

        public ActionResult File2()
        {
            return File(Server.MapPath("~/Content/Pic1.png"), "image/png");
        }

        public ActionResult File3(string url)
        {
            var wc = new WebClient();

            var content = wc.DownloadData(url);

            return File(content, "image/png");
        }

        public ActionResult File4()
        {
            return File(Server.MapPath("~/Content/File4.html"), "text/plain");
        }

        public ActionResult File5( )
        {
            byte[] content = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/Pic1.png"));

            return File(content, "image/png", "File5.png");
        }

        public ActionResult JavaScript1()
        {
            return JavaScript("alert('JS')");
        }

        public ActionResult Json1()
        {
            db.Configuration.LazyLoadingEnabled = false;

            var data = db.Product.Take(10);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}