using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{

#if !DEBUG
    [Authorize]
#endif
    public abstract class BaseController : Controller
    {
        protected FabricsEntities db = new FabricsEntities();

        protected ClientRepository repo = RepositoryHelper.GetClientRepository();

        protected OccupationRepository repoOccupation = RepositoryHelper.GetOccupationRepository();

        protected ProductRepository repoProduct = RepositoryHelper.GetProductRepository();

#if DEBUG
        public ActionResult Debug()
        {
            return View();
        }
#endif
    }
}