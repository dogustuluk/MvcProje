﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IUserProfileManagerService: IGenericService<Author>
    {
        List<Author> GetAuthorByMail(string p);
        List<Blog> GetBlogByAuthor(int id);
    }
}
