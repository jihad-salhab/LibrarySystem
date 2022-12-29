using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Presistence
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<SubCategory>? SubCategories { get; set; }




    }
}
