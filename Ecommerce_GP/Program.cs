using GP.Business.Interfaces;
using GP.Business.Services;
using GP.Data.Data;
using GP.Data.Entities;
using GP.Data.Interface;
using GP.Data.Repositories;
using GP.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_GP
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Register Services
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<ReviewService>();


            //Register Repositories
            builder.Services.AddScoped(serviceType: typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IUserRepository, UserRpository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();



            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Database Configuration
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure()
                )
            );

            // Add Identity Services
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddDefaultTokenProviders(); // Enables token generation for password reset, email confirmation, etc.


            // Configure Identity Cookie Settings
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login"; // Redirect if not logged in
                options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect if unauthorized
            });

            // Authorization Policies (if needed)
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
            });

            var app = builder.Build();

           

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Ensure static files are served

            app.UseRouting();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await RoleBasedService.seedRolesAdminsAndUser(services);
            }

            app.UseAuthentication(); // Add Authentication Middleware
            app.UseAuthorization();  // Add Authorization Middleware

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
