using Microsoft.EntityFrameworkCore;
using CV_Central.Models;
namespace CV_Central.Context
{
    public class CVCentralContext : DbContext
    {
        public CVCentralContext(DbContextOptions<CVCentralContext> options) : base(options) { }
        public DbSet<User> Users {get; set;}
        public DbSet<ExternalAuthentication> ExternalAuthentications { get; set; }
    }
}