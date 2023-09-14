using Microsoft.EntityFrameworkCore;
using net_core_webapi_boilerplate.Models;

namespace net_core_webapi_boilerplate.Data
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }

        public DbSet<Example> Examples { get; set; }
    }
}
