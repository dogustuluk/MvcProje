using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repouser = new Repository<Author>();
        Repository<Blog> repouserblog = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repouser.List(x => x.Mail == p);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repouserblog.List(x => x.AuthorId == id);
        }
        public int EditAuthor(Author auth)
        {
            Author author = repouser.Find(x => x.AuthorId == auth.AuthorId);
            author.AboutShort = auth.AboutShort;
            author.AuthorAbout = auth.AuthorAbout;
            author.AuthorImage = auth.AuthorImage;
            author.AuthorName = auth.AuthorName;
            author.AuthorTitle = auth.AuthorTitle;
            author.Mail = auth.Mail;
            author.Password = auth.Password;
            author.PhoneNumber = auth.PhoneNumber;
            return repouser.Update(author);
        }
    }
}
