using StoreQuery.Article;
using System.Collections.Generic;

namespace StoreQuery.ArticleCategory
{
    public class ArticleCategoryQM
    {
        public int Id { get; set; }

        public string Picture { get; set; }

        public string PictureAlt { get; set; }

        public string PictureTitle { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MetaDescription { get; set; }

        public int ShowOrder { get; set; }

        public string Slug { get; set; }

        public string KeyWords { get; set; }

        public string CanonicalAddress { get; set; }

        public long ArticleCount { get; set; }

        public List<ArticleQM> Articles { get; set; }

        public List<string> KeywordsList { get; set; }
    }
}
