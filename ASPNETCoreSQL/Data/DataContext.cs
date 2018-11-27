using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreSQL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        { }
        public DbSet<Thing> Things { get; set; }
    }
}
