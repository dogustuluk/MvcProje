﻿using BusinessLayer.Abstract;
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
    public class CommentManager: ICommentService
    {
        ICommentDal _commentDal;
        Repository<Comment> repocomment = new Repository<Comment>();

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> CommentList()
        {
            return repocomment.List();
        }

        public List<Comment> CommentByBlog(int id)
        {
            return _commentDal.List(x => x.BlogId == id);
        }

        public List<Comment> CommentByStatusTrue()
        {
            return repocomment.List(x => x.CommentStatus == true);
        }

        public List<Comment> CommentByStatusFalse()
        {
            return repocomment.List(x => x.CommentStatus == false);
        }
        public void CommentAdd(Comment c)
        {
            //if (c.UserName.Length <= 2 || c.UserName == "" || c.CommentText.Length <= 4 || c.CommentText.Length >=301 || c.Mail == "")
            //{
            //    return -1;
            //}
            repocomment.Insert(c);
        }

        public void CommentStatusChangeToFalse(int id)
        {
            Comment comment = repocomment.Find(x => x.CommentId == id);
            comment.CommentStatus = false;
            repocomment.Update(comment);
        }

        public void CommentStatusChangeToTrue(int id)
        {
            Comment comment = repocomment.Find(x => x.CommentId == id);
            comment.CommentStatus = true;
            repocomment.Update(comment);
        }

        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }

        public Comment GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void CommentDelete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void CommentUpdate(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
