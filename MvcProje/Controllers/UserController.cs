﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
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
        BlogManager blogmanager = new BlogManager();
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
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = blogmanager.FindBlog(id);
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
            blogmanager.UpdateBlog(updatedblog);
            return RedirectToAction("BlogList");
        }
    }
}