namespace BlogManagement.Application.Constract.Article
{
    public class ArticleVM 
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string PublishDate { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public bool IsRemoved { get; set; }
    }
}
