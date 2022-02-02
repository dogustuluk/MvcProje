﻿using BusinessLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult BlogList(int page = 1)
        {
            var bloglist = bm.GetAll().ToPagedList(page,6);
            return PartialView(bloglist);
        }

        public PartialViewResult FeaturedPost()
        {
            //1.post
            var posttitle1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate1 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.blogdate1 = blogdate1;

            //2.post
            var posttitle2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate2 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.blogdate2 = blogdate2;

            //3.post
            var posttitle3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate3 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 6).Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.blogdate3 = blogdate3;

            //4.post
            var posttitle4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate4 = bm.GetAll().OrderByDescending(z => z.BlogDate).Where(x => x.CategoryId == 3).Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.blogdate4 = blogdate4;

            //5.post(center post)
            var posttitle5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 7).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 7).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate5 = bm.GetAll().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 7).Select(y => y.BlogDate).FirstOrDefault();

            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.blogdate5 = blogdate5;


            return PartialView();
        }

        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }

        //public PartialViewResult MailSubscribe()
        //{
        //    return PartialView();
        //}

        public ActionResult BlogDetails()
        {
            return View();
        } 

        public PartialViewResult BlogCover(int id)
        {
            var BlogCover = bm.GetBlogById(id);
            return PartialView(BlogCover);
        }

        public PartialViewResult BlogReadAll(int id) //controller tarafında parametre gönderilecek ise 'id' olarak gönderilmesi zorunludur. Çünkü app start klasöründe route config'te parametre kullanılacaksa 'id' olmalı diyor.
        {
            var BlogDetailsList = bm.GetBlogById(id);
            return PartialView(BlogDetailsList);
        }

        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = bm.GetBlogByCategory(id);
            return View(BlogListByCategory);
        }

    }
}