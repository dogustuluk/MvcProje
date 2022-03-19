using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        AuthorManager authormanager = new AuthorManager(new EFAuthorDal());

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = blogmanager.GetBlogById(id);
            return PartialView(authordetail);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = blogmanager.GetAll().Where(x => x.BlogId == id).Select(y => y.AuthorId).FirstOrDefault();
            var authorblogs = blogmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }

        public ActionResult AuthorList()
        {
            var authorlists = authormanager.GetList();
            return View(authorlists);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult results = authorValidator.Validate(p);
            if (results.IsValid)
            {
                authormanager.AuthorAdd(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();   
        }

        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authormanager.FindAuthor(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            authormanager.EditAuthor(p);
            return RedirectToAction("AuthorList");
        }
    }
}