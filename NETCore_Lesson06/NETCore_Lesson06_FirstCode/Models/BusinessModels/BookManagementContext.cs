using Microsoft.EntityFrameworkCore;
using NETCore_Lesson06_FirstCode.Models.DataModels;

namespace NETCore_Lesson06_FirstCode.Models.BusinessModels
{
    public class BookManagementContext : DbContext
    {
        public BookManagementContext(DbContextOptions<BookManagementContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
