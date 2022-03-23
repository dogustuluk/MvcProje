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
    public class UserProfileManager: IUserProfileManagerService
    {
        IUserProfileManagerDal _userProfileDal;
        IBlogDal _blogDal;
        IAuthorDal _authorDal;

        public UserProfileManager(IUserProfileManagerDal userProfileDal, IBlogDal blogDal, IAuthorDal authorDal)
        {
            _userProfileDal = userProfileDal;
            _blogDal = blogDal;
            _authorDal = authorDal;
        }

        public List<Author> GetAuthorByMail(string p)
        {
            return _authorDal.List(x => x.Mail == p);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blogDal.List(x => x.AuthorId == id);
        }
        

        public List<Author> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Author t)
        {
            throw new NotImplementedException();
        }

        public Author GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Author t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Author t)
        {
            _authorDal.Update(t);
        }
    }
}
