using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    [AllowAnonymous]

    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutDal());
        public ActionResult Index()
        {
            var aboutcontent = abm.GetList();
            return View(aboutcontent);
        }

        public PartialViewResult Footer()
        {
          
            var aboutcontent = abm.GetList();
            return PartialView(aboutcontent);
        }

        public PartialViewResult MeetTheTeam()
        {
            AuthorManager autman = new AuthorManager(new EFAuthorDal());
            var authorlist = autman.GetList();
            return PartialView(authorlist);
        }

        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutlist = abm.GetList();
            return View(aboutlist);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            abm.TUpdate(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}