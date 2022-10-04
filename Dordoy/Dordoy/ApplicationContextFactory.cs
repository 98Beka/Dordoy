using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dordoy {
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext> {
        public ApplicationContext CreateDbContext(string[] args) {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"]);

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
