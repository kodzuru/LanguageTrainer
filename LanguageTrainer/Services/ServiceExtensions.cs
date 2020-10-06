using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LanguageTrainer.Entities;

namespace LanguageTrainer.Services
{
    public static class ServiceExtensions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:MSSQLConnection_development"];
            var assemblyName = typeof(RepositoryContext).Namespace;
            services.AddDbContext<RepositoryContext>(x => x.UseSqlServer(connectionString, y => y.MigrationsAssembly(assemblyName)));
        }
    }
}
