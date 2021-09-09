using ShopManagement.Domain.ProductAgg;
using System;

namespace ShopManagement.Domain.CommentAgg
{
    public class Comment
    {
        public long Id { get;private set; }

        public string Name { get; private set; }

        public string Email { get;private set; }

        public string Message { get; private set; }

        public DateTime CreationDate { get; private set; }

        public long ProductId { get; private set; }

        public Product Prodcut { get;private set; }

        public bool IsPublished { get; private set; }



        public Comment(string name, string email, string message, long productId)
        {
            Name = name;
            Email = email;
            Message = message;
            ProductId = productId;
            CreationDate = DateTime.Now;
            IsPublished = false;
        }


        public void Cancel()
        {
            IsPublished = false;
        }
        

        public void Publish()
        {
            IsPublished = true;
        }
    }
}
