using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        int Insert(T p);

        int Update(T p);

        int Delete(T p);

        T GetByID(int id);

        /*
         * Repository sınıfında;
         * return _object.Where(x =>x.BlogId) yazamıyoruz, çünkü generic bir yapı oluşturmamız gerekiyor
         * alttaki yapıda kullanırsak sorun ortadan kalkacak.
         */
        List<T> List(Expression<Func<T, bool>> filter); // linq expression ile istediğimiz herhangi bir kritere göre arama işlemi veya getirme işlemi yapabiliriz
                                                        // where yerine filter da yazabiliri

        T Find(Expression<Func<T, bool>> where);
    }
}
