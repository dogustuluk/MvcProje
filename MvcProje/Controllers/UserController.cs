using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        public ActionResult BlogList(string mail)
        {
            mail = (string)Session["Mail"];
            Context context = new Context();
            int id = context.Authors.Where(x => x.Mail == mail).Select(y => y.AuthorId).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);
            return View(blogs);
        }
    }
}