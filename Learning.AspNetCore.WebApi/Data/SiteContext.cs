using Learning.AspNetCore.WebApi.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Learning.AspNetCore.WebApi.Data
{
    public class SiteContext : DbContext
    {
        private DatabaseOptions _options;

        public DbSet<SettingEntity> Settings { get; set; }

        public DbSet<MenuEntity> Menu { get; set; }

        public DbSet<PageEntity> Pages { get; set; }

        public SiteContext(IOptions<DatabaseOptions> options)
        {
            _options = options?.Value ?? throw new InvalidOperationException("No database configured.");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (_options.Provider == DatabaseOptionsProvider.Sqlite)
            {
                options.UseSqlite(_options.ConnectionString);
            }
            else
            {
                throw new NotSupportedException($"The database provider '{_options.Provider}' is not supported.");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SettingEntity>();
            builder.Entity<MenuEntity>();
            builder.Entity<PageEntity>();
        }


    }
}
