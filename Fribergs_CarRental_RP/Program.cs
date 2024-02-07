using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Fribergs_CarRental_RP.Data;
using Fribergs_CarRental_RP.Interfaces;
using Fribergs_CarRental_RP.Repos;
namespace Fribergs_CarRental_RP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Fribergs_CarRental_RPContext") ?? throw new InvalidOperationException("Connection string 'Fribergs_CarRental_RPContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddTransient<ICustomer, CustomerRepository>();
            builder.Services.AddTransient<IAdmin, AdminRepository>();
            builder.Services.AddTransient<ICar, CarRepository>();
            builder.Services.AddTransient<IOrder, OrderRepository>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromHours(2);});
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
            app.UseSession();
            app.UseRouting();
            
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
