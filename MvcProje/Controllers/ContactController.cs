﻿using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(Contact p)
        {
            cm.BLContactAdd(p);
            return View();
        }

        public ActionResult SendBox()
        {
            return View();
        }
    }
}