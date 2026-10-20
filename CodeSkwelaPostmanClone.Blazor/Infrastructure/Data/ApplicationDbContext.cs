using CodeSkwelaPostmanClone.Blazor.Shared;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Xml;

namespace CodeSkwelaPostmanClone.Blazor.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Core.Entities.RequestSettings> RequestSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Infrastructure\\Data\\application.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.General);

            modelBuilder.Entity<Core.Entities.RequestSettings>()
                .Property(e => e.HeaderParameters)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, options),
                    s => JsonSerializer.Deserialize<List<HeaderParameter>>(s, options) ?? new()
                );

            modelBuilder.Entity<Core.Entities.RequestSettings>().Property(e => e.Name).IsRequired(true);
            modelBuilder.Entity<Core.Entities.RequestSettings>().Property(e => e.Url).IsRequired(true);
            modelBuilder.Entity<Core.Entities.RequestSettings>().Property(e => e.Verb).IsRequired(true);
            modelBuilder.Entity<Core.Entities.RequestSettings>().Property(e => e.HeaderParameters).IsRequired(false);
            modelBuilder.Entity<Core.Entities.RequestSettings>().Property(e => e.Body).IsRequired(false);
        }
    }
}
