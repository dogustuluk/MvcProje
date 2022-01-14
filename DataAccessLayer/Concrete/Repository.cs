using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context c = new Context(); //sınıfların içerisindeki sınıflara erişim için 'c' nesnesini Context sınıfından türetmemiz lazım.
        DbSet<T> _object; //'object' dışarıdan göndereceğimiz değerlerimiz oluyor.

        public Repository() //ctor tab tab yaparak oluşturulur.
        {
            _object = c.Set<T>(); //context üzerinden gönderdiğimiz sınıfı '_object'e ata.
        }

        public int Delete(T p)
        {
            throw new NotImplementedException();
        }

        public T GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T p)
        {
            throw new NotImplementedException();
        }

        public List<T> List()
        {
            throw new NotImplementedException();
        }

        public int Update(T p)
        {
            throw new NotImplementedException();
        }
    }
}
