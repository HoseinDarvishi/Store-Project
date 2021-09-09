namespace ShopManagement.Application.Constract.Comment
{
    public class CommentVM
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public long ProductId { get; set; }

        public string CreationDate { get; set; }

        public string Product { get; set; }
    }
}
