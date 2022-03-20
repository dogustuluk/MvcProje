﻿using BusinessLayer.Abstract;
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

        public void BlogAddBL(Blog p) 
        {
            //if (p.BlogTitle == "" | p.BlogImage == "" | p.BlogTitle.Length <=5 || p.BlogContent.Length <= 200)
            //{
            //    return -1;
            //}
            repoblog.Insert(p);
        }

        public void DeleteBlogBL(int p)
        {
            Blog blog = repoblog.Find(x => x.BlogId == p);
            repoblog.Delete(blog);
        }

        public Blog FindBlog(int id)
        {
            return repoblog.Find(x => x.BlogId == id);
        }

        public void UpdateBlog(Blog p)
        {
            Blog blog = repoblog.Find(x => x.BlogId == p.BlogId);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogContent = p.BlogContent;
            blog.BlogDate = p.BlogDate;
            blog.BlogImage = p.BlogImage;
            blog.CategoryId = p.CategoryId;
            blog.AuthorId = p.AuthorId;
            repoblog.Update(blog);
        }

        public List<Blog> GetList()
        {
            return _blogDal.List();
        }

        public void BlogAdd(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Blog GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void BlogDelete(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void BlogUpdate(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
