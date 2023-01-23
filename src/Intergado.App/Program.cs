using Intergado.Business.Repository;
using Intergado.Data.Context;
using Intergado.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Intergado.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Connection String

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<IntergadoContext>(options => options.UseNpgsql(connectionString));

            #endregion Connection String

            #region Resolução DI

            builder.Services.AddScoped<IntergadoContext>();
            builder.Services.AddScoped<IFazendaRepository, FazendaRepository>();
            builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

            #endregion Resolução DI

            ///<summary>
            /// Auto mapper
            ///</summary>
            builder.Services.AddAutoMapper(typeof(Program));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}