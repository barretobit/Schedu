using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Schedu.Models
{
    public class ScheduDbContext: DbContext
    {
        public ScheduDbContext(DbContextOptions<ScheduDbContext> options): base(options)
        {

        }

        // something missing here to make the relation work

        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessOwner> BusinessesOwners { get; set; }
    }
}
