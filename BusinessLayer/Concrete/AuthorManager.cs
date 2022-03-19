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
    public class AuthorManager: IAuthorService
    {
        Repository<Author> repoauthor = new Repository<Author>();
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
         
        //yazar id'sini edit sayfasına taşıma

        public Author FindAuthor(int id)
        {
            return repoauthor.Find(x => x.AuthorId == id);
        }

        public void EditAuthor(Author p)
        {
            Author author = repoauthor.Find(x => x.AuthorId == p.AuthorId);
            author.AboutShort = p.AboutShort;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorImage = p.AuthorImage;
            author.AuthorName = p.AuthorName;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            repoauthor.Update(author);

        }

        public List<Author> GetList()
        {
            return _authorDal.List();
        }

        public void AuthorAdd(Author author)
        {
            _authorDal.Insert(author);
        }

        public Author GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void AuthorDelete(Author author)
        {
            throw new NotImplementedException();
        }

        public void AuthorUpdate(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
