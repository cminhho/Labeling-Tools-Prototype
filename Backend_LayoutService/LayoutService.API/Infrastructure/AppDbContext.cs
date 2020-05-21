using LayoutService.API.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace LayoutService.API.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Template>(template => { 
                
            });
        }

        public DbSet<Template> Templates { get; set; }

        public DbSet<TemplateType> TemplateTypes { get; set; }
    }
}
