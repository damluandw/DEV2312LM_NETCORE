using Microsoft.EntityFrameworkCore;

namespace NETCore_Lesson12_Lab.Models
{
    public class Lesson12DbContext: DbContext
    {
        public Lesson12DbContext(DbContextOptions<Lesson12DbContext> options)
        : base(options)
        {
        }

        DbSet<Account> Accounts { get; set; }
        DbSet<Customer> Customers { get; set; }
    }
}
