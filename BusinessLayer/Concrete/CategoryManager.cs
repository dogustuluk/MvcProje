using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repocategory = new Repository<Category>();
        public List<Category> GetAll()
        {
            return repocategory.List();
        }
        public int CategoryAddBL(Category p)
        {
            if (p.CategoryName == "" | p.CategoryName.Length <= 3 | p.CategoryDescription == "" | p.CategoryDescription.Length <= 5)
            {
                return -1;
            }
            return repocategory.Insert(p);
        }
    }
}
