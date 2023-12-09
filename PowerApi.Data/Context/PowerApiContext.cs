using Microsoft.EntityFrameworkCore;
using PowerApi.Application.Entitys;
using PowerApi.Application.Interfaces;

namespace PowerApi.Data.Context
{
    public class PowerApiContext : DbContext, IUnitOfWork
    {
        public PowerApiContext()
        {
            
        }
        public PowerApiContext(DbContextOptions<PowerApiContext> optionsBuilder) : base(optionsBuilder) 
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
