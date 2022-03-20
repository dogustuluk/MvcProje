using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager: IBlogService
    {
        Repository<Blog> repoblog = new Repository<Blog>();
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
      public List<Blog> GetBlogById(int id)
        {
            return repoblog.List(x => x.BlogId == id); //ilgili sınıfa ait parametre göndermemiz gerekiyor. sadece 'list' metodu çağrıldı
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoblog.List(x => x.AuthorId == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return repoblog.List(x => x.CategoryId == id);
        }
        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public void BlogAdd(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public Blog GetByID(int id)
        {
            return _blogDal.GetByID(id);
        }

        public void BlogDelete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
