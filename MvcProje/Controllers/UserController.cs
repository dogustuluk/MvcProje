using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager userProfile = new UserProfileManager(new EFUserProfileManagerDal(), new EFBlogDal(), new EFAuthorDal());
        BlogManager blogmanager = new BlogManager(new EFBlogDal());
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
        public ActionResult UpdateUserProfile(Author auth)
        {
            userProfile.TUpdate(auth);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string mail)
        {
            mail = (string)Session["Mail"];
            Context context = new Context();
            int id = context.Authors.Where(x => x.Mail == mail).Select(y => y.AuthorId).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);
            return View(blogs);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = blogmanager.GetByID(id);
            Context context = new Context();
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            List<SelectListItem> values2 = (from x in context.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();
            ViewBag.values = values;
            ViewBag.values2 = values2;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog updatedblog)
        {
            blogmanager.TUpdate(updatedblog);
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context context = new Context();
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            List<SelectListItem> values2 = (from x in context.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorId.ToString()
                                            }).ToList();
            ViewBag.values = values;
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);
            if (results.IsValid)
            {
                blogmanager.TAdd(blog);
                return RedirectToAction("BlogList");
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
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            if (User.IsInRole("A") | User.IsInRole("B"))
            {
                return RedirectToAction("AdminLogin", "Login");
            }
            else
            return RedirectToAction("AuthorLogin", "Login");
        }
        
    }
}