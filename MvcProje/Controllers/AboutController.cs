using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Footer()
        {
            AboutManager abm = new AboutManager();
            var aboutcontent = abm.GetAll();
            return PartialView(aboutcontent);
        }

        public PartialViewResult MeetTheTeam()
        {
            return PartialView();
        }
    }
}