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
        public ActionResult Index(string mail)
        {
            mail = (string)Session["Mail"];
            var profilevalues = userProfile.GetAuthorByMail(mail);
            return View(profilevalues);
        }
    }
}