using Microsoft.EntityFrameworkCore;

namespace NETCore_Lesson12_Lab.Models
{
    public class Lesson12DbContext: DbContext
    {
        public Lesson12DbContext(DbContextOptions<Lesson12DbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
