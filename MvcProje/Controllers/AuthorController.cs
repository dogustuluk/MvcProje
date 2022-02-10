using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogmanager = new BlogManager();
        AuthorManager authormanager = new AuthorManager();
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = blogmanager.GetBlogById(id);
            return PartialView(authordetail);
        }

        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = blogmanager.GetAll().Where(x => x.BlogId == id).Select(y => y.AuthorId).FirstOrDefault();
            var authorblogs = blogmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }

        public ActionResult AuthorList()
        {
            var authorlists = authormanager.GetAll();
            return View(authorlists);
        }
    }
}