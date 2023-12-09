using Microsoft.EntityFrameworkCore;

namespace PowerApi.Data.Context
{
    public static class DbContextConfiguration
    {
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextConfiguration).Assembly);
        }
    }
}
