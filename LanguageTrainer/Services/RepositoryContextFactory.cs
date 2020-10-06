using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LanguageTrainer.Entities
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {

            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"{Directory.GetCurrentDirectory()}/../LanguageTrainer/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            var connectionString = config["ConnectionStrings:MSSQLConnection_development"];
            var assemblyName = typeof(RepositoryContext).Namespace;
            builder.UseSqlServer(connectionString, y => y.MigrationsAssembly(assemblyName));
            return new RepositoryContext(builder.Options);
        }
    }
}
