using Microsoft.EntityFrameworkCore;

namespace NETCore_Lesson12_Lab.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}
