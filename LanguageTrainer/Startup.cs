using AutoMapper;
using LanguageTrainer.Services;
using LanguageTrainer.Services.TelegramBot;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;

namespace LanguageTrainer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(x => {
                x.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddDatabase(Configuration);

            services.AddSingleton<IBotService, BotService>();

            services.AddScoped<IUpdateService, UpdateService>();


            services.AddCommands();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBotService bot)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            bot.SetWebHookAsync();
        }
    }
}
