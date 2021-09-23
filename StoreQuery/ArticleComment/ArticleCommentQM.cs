using UtilityFreamwork.Application;

namespace StoreQuery.ArticleComment
{
   public class ArticleCommentQM
   {
      public long Id { get; set; }

      public string Name { get; set; }

      public string Email { get; set; }

      public string Message { get; set; }

      public long ArticleId { get; set; }

      public StatusComment Status { get; set; }

      public string ParentName { get; set; }

      public long ParentId { get; set; }

      public string CreationDate { get; set; }
   }
}
