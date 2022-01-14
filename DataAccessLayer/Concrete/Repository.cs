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
            _object.Remove(p);
            return c.SaveChanges();
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T p)
        {
            _object.Add(p);
            return c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public int Update(T p)
        {
            return c.SaveChanges();
        }
    }
}
