using Microsoft.EntityFrameworkCore;

namespace DannyDefaults.Models
{
    public class Default_Context : DbContext
    {
        public Default_Context(DbContextOptions<Default_Context> options) 
            : base(options) { }
        public DbSet<Default_Model> Defaults_table { get; set; }
    }
}
