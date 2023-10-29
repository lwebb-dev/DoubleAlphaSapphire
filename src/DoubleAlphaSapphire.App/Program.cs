using DoubleAlphaSapphire.App.Utilities;
using DoubleAlphaSapphire.Data;
using DoubleAlphaSapphire.Domain.Services;
using DoubleAlphaSapphire.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace DoubleAlphaSapphire.App
{
    public class Program
    {
        public static IConfiguration Configuration { get; private set; }
        public static bool IsDevelopment { get; private set; }
        public static async Task Main(string[] args)
        {
            string devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            IsDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) || devEnvironmentVariable.ToLower() == "development";

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Configuration

            var configBuilder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args);

            if (IsDevelopment)
            {
                configBuilder.AddUserSecrets<UserSecretsUtility>();
            }

            Configuration = configBuilder.Build();

            // Services

            builder.Services.Configure<UserSecretsUtility>(Configuration.GetSection(nameof(UserSecretsUtility)));
            builder.Services.AddLogging();
            builder.Services.AddOptions();

            string postgressConnectionString = Configuration["UserSecretsUtility:POSTGRES_CONNECTION_STRING"];
            builder.Services.AddDbContext<DasDbContext>(options =>
            {
                options.UseNpgsql(postgressConnectionString);
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ITrainerService, TrainerService>();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            using (IServiceScope serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<DasDbContext>();
                dbContext.Database.Migrate();
            }

            await app.RunAsync();
        }
    }
}