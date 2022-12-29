namespace LibrarySystem.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; } 
    }
}
