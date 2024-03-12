using Microsoft.EntityFrameworkCore;
using NETCore_Lesson06_Lab01.Models;

namespace NETCore_Lesson06_Lab01.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
