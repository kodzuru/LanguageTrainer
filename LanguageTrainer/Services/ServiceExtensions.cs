using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LanguageTrainer.Entities;
using LanguageTrainer.Services.TelegramBot;
using LanguageTrainer.Services.Commands;

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
        public static void AddBot(this IServiceCollection services)
        {
            services.AddTransient<ITelegramBotService, TelegramBotService>();
        }
        public static void AddCommands(this IServiceCollection services)
        {
            services.AddTransient<ICommandWrapper, CommandWrapper>();
        }
    }
}
