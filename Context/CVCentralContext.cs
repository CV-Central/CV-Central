using Microsoft.EntityFrameworkCore;
namespace CV_Central.Context
{
    public class CVCentralContext : DbContext
    {
        public CVCentralContext(DbContextOptions<CVCentralContext> options) : base(options) { }
        public DbSet<User> Users {get; set;}
    }
}