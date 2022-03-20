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
    public class AboutManager: IAboutService
    {
        IAboutDal _aboutDal;
        Repository<About> repoabout = new Repository<About>();

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAdd(About about)
        {
            throw new NotImplementedException();
        }

        public void AboutDelete(About about)
        {
            throw new NotImplementedException();
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }
        public About GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }
    }
}
