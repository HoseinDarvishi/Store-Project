using BlogManagement.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace BlogManagement.Domain.ArticleCommentAgg
{
    public class ArticleComment
    {
        public long Id { get;private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Website { get; private set; }

        public string Message { get; private set; }

        public Article Article { get; private set; }

        public long ArticleId { get; private set; }

        public StatusComment Status { get;private set; }

        public ArticleComment Parent { get;private set; }

        public long ParentId { get; private set; }

        public List<ArticleComment> Children { get;private set; }

        public DateTime CreationDate{ get; private set; }


        public ArticleComment(string name, string email, string website, string message, long articleId, long parentId)
        {
            Name = name;
            Email = email;
            Website = website;
            Message = message;
            ArticleId = articleId;
            ParentId = parentId;
            CreationDate = DateTime.Now;
            Status = StatusComment.Wait;
        }


        public void Confirm()
        {
            Status = StatusComment.Confirmed;
        }

        public void Cancel()
        {
            Status = StatusComment.Canceled;
        }

        public void Wait()
        {
            Status = StatusComment.Wait;
        }
    }
}
