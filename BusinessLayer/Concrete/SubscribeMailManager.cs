using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubscribeMailManager
    {
        Repository<SubscribeMail> reposubscribemail = new Repository<SubscribeMail>();
        public int BLAdd(SubscribeMail p)
        { 
            //@gmail.com >>10 karakter
            if (p.Mail.Length <= 10 || p.Mail.Length >= 50)
            {
                return -1; //işlemi gerçekleştirme
            }
            return reposubscribemail.Insert(p); //repository design pattern kullanarak tekrardan ekleme ile ilgili kodları kullanmamış olduk.
        }
    }
}
