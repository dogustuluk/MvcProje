using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager userProfile = new UserProfileManager();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Partial1(string mail)
        {
            mail = (string)Session["Mail"];
            var profilvalues = userProfile.GetAuthorByMail(mail);
            return PartialView(profilvalues);
        }
    }
}