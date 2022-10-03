using Microsoft.EntityFrameworkCore;

namespace Schedu.Models
{
    public class BusinessDbContext: DbContext
    {
        public BusinessDbContext(DbContextOptions<BusinessDbContext> options): base(options)
        {

        }

        public DbSet<Business> Businesses { get; set; }
    }
}
