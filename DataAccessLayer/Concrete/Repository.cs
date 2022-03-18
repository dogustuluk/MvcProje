using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); //generic list'i bozmamış oluruz böylelikle
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            
            c.SaveChanges();
        }
    }
}
