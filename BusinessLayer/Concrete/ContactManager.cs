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
    public class ContactManager: IContactService
    {
        IContactDal _contactDal; 
        Repository<Contact> repocontact = new Repository<Contact>();

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void BLContactAdd(Contact c)
        {
            repocontact.Insert(c);
        }

        public List<Contact> GetAll()
        {
            return repocontact.List();
        }

        public Contact GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactDetails(int id)
        {
            return repocontact.Find(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }

        public void TAdd(Contact t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Contact t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
