using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarWorkshop.Infrastructure.Persistence
{
    public class CarWorkshopDbContextFactory : IDesignTimeDbContextFactory<CarWorkshopDbContext>
    {
        public CarWorkshopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarWorkshopDbContext>();

            // 🔑 Pobieramy connection string z ENV lub fallback
            var connectionString =
                Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                ?? "Host=localhost;Port=5432;Database=CarWorkshopDb;Username=postgres;Password=postgres;";

            optionsBuilder.UseNpgsql(connectionString);

            return new CarWorkshopDbContext(optionsBuilder.Options);
        }
    }
}
