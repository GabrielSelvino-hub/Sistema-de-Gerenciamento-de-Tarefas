using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sistema_de_Gerenciamento_de_Tarefas.Context;
using Microsoft.AspNetCore.Authorization;
using Sistema_de_Gerenciamento_de_Tarefas.Models.Contexts;

namespace Sistema_de_Gerenciamento_de_Tarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Obtenha a string de conex�o do arquivo de configura��o
            string sqlServerConnection = Configuration.GetConnectionString("DefaultConnection");

            // Configure o Entity Framework Core para usar o SQL Server
            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(sqlServerConnection));
            services.AddSession();
            // Adicione outros servi�os, se necess�rio
            services.AddControllersWithViews();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AutorizacaoSessionPolicy", policy =>
                    policy.Requirements.Add(new AutorizacaoSessionPolicy("OK")));
            });

            services.AddSingleton<IAuthorizationHandler, AutorizacaoSessionHandler>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Usuario}/{action=Index}/{id?}");
            });
        }
    }
}
