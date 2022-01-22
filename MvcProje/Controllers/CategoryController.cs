using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(); //bu yapıyla beraber tüm katmanları kullanmış olduk. >> GetAll() metoduna sağ tık yapıp go to definition 
                                                    //dersek dataaccesslayer'daki CategoryManager tüm yapıyı çağırmaktadır.


        public ActionResult Index()
        {
            var categoryvalues = cm.GetAll();
            return View(categoryvalues);
        }

        public PartialViewResult BlogDetailsCategoryList()
        {
            return PartialView();
        }
    }
}