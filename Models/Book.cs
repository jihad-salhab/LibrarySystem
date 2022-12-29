namespace LibrarySystem.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public Author? Author { get; set; }
        public Category? Category { get; set; }
        public SubCategory? SubCategory { get; set; }
    }
    public class BookResult
    {
        public List<Book> data { get; set; }
        public bool didFail { get; set; }
        public string reason { get; set; }
    }
}
